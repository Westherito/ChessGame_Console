using tabuleiro;
using xadrex;

namespace ChessGame_console
{
    class Program
    {
        private static void Main(string[] args) //Programa Principal
        {
            try
            {
                Tabuleiro tab = new Tabuleiro(8, 8);

                tab.ColocPeca(new Torre(Cor.Branca, tab), new Posicao(0, 0));
                tab.ColocPeca(new Rei(Cor.Verde, tab), new Posicao(8, 2));
                tab.ColocPeca(new Rainha(Cor.Laranja, tab), new Posicao(3, 3));
                Tela.printTab(tab);



                Console.ReadLine();

            }
            catch (TabuleiroException e)
            {
                Console.WriteLine(e.Message);
                
            }
            Console.ReadLine();
        }

        
    }
}