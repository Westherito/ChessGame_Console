using tabuleiro;
using xadrez;

namespace ChessGame_console
{
    class Program
    {
        private static void Main(string[] args) //Programa Principal
        {
            PosicaoXadrez pos = new PosicaoXadrez('c', 4);

            Console.WriteLine(pos);

            Console.WriteLine(pos.convertPos());

            Console.ReadLine();
        }  
    }
}