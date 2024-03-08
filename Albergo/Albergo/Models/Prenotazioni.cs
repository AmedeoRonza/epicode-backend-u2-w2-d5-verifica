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

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DataPrenotazione { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataCheckIn { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataCheckOut { get; set; }
        public decimal Anticipo { get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public decimal Prezzo { get; set; }
        public int IdCliente { get; set; }
        public int IdCamera { get; set; }
        public int IdServizio { get; set; }
    }
}
