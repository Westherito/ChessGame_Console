using tabuleiro;
namespace ChessGame_console
{
    class Tela
    {
        public static void printTab(Tabuleiro tab) //Configurando tela
        {
            for (int i = 0; i < tab.Linhas; i++)
            {
                for (int j = 0; j < tab.Colunas; j++)
                {
                    if (tab.peca(i,j) != null) {
                        Console.Write(tab.peca(i, j) + " ");
                    }
                    else
                    {
                        Console.Write("- ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
