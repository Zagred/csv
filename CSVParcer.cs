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
        public static List<List<string>> FileParsing(StreamReader Reader)
        {
            int counter = 0, switcher = 0;
            string words = null;
            string[] fileArray = new string[99];
            List<List<string>> fileList = new List<List<string>>();
            while (!Reader.EndOfStream)
            {
                var line = Reader.ReadLine();
                for (int i = 0; i < line.Length; i++)
                {
                    words += line[i];

                    if (line[i] == ',')
                    {
                        words = words.Trim(',');
                        words = words.Trim(' ');
                        fileArray[counter] = words;
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
                                fileArray[counter] = words;
                                words = null;
                                counter++;
                                i = j;
                                break;

                            }

                        }
                    }
                }
            }

            for (int i = 0; i < fileArray.Length; i += 3)
            {
                fileList.Add(new List<string> { fileArray[i], fileArray[i + 1], fileArray[i + 2] });
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