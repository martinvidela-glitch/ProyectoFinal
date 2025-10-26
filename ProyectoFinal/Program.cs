using Microsoft.EntityFrameworkCore;
using ProyectoFinal.Clases;
using ProyectoFinal.EntityFramework;
using ProyectoFinal.ReaderPresenter;
using System;
using System.Linq;

internal class Program
{
    public static Reader Reader = new Reader();
    public static Presenter Presenter = new Presenter();
    public static CodeFirstDbContext Context = new CodeFirstDbContext();
    public static Cliente Cliente = new Cliente();
    public static Program p = new Program();

    static void Main(string[] args)
    {
        Inicializar();
        
    }

    private static void Inicializar()
    {
        bool validar = false;
        do
        {
            Console.Clear();
            Presenter.PrimerMenu();
            int opcion = int.Parse(Console.ReadLine());
            switch (opcion)
            {
                case 1: GestionarCliente();
                    break;
                case 2: GestionarFacturas();
                    break;
                case 3:
                    validar = true;
                    break;
                default:
                    Console.WriteLine("La opcion ingresada no es correcta. Presione una tecla para continuar...");
                    Console.ReadKey();
                    break;
            }
        } while (!validar);

    }

    private static void GestionarFacturas()
    {
        bool validar = false;
        do
        {
            Console.Clear();
            Presenter.MenuFacturas();
            int opcion = int.Parse(Console.ReadLine());
            switch (opcion)
            {
                case 1:
                    Console.Clear();
                    p.crearFactura();
                    break;
                case 2:
                    Console.Clear();
                    //Listar Factura
                    break;
                case 3:
                    validar = true;
                    break;
                default:
                    Console.WriteLine("La opcion ingresada no es correcta. Presione una tecla para continar...");
                    Console.ReadKey();
                    break;
            }
        } while (!validar);
    }
    public static void GestionarCliente()
    {
        bool validar = false;
        do
        {
            Console.Clear();
            Presenter.MenuClientes();
            int opcion = int.Parse(Console.ReadLine());
            switch (opcion)
            {
                case 1:
                    Console.Clear();
                    p.CrearClientes();
                    break;
                case 2:
                    Console.Clear();
                    p.ModificarCliente();
                    break;
                case 3:
                    p.eliminarCliente();

                    break;
                case 4:
                    Console.Clear();
                    p.encontrarCliente();
                    break;
                case 5:
                    validar = true;
                    break;
                default:
                    Console.WriteLine("La opcion ingresada no es correcta. Presione una tecla para continar...");
                    Console.ReadKey();
                    break;
            }
        } while (!validar);

    }

    public void CrearClientes()
    {
        Cliente cliente = new Cliente();
        Presenter.MostrarMensaje("Ingrese la razon social");
        cliente.RazonSocial = Reader.AsignarString("Razon social mal");
        Presenter.MostrarMensaje("Ingrese su domicilio");
        cliente.Domicilio = Reader.AsignarString("Domicilio incorrecto");
        Presenter.MostrarMensaje("Ingrese su cuil/cuit");
        cliente.CuilCuit = Reader.AsignarString("Cuil/Cuit erroneo");
        Context.Clientes.Add(cliente);
        Context.SaveChanges();
    }
    public Cliente ModificarCliente()
    {

        Cliente cliente = p.encontrarCliente();
        Presenter.MostrarMensaje("Que desea modificar?");
        Presenter.MenuModificar();
        int opcion;
        bool validar = false;
        string nuevoDato;

        do
        {
            opcion = int.Parse(Console.ReadLine());
            switch (opcion)
            {
                case 1:
                    Console.WriteLine("Ingrese la nueva razon social.");
                    nuevoDato = Reader.AsignarString("Razon social mal");
                    cliente.RazonSocial = nuevoDato;


                    break;
                case 2:
                    Console.WriteLine("Ingrese el nuevo domicilio.");
                    nuevoDato = Reader.AsignarString("Domicilio invalido.");
                    cliente.Domicilio = nuevoDato;

                    break;
                case 3:
                    Console.WriteLine("Ingrese el nuevo cuil/cuit.");
                    nuevoDato = Reader.AsignarString("Cuil/Cuit incorrecto");
                    cliente.RazonSocial = nuevoDato;


                    break;
                case 4:
                    Presenter.PrimerMenu();
                    //p.LeerPrimerMenu();
                    break;
                case 5:
                    Presenter.MenuClientes();
                    //p.LeerMenuClientes();
                    break;
                default:
                    Console.WriteLine("El numero ingresado no es correcto");
                    validar = true;
                    break;
            }

            Context.Clientes.Update(cliente);
            Context.SaveChanges();

        } while (validar);
        return cliente;

    }
    public Cliente encontrarCliente()
    {
       
        bool validar = true;
        Cliente clienteEncontrado = new Cliente();
       do
        {
            Presenter.MostrarMensaje("Ingrese el Cuit/Cuil");
            string cuil = Reader.AsignarString("Cuit/Cuil invalido");
            clienteEncontrado = Context.Clientes.FirstOrDefault(c => c.CuilCuit == cuil);
            if (clienteEncontrado != null)
            {
                Presenter.MostrarMensaje($"Cliente encontrado:");
                Presenter.MostrarMensaje($"Razón Social: {clienteEncontrado.RazonSocial}");
                Presenter.MostrarMensaje($"Domicilio: {clienteEncontrado.Domicilio}");
                Presenter.MostrarMensaje($"CUIT/CUIL: {clienteEncontrado.CuilCuit}");
                validar =false;
            }
            else
            {
                Presenter.MostrarMensaje("No se encontró un cliente con ese CUIT/CUIL.");
                Presenter.MostrarMensaje("Intentelo de nuevo.");
            }
        } while (validar);

        return clienteEncontrado;

    }
    public void eliminarCliente()
    {
        Cliente cliente = p.encontrarCliente();
        int valor;
        Presenter.MostrarMensaje("Desea eliminar este cliente?");
        Presenter.MostrarMensaje("1: Si \n 2: No");
        valor = Reader.LeerInt();

        if (valor == 1)
        {
            Context.Clientes.Remove(cliente);
            Context.SaveChanges();
        }
        if (valor == 2)
        {
            Presenter.MenuClientes();
        } else
        {
            Presenter.MostrarMensaje("Numero incorrecto");
            Presenter.MenuClientes();
        }
    }
    public void crearFactura()
    {
        Factura factura = new Factura();
        Cliente cliente = p.encontrarCliente();
        bool validar = false;
        int opcion;
        Presenter.MostrarMensaje("Ingrese el tipo de factura A, B o C");
        factura.Tipo = Reader.AsignarCaracter("No existe ese tipo de factura, vuelva a intentarlo");
        factura.Items = new List<Item>();
        do
        {
            Console.Clear();
            Item nuevoItem = p.crearItem();  
            factura.Items.Add(nuevoItem);
            Context.Items.Add(nuevoItem);
            Presenter.MostrarMensaje("Desea ingresar otro producto?");
            Presenter.MostrarMensaje("1- Si \n 2-No");
            opcion = Reader.AsignarInt("Opcion incorrecta");
            switch (opcion)
            {
                case 1:
                    validar = true;
                    break;
                case 2:
                    validar = false;
                    break;
                default:
                    Console.WriteLine("La opcion ingresada no es correcta. Presione una tecla para continar...");
                    validar = false;
                    Console.ReadKey();
                    break;
            }
        } while (validar);
        float importeTotal = factura.Items.Sum(i => i.Importe);
        factura.ImporteTotal = importeTotal;

        cliente.Facturas.Add(factura);
        Context.Clientes.Update(cliente);
        Context.Facturas.Add(factura);
        Context.SaveChanges();
    }
    public Item crearItem()
    {
        Item item = new Item();
        Presenter.MostrarMensaje("Ingrese la descripcion del producto.");
        item.Descripcion = Reader.AsignarString("Descripcion incorrecta, intente de nuevo");
        Presenter.MostrarMensaje("Ingrese la cantidad del producto");
        item.Cantidad = Reader.AsignarInt("Cantidad invalidad");
        Presenter.MostrarMensaje("Ingrese el importe unitario");
        item.Importe = Reader.AsignarFloat("el precio es incorrecto, intentelo de nuevo");
        return item;
    }
}
