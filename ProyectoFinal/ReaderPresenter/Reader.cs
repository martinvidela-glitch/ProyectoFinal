using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal.ReaderPresenter
{
    public class Reader
    {
      
        public char LeerCaracter()
        {
            try
            {
                return char.Parse(Console.ReadLine().ToUpper());
            }
            catch (Exception)
            {
                throw new InvalidOperationException("El caracter ingresado es invalido");
            }
        }

        public char AsignarCaracter(string mensaje)
        {
            char tipo;
            bool validar = true;
            do
            {
                tipo = LeerCaracter();
                switch (tipo)
                {
                    case 'A':
                        validar = false;
                        return tipo;
                        break;
                    case 'B':
                        validar = false;
                        return tipo;
                        break;
                    case 'C':
                        validar = false;
                        return tipo;
                        break;
                    default:
                        Console.WriteLine(mensaje);
                        validar = true;
                        break;
                }
            } while (validar);
            return tipo;
        }

        public string LeerString()
        {
            try
            {
                string linea = Console.ReadLine();
                return linea;
            }
            catch (Exception)
            {
                throw new InvalidOperationException("Error en la descripción.");
            }
        }

        public string AsignarString(string mensaje)
        {
            string descripcion;
            bool validar = false;

            do
            {
                descripcion = LeerString();
                if (string.IsNullOrEmpty(descripcion))
                {
                    Console.WriteLine(mensaje);
                    validar = true;
                }else
                {
                    validar = false;
                }

            } while (validar);

            return descripcion;
        }


        public int LeerInt()
        {
            try
            {
                return int.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                throw new InvalidOperationException("El numero ingresado es incorrecto");
            }
        }

        public int AsignarInt(string mensaje)
        {
            int cantidad;
            bool validar = true;
            do
            {
                cantidad = LeerInt();
                if (cantidad <= 0)
                {
                    Console.WriteLine(mensaje);
                    validar = true;
                }
                else
                {
                    validar = false;
                }
            } while (validar);
            return cantidad;

        }

        public float LeerFloat()
        {
            try
            {
                return float.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                throw new InvalidOperationException("El numero ingresado es incorrecto");
            }
        }
        public float AsignarFloat(string mensaje)
        {
            float precio;
            bool validar = true;
            do
            {
                precio = LeerFloat();
                if (precio <= 0)
                {
                    Console.WriteLine(mensaje);
                    validar = true;
                }
                else
                {
                    validar = false;
                }
            } while (validar);
            return precio;
        }
      
       
        

    }
}
