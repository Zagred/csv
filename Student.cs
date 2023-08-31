using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;
using System.Threading;
public  class Student{
    public string Name{get;set;}
    public string Lastname{get;set;}
    public string Adres{get;set;}
    public Student(string name, string lastname, string adres)
    {
        Name = name;
        Lastname = lastname;
        Adres = adres;
    }
}