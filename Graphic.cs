using System;
using System.IO;
using System.Collections.Generic;

class Graphic : TempReal
{
    private int warningCount = 0;
    private int infoCount = 0;
    private int errorCount = 0;
    private int debugCount = 0;
    private List<string> graphLines = new List<string>();

    
    public void ProcessarLog()
    {
        LogMonitor();

        if (linha.Contains("INFO"))
        {
            infoCount++;
        }
        else if (linha.Contains("WARNING"))
        {
            warningCount++;
        }
        else if (linha.Contains("ERROR"))
        {
            errorCount++;
        }
        else if (linha.Contains("DEBUG"))
        {
            debugCount++;
        }

        AtualizarGraficoEmTempoReal();
    }

    private void AtualizarGraficoEmTempoReal()
    {
        Console.Clear();
        Console.WriteLine("Gráfico em Tempo Real:");
        AdicionarBarra("INFO", infoCount);
        AdicionarBarra("WARNING", warningCount);
        AdicionarBarra("ERROR", errorCount);
        AdicionarBarra("DEBUG", debugCount);

        foreach (var line in graphLines)
        {
            Console.WriteLine(line);
        }
    }

    private void AdicionarBarra(string label, int count)
    {
        string bar = GetBar(count);
        string line = $"{label.PadRight(10)}: {bar}";
        if (graphLines.Count <= count)
        {
            graphLines.Add(line);
        }
        else
        {
            graphLines[count] = line;
        }
    }

    private string GetBar(int count)
    {
        return new string('█', count);
    }
}
