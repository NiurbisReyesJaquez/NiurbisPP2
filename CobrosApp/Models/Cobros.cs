using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CobrosApp.Models
{
    public class Cobros
    {
        [Key]
        public int CobrosId { get; set; }

        [ForeignKey("ClientesId")]
        public int ClienteId { get; set; }

        [Required(ErrorMessage = "El campo fecha es obligatorio")]
        public DateTime Fecha { get; set; } = DateTime.Now;

        public double Totales { get; set; }
        
        public string Observaciones { get; set; }
        [ForeignKey("CobrosId")]
        
        public virtual List<CobrosDetalle> CobrosApp { get; set; } = new List<CobrosDetalle>();

        public Cobros()
        {
        }




    }
}
