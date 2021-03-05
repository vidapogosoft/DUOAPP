using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloDatos
{
    public class clsParametos
    {

        public const string EstadoActivo = "A";
        //public const string ESTADO_ACTIVO = "A";
        public const string EstadoInactivo = "I";
        public const string EstadoCerrado = "C";
        //public const int CodigoTicket = 6;
        //public const int CodigoTicketMitad = 7;


        public const int CAT_PARAMETROS_SRI = 20;
        public const int CAT_DET_Consumidor_Final_Monto_Max = 1;
        public static decimal Consumidor_Final_Monto_Max { get; set; }

        public const int SECOND = 1;
        public const int MINUTE = 60 * SECOND;
        public const int HOUR = 60 * MINUTE;
        public const int DAY = 24 * HOUR;
        public const int MONTH = 30 * DAY;
        public const int Edad_default = 25;

        public const int CatalogoTipoIdentificacion = 1;

        public const int RUC = 1;
        public const int CED = 2;
        public const int PAS = 3;
        public const int CONSUMIDOR_FINAL = 4;
        public const string CED_SRI = "05";
        public const string RUC_SRI = "04";
        public const string PAS_SRI = "06";
        public const string CONSUMIDOR_SRI = "07";

        public const int Provincias = 24;

        public const int ciTipoNegocioBoleteria = 1;
        public const int ciTipoNegocioEncomienda = 2;
        public const int ciTipoFacturacionManual = 3;
        public const int ciTipoFacturacionPreImpresa = 4;
        public const string ciTipoDocumentoFactura = "01";


        public const int ciSistemaVentaEasyBus = 1;
        public const int ciSistemaVentaViajaBus = 3;
        public const int ciSistemaVentaBas = 2;





        ///Cosas que hay que 
        ///poco a poco
        ///

        public const string SEMILLA = "batBoleteriants2017";
        public const string SEMILLA_VECTOR = "0ADSAL0AzgBcANcAvQDMAMUA";



        public const int keySize = 32;
        public const int ivSize = 16;


        public const int CATALOGO_TIPO_SERVICIO = 3;
        public const int CATALOGO_TIPO_CLIENTE = 2;
        public const int CATALOGO_DIA = 6;
        public const int CATALOGO_TIPO_NEGOCIO = 11;
        public const int CATALOGO_TIPO_FACTURACION = 12;
        public const int CARGO_OFICINISTA = 1;
        public const int CARGO_CONDUCTOR = 3;
        public const int CARGO_SOCIO = 5;
        public const int CARGO_ADMINISTRADOR = 2;
        public const int CARGO_TIPO_DESCUENTO = 7;
        public const int CARGO_FRECUENCIA = 8;
        public const int CARGO_TIPO_VALOR = 9;


        public const int TIPO_CLIENTE_CONVENCIONAL = 1;
        public const string CATALOGO_TIPO_IDENTIFICAICON_DEFECTO = "05";

        public enum TipoMensaje
        {
            Info,
            Warning,
            Error,
            Success,
            Notice
        }


        public const string Pendiente = "P";
        public const string Enviado = "C";
        public const string Aprobado = "A";
        public const string Error = "E";

    }
}
