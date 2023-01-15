using System.Security.Cryptography.X509Certificates;
using tabuleiro;
using xadrez;

namespace ChessGame_console
{
    class Program
    {
        private static void Main(string[] args) //Programa Principal
        {
            try
            {
                Tabuleiro tab = new Tabuleiro(8, 8); //Criando o tabuleiro

                tab.ColocPeca(new Torre(Cor.Branca, tab), new Posicao(0, 2));
                tab.ColocPeca(new Rei(Cor.Preta, tab), new Posicao(2, 2));
                tab.ColocPeca(new Rainha(Cor.Preta, tab), new Posicao(6, 2));
                tab.ColocPeca(new Torre(Cor.Branca, tab), new Posicao(5, 3));
                Tela.printTab(tab);
            }
            catch (TabuleiroException e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadLine();
        }  
    }
}