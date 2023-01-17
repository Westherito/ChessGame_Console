using System;
using tabuleiro;
using xadrez;
namespace ChessGame_console
{
    class Tela //Configurando tela
    {
        public static void printTab(Tabuleiro tab) //Imprimindo tabuleiro com as peças
        {
            for (int i = 0; i < tab.Linhas; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < tab.Colunas; j++)
                {               
                    printPeca(tab.peca(i,j)); //Imprimir peca conforme a cor dele ou caso for nulo
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }

        public static void printTab(Tabuleiro tab, bool[,] posPossiveis) //Imprimindo tabuleiro com as peças
        {
            ConsoleColor bg = Console.BackgroundColor;
            ConsoleColor bgAlt = ConsoleColor.DarkGray;
            for (int i = 0; i < tab.Linhas; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < tab.Colunas; j++)
                {
                    if (posPossiveis[i, j] == true)
                    {
                        Console.BackgroundColor = bgAlt;
                    }
                    else
                    {
                        Console.BackgroundColor = bg;
                    }
                    
                    printPeca(tab.peca(i, j)); //Imprimir peca conforme a cor dele ou caso for nulo
                    Console.BackgroundColor = bg;
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
            Console.BackgroundColor = bg;
        }
        public static PosicaoXadrez LerPosXadrez()//Fazendo leitura das peças no tabuleiro
        {
            string s = Console.ReadLine();
            char coluna = s[0];
            int linha = int.Parse(s[1] + "");
            return new PosicaoXadrez(coluna, linha);
        }
        public static void printPeca(Peca peca) //Função para colorir peças no Console
        {
            if (peca == null)
            {
                Console.Write("- ");
            }
            else
            {
                if (peca.Cor == Cor.Branca)
                {
                    ConsoleColor aux = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(peca);
                    Console.ForegroundColor = aux;
                    Console.Write(" ");
                }
                else
                {
                    ConsoleColor aux = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(peca);
                    Console.ForegroundColor = aux;
                    Console.Write(" ");
                }
            }
        }
    }
}
