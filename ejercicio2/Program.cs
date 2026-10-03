using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejercicio2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //experimento
            string[] nombres = new string[0];
            int[] numeros = new int[0];
            int cnt = 0;
            int op = 0;
            do
            {
                Console.Clear();
                Console.WriteLine("::::::::AGENDA DE CONTACTOS UPN 2026::::::::::");
                Console.WriteLine("1. Registrar nuevo contacto");
                Console.WriteLine("2. Ver conctactos");
                Console.WriteLine("3. Buscar conctacto");
                Console.WriteLine("4. Actualizar contacto");
                Console.WriteLine("5. Eliminar contacto");
                Console.WriteLine("6. Ordenar contactos");
                Console.WriteLine("0. Salir");
                Console.Write("Ingrese una opcion: ");
                op = int.Parse(Console.ReadLine());

                switch (op)
                {
                    case 0:
                        Console.WriteLine("No vuelvas!!!");
                        break;
                    case 1:
                        RegistrarContacto(nombres, numeros);
                        break;
                    default:
                        Console.WriteLine("Opcion no valida");
                        break;
                }
                Console.ReadKey();
            } while (op != 0);//! = 
        }
        private static void RegistrarContacto(string[] nombres, int[] numeros)
        {
            Array.Resize(ref nombres, 1);
            Array.Resize(ref numeros, 1);
        }
    }
}
