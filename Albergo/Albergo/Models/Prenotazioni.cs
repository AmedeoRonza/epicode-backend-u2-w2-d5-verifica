using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Albergo.Models
{
    public class Prenotazioni
    {
        [Key]
        public int IdPrenotazione { get; set; }
        [Required(ErrorMessage = "Campo Obbligatorio")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataPrenotazione { get; set; }
        [Required(ErrorMessage = "Campo Obbligatorio")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataCheckIn { get; set; }
        [Required(ErrorMessage = "Campo Obbligatorio")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataCheckOut { get; set; }
        [Required(ErrorMessage = "Campo Obbligatorio")]
        public decimal Anticipo { get; set; }
        [Required(ErrorMessage = "Campo Obbligatorio")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Campo Obbligatorio")]
        public string Cognome { get; set; }
        [Required(ErrorMessage = "Campo Obbligatorio")]
        [Display(Name = "Prezzo in €")]
        public decimal Prezzo { get; set; }
        [Required(ErrorMessage = "Campo Obbligatorio")]
        [Display(Name = "Id Cliente")]
        public int IdCliente { get; set; }
        [Required(ErrorMessage = "Campo Obbligatorio")]
        [Display(Name = "Id Camera")]
        public int IdCamera { get; set; }
        [Display(Name = "Id Servizio")]
        public int IdServizio { get; set; }
    }
}
