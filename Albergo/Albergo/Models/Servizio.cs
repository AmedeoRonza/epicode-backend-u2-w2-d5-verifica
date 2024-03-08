using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Albergo.Models
{
    public class Servizio
    {
        [Key]
        public int IdServizio { get; set; }
        [Required(ErrorMessage = "Campo Obbligatorio")]
        public string Descrizione { get; set; }
        [Required(ErrorMessage = "Campo Obbligatorio")]
        [Display(Name = "Prezzo in €")]
        public decimal Prezzo { get; set; }
        [Required(ErrorMessage = "Campo Obbligatorio")]
        public int IdCliente { get; set; }
    }
}
