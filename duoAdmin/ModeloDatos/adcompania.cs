//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ModeloDatos
{
    using System;
    using System.Collections.Generic;
    
    public partial class adcompania
    {
        public int ciCompania { get; set; }
        public string txRUC { get; set; }
        public string txRazonSocial { get; set; }
        public string txNombreComercial { get; set; }
        public string txDireccionMatriz { get; set; }
        public string ciEstado { get; set; }
        public string txRutaLogo { get; set; }
        public string txTelefono { get; set; }
        public string txEmail { get; set; }
        public string txContraseniaMail { get; set; }
        public Nullable<int> ciPuertoMail { get; set; }
        public Nullable<bool> SSLMail { get; set; }
        public string HostMail { get; set; }
        public string txRutaPdf { get; set; }
        public string txRutaLogoCorreo { get; set; }
        public string ciUsuarioIngreso { get; set; }
        public System.DateTime fcIngreso { get; set; }
        public string ciUsuarioModificacion { get; set; }
        public Nullable<System.DateTime> fcModificacion { get; set; }
    }
}