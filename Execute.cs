using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Diagnostics;

class Execute : TempReal
{
     GraphicReal graphic = new GraphicReal();
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
                case 2:
                    Console.Clear();
                    graphic.graphicreal();
                    break;
            }
        }
}