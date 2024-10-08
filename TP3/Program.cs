using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP3_Programacion
{
    internal class Program
    {
        static int[][] asientos;
        static bool vuelosCreado = false;

        static void Main(string[] args)
        {
            bool cerrarSistema = false;
            int opcionElegida = 0;

            while (!cerrarSistema)
            {
                Console.WriteLine("-----BIENVENIDO A QUALITYFLY----- \nA continuación podrá ver las opciones, elija la que desee realizar");
                Console.WriteLine("1) Crear vuelo \n2) Reservar asiento \n3) Cancelar reserva \n4) Mostrar estado del vuelo \n5) Mostrar cantidad de asientos disponibles y ocupados \n6) Buscar un asiento \n7) Salir del sistema");
                opcionElegida = int.Parse(Console.ReadLine());

                switch (opcionElegida)
                {
                    case 1:
                        Console.Clear();
                        CrearVuelo();
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 2:
                        Console.Clear();
                        ReservarAsiento();
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 3:
                        Console.Clear();
                        CancelarReserva();
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 4:
                        Console.Clear();
                        MostrarEstadoVuelo();
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 5:
                        Console.Clear();
                        MostrarCantidadAsientos();
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 6:
                        Console.Clear();
                        BuscarAsiento();
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 7:
                        Console.WriteLine("Adiós, esperamos su regreso");
                        cerrarSistema = true;
                        break;
                    default:
                        Console.WriteLine("Opción no válida");
                        break;
                }
            }

            Console.ReadKey();
        }

        static void CrearVuelo()
        {
            if (!vuelosCreado)
            {
                asientos = new int[15][];
                for (int i = 0; i < asientos.Length; i++)
                {
                    asientos[i] = new int[4]; 
                }
                vuelosCreado = true;
                Console.WriteLine("Vuelo creado con 60 asientos disponibles.");
            }
            else
            {
                Console.WriteLine("Los datos ya han sido creados.");
            }
        }

        static void ReservarAsiento()
        {
            if (!vuelosCreado)
            {
                Console.WriteLine("Primero debe crear un vuelo.");
                return;
            }

            Console.WriteLine("Ingrese el número de fila (0-14):");
            int fila = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese el número de asiento (0-3):");
            int asiento = int.Parse(Console.ReadLine());

            if (fila >= 0 && fila < 15 && asiento >= 0 && asiento < 4)
            {
                if (asientos[fila][asiento] == 0)
                {
                    asientos[fila][asiento] = 1; 
                    Console.WriteLine("Asiento reservado con éxito!");
                }
                else
                {
                    Console.WriteLine("Asiento ocupado, seleccione otro.");
                }
            }
            else
            {
                Console.WriteLine("Número de fila o asiento no válido.");
            }
        }

        static void CancelarReserva()
        {
            if (!vuelosCreado)
            {
                Console.WriteLine("Primero debe crear un vuelo.");
                return;
            }

            Console.WriteLine("Ingrese el número de fila (0-14):");
            int fila = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese el número de asiento (0-3):");
            int asiento = int.Parse(Console.ReadLine());

            if (fila >= 0 && fila < 15 && asiento >= 0 && asiento < 4)
            {
                if (asientos[fila][asiento] == 1)
                {
                    asientos[fila][asiento] = 0; 
                    Console.WriteLine("Reserva del asiento cancelada exitosamente.");
                }
                else
                {
                    Console.WriteLine("El asiento no está reservado.");
                }
            }
            else
            {
                Console.WriteLine("Número de fila o asiento no válido.");
            }
        }

        static void MostrarEstadoVuelo()
        {
            if (!vuelosCreado)
            {
                Console.WriteLine("Primero debe crear un vuelo.");
                return;
            }

            Console.WriteLine("Estado actual del vuelo:");
            for (int i = 0; i < asientos.Length; i++)
            {
                for (int j = 0; j < asientos[i].Length; j++)
                {
                    Console.Write(asientos[i][j] + (asientos[i][j] == 0 ? " (Disponible)" : " (Ocupado)") + " ");
                }
                Console.WriteLine();
            }
        }

        static void MostrarCantidadAsientos()
        {
            if (!vuelosCreado)
            {
                Console.WriteLine("Primero debe crear un vuelo.");
                return;
            }

            int disponibles = 0, ocupados = 0;
            for (int i = 0; i < asientos.Length; i++)
            {
                for (int j = 0; j < asientos[i].Length; j++)
                {
                    if (asientos[i][j] == 0)
                    {
                        disponibles++;
                    }
                    else
                    {
                        ocupados++;
                    }
                }
            }
            Console.WriteLine("Asientos disponibles: " + disponibles + ", Asientos ocupados: " + ocupados);
        }

        static void BuscarAsiento()
        {
            if (!vuelosCreado)
            {
                Console.WriteLine("Primero debe crear un vuelo.");
                return;
            }

            Console.WriteLine("Ingrese el número de fila (0-14):");
            int fila = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese el número de asiento (0-3):");
            int asiento = int.Parse(Console.ReadLine());

            if (fila >= 0 && fila < 15 && asiento >= 0 && asiento < 4)
            {
                string estado = (asientos[fila][asiento] == 0) ? "Disponible" : "Ocupado";
                Console.WriteLine("El estado del asiento " + (asiento + 1) + " en la fila " + (fila + 1) + " es: " + estado);
            }
            else
            {
                Console.WriteLine("Número de fila o asiento no válido.");
            }
        }
    }
}