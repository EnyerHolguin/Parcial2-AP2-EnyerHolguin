using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Parcial2_AP2_EnyerHolguin.Models
{
    public class CobrosDetalles
    {
        [Key]
        public int Id { get; set; }
        public int CobroId { get; set; }
        public DateTime Fecha { get; set; }
        public double Monto { get; set; }
        public double Balance { get; set; }
        public double Cobrado { get; set; }

    }
}
