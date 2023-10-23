using System;
using System.IO;

class Creator
{
    string arquivoTemporario = "temp/info.log";
    public void CriarArquivoTemporario(string informacoes) 
    {

        try 
        {
            using (StreamWriter sw = File.AppendText(arquivoTemporario)) 
            {
                sw.WriteLine(informacoes);
            }
        }
        catch(IOException e) 
        {
            Console.WriteLine("Error: " + e.Message);
        }

    }

}