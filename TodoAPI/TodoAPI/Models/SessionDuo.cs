using System;
using System.Collections.Generic;

namespace TodoAPI.Models
{
    public partial class SessionDuo
    {
        public int IdSessionDuo { get; set; }
        public string UsuarioDuo { get; set; }
        public DateTime? FechaLog { get; set; }
    }
}
