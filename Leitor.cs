using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Drawing;

class Leitor : Creator
{
    public string TodosLogs = "";
    
    public void ler(string arquivo) 
    {
        string arquivoLog = arquivo+".log";
        try 
        {
           using (StreamReader arquivoLido = new StreamReader(arquivoLog)){
            while(!arquivoLido.EndOfStream) 
            {
                string linha = arquivoLido.ReadLine();
                string[] colunas = linha.Split(',');
                    foreach(string coluna in colunas)
                    {
                        if(linha.Contains("INFO")) 
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.Write(coluna + "\t");
                            Console.ResetColor();

                        }
                        else if(linha.Contains("WARNING")) 
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write(coluna + "\t");
                            Console.ResetColor();
                        }
                        else if(linha.Contains("ERROR")) {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write(coluna + "\t");
                            Console.ResetColor();
                        }
                        else if(linha.Contains("DEBUG")) {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write(coluna + "\t");
                            Console.ResetColor();
                        }
                        else {
                            Console.Write(coluna + "\t");
                        }
                            TodosLogs += coluna + "\t";
                    }
                    Console.WriteLine();
            }
                        CriarArquivoTemporario(TodosLogs);

        }
    }
    catch (IOException e) 
    {
        Console.WriteLine("Erro detectado: " + e.Message);
    }   
    }
}