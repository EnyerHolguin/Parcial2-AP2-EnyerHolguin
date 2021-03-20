using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Parcial2_AP2_EnyerHolguin.Models
{
    public class Ventas
    {
        [Key]
        public int VentaId { get; set; }
        public DateTime Fecha { get; set; }
        [Required(ErrorMessage = "Debe Selecinar un cliente.")]
        public int ClienteId { get; set; }
        [Range(minimum: 10, maximum: 100000)]
        public double Monto { get; set; }
        public double Balance { get; set; }
        public bool DCobrado { get; set; }
        public double Cobrado { get; set; }

        [ForeignKey("ClienteId")]
        public virtual Clientes Cliente { get; set; }
    }   
}
