using tabuleiro;
using xadrez;

namespace ChessGame_console
{
    class Program
    {
        private static void Main(string[] args) //Programa Principal
        {
            try //Testando programa em caso de erros
            {
                
                PartidaXadrez part = new PartidaXadrez();//Criando o tabuleiro
                while (!part.Termina)
                {
                    try
                    {
                        Console.Clear();
                        Tela.printPartida(part);
                        Console.WriteLine();
                        Console.Write("Digite a posição origem (Letra/Número): ");
                        Posicao origem = Tela.LerPosXadrez().convertPos();
                        part.validaPosOrigem(origem);

                        bool[,] PosPossiveis = part.Tab.peca(origem).MovPossiveis();

                        Console.Clear();
                        Tela.printTab(part.Tab, PosPossiveis);

                        Console.WriteLine();
                        Console.Write("Agora, a de destino (Letra/Número): ");
                        Posicao destino = Tela.LerPosXadrez().convertPos();
                        part.validaPosDestino(origem,destino);
                        part.realizaJogada(origem, destino);
                    }
                    catch(TabuleiroException e)//Executando erro dentro da partida
                    {
                        Console.WriteLine();
                        Console.WriteLine("Erro: " + e.Message);
                        Console.WriteLine();
                        Console.WriteLine("Pressione Enter para continuar...");
                        Console.ReadLine();
                    }
                }
                Console.Clear();
                Tela.printPartida(part);
            }
            catch (TabuleiroException e)//Executando erro caso houver
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadLine();
        }  
    }
}