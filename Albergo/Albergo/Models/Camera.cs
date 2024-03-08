using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Albergo.Models
{
    public class Camera
    {
        public int IdCamera { get; set; }
        [Required(ErrorMessage = "Campo Obbligatorio")]
        public string Numero { get; set; }
        [Required(ErrorMessage = "Campo Obbligatorio")]
        public string Tipo { get; set; }
        [Required(ErrorMessage = "Campo Obbligatorio")]
        public int IdCliente { get; set; }
    }
}