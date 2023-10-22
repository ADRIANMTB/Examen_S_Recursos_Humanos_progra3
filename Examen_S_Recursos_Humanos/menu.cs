using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Examen_S_Recursos_Humanos
{
    class menu
    {
        private static int opcion = 0;
        private static Empleado[] empleados = new Empleado[50];
        private static int cant_empleados = 0;

        public static void Desplegar()
        {
            do
            {
                Console.Clear();
                Console.WriteLine("*****Sistema de Recursos Humanos*****");
                Console.WriteLine("1- Inicializar Arreglos");
                Console.WriteLine("2- Agregar Empleados");
                Console.WriteLine("3- Consultar Empleados");
                Console.WriteLine("4- Modificar Empleados");
                Console.WriteLine("5- Borrar Empleados");
                Console.WriteLine("6- Reportes");
                Console.WriteLine("7- Salir");

                opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        ini_arreglos();
                        break;
                    case 2:
                        a_empleado();
                        break;
                    case 3:
                        C_empleado();
                        break;
                    case 4:
                        m_empleados();
                        break;
                    case 5:
                        b_empleados();
                        break;
                    case 6:
                        m_reportes();
                        break;
                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }
            } while (opcion != 7);
        }

        static void ini_arreglos()
        {
            for (int i = 0; i < empleados.Length; i++)
            {   //Console.WriteLine("Arreglos Iniciados");
                empleados[i] = null;

                //Console.ReadLine();
            }
            cant_empleados = 0;

        }


        public static void a_empleado()
        {
            Console.Clear();
            Console.Write("Ingrese la cédula del empleado: ");
            string cedula = Console.ReadLine();
            Console.Write("Ingrese el nombre del empleado: ");
            string nombre = Console.ReadLine();
            Console.Write("Ingrese la dirección del empleado: ");
            string direccion = Console.ReadLine();
            Console.Write("Ingrese el teléfono del empleado: ");
            string telefono = Console.ReadLine();
            Console.Write("Ingrese el salario del empleado: ");
            double salario = double.Parse(Console.ReadLine());
            Empleado empleado = new Empleado(cedula, nombre, direccion, telefono, salario);
            empleados[cant_empleados] = empleado;
            cant_empleados++;
            Console.WriteLine("Empleado agregado exitosamente.");
            Console.ReadKey();
        }

        public static void C_empleado()
        {
            Console.Clear();
            Console.Write("Ingrese la cédula del empleado que desea consultar: ");
            string cedula = Console.ReadLine();
            bool encontrado = false;
            foreach (var empleado in empleados)
            {
                if (empleado != null && empleado.Cedula == cedula)
                {
                    Console.WriteLine("Nombre: " + empleado.Nombre);
                    Console.WriteLine("Dirección: " + empleado.Direccion);
                    Console.WriteLine("Teléfono: " + empleado.Telefono);
                    Console.WriteLine("Salario: " + empleado.Salario);
                    encontrado = true;
                    break;
                }
            }
            if (!encontrado)
            {
                Console.WriteLine("No se encontró el empleado.");
            }
            Console.ReadKey();
        }

        public static void m_empleados()
        {
            Console.Clear();
            Console.Write("Ingrese la cédula del empleado que desea modificar: ");
            string cedula = Console.ReadLine();
            bool encontrado = false;
            for (int i = 0; i < cant_empleados; i++)
            {
                if (empleados[i] != null && empleados[i].Cedula == cedula)
                {
                    Console.WriteLine("Empleado encontrado:");
                    Console.WriteLine("Ingrese el nuevo nombre del empleado: ");
                    string nuevoNombre = Console.ReadLine();
                    Console.WriteLine("Ingrese la nueva dirección del empleado: ");
                    string nuevaDireccion = Console.ReadLine();
                    Console.WriteLine("Ingrese el nuevo teléfono del empleado: ");
                    string nuevoTelefono = Console.ReadLine();
                    Console.WriteLine("Ingrese el nuevo salario del empleado: ");
                    double nuevoSalario = double.Parse(Console.ReadLine());
                    empleados[i].Nombre = nuevoNombre;
                    empleados[i].Direccion = nuevaDireccion;
                    empleados[i].Telefono = nuevoTelefono;
                    empleados[i].Salario = nuevoSalario;
                    Console.WriteLine("Empleado modificado exitosamente.");
                    encontrado = true;
                    break;
                }
            }
            if (!encontrado)
            {
                Console.WriteLine("Empleado no encontrado.");
            }
            Console.ReadKey();
        }

        static void b_empleados()
        {
            Console.Clear();
            Console.Write("Ingrese la cédula del empleado que desea borrar: ");
            string cedula = Console.ReadLine();
            bool encontrado = false;
            for (int i = 0; i < cant_empleados; i++)
            {
                if (empleados[i] != null && empleados[i].Cedula == cedula)
                {
                    empleados[i] = null;
                    Console.WriteLine("Empleado eliminado exitosamente.");
                    encontrado = true;
                    break;
                }
            }
            if (!encontrado)
            {
                Console.WriteLine("No se encontró el empleado.");
            }
            Console.ReadKey();
        }

        static void m_reportes()
        {
            int opcion;
            do
            {
                Console.WriteLine("Menú de Reportes:");
                Console.WriteLine("1. Consultar empleados con número de cédula.");
                Console.WriteLine("2. Listar todos los empleados ordenados por nombre.");
                Console.WriteLine("3. Calcular y mostrar el promedio de los salarios.");
                Console.WriteLine("4. Calcular y mostrar el salario más alto y el más bajo.");
                Console.WriteLine("0. Volver al Menú Principal");

                opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        Cons_emp_ced();
                        break;
                    case 2:
                        List_empl();
                        break;
                    case 3:
                        Calc_prom();
                        break;
                    case 4:
                        Calc_maxmin();
                        break;
                }
            } while (opcion != 0);
        }

        public static void Cons_emp_ced()
        {
            Console.Write("Introduce la cédula del empleado que deseas consultar: ");
            string cedula = Console.ReadLine();

            bool encontrado = false;
            foreach (var empleado in empleados)

                if (empleado != null && empleado.Cedula == cedula)
            {
                Console.WriteLine($"Cédula: {empleado.Cedula}, Nombre: {empleado.Nombre}, Dirección: {empleado.Direccion}, Teléfono: {empleado.Telefono}, Salario: {empleado.Salario}");
            }
           if (!encontrado)
            {
                Console.WriteLine("No se encontró ningun empleado.");
            }
           Console.ReadKey();
        }

        public static void List_empl()
        {
            var Ordenado = empleados.OrderBy(e => e.Nombre);

            Console.WriteLine("Lista de Empleados ordenados por nombre:");
            foreach (var empleado in Ordenado)
            {
                Console.WriteLine($"Cédula: {empleado.Cedula}, Nombre: {empleado.Nombre}");
            }
        }

        public static void Calc_prom()
        {
            double promedio = empleados.Average(e => e.Salario);
            Console.WriteLine($"El promedio de los salarios es: {promedio}");
        }


        public static void Calc_maxmin()
        {
            double salarioMaximo = empleados.Max(e => e.Salario);
            double salarioMinimo = empleados.Min(e => e.Salario);

            Console.WriteLine($"El Salario más alto es de: {salarioMaximo}");
            Console.WriteLine($"El Salario más bajo es de: {salarioMinimo}");
        }
    }
}
