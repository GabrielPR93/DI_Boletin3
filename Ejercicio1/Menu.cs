using System;
using System.Collections;
using System.IO;
using System.Linq;
using System.Security.Policy;

namespace Ejercicio1
{
    class Menu
    {
        public static bool ComprobarRam(int ram)
        {
            if (ram < 0)
            {
                return false;
            }
            return true;
        }
        public static bool ComprobarIp(string ip)
        {

            int temp;
            string[] partes = ip.Split('.');

            if (partes.Length != 4)
            {
                return false;
            }
            else
            {
                foreach (String direcciones in partes)
                {
                    if (direcciones.Length > 3)
                    {
                        return false;
                    }

                    temp = int.Parse(direcciones);
                    if (temp > 255 || temp < 0)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public static void MuestraIp(Hashtable ordenadores)
        {
            foreach (DictionaryEntry de in ordenadores)
            {
                Console.WriteLine("Direccion IP: {0,-15} tiene {1}GB de Ram", de.Key, de.Value);
            }
        }
        public static void menu()
        {
            Hashtable ordenadores = new Hashtable();
            int opcion;
            int ram;
            bool flag, flag2;
            string ip, clave, clave2, linea;
            StreamWriter s;
            StreamReader sr;

            string ruta = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\PRUEBA.txt";
            //string ruta= "C:\\Users\\gabri\\Desktop\\PRUEBA.txt";
            if (File.Exists("PRUEBAS.txt"))
            {
                using (sr = new StreamReader("PRUEBAS.txt"))
                {
                    linea = sr.ReadLine();
                    while (linea != null)
                    {
                        string[] datos = linea.Split(',');
                        ip = datos[0];

                        if (datos.Length == 2)
                        {
                            if (ComprobarIp(ip) == true)
                            {
                                try
                                {
                                    ram = Convert.ToInt32(datos[1]);
                                    try
                                    {
                                        ordenadores.Add(datos[0], datos[1]);
                                    }
                                    catch (ArgumentException)
                                    {
                                        Console.WriteLine("Error valor repetido");
                                    }
                                }
                                catch (FormatException)
                                {
                                    Console.WriteLine("Error introduce un numero");
                                }
                            }
                        }
                        linea = sr.ReadLine();


                    }
                }
            }

            do
            {
                try
                {

                    flag2 = true;
                    do
                    {

                        Console.WriteLine("Selecciona una opcion");
                        Console.WriteLine("1.Introduccion de datos-");
                        Console.WriteLine("2.-Elimina un dato por clave");
                        Console.WriteLine("3.-Muestra coleccion entera");
                        Console.WriteLine("4.- Muestra de un elemento de la coleccion");
                        Console.WriteLine("5.-Salir");
                        opcion = Int32.Parse(Console.ReadLine());

                        switch (opcion)
                        {
                            case 1:
                                do
                                {
                                    flag = true;
                                    try
                                    {
                                        Console.WriteLine("Introduce direccion IP");
                                        ip = Console.ReadLine();
                                        if (!ComprobarIp(ip))
                                        {
                                            throw new FormatException();
                                        }
                                        Console.WriteLine("Introduce cantidad de RAM");
                                        ram = Int32.Parse(Console.ReadLine());
                                        if (!ComprobarRam(ram))
                                        {
                                            throw new FormatException();
                                        }
                                        else
                                        {
                                            try
                                            {
                                                ordenadores.Add(ip, ram);

                                            }
                                            catch (ArgumentException)
                                            {
                                                flag = false;
                                                Console.WriteLine("Ip repetida introduce otra");
                                            }

                                        }
                                    }
                                    catch (FormatException)
                                    {
                                        flag = false;
                                        Console.WriteLine("Datos no validos");
                                        Console.ReadLine();
                                    }
                                    catch (OverflowException)
                                    {
                                        flag = false;
                                        Console.WriteLine("Numero demasiado grande");
                                        Console.ReadLine();
                                    }

                                } while (!flag);
                                break;
                            case 2:
                                MuestraIp(ordenadores);
                                Console.WriteLine("Selecciona IP para eliminar");
                                clave = Console.ReadLine();
                                if (ordenadores.ContainsKey(clave))
                                {
                                    ordenadores.Remove(clave.Trim());
                                    Console.WriteLine("Eliminado Correctamente");
                                }
                                else
                                {
                                    Console.WriteLine("No se pudo eliminar ");
                                }
                                break;
                            case 3:
                                MuestraIp(ordenadores);
                                break;
                            case 4:
                                Console.WriteLine("Que elemento de la coleccion quieres ver");
                                clave2 = Console.ReadLine();
                                foreach (DictionaryEntry de in ordenadores)
                                {
                                    if (de.Key.Equals(clave2))
                                    {
                                        Console.WriteLine("Direccion IP: {0,-15} tiene {1}GB de Ram", de.Key, de.Value);
                                        Console.ReadLine();
                                    }
                                    else
                                    {
                                        Console.WriteLine("No se encontro esa ip");
                                    }
                                }

                                break;
                            case 5:
                                Console.WriteLine("Adios");
                                using (s = new StreamWriter(ruta, true))
                                {

                                    foreach (DictionaryEntry de in ordenadores)
                                    {
                                        s.WriteLine("{0}-{1}", de.Key, de.Value);
                                    }

                                }

                                break;
                            default:
                                break;
                        }
                    } while (opcion != 5);

                }
                catch (FormatException)
                {
                    flag2 = false;
                    Console.WriteLine("Formato incorrecto");
                }
                catch (OverflowException)
                {
                    flag2 = false;
                    Console.WriteLine("Numero demasiado grande");
                }
            } while (!flag2);
        }

    }
}

