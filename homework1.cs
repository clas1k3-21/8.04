using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            WriteToFile("C:\\Users\\Игорь\\source\\repos\\ConsoleApp6\\bin\\Debug\\text.txt", "Привет, мир!123");
            string text = ReadFromFile("C:\\Users\\Игорь\\source\\repos\\ConsoleApp6\\bin\\Debug\\text.txt");
            Console.WriteLine(text);
            CopyFile("C:\\Users\\Игорь\\source\\repos\\ConsoleApp6\\bin\\Debug\\text.txt", "C:\\Users\\Игорь\\source\\repos\\ConsoleApp6\\bin\\Debug\\text2.txt");
            string text2 = ReadFromFile("C:\\Users\\Игорь\\source\\repos\\ConsoleApp6\\bin\\Debug\\text2.txt");
            Console.WriteLine(text2);
        }
        static void WriteToFile(string filePath, string message)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(message);
            using (FileStream fs = new FileStream(filePath, FileMode.Create))
            { 
                fs.Write(bytes, 0, bytes.Length);
            }
        }

        static string ReadFromFile(string filePath)
        {
            using (FileStream fs = new FileStream(filePath, FileMode.Open))
            {
                byte[] bytes = new byte[fs.Length];
                fs.Read(bytes, 0, bytes.Length);
                return Encoding.UTF8.GetString(bytes);
            }
        }
        static void CopyFile(string sourcePath, string destinationPath)
        {
            using (FileStream sourceStream = new FileStream(sourcePath, FileMode.Open))
            {
                using (FileStream destStream = new FileStream(destinationPath, FileMode.Create))
                {
                    byte[] buffer = new byte[1024];
                    int bytesRead;
                    while ((bytesRead = sourceStream.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        destStream.Write(buffer, 0, bytesRead);
                    }
                }
            }
        }
    }
}
