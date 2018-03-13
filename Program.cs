using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

            string[] fila_sudoku = new string [9];
            fila_sudoku = AllMethods.lista_sudoku();
            //AllMethods.revisar_sudoku(names);
            for (int i = 0; i <= 8; i++)
            {
                Console.WriteLine(fila_sudoku[i]);
            }
            Console.ReadLine();
        }
    }
    public class AllMethods
    {
        public static string[] lista_sudoku()
        {
            //var names = new List<List<int>>();
            string[] fila_sudoku = new string[9];
            for (int i=0; i<=8; i++)
            {
                fila_sudoku[i]= Console.ReadLine();
            }
            
            //names.Add(new List<int> { 5, 6, 3, 2, 1, 9, 8, 4, 7 });
            //names.Add(new List<int> { 7, 1, 8, 4, 5, 3, 9, 2, 6 });
            //names.Add(new List<int> { 2, 9, 4, 6, 7, 8, 3, 1, 5 });
            //names.Add(new List<int> { 1, 2, 5, 7, 9, 6, 4, 3, 8 });
            //names.Add(new List<int> { 6, 8, 7, 3, 4, 2, 1, 5, 9 });
            //names.Add(new List<int> { 3, 4, 9, 1, 8, 5, 7, 6, 2 });
            //names.Add(new List<int> { 4, 5, 1, 8, 2, 7, 6, 9, 3 });
            //names.Add(new List<int> { 9, 7, 6, 5, 3, 1, 2, 8, 4 });
            //names.Add(new List<int> { 8, 3, 2, 9, 6, 4, 5, 7, 1 });

            

            return fila_sudoku;

        }
        /*public static void revisar_sudoku(string fila_sudoku)
        {
            int num1 = 0;
            int num2 = 0;
            //Revisar vertical
            for (int i = 0; i <= 8; i++)
            {
                for (int i2 = i+1; i2 <= 8; i2++)
                {
                    num1 = names[i2][i];
                    for (int i3=i2+1; i3<=8; i3++)
                    {

                    }
                    if (num1 == num2)
                    {
                        Console.WriteLine("False");
                    }

                }
            }


        }*/
    }
}

