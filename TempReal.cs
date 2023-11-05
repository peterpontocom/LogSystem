using System;
using System.IO;
using System.Text;
using System.Linq;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;
using System;
using System.Net;
using System.Net.Mail;
using System.Threading;
using System.ComponentModel;

class TempReal : Email
{
    public string linha;
    public int info = 0;
    public int warning = 0;
    public int error = 0;
    public int debug = 0;


    public void LogMonitor()
    {
        Console.WriteLine("Digite seu email");
        string destinario = Console.ReadLine();
        while(destinario == "" || !destinario.Contains("@")) 
        {   
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Email inválido! Tente novamente!");
            Console.ResetColor();
            destinario = Console.ReadLine();
        }
        Console.WriteLine("Importe o arquivo que deseja monitorar");
        string nomedoarquivo = Console.ReadLine();

        string logFilePath = nomedoarquivo;

        if(!logFilePath.Contains(".log")) 
        {
            logFilePath += ".log";
        }

        

        while (!File.Exists(logFilePath))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("O arquivo de log não foi encontrado.");
            Console.ResetColor();
            Console.WriteLine("Digite novamente");
            nomedoarquivo = Console.ReadLine();
            logFilePath = nomedoarquivo;
            Console.WriteLine(logFilePath);
            if(!logFilePath.Contains(".log")) 
            {
                logFilePath += ".log";
            }
        }
        Console.Clear();
        Console.WriteLine("Monitorando seus logs...");
        using (FileStream fileStream = new FileStream(logFilePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
        using (StreamReader streamReader = new StreamReader(fileStream))
        {
            streamReader.BaseStream.Seek(0, SeekOrigin.End);

            while (true)
            {
                linha = streamReader.ReadLine();
                if (linha != null)
                {
                    if (linha.Contains("INFO"))
                    {
                        info++;
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write(linha + "\n");
                        Console.ResetColor();
                    }
                    else if (linha.Contains("WARNING"))
                    {
                        warning++;
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write(linha + "\n");
                        Console.ResetColor();
                    }
                    else if (linha.Contains("ERROR"))
                    {
                        error++;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(linha + "\n");
                        Console.ResetColor();
                    }
                    else if (linha.Contains("DEBUG"))
                    {
                        debug++;
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(linha + "\n");
                        Console.ResetColor();
                    }
                    if (error == 1)
                    {
                        Console.WriteLine($"Erro crítico. Enviando email...");
                        EnviarEmail(destinario, "error");
                        error = 0;
                    }

                    if (warning == 20)
                    {
                        Console.WriteLine($"Já foram 20 avisos. Enviando email...");
                        EnviarEmail(destinario, "warning");
                        warning = 0;
                    }
                    if (debug == 12)
                    {
                        Console.WriteLine($"Já foram 12 avisos de debug. Enviando email...");
                        EnviarEmail(destinario, "degug");
                        debug = 0;
                    }
                    if (info == 15)
                    {
                        Console.WriteLine($"Já foram 15 informações. Enviando email...");
                        EnviarEmail(destinario, "info");
                        info = 0;
                    }
                }
                else
                {
                    System.Threading.Thread.Sleep(1000);
                }
            }
        }
        
    }

}
