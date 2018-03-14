using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Sudoku
{
    class Program
    {
        static void Main(string[] args)
        {
            {
                //Declaracion de variables
                string[] string_resultado = new string [] {"True","-1","-1"};
                int[][] int_sudoku = new int[9][];
   
                //Llamada a los metodos
                int_sudoku = AllMethods.generar_tabla(); //Carga de la tabla
                string_resultado=AllMethods.revisar_sudoku(int_sudoku, string_resultado);//Revision de la tabla
                AllMethods.imprimir_tabla(string_resultado, int_sudoku); //Impresion de los resultados
                

                Console.ReadLine();
            }
        }
    }
    public class AllMethods
    {
        public static int[][] generar_tabla()
        {
            //Variables
            int[][] int_sudoku = new int[9][];
            string[][] string_sudoku = new string[9][];
            //Inicializacion
            for (int i = 0; i <= 8; i++)
            {
                string_sudoku[i] = new string[9];
                int_sudoku[i] = new int[9];
            }
            //Metodo
            for (int i = 0; i <= 8; i++)
            {
                bool condicion_termino = true;
                int[] fila_sudoku = new int[9];

                while (condicion_termino)
                {
                    Console.WriteLine("Ingrese linea " + (i + 1) + " sudoku:");
                    string_sudoku[i] = Console.ReadLine().Split(new Char[] { ',', ' ' });
                    for (int i2 = 0; i2 < string_sudoku[i].Length; i2++)
                    {
                        if (int.TryParse(string_sudoku[i][i2], out fila_sudoku[i2]) & fila_sudoku[i2] > 0 & fila_sudoku[i2] < 10)
                        {
                            if (i2 < string_sudoku[i].Length - 1)
                            {
                                continue;
                            }
                            else
                            {
                                condicion_termino = false;
                            }
                        }
                        else
                        {
                            Console.WriteLine();
                            Console.WriteLine("Error: El caracter \"" + string_sudoku[i][i2] + "\" no es valido, favor ingresar solo numeros entre 1-9");
                            Console.WriteLine();
                            break;
                        }
                    }
                }
                int_sudoku[i] = fila_sudoku;
            }
            Console.WriteLine();
            return int_sudoku;

        }
        public static string[] revisar_sudoku(int[][] int_sudoku, string[] string_resultado)
        {
            int num1 = 0;
            //Definicion de los 9 cuadrantes del tablero
            int[][] limites_cuadrantes = new int[9][];
            limites_cuadrantes[0] = new int[] { 0, 2, 0, 2 };
            limites_cuadrantes[1] = new int[] { 0, 2, 3, 5 };
            limites_cuadrantes[2] = new int[] { 0, 2, 6, 8 };
            limites_cuadrantes[3] = new int[] { 3, 5, 0, 2 };
            limites_cuadrantes[4] = new int[] { 3, 5, 3, 5 };
            limites_cuadrantes[5] = new int[] { 3, 5, 6, 8 };
            limites_cuadrantes[6] = new int[] { 6, 8, 0, 2 };
            limites_cuadrantes[7] = new int[] { 6, 8, 3, 5 };
            limites_cuadrantes[8] = new int[] { 6, 8, 6, 8 };

            for (int i = 0; i < int_sudoku.Length; i++)
            {
                for (int j = 0; j < int_sudoku[i].Length; j++)
                {
                    num1 = int_sudoku[i][j];
                     if (j < int_sudoku[i].Length - 1)//Revisar horizontal
                     {
                         for (int j2 = j + 1; j2 < int_sudoku[i].Length; j2++)
                         {
                             if (num1 == int_sudoku[i][j2])
                             {
                                 string_resultado = new string[] { "False", Convert.ToString(i), Convert.ToString(j2) };
                                 return string_resultado;
                             }
                         }
                     }
                     if (i < int_sudoku.Length - 1)//Revisar vertical
                     {
                         for (int i2 = i + 1; i2 < int_sudoku.Length; i2++)
                         {
                             if (num1 == int_sudoku[i2][j])
                             {
                                 string_resultado = new string[] { "False", Convert.ToString(i2), Convert.ToString(j) };
                                 return string_resultado;
                             }
                         }
                     }
                    //Revisar cuadrante
                    for (int lc = 0; lc <= 8; lc++)
                    {
                        if (i >= limites_cuadrantes[lc][0] & i <= limites_cuadrantes[lc][1] & j >= limites_cuadrantes[lc][2] & j <= limites_cuadrantes[lc][3])
                        {
                            for (int ic = limites_cuadrantes[lc][0]; ic <= limites_cuadrantes[lc][1]; ic++)
                            {
                                for (int jc = limites_cuadrantes[lc][2]; jc <= limites_cuadrantes[lc][3]; jc++)
                                {
                                    if (num1 == int_sudoku[ic][jc] & i != ic & j != jc)
                                    {
                                        string_resultado = new string[] { "False", Convert.ToString(ic), Convert.ToString(jc) };
                                        return string_resultado;
                                    }
                                }
                            }
                        }

                    }
                }
            }
            return string_resultado;
        }
        public static void imprimir_tabla(string[] string_resultado, int[][] int_sudoku)
        {
            int limite_j2 = 8;
            int limite_i = 8;
            int limite_j = 8;
            string alineamiento_resultado = "{0," + (12 + string_resultado.Length) + "}";
 

            Console.WriteLine(string.Format(alineamiento_resultado, string_resultado[0]));
            Console.WriteLine(string.Format("{0,0}", " ------------------------ "));
            if (int.Parse(string_resultado[1]) != -1)
            {
                limite_i = int.Parse(string_resultado[1]);
                limite_j2 = int.Parse(string_resultado[2]);
                formato_tabla(limite_i, limite_j, limite_j2, int_sudoku, string_resultado[0]);
            }
            else
            {
                formato_tabla(limite_i,limite_j,limite_j2, int_sudoku,string_resultado[0]);
            }
        }
        public static void formato_tabla(int limite_i, int limite_j,int limite_j2, int [][] int_sudoku,string string_resultado)
        {
            for (int i = 0; i <= limite_i; i++)
            {
                if (limite_i==i & limite_j2 != 8)
                {
                    limite_j = limite_j2;
                }
                for (int j = 0; j <= limite_j; j++)
                {
                    if (j == 0 || j == 3 || j == 6)
                    {
                        if (i == limite_i & j == limite_j & string_resultado.Equals("False"))
                        {
                            Thread.Sleep(250);
                            Console.Write("|" + " ");
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write(int_sudoku[i][j] + " ");
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.Write("|" + " " + int_sudoku[i][j] + " ");
                        }
                    }
                    else if (j == 8)
                    {
                        if (i == limite_i & j == limite_j & string_resultado.Equals("False"))
                        {
                            Thread.Sleep(250);
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write(int_sudoku[i][j]);
                            Console.ResetColor();
                            Console.Write(" |");
                        }
                        else
                        {
                            Thread.Sleep(250);
                            Console.Write(int_sudoku[i][j] + " |");
                        }
                    }
                    else
                    {
                        if (i == limite_i & j == limite_j & string_resultado.Equals("False"))
                        {
                            Thread.Sleep(250);
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write(int_sudoku[i][j] + " ");
                            Console.ResetColor();
                        }
                        else
                        {
                            Thread.Sleep(250);
                            Console.Write(int_sudoku[i][j] + " ");
                        }
                    }
                }
                if (i == 2 || i == 5)
                {
                    Console.WriteLine();
                    Console.WriteLine(string.Format("{0,0}", " ------------------------ "));
                }
                else
                {
                    if (i < limite_i)
                    {
                        Console.WriteLine();
                    }
                }
            }
            if (string_resultado.Equals("False"))
            {
                if (limite_j2 < 8)
                {
                    for (int j=limite_j2+1; j<=8; j++)
                    {
                        if (j == 0 || j == 3 || j == 6)
                        {
                            Console.Write("|" + " " + " " + " ");
                        }
                        else if (j == 8)
                        {
                            Console.Write(" " + " |");
                        }
                        else
                        {
                            Console.Write(" " + " ");
                        }
                    }
                    if (limite_i < 8)
                    {
                        Console.WriteLine();
                    }
                }
                if (limite_i < 8)
                {
                    for (int i = limite_i+1; i <= 8; i++)
                    {
                        for (int j = 0; j <= 8; j++)
                        {
                            if (j == 0 || j == 3 || j == 6)
                            {
                                Console.Write("|" + " " + " "+ " ");
                            }
                            else if (j == 8)
                            {
                                Console.Write(" " + " |");
                            }
                            else
                            {
                                Console.Write(" " + " ");
                            }
                        }
                        if (i == 2 || i == 5)
                        {
                            Console.WriteLine();
                            Console.WriteLine(string.Format("{0,0}", " ------------------------ "));
                        }
                        else
                        {
                            if (i < 8)
                            {
                                Console.WriteLine();
                            }
                        }
                    }
                    
                }
            }
            Console.WriteLine();
            Console.WriteLine(string.Format("{0,0}", " ------------------------ "));
        }
    }
}
