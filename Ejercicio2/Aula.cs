using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio2
{
    class Aula
    {
        private int[,] alumnosAsig = new int[4, 12];
        Random generador = new Random();

        public int this[int indice1, int indice2]
        {
            set
            {
                alumnosAsig[indice1, indice2] = value;
            }
            get
            {
                return alumnosAsig[indice1, indice2];
            }
        }


        enum asignaturas
        {
            Programacion,
            AccesoDatos,
            SistemasGestion,
            Moviles
        }

        public Aula()
        {
            for (int i = 0; i < alumnosAsig.GetLength(0); i++)          
                for (int j = 0; j < alumnosAsig.GetLength(1); j++)
                    alumnosAsig[i, j] = ponderada();
        }



        public int ponderada()
        {
            int numero;
            int numPonderado = 0;
            numero = generador.Next(1, 101);

            switch (numero)
            {
                case int n when (n <= 15):
                    numPonderado = generador.Next(1, 4);
                    break;
                case int n when (n > 15 && n <= 25):
                    numPonderado = 3;
                    break;
                case int n when (n > 25 && n <= 70):
                    numPonderado = generador.Next(4, 7);
                    break;
                case int n when (n > 70 && n <= 90):
                    numPonderado = generador.Next(7, 9);
                    break;
                case int n when (n > 90 && n <= 100):
                    numPonderado = generador.Next(9, 11);
                    break;

                default:
                    break;
            }

            return numPonderado;
        }

        public void mostrarTabla()
        {

            for (int i = 0; i < alumnosAsig.GetLength(0); i++)      //Mostrarlo
            {
                for (int j = 0; j < alumnosAsig.GetLength(1); j++) 
                    Console.Write("{0,3}", alumnosAsig[i, j]);
                    Console.WriteLine(" "+Enum.GetName(typeof(asignaturas), i));
                Console.WriteLine();
            }
            Console.ReadLine();
        }

        public int mediaTotal()
        {
            int total = 0;
            int mediaTotal;

            for (int i = 0; i < alumnosAsig.GetLength(0); i++)
                for (int j = 0; j < alumnosAsig.GetLength(1); j++)
                    total += alumnosAsig[i, j];

            mediaTotal = total / alumnosAsig.Length;
            return mediaTotal;
        }

        public int mediaAlumno(int n)
        {
            int media = 0;
            int total = 0;

            for (int i = 0; i < alumnosAsig.GetLength(0); i++)
                for (int j = 0; j < alumnosAsig.GetLength(1); j++)
                    if (n == j)
                    {
                        total += alumnosAsig[i, j];
                    }
            media = total / alumnosAsig.GetLength(0);

            return media;
        }
        public int mediaAsignatura(int n)
        {
            int media = 0;
            int total = 0;

            for (int i = 0; i < alumnosAsig.GetLength(0); i++)
                for (int j = 0; j < alumnosAsig.GetLength(1); j++)
                    if (n == i)
                    {
                        total += alumnosAsig[i, j];
                    }
                    else if (n < 0 || n > alumnosAsig.Length)
                    {
                        total = 0;
                    }

            media = total / alumnosAsig.GetLength(1);



            return media;
        }

        public void notasAlumno(int n)
        {

            for (int i = 0; i < alumnosAsig.GetLength(0); i++)
                for (int j = 0; j < alumnosAsig.GetLength(1); j++)
                    if (n == j)
                    {
                        Console.Write("{0,3}", alumnosAsig[i, j]);
                    }
            Console.WriteLine();
            Console.ReadLine();

        }

        public void notasAsignatura(int n)
        {

            for (int i = 0; i < alumnosAsig.GetLength(0); i++)
                for (int j = 0; j < alumnosAsig.GetLength(1); j++)
                    if (n == i)
                    {
                        Console.Write("{0,3}", alumnosAsig[i, j]);
                    }
            Console.WriteLine();
            Console.ReadLine();

        }

        public void maxMin(int n)
        {
            int max = alumnosAsig[0, 0], min = alumnosAsig[0, 0];

            for (int i = 0; i < alumnosAsig.GetLength(0); i++)
                for (int j = 0; j < alumnosAsig.GetLength(1); j++)

                    if (n == j)
                    {

                        if (min > alumnosAsig[i, j])
                        {
                            min = alumnosAsig[i, j];
                        }
                        if (max < alumnosAsig[i, j])
                        {
                            max = alumnosAsig[i, j];


                        }
                    }

            Console.WriteLine("maximo: " + max + " minimo: " + min);

        }

        public void aprobados()
        {
            for (int i = 0; i < alumnosAsig.GetLength(0); i++)
            {
                for (int j = 0; j < alumnosAsig.GetLength(1); j++)
                    if (alumnosAsig[i,j]>=5)
                    {
                    Console.Write("{0,3}", alumnosAsig[i, j]);
                    }
                Console.WriteLine(" " + Enum.GetName(typeof(asignaturas), i));
                Console.WriteLine();
            }
            Console.ReadLine();

        }


    }
}
