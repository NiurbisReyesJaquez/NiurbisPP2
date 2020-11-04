using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CobrosApp.Models
{
    public class Clientes
    {
        [Key]
        public int ClienteId { get; set; }
        
        [Required(ErrorMessage ="Es obligatorio introducir el nombre")]
        public string Nombres { get; set; }
        


    }
}
