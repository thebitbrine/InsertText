using System;
using System.Collections.Generic;

namespace InsertText
{
    class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();
            Console.WriteLine("Maximize your window and press any key...");
            Console.ReadKey();
            p.Run();
            Console.ReadKey();
        }

        public void Run()
        {
            Console.Clear();
            int Width = Console.WindowWidth - 1;
            char[] Array = GenSeq(' ', Width);
            string RawLine = string.Join("", Array);
            string Line = RawLine;
            for (int i = 1; i < Console.WindowHeight; i++)
            {
                Width = Console.WindowWidth - 1;
                Line = InsertText(Line, "@", i * 1);
                Line = InsertText(Line, "#", i * 2);
                Line = InsertText(Line, "^", i * 3);
                Line = InsertText(Line, "-", i * 4);
                Line = InsertText(Line, "·", i * 5);
                Console.WriteLine(Line);
                System.Threading.Thread.Sleep(50);
            }
        }

        public string InsertText(string Line, string Text, int PositionPercent)
        {
            int Index = 0;
            char[] LineArr = Line.ToCharArray();
            double Position = ((double)Line.Length / 100) * PositionPercent;
            for (int i = 0; i < Line.Length; i++)
            {
                if (i >= Position && Index < Text.Length)
                {
                    LineArr[i] = Text[Index];
                    Index++;
                }
            }
            return string.Join("", LineArr);
        }
        public char[] GenSeq(char Character, int Count)
        {
            List<char> Seq = new List<char>();
            for (int i = 0; i < Count; i++)
                Seq.Add(Character);
            return Seq.ToArray();
        }

    }
}
