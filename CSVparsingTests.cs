using Microsoft.VisualStudio.TestTools.UnitTesting;
using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSVLibrary;

namespace Library.Tests
{
    [TestClass()]
    public class CSVparsingTests
    {
        [TestMethod()]
        public void Test()
        {
                using (var reader = new StreamReader(File.OpenRead(@"C:\Users\paco\Desktop\csv-main\document.csv")))
                {
                    if (CSVparsing.FileParsing(reader) == null)
                    {
                        Assert.Fail();
                    }
                }
        }   
    }
}