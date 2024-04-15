using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

namespace fiteryomin
{
// даны два файла с отсортированными данными
// необходимо сформировать выходной файл, который является слиянием
// двух файлов, жанные в выходном файле тоже должны
// быть отсортированы, ограничения: нельзя считывать данные в промежуточные
// списки -> надо брать попеременно.

    class Program
    {
        static void Main() 
        {
            StreamReader fileA = new StreamReader("a.txt");
            StreamReader fileB = new StreamReader("b.txt");
            StreamWriter answer = new StreamWriter("answer.txt");
            answer.AutoFlush = true;

            bool hasA = false;
            int dataA = 0;

            bool hasB = false;
            int dataB = 0;

            while (fileA.Peek() >= 0 || fileB.Peek() >= 0)
            {
                if (!hasA && fileA.Peek() >= 0)
                {
                    dataA = int.Parse(fileA.ReadLine().Trim());
                    hasA = true;
                }
                if (!hasB && fileB.Peek() >= 0)
                {
                    dataB = int.Parse(fileB.ReadLine().Trim());
                    hasB = true;
                }

                if (hasA && !hasB)
                {
                    // нет во втором файле 
                    hasA = false;
                    answer.WriteLine(dataA);
                }
                else if (hasB && !hasA)
                {
                    // нет в первом файле 
                    hasB = false;
                    answer.WriteLine(dataB);
                }
                else if (hasA && hasB)
                {
                    if (dataA <= dataB)
                    {
                        hasA = false;
                        answer.WriteLine(dataA);
                    }
                    else 
                    {
                        hasB = false;
                        answer.WriteLine(dataB);
                    }
                }
            }

        }

    }

}
