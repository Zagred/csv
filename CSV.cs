using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;
using System.Threading;

namespace Library
{
    public class CSVparsing
    {
        public static List<Student> FileToList(StreamReader Reader, string[] FileContent, List<Student> StudentList)
        {
            int counter = 0,countersecond=0;
            string words = null;
            while (!Reader.EndOfStream)
            {
                var line = Reader.ReadLine();
                string[] split = new string[line.Length];
                for (int i = 0; i < line.Length; i++)
                {
                    words += line[i];

                    if (line[i] == ',')
                    {
                        words = words.Trim(',');
                        words = words.Trim(' ');
                        FileContent[counter] = words;
                        counter++;
                        words = null;
                    }
                    else if (line[i] == '"')
                    {
                        for (int j = i+1; j < line.Length; j++)
                        {
                            if (line[j] != '"')
                            {
                                words += line[j];
                            }
                            else
                            {
                                words += line[j];
                                FileContent[counter] = words;
                                words = null;
                                counter++;
                                countersecond = j;
                                break;

                            }

                        }
                       i=countersecond;
                    }
                }
            }
            
            for (int i = 0; i < FileContent.Length; i += 3)
            {
                StudentList.Add(new Student(FileContent[i], FileContent[i + 1], FileContent[i + 2]));
            }
            return StudentList;
        }
        public static void ListPrint(List<Student> StudentList)
        {
            foreach (var Student in StudentList)
            {
                Console.WriteLine($"{Student.Name} {Student.Lastname} {Student.Adres}");
            }
        }
    }
}