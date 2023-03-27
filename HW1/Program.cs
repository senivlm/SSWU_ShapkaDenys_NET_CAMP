using System.Security.Cryptography.X509Certificates;

namespace HW1
{
    internal class Program
    {
        

        static void Main(string[] args)
        {
            Console.WriteLine("Натисьнiть цифру яка вiдповiдає завданню: 1-2");
            int a= int.Parse(Console.ReadLine());            
            switch (a)
            {
                case 1:

                    Console.WriteLine("Введiть вишину масиву");
                    int height = int.Parse(Console.ReadLine());
                    Console.WriteLine("Введiть довжинуо масиву");
                    int width = int.Parse(Console.ReadLine());
                    int[,] snail = new int[height, width];
                    int[] en = new int[height * width];
                    int num = 1;
                    int rez = 0;
                    int side = 1;
                    if (height < width)
                    {
                        int gump = height;
                        for (int i = 0; i < height; i++)
                        {
                            for (int j = 0; j < gump; j++)
                            {
                                rez = rez + (1 * side);
                                en[rez - 1] = num;
                                num++;

                            }
                            for (int j = 0; j < gump; j++)
                            {

                                en[rez + (height * side) - 1] = num;
                                num++;
                                rez = rez + (height * side);
                            }
                            gump--;
                            side = side * -1;
                        }
                        int n = 0;
                        for (int x = 0; x < width; x++)
                        {
                            for (int y = 0; y < height; y++)
                            {
                                snail[y, x] = en[n];
                                n++;
                            }
                        }
                        Console.WriteLine();
                        for (int y = 0; y < height; y++)
                        {
                            for (int x = 0; x < width; x++)
                            {
                                Console.Write($"{snail[y, x]}; ");
                            }
                            Console.WriteLine();
                        }
                    }
                    if (width<height)
                    {        
                        int gump=width;
                        rez = -1;
                        for (int i = 0; i <3; i++)
                        {
                            for (int j = 0; j < height; j++)
                            {
                                rez = rez + (1 * side);
                                en[rez] = num;                                
                                num++;
                                
                            }
                            for (int j = 0; j < width-1; j++)
                            {
                                rez=rez+(1*side);
                                rez = rez + (gump*side);
                                en[rez] = num;                                
                                num++;                                
                            }
                            height--;
                            width--;
                            side = side * (-1);
                        }
                        int n=0;
                        for (int i = 0; i < en.Length; i++)
                        {
                            Console.Write($"{en[i]}; ");
                        }
                        
                    }
                    
                    break;
                case 2:

                    int[,] mas;
                    int rows, columns, colors = 16;
                    (int i, int j) maxStart = (-1, -1), maxEnd = (-1, -1), start = (-1, -1), pStart = (-1, -1), pEnd = (-1, -1);
                    bool result;
                    Random random = new Random();

                    do
                    {
                        Console.Write("Введiть кiлькiсть рядкiв: ");
                        result = int.TryParse(Console.ReadLine(), out rows);
                    } while (!result || rows <= 0);
                    do
                    {
                        Console.Write("Введiть кiлькiсть стовбцiв: ");
                        result = int.TryParse(Console.ReadLine(), out columns);
                    } while (!result || columns <= 0);

                    mas = new int[rows, columns];
                    for (int i = 0; i < rows; i++)
                    {
                        for (int j = 0; j < columns; j++)
                        {
                            mas[i, j] = random.Next(colors + 1);
                            Console.Write($"{mas[i, j]}; ");
                        }
                        Console.WriteLine();
                    }

                    for (int i = 0; i < rows; i++)
                    {
                        for (int j = 0; j < columns; j++)
                        {
                            if ((j == 0) || (j > 0 && mas[i, j] != mas[i, j - 1]))
                            {
                                pStart = j == 0 ? (-1, -1) : start;
                                pEnd = j == 0 ? (-1, -1) : (i, j - 1);
                                start = (i, j);
                            }
                            if ((j >= columns - 1) && mas[i, j] == mas[i, j - 1]) 
                            {
                                pStart = start;
                                pEnd = (i, j);
                            }
                            if ((maxEnd.j - maxStart.j + 1 < pEnd.j - pStart.j + 1) || (maxStart.j == -1 && pEnd.j != -1)) 
                            {
                                maxStart = pStart;
                                maxEnd = pEnd;
                            }
                        }
                    }
                    Console.WriteLine($"Найдовший рядок - колiр: {mas[maxStart.i, maxStart.j]}, з iндексами: [{maxStart.i}, {maxStart.j}] - [{maxEnd.i}, {maxEnd.j}], має довжину: {maxEnd.j - maxStart.j + 1}");
                    break;
            }



        }
    }
}