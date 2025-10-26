using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal.Clases
{
    public class Item
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required]
        [MaxLength (100)]
        public string Descripcion { get;  set; }
        [Required]
        public int Cantidad { get;  set; }
        [Required]
        public float Importe { get;  set; }

        public Factura Factura { get; set; }
       
        
        
        public Item()
        {
            // Constructor requerido por Entity Framework
        }

        public Item(string descripcion, int cantidad, float precio)
        {
            Descripcion = descripcion;
            Cantidad = cantidad;    
            Importe = precio * cantidad;
        }
    }
}
