using System;
using System.IO;

namespace OOP_Task1
{
    class Program
    {
        static class Part1
        {
            public static void DoIt(string inputFilename, string outputFilename)
            {
                int answer = 0;
                try
                {
                    using (StreamReader reader = new StreamReader(inputFilename))
                    {
                        int current = 0;
                        while (!reader.EndOfStream)
                        {
                            if (Int32.TryParse(reader.ReadLine(), out current))
                            {
                                answer += current;
                            }
                            else
                            {
                                Console.WriteLine("Can not parse the file " + inputFilename);
                                return;
                            }
                        }
                    }

                    using (StreamWriter writer = new StreamWriter(outputFilename))
                    {
                        writer.WriteLine(answer);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Can not open or create the file");
                    Console.WriteLine(e.Message);
                }

                Console.WriteLine("done");
            }
        }

        static class Part2
        {
            public static void DoIt()
            {
                int count = 0;
                Console.Write("Enter the numbers count: ");
                if (Int32.TryParse(Console.ReadLine(), out count))
                {
                    if (count > -1)
                    {
                        long first = 0, second = 1;
                        if (count > 0 && count < 2)
                        {
                            Console.Write(first);
                        }
                        else if (count > 0 && count < 3)
                        {
                            Console.Write(first + " " + second);
                        }
                        else if (count > 0)
                        {
                            Console.Write(first + " " + second + " ");
                            for (int i = 2; i < count; ++i)
                            {
                                long current = first + second;
                                first = second;
                                second = current;
                                Console.Write(current + " ");
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Count can not be negative");
                        return;
                    }
                }
                else
                {
                    Console.WriteLine("Incorrect number");
                    return;
                }
            }
        }

        static class Part3
        {
            static int resolveRomanian(char c)
            {
                switch (c)
                {
                    case 'I':
                        return 1;
                    case 'V':
                        return 5;
                    case 'X':
                        return 10;
                    case 'L':
                        return 50;
                    case 'C':
                        return 100;
                    case 'D':
                        return 500;
                    case 'M':
                        return 1000;
                    default:
                        throw new Exception("Can not resolve Romanian char");
                    
                }
            }
            public static void DoIt()
            {   
                Console.Write("Enter Romanian number: ");
                string number = Console.ReadLine();
                int last = 0, answer = 0, curr;
                for (int i = 0; i < number.Length; ++i)
                {
                    try
                    {
                        curr = resolveRomanian(number[i]);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        return;
                    }

                    if (curr < last)
                    {
                        answer += last;
                        last = curr;
                    }
                    else if (curr > last)
                    {
                        if (last != 0)
                        {
                            answer += curr - last;
                            last = 0;
                        }
                        else
                        {
                            last = curr;
                        }
                    }
                    else
                    {
                        answer += last + curr;
                        last = 0;
                    }
                }
                answer += last;

                Console.WriteLine(answer);
            }
        }

        static void Main(string[] args)
        {
            int taskNumber;
            while (true)
            {
                Console.Write("Enter the number of task you want to check (0 - exit): ");
                if (Int32.TryParse(Console.ReadLine(), out taskNumber))
                {
                    switch (taskNumber)
                    {
                        case 0:
                            return;
                        case 1:
                            Part1.DoIt("input.txt", "output.txt");
                            break;
                        case 2:
                            Part2.DoIt();
                            break;
                        case 3:
                            Part3.DoIt();
                            break;
                        default:
                            Console.WriteLine("Incorrect task number");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Can not resolve the task number");
                }
            }
        }
    }
}
