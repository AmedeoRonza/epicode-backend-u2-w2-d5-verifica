using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Albergo.Models
{
    public class Clienti
    {
        [Key]
        [Required(ErrorMessage = "Campo Obbligatorio")]
        [Display(Name = "Id Cliente")]
        public int IdCliente { get; set; }
        [Required(ErrorMessage = "Campo Obbligatorio")]
        [Display(Name = "Codice Fiscale")]
        public string CodFisc { get; set; }
        [Required(ErrorMessage = "Campo Obbligatorio")]
        public string Cognome { get; set; }
        [Required(ErrorMessage = "Campo Obbligatorio")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Campo Obbligatorio")]
        [Display(Name = "Città")]
        public string Citta { get; set; }
        [Required(ErrorMessage = "Campo Obbligatorio")]
        public string Provincia { get; set; }
        [Required(ErrorMessage = "Campo Obbligatorio")]
        [Display(Name = "E-Mail")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Campo Obbligatorio")]
        public string Telefono { get; set; }
        [Required(ErrorMessage = "Campo Obbligatorio")]
        public string Cellulare { get; set; }
    }
}