using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;
using System.Threading;

namespace ConsoleApp1
{
    public class student
    {
        public string name;
        public string lastname;
        public string adres;
        public student(string name, string lastname, string adres)
        {
            this.name = name;
            this.lastname = lastname;
            this.adres = adres;
        }

        public class main
        {
            static void Main(string[] args)
            {
                string filePath = @"C:\Users\paco\Desktop\Document.csv";
                StreamReader reader = null;
                reader = new StreamReader(File.OpenRead(filePath));
                List<student> list_student = new List<student>();
                int counter = 0;
                string[] array_student = new string[99];
                string words = null;
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    string[] split = new string[line.Length];
                    for (int i = 0; i < line.Length; i++)
                    {
                        words += line[i];

                        if (line[i] == ',')
                        {
                            words = words.Trim(',');
                            array_student[counter] = words;
                            counter++;
                            words = null;
                        }
                        else if (line[i] == '"')
                        {
                            for (int j = i + 1; j < line.Length; j++)
                            {
                                if (line[j] != '"')
                                {
                                    words += line[j];
                                }
                                else
                                {
                                    words += line[i];
                                    array_student[counter] = words;
                                    words = null;
                                    counter++;

                                }
                            }
                            break;
                        }

                    }
                }

                for (int i = 0; i < array_student.Length; i+=3)
                {
                    list_student.Add(new student(array_student[i], array_student[i+1], array_student[i + 2])); 
                }
                foreach (var student in list_student)
                {
                    Console.WriteLine($"{student.name} {student.lastname} {student.adres}");
                }


            }
        }
    }
}
