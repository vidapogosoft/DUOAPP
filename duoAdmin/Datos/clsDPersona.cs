using ModeloDatos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Datos
{
    public class clsDPersona
    {
        public List<persona> Get(persona FiltroCliente = null)
        {
            return GetQuery(FiltroCliente).ToList();
        }


        public IQueryable<persona> GetQuery(persona FiltroCliente = null)
        {
            EncuestaEntities ctx = new EncuestaEntities();
            ctx.Configuration.AutoDetectChangesEnabled = false;
            IQueryable<persona> query = ctx.persona;

            if (FiltroCliente != null)
            {
                if (FiltroCliente.TipoIdentificacion != null && FiltroCliente.TipoIdentificacion != 0)
                    query = query.Where(a => a.TipoIdentificacion == FiltroCliente.TipoIdentificacion);

                if (!string.IsNullOrEmpty(FiltroCliente.Identificacion))
                    query = query.Where(a => a.Identificacion == FiltroCliente.Identificacion);

                if (!string.IsNullOrEmpty(FiltroCliente.ciEstado))
                    query = query.Where(a => a.ciEstado == FiltroCliente.ciEstado);
            }
            return query.AsNoTracking();

        }

        public persona GetDatosPersona(string Identificacion)
        {
            using (EncuestaEntities ctx = new EncuestaEntities())
            {
                persona cliente;
                return cliente = ctx.persona.Where(a => a.Identificacion == Identificacion).FirstOrDefault();
            }
        }

        public persona GetDatosPersonaFuturoDeportista(string Identificacion)
        {
            using (EncuestaEntities ctx = new EncuestaEntities())
            {
                persona cliente;
                return cliente = ctx.persona.Where(a => a.Identificacion == Identificacion && a.cianios < 19).FirstOrDefault();
            }
        }

        public persona GetDatosPersonaFuturoEntrenador(string Identificacion)
        {
            using (EncuestaEntities ctx = new EncuestaEntities())
            {
                persona cliente;
                return cliente = ctx.persona.Where(a => a.Identificacion == Identificacion && a.cianios >= 19).FirstOrDefault();
            }
        }

        public persona GetDatosPersonaId(int IdPersona)
        {
            using (EncuestaEntities ctx = new EncuestaEntities())
            {
                persona cliente;
                return cliente = ctx.persona.Where(a => a.IdPersona == IdPersona).FirstOrDefault();
            }
        }
        public void Save(persona toCliente)
        {
            using (EncuestaEntities ctx = new EncuestaEntities())
            {
                var cliente = ctx.persona.Where(a => a.Identificacion == toCliente.Identificacion).FirstOrDefault();

                if (cliente != null)
                {
                    cliente.Nombres = toCliente.Nombres;
                    cliente.ApellidoPaterno = toCliente.ApellidoPaterno;
                    cliente.ApellidoMaterno = toCliente.ApellidoMaterno;
                    cliente.RazonSocial = toCliente.RazonSocial;
                    cliente.TipoIdentificacion = toCliente.TipoIdentificacion;
                    cliente.ciTipoPersona = toCliente.ciTipoPersona;
                    cliente.txCorreoElectronico = !string.IsNullOrEmpty(toCliente.txCorreoElectronico) ? toCliente.txCorreoElectronico : cliente.txCorreoElectronico;
                    cliente.fcNacimiento = toCliente.fcNacimiento ?? cliente.fcNacimiento;
                    cliente.txDireccion = !string.IsNullOrEmpty(toCliente.txDireccion) ? toCliente.txDireccion : cliente.txDireccion;
                    cliente.txTelefono = !string.IsNullOrEmpty(toCliente.txTelefono) ? toCliente.txTelefono : cliente.txTelefono;
                    cliente.txCodConadis = !string.IsNullOrEmpty(toCliente.txCodConadis) ? toCliente.txCodConadis : cliente.txCodConadis;
                    cliente.ciUsuarioModifica = toCliente.ciUsuarioIngreso;
                    cliente.fcModificacion = toCliente.fcIngreso;
                    cliente.cianios = toCliente.cianios;
                }
                else
                    ctx.persona.Add(toCliente);
                ctx.SaveChanges();
            }
        }
    }
}
