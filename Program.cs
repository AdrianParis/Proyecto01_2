using System;
using System.ComponentModel.Design;
using System.Globalization;
using System.IO;
using System.Timers;
using System.Xml.Schema;

namespace Proyecto01_2
{
    class Program
    {
        static void Main(string[] args)
        {
            bool continuar = true;
            // Crear arreglos para almacenar los números
            double[] gastoFijoSemanal = new double[1];
            double resultado = 0;



            Console.WriteLine("El siguiente codigo sera guardado en C:\\Users\\adrie\\OneDrive\\Escritorio\\Fif\\Intro Progra\\GitHub\\ArchivosDeTextoProyecto\\Semana.txt");
            Console.WriteLine();
            Console.WriteLine("Calculadora de gastos semanales para la escuela");

            while (continuar)
            {
                Console.WriteLine();
                Console.WriteLine("Por favor ingrese qué desea realizar: ");
                Console.WriteLine("(Se recomienda hacer todo jerarquicamente de menor a mayor) ") ;

                Console.WriteLine("1. Ingresar un nuevo ingreso semanal.");
                Console.WriteLine("     (Cuanto dinero tienes para gastar a la semana)") ;

                Console.WriteLine("2. Ingresar nuevos gastos semanales");
                Console.WriteLine("     (Dinero a gastar diario de unes a Viernes )");

                Console.WriteLine("3. Ingresar nuevos gastos unico a la semana");
                Console.WriteLine("     (Ocurrio un gasto inesperado o un postre por ahi)");

                Console.WriteLine("4. Mostrar dinero restante");
                Console.WriteLine("5. Salir");
                Console.Write("Opcion: ");
                int opcion = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();

                switch (opcion)// Bucle principal del programa
                {
                    case 1:

                        for (int i = 0; i < gastoFijoSemanal.Length; i++)
                        {
                            Console.Write($"Ingresa la cantidad semanal a gastar: ");
                            gastoFijoSemanal[i] = Convert.ToDouble(Console.ReadLine());
                        }
                        Console.WriteLine();

                        // Guardar el arreglo en un archivo de texto
                        string rutaArchivo = "C:\\Users\\adrie\\OneDrive\\Escritorio\\Fif\\Intro Progra\\GitHub\\ArchivosDeTextoProyecto\\Semana.txt";
                        using (StreamWriter writer = new StreamWriter(rutaArchivo))
                        {
                            foreach (double numero in gastoFijoSemanal)
                            {
                                writer.WriteLine(numero);
                            }
                        }
                        break;

                    case 2:

                        Console.WriteLine("Ingresa las cantidades diarias para restar de tu gasto fijo:");
                        string[] diasSemana = { "Lunes", "Martes", "Miércoles", "Jueves", "Viernes" };
                        double[] gastos = new double[5];

                        for (int i = 0; i < gastos.Length; i++)
                        {
                            Console.Write($"Ingresa la cantidad para el día {diasSemana[i]}: ");
                            gastos[i] = Convert.ToDouble(Console.ReadLine());
                        }

                        Console.WriteLine();


                        // Guardar el arreglo en un archivo de texto para visualisarlo si es necesario 
                        string rutaArchivo2 = "C:\\Users\\adrie\\OneDrive\\Escritorio\\Fif\\Intro Progra\\GitHub\\ArchivosDeTextoProyecto\\GastoFijo.txt";
                        using (StreamWriter writer = new StreamWriter(rutaArchivo2))
                        {
                            foreach (double numero in gastoFijoSemanal)
                            {
                                writer.WriteLine(numero);
                            }
                        }
                        int gastosSuma = 0;

                        // Recorrer el arreglo y sumar los números
                        foreach (int numero in gastos)
                        {
                            gastosSuma += numero;
                        }
                        Console.WriteLine($"El gasto semanal es de: {gastosSuma}");

                        //Elije que hacer si el usuario ingreso primero un gasto unico
                        string Opcion = "C:\\Users\\adrie\\OneDrive\\Escritorio\\Fif\\Intro Progra\\GitHub\\ArchivosDeTextoProyecto\\Case2.txt";
                        if (File.Exists(Opcion))
                        {
                            //extrae los archivos necesarios y convierte los archivos necesarios 
                            Opcion = "C:\\Users\\adrie\\OneDrive\\Escritorio\\Fif\\Intro Progra\\GitHub\\ArchivosDeTextoProyecto\\Case2.txt";
                            double numeroGastoFijo1 = Convert.ToDouble(File.ReadAllText(Opcion));

                            //Realiza la operacion 
                            resultado = numeroGastoFijo1 - gastosSuma;

                            //Escribe en consola la operacion
                            Console.WriteLine($"El dinero restante es: {resultado}");
                            Console.WriteLine();
                            if (resultado >= numeroGastoFijo1 / 2)
                            {
                                Console.WriteLine("No hay problema si se gasta un poco mas :b");
                                Console.WriteLine();
                            }
                            else
                            {
                                Console.WriteLine("Se recomienda no gastar mas dinero de lo planeado ");
                                Console.WriteLine();
                            }
                        }
                        else
                        {
                            //El usiario siguio jerarquicamente las opciones 
                            //Extrae los archivos de sus lugares
                            string rutaArchivoGastoFijo = @"C:\Users\adrie\OneDrive\Escritorio\Fif\Intro Progra\GitHub\ArchivosDeTextoProyecto\GastoFijo.txt";

                            // Leer los números desde los archivos
                            double numeroGastoFijo = Convert.ToDouble(File.ReadAllText(rutaArchivoGastoFijo));

                            // Realizar la resta
                            resultado = numeroGastoFijo - gastosSuma;

                            Console.WriteLine($"El dinero restante es: {resultado}");
                            Console.WriteLine();
                            if (resultado >= numeroGastoFijo / 2)
                            {
                                Console.WriteLine("No hay problema si se gasta un poco mas :b");
                                Console.WriteLine();
                            }
                            else
                            {
                                Console.WriteLine("Se recomienda no gastar mas dinero de lo planeado ");
                                Console.WriteLine();
                            }
                            
                        }
                        //guarda el resultado de esta operacion 
                        string resutadoTexto = Convert.ToString(resultado);
                        string rutaArchivoResultado = "C:\\Users\\adrie\\OneDrive\\Escritorio\\Fif\\Intro Progra\\GitHub\\ArchivosDeTextoProyecto\\Case2.txt";

                        using (StreamWriter writer = new StreamWriter(rutaArchivoResultado))
                        {
                            writer.WriteLine(resutadoTexto);
                        }
                        break;

                    case 3:
                        Console.WriteLine("Oh no... una lastima pero asi pasa, ¿cuanto dinero va a ser?");
                        double GastoInesperado = Convert.ToDouble(Console.ReadLine());

                        //Extrae los archivos de sus lugares
                        rutaArchivo = "C:\\Users\\adrie\\OneDrive\\Escritorio\\Fif\\Intro Progra\\GitHub\\ArchivosDeTextoProyecto\\Semana.txt";

                        // Leer los números desde los archivos
                        double DineroDisponible = Convert.ToDouble(File.ReadAllText(rutaArchivo));

                        rutaArchivoResultado = "C:\\Users\\adrie\\OneDrive\\Escritorio\\Fif\\Intro Progra\\GitHub\\ArchivosDeTextoProyecto\\Case2.txt";
                        if (File.Exists(rutaArchivoResultado))
                        {
                            resultado = Convert.ToDouble(File.ReadAllText(rutaArchivoResultado));
                        }

                        double total;
                        if (resultado <=1)
                        {
                            total = DineroDisponible - GastoInesperado;

                        }
                        else
                        {
                            total = resultado - GastoInesperado;
                        }

                        if (total >= 100)
                        {
                            Console.WriteLine($"Genial, aún te quedan {total}, ¡NO gastes más!");
                        }
                        else if (total >= 15 && total <= 99)
                        {
                            Console.WriteLine($"¡Enhorabuena! Aún tienes {total}, suficiente dinero para una maruchan.");
                        }
                        else if (total <= 14 && total >=1)
                        {
                            Console.WriteLine($"Oh no, no te alcanza ni para una maruchan. Pero ánimo, aún te quedan {total}.");
                        }
                        else if (total == 0)
                        {
                            Console.WriteLine($"Bueno... te queda {total}, al menos no debes, así que mucha suerte con el hambre.");
                        }
                        else
                        {
                            Console.WriteLine($"Bueno... ahora debes {total}.");
                        }



                        //sobre escribe el resultado en el archivo inicial

                        rutaArchivo = "C:\\Users\\adrie\\OneDrive\\Escritorio\\Fif\\Intro Progra\\GitHub\\ArchivosDeTextoProyecto\\Semana.txt";
                        String total1 = Convert.ToString(total); 
                        File.WriteAllText(rutaArchivo, total1);

                        //guarda el resultado de esta operacion 
                        string rutaArchivo3 = "C:\\Users\\adrie\\OneDrive\\Escritorio\\Fif\\Intro Progra\\GitHub\\ArchivosDeTextoProyecto\\Case2.txt";
                        using (StreamWriter writer = new StreamWriter(rutaArchivo3))
                        {
                            writer.WriteLine(total1);
                        }


                        break;

                    case 4:
                        Console.Write("El dinero restante es de :");
                        rutaArchivo3 = "C:\\Users\\adrie\\OneDrive\\Escritorio\\Fif\\Intro Progra\\GitHub\\ArchivosDeTextoProyecto\\Case2.txt";
                        string content = File.ReadAllText(rutaArchivo3);
                        Console.Write(content);
                        break;

                    case 5:

                        //Borra todo los archivos de texto creados para evitar problemas en otros usos
                       
                        rutaArchivo = "C:\\Users\\adrie\\OneDrive\\Escritorio\\Fif\\Intro Progra\\GitHub\\ArchivosDeTextoProyecto\\Semana.txt";
                        rutaArchivo2 = "C:\\Users\\adrie\\OneDrive\\Escritorio\\Fif\\Intro Progra\\GitHub\\ArchivosDeTextoProyecto\\GastoFijo.txt";
                        rutaArchivoResultado = "C:\\Users\\adrie\\OneDrive\\Escritorio\\Fif\\Intro Progra\\GitHub\\ArchivosDeTextoProyecto\\Case2.txt";
                        File.Delete(rutaArchivoResultado);
                        File.Delete(rutaArchivo);
                        File.Delete(rutaArchivo2);

                        continuar = false;                        
                        break;
                }
            }
        }
        
    }
}