using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio2
{
    class Menu
    {
        public void menu()
        {
            Aula aula = new Aula();
            int opcion;
            bool flag;

            do
            {
                try
                {
                    flag = true;
                    do
                    {


                        Console.WriteLine("1.-Calcular la media de notas de toda la tabla");
                        Console.WriteLine("2.-Media de un Alumno");
                        Console.WriteLine("3.-Media de una Asignatura");
                        Console.WriteLine("4.-Visualizar notas de un alumno");
                        Console.WriteLine("5.-Visualizar notas de una asignatura");
                        Console.WriteLine("6.-Nota máxima y mínima de un alumno");
                        Console.WriteLine("7.-Tabla solo de aprobados");
                        Console.WriteLine("8.-Visualizar Tabla completa");
                        Console.WriteLine("9.-Salir");
                        opcion = Convert.ToInt32(Console.ReadLine());

                        switch (opcion)
                        {
                            case 1:
                                Console.WriteLine("Media Total: " + aula.mediaTotal());
                                Console.ReadLine();
                                break;
                            case 2:
                                Console.WriteLine("Media del alumno: " + aula.mediaAlumno(0));
                                Console.ReadLine();
                                break;
                            case 3:
                                Console.WriteLine("Media de la Asignatura: " + aula.mediaAsignatura(0));
                                Console.ReadLine();
                                break;
                            case 4:
                                aula.notasAlumno(0);
                                break;
                            case 5:
                                aula.notasAsignatura(0);
                                break;
                            case 6:
                                //Console.WriteLine(aula[0,0]); 
                                aula.maxMin(0);
                                break;
                            case 7:
                                aula.aprobados();
                                break;
                            case 8:
                                aula.mostrarTabla();
                                break;
                            case 9:
                                Console.WriteLine("Adios");
                                Console.ReadLine();
                                break;

                            default:
                                break;
                        }
                    } while (opcion != 9);
                }
                catch (Exception)
                {
                    flag = false;
                    Console.WriteLine("Opcion invalida");
                    Console.ReadLine();
                }
            } while (!flag);
        }
    }
}
