using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejercicio1
{
    // Clase para representar la solicitud
    class Solicitud
    {
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Tipo { get; set; }
        public string Descripcion { get; set; }
        public string Prioridad { get; set; }

        public Solicitud()
        {
            Codigo = string.Empty;
            Nombre = string.Empty;
            Tipo = string.Empty;
            Descripcion = string.Empty;
            Prioridad = string.Empty;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            List<Solicitud> solicitudes = new List<Solicitud>();
            bool salir = false;

            while (!salir)
            {
                MostrarMenu();
                Console.Write("Seleccione una opción (1-2): ");
                string opcion = Console.ReadLine();
                if (opcion != null) opcion = opcion.Trim();

                switch (opcion)
                {
                    case "1":
                        Console.WriteLine("\n--- REGISTRO DE NUEVA SOLICITUD ---");

                        // 1. Validación de Código
                        Console.Write("Ingrese código de estudiante (mínimo 4 caracteres): ");
                        string codigo = Console.ReadLine();
                        while (!ValidarTexto(codigo, 4))
                        {
                            Console.WriteLine(" Error: El código no puede estar vacío y debe tener al menos 4 caracteres.");
                            Console.Write("Ingrese un código válido: ");
                            codigo = Console.ReadLine();
                        }

                        // 2. Validación de Nombre
                        Console.Write("Ingrese nombre completo: ");
                        string nombre = Console.ReadLine();
                        while (!ValidarTexto(nombre, 2))
                        {
                            Console.WriteLine(" Error: El nombre debe tener al menos 2 caracteres.");
                            Console.Write("Ingrese un nombre válido: ");
                            nombre = Console.ReadLine();
                        }

                        // 3. Validación de Tipo de Consulta
                        Console.WriteLine("\nTipos permitidos: Matrícula, Pagos, Constancia, Plataforma, Otro");
                        Console.Write("Ingrese el tipo de consulta: ");
                        string tipo = Console.ReadLine();
                        while (!ValidarTipoConsulta(tipo))
                        {
                            Console.WriteLine(" Error: Tipo de consulta no permitido.");
                            Console.Write("Ingrese un tipo válido (Matrícula, Pagos, Constancia, Plataforma, Otro): ");
                            tipo = Console.ReadLine();
                        }

                        // 4. Descripción
                        Console.Write("Ingrese una breve descripción del problema: ");
                        string descripcion = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(descripcion))
                        {
                            descripcion = "Sin descripción";
                        }
                        else
                        {
                            descripcion = descripcion.Trim();
                        }

                        // 5. Asignación de Prioridad
                        string prioridad = ObtenerPrioridad(tipo);

                        // Crear registro
                        Solicitud nuevaSolicitud = new Solicitud
                        {
                            Codigo = codigo.Trim(),
                            Nombre = nombre.Trim(),
                            Tipo = tipo.Trim(),
                            Descripcion = descripcion,
                            Prioridad = prioridad
                        };

                        solicitudes.Add(nuevaSolicitud);

                        // 6. Mostrar Resumen
                        MostrarResumenSolicitud(nuevaSolicitud.Codigo, nuevaSolicitud.Nombre, nuevaSolicitud.Tipo, nuevaSolicitud.Descripcion, nuevaSolicitud.Prioridad);
                        Console.WriteLine($" Solicitud registrada con éxito. (Total registradas: {solicitudes.Count})\n");
                        break;

                    case "2":
                        Console.WriteLine($"\nSaliendo del programa. Solicitudes registradas en la sesión: {solicitudes.Count}");
                        salir = true;
                        break;

                    default:
                        Console.WriteLine(" Opción no válida. Intente nuevamente.\n");
                        break;
                }
            }
        }

        // ==========================================
        // FUNCIONES MODULARES
        // ==========================================

        static void MostrarMenu()
        {
            Console.WriteLine("=============================================");
            Console.WriteLine("      SISTEMA DE SOPORTE ACADÉMICO - C#      ");
            Console.WriteLine("=============================================");
            Console.WriteLine("1. Registrar nueva solicitud");
            Console.WriteLine("2. Salir");
            Console.WriteLine("=============================================");
        }

        static bool ValidarTexto(string texto, int longitudMinima)
        {
            if (string.IsNullOrWhiteSpace(texto))
            {
                return false;
            }
            return texto.Trim().Length >= longitudMinima;
        }

        static bool ValidarTipoConsulta(string tipoIngresado)
        {
            if (string.IsNullOrWhiteSpace(tipoIngresado))
                return false;

            string tipoNormalizado = tipoIngresado.Trim().ToLower();
            string[] tiposValidos = { "matrícula", "matricula", "pagos", "constancia", "plataforma", "otro" };

            foreach (string t in tiposValidos)
            {
                if (t == tipoNormalizado)
                    return true;
            }

            return false;
        }

        static string ObtenerPrioridad(string tipoConsulta)
        {
            if (string.IsNullOrWhiteSpace(tipoConsulta))
                return "BAJA";

            string tipo = tipoConsulta.Trim().ToLower();

            if (tipo == "pagos" || tipo == "plataforma")
            {
                return "ALTA";
            }
            else if (tipo == "matrícula" || tipo == "matricula")
            {
                return "MEDIA";
            }
            else
            {
                return "BAJA";
            }
        }

        static void MostrarResumenSolicitud(string codigo, string nombre, string tipo, string descripcion, string prioridad)
        {
            Console.WriteLine("\n-------------------------------------------");
            Console.WriteLine("       RESUMEN DE SOLICITUD REGISTRADA      ");
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine($"Código Estudiante : {codigo}");
            Console.WriteLine($"Nombre            : {nombre}");
            Console.WriteLine($"Tipo de Consulta  : {tipo}");
            Console.WriteLine($"Prioridad Asignada: {prioridad}");
            Console.WriteLine($"Descripción       : {descripcion}");
            Console.WriteLine("-------------------------------------------\n");
        }
    }
}