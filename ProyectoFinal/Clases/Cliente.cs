using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal.Clases
{
    public class Cliente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID  { get; set; }
        [Required]
        [MaxLength (50)]
        public string RazonSocial {get; set;}
        [Required]
        [MaxLength (50)]
        public string Domicilio {get; set;}
        [Required]
        [MaxLength (13)]
        public string CuilCuit { get; set;}

        public List<Factura> Facturas { get; set;}


     
        public Cliente()
        {
            Facturas = new List<Factura>();
        }

        public Cliente(string razonSocial, string domicilio, string cuilCuit)
        {
            RazonSocial = razonSocial;
            Domicilio = domicilio;
            CuilCuit = cuilCuit;
            Facturas = new List<Factura>();
        }
    }
}
