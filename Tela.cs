using tabuleiro;
using xadrez;
namespace ChessGame_console
{
    class Tela //Configurando tela
    {
        public static void printPartida(PartidaXadrez part)//Imprimindo a partida de xadrez
        {
            Tela.printTab(part.Tab);
            Console.WriteLine();
            printPecasCapturadas(part);
            Console.WriteLine();
            Console.WriteLine("Turno: " + part.Turno);
            if (!part.Termina)
            {
                Console.WriteLine("Aguardando Jogada: " + part.JogadorAtual);
                if (part.Xeque)
                {
                    Console.WriteLine(part.JogadorAtual + " Está em XEQUE!" );
                }
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine(" XEQUEMATE! ");
                Console.WriteLine(" Vencedor: " + part.JogadorAtual);
                Console.WriteLine(" Pressione Qualquer tecla para encerrar! Obrigado por jogar :3");
            }
        }

        public static void printPecasCapturadas(PartidaXadrez part)//Imprimindo pecas capturadas
        {
            Console.WriteLine(" Peças Capturadas");
            Console.Write(" Brancas: ");
            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            printConjunto(part.PecaCapturada(Cor.Branca));
            Console.ForegroundColor = aux;
            Console.WriteLine();
            Console.Write(" Pretas: ");
            ConsoleColor aux2 = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            printConjunto(part.PecaCapturada(Cor.Preta));
            Console.ForegroundColor = aux2;
            Console.WriteLine();
        }

        public static void printConjunto(HashSet<Peca> conj)//Parte da impressão do conjunto
        {
            Console.Write("[");
            foreach (Peca x in conj)
            {
                Console.Write(x + " ");
            }
            Console.Write("]");
        }
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
            if (s.Length <= 2 && char.IsLetter(s[0]) && char.IsDigit(s[1])) {
                char coluna = s[0];
                int linha = int.Parse(s[1] + "");
                return new PosicaoXadrez(coluna, linha);
            }
            else
            {
                throw new TabuleiroException("Digite uma posição válida!")
;           }
        }
        public static void printPeca(Peca peca) //Função para colorir peças no Console
        {
            if (peca == null)
            {
                Console.Write("■ ");
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
