using ProyectoFinal.ReaderPresenter;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal.Clases
{
    public class Factura
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID {  get; set; }
        [Required]
        [MaxLength (1)]
        public char Tipo { get;  set; }
        [Required]
        [MaxLength (15)]
        public string Numero { get; private set; }
        [Required]
        public DateOnly Fecha { get; private set; }
        [Required]
        public float ImporteTotal { get;  set; }

        public Cliente Cliente { get;  set; }

        public List<Item> Items { get;  set; }

        Reader readerFac = new Reader ();
        public string AsignarNumero()
        {
            Random random = new Random();

            // Primer bloque: 4 cifras
            int parte1 = random.Next(1000, 10000); // genera entre 1000 y 9999

            // Segundo bloque: 10 cifras
            long parte2 = random.NextInt64(1000000000L, 10000000000L); // entre 1.000.000.000 y 9.999.999.999

            // Combinar con guion
            string numeroFactura = $"{parte1}-{parte2}";

            return numeroFactura;
        }
        
        public DateOnly AsignarFecha()
        {
            return DateOnly.FromDateTime(DateTime.Now);
             
        }
        public Factura()
        {
            Numero = AsignarNumero();
            Fecha = AsignarFecha();
            Items = new List<Item>();
        }
        

        public Factura(char tipo)
        {
            Tipo = tipo;
            Numero = AsignarNumero();
            Fecha = AsignarFecha();
        }
    }
}
