using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Diagnostics;

namespace ConsoleApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Execute ex = new Execute();
            List<string> opcoes = new List<string>
            {
                "Ler e Armazenar meus Logs",
                "Ler meus arquivos log em tempo real",
            };

            int posicaoSelecionada = 0;
            bool ver = true;
            while (ver)
            {
                Console.Clear();
                Console.WriteLine("Insira a tarefa que deseja executar");

                for (int i = 0; i < opcoes.Count; i++) 
                {
                    if (i == posicaoSelecionada)
                    {
                        Console.Write("-> ");
                    }
                    else
                    {
                        Console.Write("   "); 
                    }

                    Console.WriteLine(opcoes[i]);
                }

                ConsoleKeyInfo keyInfo = Console.ReadKey();
                switch (keyInfo.Key)
                {
                    case ConsoleKey.UpArrow:
                        posicaoSelecionada = Math.Max(0, posicaoSelecionada - 1);
                        break;
                    case ConsoleKey.DownArrow:
                        posicaoSelecionada = Math.Min(opcoes.Count - 1, posicaoSelecionada + 1);
                        break;
                    case ConsoleKey.Enter:
                        ex.ExecutaTarefaSelecionada(posicaoSelecionada);
                        ver = false;
                        break;
                }
            }
        }

        
    }
}