using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal.ReaderPresenter
{
    public class Presenter
    {

        public void MostrarMensaje(string mensaje) 
        {
            Console.WriteLine(mensaje);
        }

        public void PedirTipoFact()
        {
            Console.WriteLine("Ingrese el tipo de factura A, B o C");
        }

        public void PedirDescrItem()
        {
            Console.WriteLine("Ingrese la descripcion del producto.");
        }

        public void AsignarCantidad()
        {
            Console.WriteLine("Ingrese la cantidad del producto");
        }

        public void PedirImporte()
        {
            Console.WriteLine("Ingrese el precio del producto");
        }
        public void PedirRazonSocial()
        {
            Console.WriteLine("Ingrese la razon social del cliente");
        }
        public void PedirDomicilio()
        {
            Console.WriteLine("Ingrese el domicilio del cliente");
        }
        public void PedirCuilCuit()
        {
            Console.WriteLine("Ingrese el CUIL/CUIT del cliente");
        }
        public void PrimerMenu()
        {
            Console.WriteLine("1- Gestionar clientes.");
            Console.WriteLine("2- Gestionar facturas.");
            Console.WriteLine("3- Salir");
        }
        public void MenuClientes()
        {
            Console.WriteLine("1- Crear cliente");
            Console.WriteLine("2- Modificar cliente");
            Console.WriteLine("3- Eliminar cliente");
            Console.WriteLine("4- Consultar cliente");
            Console.WriteLine("5- Volver al inicio");
        }
        public void MenuFacturas()
        {
            Console.WriteLine("1- Emitir factura");
            Console.WriteLine("2- Consultar factura");
            Console.WriteLine("3- Volver al inicio");
        }
        
    }
}
