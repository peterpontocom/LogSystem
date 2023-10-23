using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Diagnostics;

class Execute : TempReal
{
    Graphic graphic = new Graphic();
     public void ExecutaTarefaSelecionada(int posicao)
        {
            switch (posicao)
            {
                case 0:
                    Console.Clear();
                    Console.WriteLine("Importe o arquivo");
                     string arquivolido = Console.ReadLine();
                     Leitor l = new Leitor();
                     l.ler(arquivolido);
                    break;
                case 1:
                    Console.Clear();
                    LogMonitor();
                    break;
            }
        }
}