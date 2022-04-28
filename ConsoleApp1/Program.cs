using System;

namespace ConsoleApp1
{
    class Window
    {
        int x, y;
        int Height, Width;
        string Title;
        string Text;
        public void Print(bool IsActive)
        {
            int text_x = 0, text_y = 0;

            for (int i = x; i < x + Width; ++i)
            {
                for (int j = y; j < y + Height; ++j)
                {
                    if (x < 0 || x >= Console.WindowWidth || y < 0 || y >= Console.WindowHeight) return;
                    else
                    {
                        Console.SetCursorPosition(i, j);
                        if ((i == x && j == y) || (i == x + Width - 1 && j == y + Height - 1) || 
                            (i == x && j == y + Height - 1) || (i == x + Width - 1 && j == y) || 
                            (i == x && j == y + 2) || (i == x + Width - 1 && j == y + 2))
                            Console.Write("+");

                        else if (i == x || i == x + Width - 1)
                            Console.Write("|");
                        else if (j == y || j == y + Height - 1 || j == y + 2)
                            Console.Write("-");

                        else if (i == x + Width - 2 && j == y + 1)
                            Console.Write("X");
                        
                        else if (i == x + 1 && j == y + 1)
                        {
                            if (IsActive) Console.Write("(A)" + Title);
                            else Console.Write("(N)" + Title);
                        }

                        //Текст
                        /*
                        else if (i == x + 1 + text_x && j == y + 3 + text_y)
                        {
                            if (text_x < Width - 2)
                            {
                                text_x++;
                            }
                            if (text_x >= 10)
                            {
                                Console.Write(text_y);
                                text_y++;
                                text_x = 0;
                            }
                        }*/
                        

                        //Координаты
                        else if (i == x + 1 && j == y + 3)
                            Console.Write(x);
                        else if (i == x + 5 && j == y + 3)
                            Console.Write(y);

                        //else
                        //Console.Write(" ");
                    }
                   
                }
            }

        }

        public void Handle(ConsoleKey CurrentKey)
        {
            //Перемещение
            if (CurrentKey == ConsoleKey.UpArrow)
            {
                Console.Clear();
                if (x > 0)
                    y--;
            }
            if (CurrentKey == ConsoleKey.DownArrow)
            {
                Console.Clear();
                if (y + Height < Console.WindowHeight - 1)
                    y++;
            }
            if (CurrentKey == ConsoleKey.LeftArrow)
            {
                Console.Clear();
                if (x > 0)
                    x--;
            }
            if (CurrentKey == ConsoleKey.RightArrow)
            {
                Console.Clear();
                if (x + Width < Console.WindowWidth - 1)
                    x++;
            }

            //Изменение размера
            if (CurrentKey == ConsoleKey.P)
            {
                Console.Clear();
                if (x + Width < Console.WindowWidth - 1 && y + Height < Console.WindowHeight - 1)
                {
                    Width++;
                    Height++;
                }
            }
            //не доделано
            if (CurrentKey == ConsoleKey.O)
            {
                Console.Clear();
                if (x + Width < Console.WindowWidth - 1 && y + Height < Console.WindowHeight - 1)
                {
                    Width--;
                    Height--;
                }
            }
        }
        public Window(int x, int y, int Height, int Width, string Name, int Seed)
        {
            this.x = x; this.y = y;
            this.Height = Height; this.Width = Width;
            this.Title = Name;
            Text = "EEWVVWWWBdiposicoskdvsvpowoebjewvbjpoewvjpo";
        }
    } 
    public class Program
    {
        static void Main()
        {
            List<Window> Windows = new List<Window>();
            int CurrentWindowIndex = -1;

            while (true)
            {
                ConsoleKey CurrentKey = Console.ReadKey().Key;

                if (CurrentKey == ConsoleKey.N)
                {
                    Window NewWindow = new Window(Windows.Count * 2, Windows.Count * 2, 20, 30, "Window" + (Windows.Count).ToString(), 
                        Windows.Count * 17);

                    Windows.Add(NewWindow);
                    CurrentWindowIndex = Windows.Count - 1;
                }
                else if (CurrentKey == ConsoleKey.E && Windows.Count > 1)
                {
                    Windows.RemoveAt(Windows.Count - 1);
                    CurrentWindowIndex--;
                }
                else if (CurrentKey == ConsoleKey.Tab)
                {
                    if (CurrentWindowIndex < Windows.Count) CurrentWindowIndex++;
                    if (CurrentWindowIndex == Windows.Count) CurrentWindowIndex = 0;

                    /*
                    Window T = Windows[CurrentWindowIndex];
                    Windows[CurrentWindowIndex] = Windows[Windows.Count - 1];
                    Windows[Windows.Count - 1] = T;
                    */
                }

                //Обновление
                if (Windows.Count != 0)
                {
                    Windows[CurrentWindowIndex].Handle(CurrentKey);
                    for (int i = 0; i < Windows.Count; ++i)
                    {
                        Windows[i].Print(CurrentWindowIndex == i);
                    }
                }
            }
        }
    }
}