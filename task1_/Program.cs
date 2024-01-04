using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Security.Policy;
using System.IO;

namespace task1_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Random rnd = new Random();
            // int i = rnd.Next(1, 3);

            // string x = i.ToString();

            Console.WriteLine("Введите число файла, который хотите скачать:");
            Console.WriteLine("1 - пьеса 'Гамлет'");
            Console.WriteLine("2 - стих 'Белеет парус одинокий...'");
            Console.WriteLine("3 - видео с котиками");

            Console.WriteLine("Ввод:");

            string x = Console.ReadLine();
            // Console.WriteLine($"{x}");

            // Используется сайт https://www.file.io/ как сервер для скачивания файла. После 1-го скачивания повторное скачивание по одной ссылке не работает! 
            switch (x)
            {
                case "1":
                    Download("https://file.io/ud7f5mwyqwM5", "gamlet.txt");
                    break;

                case "2":
                    Download("https://file.io/K3K0xjoQLaBD", "parus.txt");
                    break;

                case "3":
                    Download("https://file.io/SkxSHsxboyD3", "kotiks.mp4");
                    break;

                case "":
                    Console.WriteLine("Файла с таким кодом не существует!");
                    break;

                default:
                    Console.WriteLine("Некорректный ввод");
                    break;
            }
        }

        static void Download(string url, string filename)
        {
            using (WebClient webClient = new WebClient())
            {
                // string currentDirectory = Directory.GetCurrentDirectory();
                string currentDirectory = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Downloads";
                string filePath = Path.Combine(currentDirectory, filename);

                webClient.DownloadFile(url, filePath);
            }
            Console.WriteLine("Скачано!");
        }

    }
}
