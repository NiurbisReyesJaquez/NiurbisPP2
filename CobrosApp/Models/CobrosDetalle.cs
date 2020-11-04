using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CobrosApp.Models
{
    public class CobrosDetalle
    {
        [Key]
        public int Id { get; set; }
        public int VentasId { get; set; }
        public int CobrosId { get; set; }
        public double Cobrado { get; set; }
        public double Balance { get; set; }
        public bool Pagar { get; set; }

        public CobrosDetalle()
        {

        }

    }
}
