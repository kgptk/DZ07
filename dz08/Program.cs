using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hwStream
{
    internal class Program
    { //Объедините две предыдущих работы (практические работы 2 и 3):
      //поиск файла и поиск текста в файле написав утилиту которая ищет
      //файлы определенного расширения с указанным текстом. Рекурсивно.
      //Пример вызова утилиты: utility.exe txt текст.
        static void Main(string[] args)
        {
            //var filePuth = args[0];
            //var fileName = args[1];

            SomeMethod(@"D:\D\01", ".txt");
            Console.ReadKey();

        }

        static void SomeMethod(string directory, string fileExtension)
        {
            var dirs = Directory.EnumerateDirectories(directory);
            var files = Directory.EnumerateFiles(directory);

            foreach ( var file in files)

            {
                string[] fileName = file.Split('.');

                if (file.Contains(fileName[0]+fileExtension)) 
                {
                    Console.WriteLine($"Файл {file} c расширением {fileExtension} находится в директории {directory}");
                    SearchStringInFiles(directory, "hello");
                    break;
                }
            }

            foreach ( var dir in dirs)
            {
                SomeMethod(dir, fileExtension);
            }
        }

        static void SearchStringInFiles(string puch, string stringSearch)
        {
            try
            {
                using (FileStream fs = new FileStream(puch, FileMode.OpenOrCreate))
                {
                    using (BufferedStream bs = new BufferedStream(fs))
                    {
                        byte[] bytes = new Byte[fs.Length];
                        bs.Read(bytes, 0, bytes.Length);
                        string date = Encoding.UTF8.GetString(bytes);
                        //Console.WriteLine(date);
                        if (date.Contains(stringSearch))
                        {
                            Console.WriteLine(date);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            //if (!File.Exists(directory))
            //{
            //    Console.WriteLine("Директория не существует!");
            //}

            //using (StreamReader sr = new StreamReader(directory))
            //{
            //    while (!sr.EndOfStream) 
            //    { 
            //        var line = sr.ReadLine();
            //        Console.WriteLine(line);
            //        if (line.Contains(stringSearch))
            //        {
            //            Console.WriteLine(line);
            //        }
            //    }
            //}
        }
    }
}
