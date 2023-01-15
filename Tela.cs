using System;
using tabuleiro;
namespace ChessGame_console
{
    class Tela
    {
        public static void printTab(Tabuleiro tab) //Configurando tela
        {
            for (int i = 0; i < tab.Linhas; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < tab.Colunas; j++)
                {
                    if (tab.peca(i,j) == null) {
                        Console.Write(tab.peca(i, j));
                        Console.Write("- ");
                    }
                    else
                    {
                        Tela.printPeca(tab.peca(i,j)); //Imprimir peca conforme a cor dele
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }
        public static void printPeca(Peca peca) //Função para colorir peças no Console
        {
            if (peca.Cor == Cor.Branca)
            {
                Console.Write(peca);
            }
            else
            {
                ConsoleColor aux = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(peca);
                Console.ForegroundColor = aux;
            }
        }
    }
}
