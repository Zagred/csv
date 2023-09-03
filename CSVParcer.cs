using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;
using System.Threading;

namespace CSVLibrary
{
    public static class CSVparsing
    {
        public static List<List<string>> FileToList(StreamReader Reader)
        {
            int counter = 0, countersecond = 0;
            string words = null;
            string[] FileContent = new string[99];
            List<List<string>> fileList = new List<List<string>>();
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
                        for (int j = i + 1; j < line.Length; j++)
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
                        i = countersecond;
                    }
                }
            }

            for (int i = 0; i < FileContent.Length; i += 3)
            {
                fileList.Add(new List<string> { FileContent[i], FileContent[i + 1], FileContent[i + 2] });
            }
            return fileList;
        }
        public static void ListPrint(List<List<string>> fileList)
        {
            for (int i = 0; i < fileList.Count; i++)
            {
                for (int j = 0; j < fileList[i].Count; j++)
                {
                    Console.Write($"{fileList[i][j]} ");
                }
                Console.WriteLine();
            }
        }
    }
}