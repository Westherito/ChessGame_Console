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
                Console.Title = "CHESS GAME";
                PartidaXadrez part = new PartidaXadrez();//Criando o tabuleiro
                Console.WriteLine(part.ToString());//Titulo do jogo
                Console.WriteLine();              
                Console.ReadKey();
                Console.Clear();
                while (!part.Termina)
                {
                    try
                    {
                        Console.Clear();
                        Tela.printPartida(part);//Imprimindo partida
                        Console.WriteLine();
                        Console.Write(" Digite a posição origem (Letra/Número): ");
                        Posicao origem = Tela.LerPosXadrez().convertPos();//Leitura e conversão de posição da peça para seleção
                        part.validaPosOrigem(origem);

                        bool[,] PosPossiveis = part.Tab.peca(origem).MovPossiveis();//Matriz booleana de movimentos possiveis
                        Console.Clear();
                        Tela.printTab(part.Tab, PosPossiveis);//Imprimindo partida com movimentos possíveis
                        
                        Console.WriteLine();
                        Console.Write(" Agora, a de destino (Letra/Número): ");
                        Posicao destino = Tela.LerPosXadrez().convertPos();//Leitura e conversão de posição da peça selecionada
                        part.validaPosDestino(origem,destino);

                        part.realizaJogada(origem, destino);//Realizando Jogada
                    }
                    catch(TabuleiroException e)//Detectando erro no jogo e Lançando Exceção
                    {
                        Console.WriteLine();
                        Console.WriteLine(" Erro: " + e.Message);
                        Console.WriteLine();
                        Console.WriteLine(" Pressione Qualquer Tecla para continuar...");
                        Console.ReadKey();
                    }
                }
                Console.Clear();
                Tela.printPartida(part);//Imprimindo resultado das ações em partida
            }
            catch (TabuleiroException e)//Detectando erro no programa e Lançando Exceção
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadKey();
        }  
    }
}