public class CSVparsing
{
    public static void FileToString(StreamReader Reader, string[] FileContent)
    {
        int counter = 0;
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
                            words += line[i];
                            FileContent[counter] = words;
                            words = null;
                            counter++;
                            break;

                        }
                    }
                    break;
                }

            }
        }
    }
    public static void FileToList(List<Student> StudentList, string[] ArrayStudent)
    {
        for (int i = 0; i < ArrayStudent.Length; i += 3)
        {
            StudentList.Add(new Student(ArrayStudent[i], ArrayStudent[i + 1], ArrayStudent[i + 2]));
        }
        foreach (var Student in StudentList)
        {
            Console.WriteLine($"{Student.name} {Student.lastname} {Student.adres}");
        }
    }
}