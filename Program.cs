using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;
using System.Threading;
using Library;
public class Program
{
        static void Main(string[] args)
        {
            string FilePath = @"C:\Users\paco\Desktop\csv-main\document.csv";
            StreamReader Reader=null;
            using(Reader = new StreamReader(File.OpenRead(FilePath))){
            string[] ArrayStudent = new string[99];
            List<Student> List=new List<Student>();
            List=CSVparsing.FileToList(Reader, ArrayStudent,List);
            CSVparsing.ListPrint(List);
            
        }
    }
}
