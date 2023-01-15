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
                
                PartidaXadrez part = new PartidaXadrez();//Criando o tabuleiro
                while (!part.Termina)
                {
                    Console.Clear();
                    Tela.printTab(part.Tab);
                    Console.Write("Digite a posição origem (Letra/Número): ");
                    Posicao origem = Tela.LerPosXadrez().convertPos();
                    Console.Write("Agora, a de destino (Letra/Número): ");
                    Posicao destino = Tela.LerPosXadrez().convertPos();

                    part.executaMov(origem, destino);
                }
            }
            catch (TabuleiroException e)//Executando erro caso houver
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadLine();
        }  
    }
}