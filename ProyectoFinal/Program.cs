using Microsoft.EntityFrameworkCore;
using ProyectoFinal.Clases;
using ProyectoFinal.EntityFramework;
using ProyectoFinal.ReaderPresenter;

internal class Program
{
    public static Reader Reader = new Reader();
    public static Presenter Presenter = new Presenter();    

    static void Main (string[] args)
    {
        Program p = new Program();
        //CodeFirstDbContext Context = new CodeFirstDbContext();
        //Context.Database.Migrate();
        Presenter.PrimerMenu();
        p.LeerPrimerMenu();
    }

    private void LeerPrimerMenu()
    {
        int opcion;
        bool validar = false;
        string accion;
        do
        {
            opcion = int.Parse(Console.ReadLine());
            switch (opcion)
            {
                case 1:
                    Console.Clear();
                    Presenter.MenuClientes();
                    break;
                case 2:
                    Console.Clear();
                    Presenter.MenuFacturas();
                    break;
                case 3:
                    Console.ReadKey();
                    break;
                default:
                    Console.WriteLine("El numero ingresado no es correcto");
                    validar = true;
                    break;
            }
        } while (validar);
       
    }

    private void GestionClientes()
        {
            //
            Cliente cliente = new Cliente();
            cliente.Domicilio = Reader.AsignarString("Domicilio incorrecto");
            cliente.RazonSocial = Reader.AsignarString("Razon social mal");
            cliente.CuilCuit = Reader.AsignarString("Cuil/Cuit erroneo");
        }
}


