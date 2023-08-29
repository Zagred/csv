using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;
using System.Threading;

namespace paco{
    public  class student
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
    }
    public class main
    {

        public static void from_file_to_list(List<student> student_list, string[] array_student)
        {
            for (int i = 0; i < array_student.Length; i += 3)
            {
                student_list.Add(new student(array_student[i], array_student[i + 1], array_student[i + 2]));
            }
            foreach (var student in student_list)
            {
                Console.WriteLine($"{student.name} {student.lastname} {student.adres}");
            }
        }

        public static void file_to_string(StreamReader reader, string filePath, string []file_content)
        {
            int counter = 0;
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
                        file_content[counter]=words;
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
                                file_content[counter] = words;
                                words = null;
                                counter++;

                            }
                        }
                        break;
                    }

                }
            }
        }
        static void Main(string[] args)
        {
            string filePath = @"C:\Users\ppandev\Desktop\Document.txt";
            StreamReader reader=null;
            using(reader = new StreamReader(File.OpenRead(filePath))){

            string[] array_student = new string[99];
            List<student> list=new List<student>();

            file_to_string(reader, filePath, array_student);
            
            from_file_to_list(list, array_student);}
        }
    }
}