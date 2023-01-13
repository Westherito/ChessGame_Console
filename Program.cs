using tabuleiro;
using System;
namespace ChessGame_console
{
    class Program
    {
        private static void Main(string[] args) //Programa Principal
        {
            Tabuleiro tab = new Tabuleiro(8, 8);

            Tela.printTab(tab);

            Console.ReadLine();

            
        }

        
    }
}