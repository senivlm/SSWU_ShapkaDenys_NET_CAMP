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

                    Console.WriteLine("Введіть вишину масиву");
                    int height = int.Parse(Console.ReadLine());
                    Console.WriteLine("Введіть довжинуо масиву");
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
                    }
                    int n = 0;
                    for (int y = 0; y < width; y++)
                    {
                        for (int x = 0; x < height; x++)
                        {
                            snail[x, y] = en[n];
                            n++;
                        }
                        Console.WriteLine();
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
                    break;
                case 2:
                    
                    Random random = new Random();
                    int [,] m= new int[16, 16];
                    for (int i = 0; i < m.GetLength(0); i++)
                    {
                        for (int j = 0; j < m.GetLength(1); j++)
                        {
                            m[i, j] = random.Next(0, 17);
                        }
                    }
                    int rep = m[0,0];
                    int next = 0;
                    int nextf = 0;
                    int bor = 0;
                    int rf = 0;
                    int xend = 0;
                    int yend = 0;
                    for (int i = 0; i < m.GetLength(0); i++)
                    {
                        for (int j = 0; j < m.GetLength(1); j++)
                        {
                            if (rep == m[i,j])
                            {                                
                                next++;
                            }
                            else
                            {
                                if (next>=nextf)
                                {
                                    rf = m[i, j - 1];
                                    nextf = next;
                                    xend = j;
                                    yend = i;
                                }
                                next= 0;
                            }
                            bor++;
                        }
                        bor = 0;

                    }                    
                    Console.WriteLine($"Довжина: {nextf}, Колір: {rf}, кінцева координата Х: {xend}, кінцева координата Y:{yend}");

                    for (int i = 0; i < m.GetLength(0); i++)
                    {
                        for (int j = 0; j < m.GetLength(1); j++)
                        {
                            Console.Write($"{m[i,j]}; ");
                        }
                        Console.WriteLine();
                    }

                    break;
            }



        }
    }
}