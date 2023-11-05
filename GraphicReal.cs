public class GraphicReal
{
    public void graphicreal()
    {
        
        TempReal temp = new TempReal();

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
                temp.linha = streamReader.ReadLine();
                if (temp.linha != null)
                {
                    if (temp.linha.Contains("INFO"))
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        temp.info++;
                        Console.WriteLine("Info: " + barra(temp.info));
                        Console.ResetColor();

                    }
                    else if (temp.linha.Contains("WARNING"))
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        temp.warning++;
                        Console.WriteLine("Warning: " + barra(temp.warning));
                        Console.ResetColor();
                    }
                    else if (temp.linha.Contains("ERROR"))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        temp.error++;
                        Console.WriteLine("Error: " + barra(temp.error));
                        Console.ResetColor();
                    }
                    else if (temp.linha.Contains("DEBUG"))
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        temp.debug++;
                        Console.WriteLine("Debug: " + barra(temp.debug));
                        Console.ResetColor();
                    }
                }
                else
                {
                    System.Threading.Thread.Sleep(1000);
                }
            }
        }
    }
    public string barra(int count)
    {
        return new string('█', count);
    }
}