using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace SortingWithVisualizer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] visualizerSize = { 29, 120 }; // rows and columns of console

            Random rnd = new Random();
            int[] arr = new int[visualizerSize[1]];
            int temp = 0;

            for (int x = 0; x < arr.Length; x++)
                arr[x] = rnd.Next(visualizerSize[0]) + 1;

            // this line just sets the window size to always display in a 
            // 120 * 30 characters in size
            Console.SetWindowSize(visualizerSize[1], visualizerSize[0] + 1);

            #region Visualizing initial display
            for (int a = visualizerSize[0]; a > 0; a--) // dictate number of rows
            {
                for (int b = 0; b < arr.Length; b++) // dictate number of columns
                {
                    if (arr[b] >= a)
                        Console.Write("*");
                    else
                        Console.Write(" ");
                }
            }
            Console.Write("To be sorted using bubble sort... Press any key to begin...");
            Console.ReadKey();
            //Console.Clear(); 
            #endregion

            for (int x = 0; x < arr.Length; x++)
            {
                for (int y = 0; y < arr.Length - 1; y++)
                {
                    
                    #region Visualizing Column Selection
                    for (int a = visualizerSize[0]; a > 0; a--) // dictate number of rows
                    {
                        for (int b = y; b <= y+1; b++) // dictate number of columns
                        {
                            // set cursor position is a targeted way of changing what is in the console.
                            // think of the console as a big 2d array
                            // b, a - 1 are the coordinates as to where it will change
                            // since it is tied to a for loop, it will change along with the loop
                            // this way is much faster than clearing and rebuilding the display
                            Console.SetCursorPosition(b, a - 1);
                            if (b == y)
                                Console.ForegroundColor = ConsoleColor.Red;
                            else if (b == y + 1)
                                Console.ForegroundColor = ConsoleColor.Blue;
                            else
                                Console.ResetColor();

                            if (arr[b] > visualizerSize[0] - a)
                                Console.Write("*");
                            else
                                Console.Write(" ");
                        }
                    }
                    Console.SetCursorPosition(0, 29);
                    Console.Write("Pass {0} : Thinking. . .                                               ", x);
                    //Console.ReadKey();
                    //Thread.Sleep(200);
                    //Console.Clear(); 
                    #endregion

                    if (arr[y] > arr[y + 1])
                    {
                        temp = arr[y];
                        arr[y] = arr[y + 1];
                        arr[y + 1] = temp;
                    }

                    #region Visualizing Swap display!
                    for (int a = visualizerSize[0]; a > 0; a--) // dictate number of rows
                    {
                        for (int b = y; b <= y+1; b++) // dictate number of columns
                        {
                            Console.SetCursorPosition(b, a - 1);
                            if (b == y || b == y + 1)
                                Console.ForegroundColor = ConsoleColor.Green;
                            else
                                Console.ResetColor();

                            if (arr[b] > visualizerSize[0] - a)
                                Console.Write("*");
                            else
                                Console.Write(" ");
                        }
                    }
                    Console.SetCursorPosition(0, 29);
                    Console.Write("Pass {0} : Swapping . . .                                             ", x);
                    //Console.ReadKey();
                    //Thread.Sleep(50);
                    //Console.Clear();
                    #endregion

                    #region Reset color
                    for (int a = visualizerSize[0]; a > 0; a--) // dictate number of rows
                    {
                        for (int b = y; b <= y + 1; b++) // dictate number of columns
                        {
                            Console.SetCursorPosition(b, a - 1);
                            Console.ResetColor();

                            if (arr[b] > visualizerSize[0] - a)
                                Console.Write("*");
                            else
                                Console.Write(" ");
                        }
                    }
                    Console.SetCursorPosition(0, 29);
                    Console.Write("Pass {0} : Resetting. . .                                             ", x);
                    //Console.ReadKey();
                    //Thread.Sleep(100);
                    //Console.Clear(); 
                    #endregion
                }
            }

            Console.SetCursorPosition(0, 29);
            Console.Write("Done!!!!!!!!!                                              ");
            Console.ReadKey();
        }
    }
}
