using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Albergo.Models
{
    public class Gest
    {
        public int IdGest { get; set; }
        [Required(ErrorMessage = "Campo Obbligatorio")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Campo Obbligatorio")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string Ruolo { get; set; }
    }
}