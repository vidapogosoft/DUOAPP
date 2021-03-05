using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Datos;
using ModeloDatos;
using System.Web;
using System.Web.UI.WebControls;


namespace Negocio
{
    public class clsNMaster
    {
        public string ConsultarImagenUsuario(string tsUsuario)
        {
            clsDadUsuario clsUsuarioDA = new clsDadUsuario();
            var usuario = clsUsuarioDA.Get(new adusuarios() { ciEstado = clsParametos.EstadoActivo, ciUsuario = tsUsuario }).FirstOrDefault();
            if (usuario != null)
                return usuario.txDirectorioImagen;
            else return "";
        }

        public string ConsultarImagenCompania(int ciCompania)
        {
            clsDadCompania clsUsuarioDA = new clsDadCompania();
            var compania = clsUsuarioDA.Get(new adcompania() { ciCompania = ciCompania }).FirstOrDefault();
            if (compania != null)
                return compania.txRutaLogo;
            else return "";
        }

        public string ConsultarMenu()
        {
            clsDadMenu MenuDA = new clsDadMenu();
            List<ModeloDatos.Entidades.clsMenu> pantallas = MenuDA.Get();
            string menu = string.Empty;

            foreach (var modulo in pantallas.Select(a => new { a.ciModulo, a.txNombreModulo, a.ciOrdenModulo, a.txIcono }).Distinct().OrderBy(a => a.ciOrdenModulo).ToList())
            {
                menu += string.Format("<li><a><i class='{0}'></i>{1} <span class='fa fa-chevron-down'></span></a><ul class='nav child_menu'>", modulo.txIcono, modulo.txNombreModulo);
                foreach (var pantalla in pantallas.Where(a => a.ciModulo == modulo.ciModulo).OrderBy(a => a.ciOrdenFormulario))
                    menu += string.Format("<li><a href='{0}'>{1}</a></li>", VirtualPathUtility.ToAbsolute(pantalla.txUrl), pantalla.txFormulario);
                menu += "</ul></li>";
            }
            return menu;
        }

        public string ConsultarMenuUsuario(string ciUsuario, int ciCompania)
        {
            clsDadMenu MenuDA = new clsDadMenu();
            List<ModeloDatos.Entidades.clsMenu> pantallas = MenuDA.GetMenuUsuario(ciUsuario, ciCompania);
            string menu = string.Empty;

            foreach (var modulo in pantallas.Select(a => new { a.ciModulo, a.txNombreModulo, a.ciOrdenModulo, a.txIcono }).Distinct().OrderBy(a => a.ciOrdenModulo).ToList())
            {
                menu += string.Format("<li><a><i class='{0}'></i>{1} <span class='fa fa-chevron-down'></span></a><ul class='nav child_menu'>", modulo.txIcono, modulo.txNombreModulo);
                foreach (var pantalla in pantallas.Where(a => a.ciModulo == modulo.ciModulo).OrderBy(a => a.ciOrdenFormulario))
                    menu += string.Format("<li><a href='{0}'>{1}</a></li>", VirtualPathUtility.ToAbsolute(pantalla.txUrl), pantalla.txFormulario);
                menu += "</ul></li>";
            }
            return menu;
        }

        public List<adcompania> ConsultarCompaniaPorUsuario(string ciUsuario, bool bdAdmin)
        {
            clsDMaster clsMasterDA = new clsDMaster();
            return clsMasterDA.GetAllxUsuario(ciUsuario, bdAdmin);
        }

        public List<adlocalidades> ConsultarLocalidadesPorUsuarios(string ciUsuario, int ciCompania, bool bdAdmin)
        {
            clsDMaster clsMasterDA = new clsDMaster();
            return clsMasterDA.GetAllxLocalidad(ciUsuario, ciCompania, bdAdmin);
        }

        public List<ModeloDatos.Entidades.clsNotificacionPupUp> ConsultarNotificaciones(int tiCompania, string tiUsuario)
        {
            clsDMaster clsPupUpDA = new clsDMaster();
            return clsPupUpDA.GetNotificacionPupUp(tiCompania, tiUsuario);
        }

        public int NotificacionesPopUpLeida(int tiCompania, string tiUsuario)
        {
            clsDMaster clsPupUpDA = new clsDMaster();
            return clsPupUpDA.NotificacionPupUpLeida(tiCompania, tiUsuario);
        }

        public int NotificacionesBarraLeida(int tiCompania, string tiUsuario)
        {
            clsDMaster clsPupUpDA = new clsDMaster();
            return clsPupUpDA.NotificacionBarraLeida(tiCompania, tiUsuario);
        }

        public void ConsultarNotificaciones(int tiCompania, string tsUsuario, ref Literal lit, ref Literal CantidadNotificaciones, bool tbActualiza)
        {
            clsDMaster clsNotficacionDA = new clsDMaster();
            List<ModeloDatos.Entidades.clsNotificacionBarra> poNotificaciones = clsNotficacionDA.GetNotificacionBarra(tiCompania, tsUsuario, tbActualiza);
            ///{0} = imagen
            ///{1} = Nombre Usuario
            ///{2} = tiempo
            ///{3} = mensaje

            int piTotalNotifNuevas = 0;
            lit.Text = "";
            CantidadNotificaciones.Text = "";
            foreach (ModeloDatos.Entidades.clsNotificacionBarra notificacion in poNotificaciones)
            {
                if (!notificacion.bdLeido)
                    piTotalNotifNuevas++;

                string li = "<li class=\"divider\"></li><li><a><span class=\"image\"><img src=\"{0}\" alt=\"Profile Image\"></span><span>";
                li += "<span>{1}</span><span class=\"time\">{2}</span></span> <span class=\"message\">{3}...</span></a></li>";
                li += "<span>{1}</span><span class=\"time\">{2}</span></span> <span class=\"message\">{3}...</span></a></li>";

                lit.Text += string.Format(li, VirtualPathUtility.ToAbsolute(notificacion.txDirectorioImagen), notificacion.txNombre, CalcularTiempoNotif(notificacion.fcIngreso), notificacion.txMensaje);
            }
            if (piTotalNotifNuevas > 0)
                CantidadNotificaciones.Text = string.Format("<span class=\"badge bg - green\">{0}</span>", piTotalNotifNuevas);

        }

        private static string CalcularTiempoNotif(DateTime tdFechaNotif)
        {
            var ts = new TimeSpan(DateTime.Now.Ticks - tdFechaNotif.Ticks);
            double delta = Math.Abs(ts.TotalSeconds);

            if (delta < 1 * clsParametos.MINUTE)
                return ts.Seconds == 1 ? "Hace un segundo" : string.Format("Hace {0} segundos", ts.Seconds);

            if (delta < 2 * clsParametos.MINUTE)
                return "Hace un minuto";

            if (delta < 45 * clsParametos.MINUTE)
                return string.Format("Hace {0} minutos", ts.Minutes);

            if (delta < 90 * clsParametos.MINUTE)
                return "Hace una hora";

            if (delta < 24 * clsParametos.HOUR)
                return string.Format("Hace {0} horas", ts.Hours);

            if (delta < 48 * clsParametos.HOUR)
                return "Ayer";

            if (delta < 30 * clsParametos.DAY)
                return string.Format("Hace {0} días", ts.Days);

            if (delta < 12 * clsParametos.MONTH)
            {
                int months = Convert.ToInt32(Math.Floor((double)ts.Days / 30));
                return months <= 1 ? "Hace un mes" : string.Format("Hace {0} meses", months);
            }
            else
            {
                int years = Convert.ToInt32(Math.Floor((double)ts.Days / 365));
                return years <= 1 ? "Hace un año" : string.Format("Hace {0} años", years);
            }
        }


    }
}
