using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;
using System.Threading;
    public class Program
    {
        static void Main(string[] args)
        {
            string FilePath = @"C:\Users\ppandev\Desktop\paco\document.csv";
            StreamReader Reader=null;
            using(Reader = new StreamReader(File.OpenRead(FilePath))){

            string[] ArrayStudent = new string[99];
            List<Student> List=new List<Student>();
            List=CSVparsing.FileToList(Reader, ArrayStudent,List);
            foreach (var Student in List)
            {
                Console.WriteLine($"{Student.Name} {Student.Lastname} {Student.Adres}");
            }
        }
    }
    }
