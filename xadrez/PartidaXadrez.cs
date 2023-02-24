using System.Text;
using ChessGame_console.tabuleiro.Enum;
using tabuleiro;
namespace xadrez
{
    class PartidaXadrez
    {
        public Tabuleiro Tab { get; private set; } //Definindo tabuleiro
        public int Turno { get; private set; } //Definindo o turno
        public Cor JogadorAtual { get; private set; } //Definir jogador com base nas cores
        public bool Termina { get; private set; } //Definir o término do jogo
        public bool Xeque { get; private set; } //Definir o término do jogo
        private HashSet<Peca> Pecas; //Conjunto de peças do jogo
        private HashSet<Peca> PecasCapturadas; //Conjunto de peças capturadas
        public Peca riscoEnPassant { get; private set; }//Caso o peão se movimente a primeira vez, recebe essa variável
        public PartidaXadrez()//Otimizando o tabuleiro em um construtor
        {
            Tab = new Tabuleiro(8, 8);
            Turno = 1;
            JogadorAtual = Cor.Branca;
            Termina = false;
            Xeque = false;
            riscoEnPassant = null;
            Pecas = new HashSet<Peca>();
            PecasCapturadas = new HashSet<Peca>();
            ColocarPecas();
        }
        private Cor Adversario(Cor cor)//Verificando Adversário
        {
            if (cor == Cor.Branca)
            {
                return Cor.Preta;
            }
            else
            {
                return Cor.Branca;
            }
        }
        private Peca rei(Cor cor)//Verificando se existe Rei no jogo
        {
            foreach(Peca x in pecasEmJogo(cor))
            {
                if (x is Rei)
                {
                    return x;
                }
            }
            return null;
        }

        public bool verificarXeque(Cor cor)//Verificando Xeque
        {
            Peca R = rei(cor);
            if (R == null)
            {
                throw new TabuleiroException("Não existe Rei da Cor " + cor + " no jogo!");
            }
            foreach (Peca x in pecasEmJogo(Adversario(cor))) 
            {
                bool[,] mat = x.MovPossiveis();
                if (mat[R.Posicao.Linha,R.Posicao.Coluna]) 
                {
                    return true;
                }
            }
            return false;
        }

        public bool verificarXequemate(Cor cor)//Verificando Xequemate
        {
            if (!verificarXeque(cor))
            {
                return false;
            }

            foreach (Peca x in pecasEmJogo(cor))//Mapeando todas as peças do jogo em valores booleanos
            {
                bool[,] mat = x.MovPossiveis();
                for (int i = 0; i < Tab.Linhas; i++)
                {
                    for (int j = 0; j < Tab.Colunas; j++)
                    {
                        if (mat[i, j])
                        {
                            Posicao origem = x.Posicao;
                            Posicao destino = new Posicao(i, j);
                            Peca pecaCapt = executaMov(origem,destino);
                            bool testeXeque = verificarXeque(cor);
                            retornarMov(origem, destino, pecaCapt);
                            if (!testeXeque) 
                            {
                                return false;
                            }

                        }
                    }
                }
            }
            return true;
        }

        public Peca executaMov(Posicao origem,  Posicao destino)//Executar o movimento conforme o usuário digitar
        {
            Peca p = Tab.RetirPeca(origem);
            p.incremtQteMov();
            Peca pecaCapt = Tab.RetirPeca(destino);
            Tab.ColocPeca(p, destino);
            if(pecaCapt !=null)
            {
                PecasCapturadas.Add(pecaCapt);
            }

            //#Jogadas Especiais: Roque (Realizando Movimento)
            //#Jogadas Especiais: Roque pequeno
            if (p is Rei && destino.Coluna == origem.Coluna + 2)
            {
                Posicao origemT = new Posicao(origem.Linha, origem.Coluna + 3);
                Posicao destinoT = new Posicao(origem.Linha, origem.Coluna + 1);
                Peca T = Tab.RetirPeca(origemT);
                T.incremtQteMov();
                Tab.ColocPeca(T, destinoT);
            }
            //#Jogadas Especiais: Roque grande
            if (p is Rei && destino.Coluna == origem.Coluna - 2)
            {
                Posicao origemT = new Posicao(origem.Linha, origem.Coluna - 4);
                Posicao destinoT = new Posicao(origem.Linha, origem.Coluna - 1);
                Peca T = Tab.RetirPeca(origemT);
                T.incremtQteMov();
                Tab.ColocPeca(T, destinoT);
            }
            //#Jogadas Especiais: En Passant (Realizando Movimento)
            if (p is Peao)
            {
                if (origem.Coluna != destino.Coluna && pecaCapt == null) 
                {
                    Posicao posP;
                    if (p.Cor == Cor.Branca)
                    {
                        posP = new Posicao(destino.Linha + 1, destino.Coluna);
                        

                    }
                    else
                    {
                        posP = new Posicao(destino.Linha - 1, destino.Coluna);
                    }
                    pecaCapt = Tab.RetirPeca(posP);
                    PecasCapturadas.Add(pecaCapt);
                }
            }

            return pecaCapt;
        }
        public void realizaJogada(Posicao origem, Posicao destino)//Relizando a jogada
        {
            Peca pecaCapt = executaMov(origem, destino);
            if (verificarXeque(JogadorAtual))//Desfazendo jogada em caso de xeque
            {
                retornarMov(origem, destino, pecaCapt);
                throw new TabuleiroException("Você não pode se colocar em Xeque!");
            }
            Peca p = Tab.peca(destino);

            //#Jogada Especial: Promoção
            if (p is Peao)
            {
                if ((p.Cor == Cor.Branca && destino.Linha == 0) || (p.Cor == Cor.Preta && destino.Linha == 7))
                {
                    Console.WriteLine();
                    Console.WriteLine("Escolha Sua Peça para Substituir o Peão");
                    Console.WriteLine();
                    Console.Write("Escolha Entre: d (Dama), c (Cavalo), b (Bispo) ou t (Torre): ");
                    char opcao = char.Parse(Console.ReadLine());
                    escolherPeca(opcao, destino);
                    
                }
            }

            if (verificarXeque(Adversario(JogadorAtual)))//Verificando xeque
            {
                Xeque = true;
            }
            else
            {
                Xeque = false;
            }
            //Caso de xequemate, termina o jogo
            if (verificarXequemate(Adversario(JogadorAtual)))
            {
                Termina = true;
            }
            else
            {
                Turno++;
                mudaJogador();
            }
            //#Jogadas Especiais: En Passant
            if (p is Peao && (destino.Linha == origem.Linha - 2  || destino.Linha == origem.Linha + 2)) 
            {
                riscoEnPassant = p;
            }


        }
        public void escolherPeca(char opcao, Posicao destino)//#Jogada Especial: Promoção (Escolha de Peças)   
        {
            Peca p = Tab.peca(destino.Linha, destino.Coluna);
            p = Tab.RetirPeca(destino);
            Pecas.Remove(p);
            if (opcao == 'd')
            {
                Peca rainha = new Rainha(p.Cor, Tab);
                Tab.ColocPeca(rainha, destino);
                Pecas.Add(rainha);
            }
            else if (opcao == 't')
            {
                Peca torre = new Torre(p.Cor, Tab);
                Tab.ColocPeca(torre, destino);
                Pecas.Add(torre);
            }
            else if (opcao == 'b')
            {
                Peca bispo = new Bispo(p.Cor, Tab);
                Tab.ColocPeca(bispo, destino);
                Pecas.Add(bispo);
            }
            else if (opcao == 'c')
            {
                Peca cavalo = new Cavalo(p.Cor, Tab);
                Tab.ColocPeca(cavalo, destino);
                Pecas.Add(cavalo);
            }
            else
            {
                throw new TabuleiroException("Você não pode escolher outra peça ou ficar sem escolher!");
            }
        }
        public void validaPosOrigem(Posicao pos)//Erros em caso de escolhas feitas na origem
        {
            if(Tab.peca(pos) == null)
            {
                throw new TabuleiroException("Não existe peça na posição de origem escolhida!");
            }
            if (JogadorAtual != Tab.peca(pos).Cor)
            {
                throw new TabuleiroException("A peça de origem escolhida não é a sua!");
            }
            if (!Tab.peca(pos).existMovPos())
            {
                throw new TabuleiroException("Não há movimentos possíveis para a peça de origem escolhida!");
            }
        }
        public void retornarMov(Posicao origem, Posicao destino, Peca pecaCapt)//Refazendo movimento de peças
        {
            Peca p = Tab.RetirPeca(destino);
            p.decremtQteMov();
            if (pecaCapt != null)
            {
                Tab.ColocPeca(pecaCapt, destino);
                PecasCapturadas.Remove(pecaCapt);
            }
            Tab.ColocPeca(p, origem);

            // #Jogadas Especiais: Roque (Desfazendo Movimento)
            // #Jogadas Especiais: Roque Pequeno
            if (p is Rei && destino.Coluna == origem.Coluna + 2)
            {
                Posicao origemT = new Posicao(origem.Linha, origem.Coluna + 3);
                Posicao destinoT = new Posicao(origem.Linha, origem.Coluna + 1);
                Peca T = Tab.RetirPeca(destinoT);
                T.decremtQteMov();
                Tab.ColocPeca(T, origemT);
            }
            // #Jogadas Especiais: Roque Grande
            if (p is Rei && destino.Coluna == origem.Coluna - 2)
            {
                Posicao origemT = new Posicao(origem.Linha, origem.Coluna - 4);
                Posicao destinoT = new Posicao(origem.Linha, origem.Coluna - 1);
                Peca T = Tab.RetirPeca(destinoT);
                T.decremtQteMov();
                Tab.ColocPeca(T, origemT);
            }
            // #Jogadas Especiais: En Passant (Desfazendo Movimento)
            if (p is Peao)
            {
                if (origem.Coluna != destino.Coluna && pecaCapt == riscoEnPassant)
                {
                    Peca peao = Tab.RetirPeca(destino);
                    Posicao posP;
                    if (p.Cor == Cor.Branca)
                    {
                        posP = new Posicao (3, destino.Coluna);
                    }
                    else
                    {
                        posP = new Posicao(4, destino.Coluna);
                    }
                    Tab.ColocPeca(peao, posP);
                }
            }

        }

        public void validaPosDestino(Posicao origem, Posicao destino)//Erros em caso de escolhas feitas no destino
        {
            if (!Tab.peca(origem).podeMover(destino))
            {
                throw new TabuleiroException("Posição Inválida");
            }
        }
        private void mudaJogador() //Mudando o jogador que pode jogar no seu turno
        {
            if (JogadorAtual == Cor.Branca)
            {
                JogadorAtual = Cor.Preta;
            }
            else
            {
                JogadorAtual = Cor.Branca;
            }
        }
        public HashSet<Peca> PecaCapturada(Cor cor)//Capturando uma peca e adicionando em um conjunto
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca peca in PecasCapturadas) {
                if (peca.Cor == cor) {
                    aux.Add(peca);
                }
            }
            return aux;
        }
        public HashSet<Peca> pecasEmJogo(Cor cor)//Separando as peças ainda em jogo
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca peca in Pecas)
            {
                if (peca.Cor == cor)
                {
                    aux.Add(peca);
                }
            }
            aux.ExceptWith(PecaCapturada(cor));
            return aux;
        }
        public void colocarnovaPeca(char coluna, int linha, Peca peca) //Metodo otimizado de colocar peças
        {
            Tab.ColocPeca(peca, new PosicaoXadrez(coluna, linha).convertPos());
            Pecas.Add(peca);
        }
        public void ColocarPecas() //Criação das peças de xadrez e suas posições
        {
            //Peças do jogador 1
            colocarnovaPeca('a', 1, new Torre(Cor.Branca, Tab));
            colocarnovaPeca('b', 1, new Cavalo(Cor.Branca, Tab));
            colocarnovaPeca('c', 1, new Bispo(Cor.Branca, Tab));
            colocarnovaPeca('d', 1, new Rainha(Cor.Branca, Tab));
            colocarnovaPeca('e', 1, new Rei(Cor.Branca, Tab, this));
            colocarnovaPeca('h', 1, new Torre(Cor.Branca, Tab));
            colocarnovaPeca('g', 1, new Cavalo(Cor.Branca, Tab));
            colocarnovaPeca('f', 1, new Bispo(Cor.Branca, Tab));
            colocarnovaPeca('a', 2, new Peao(Cor.Branca, Tab, this));
            colocarnovaPeca('b', 2, new Peao(Cor.Branca, Tab, this));
            colocarnovaPeca('c', 2, new Peao(Cor.Branca, Tab, this));
            colocarnovaPeca('d', 2, new Peao(Cor.Branca, Tab, this));
            colocarnovaPeca('e', 2, new Peao(Cor.Branca, Tab, this));
            colocarnovaPeca('f', 2, new Peao(Cor.Branca, Tab, this));
            colocarnovaPeca('g', 2, new Peao(Cor.Branca, Tab, this));
            colocarnovaPeca('h', 2, new Peao(Cor.Branca, Tab, this));
            //Peças do jogador 2
            colocarnovaPeca('a', 8, new Torre(Cor.Preta, Tab));
            colocarnovaPeca('b', 8, new Cavalo(Cor.Preta, Tab));
            colocarnovaPeca('c', 8, new Bispo(Cor.Preta, Tab));
            colocarnovaPeca('d', 8, new Rainha(Cor.Preta, Tab));
            colocarnovaPeca('e', 8, new Rei(Cor.Preta, Tab, this));
            colocarnovaPeca('h', 8, new Torre(Cor.Preta, Tab));
            colocarnovaPeca('g', 8, new Cavalo(Cor.Preta, Tab));
            colocarnovaPeca('f', 8, new Bispo(Cor.Preta, Tab));
            colocarnovaPeca('a', 7, new Peao(Cor.Preta, Tab, this));
            colocarnovaPeca('b', 7, new Peao(Cor.Preta, Tab, this));
            colocarnovaPeca('c', 7, new Peao(Cor.Preta, Tab, this));
            colocarnovaPeca('d', 7, new Peao(Cor.Preta, Tab, this));
            colocarnovaPeca('e', 7, new Peao(Cor.Preta, Tab, this));
            colocarnovaPeca('f', 7, new Peao(Cor.Preta, Tab, this));
            colocarnovaPeca('g', 7, new Peao(Cor.Preta, Tab, this));
            colocarnovaPeca('h', 7, new Peao(Cor.Preta, Tab, this));
        }
        public override string ToString() //Imprimindo a tela de Início
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("  _______  __   __  _______  _______  _______    _______  _______  __   __  _______ ");
            sb.AppendLine(" |      _||  | |  ||       ||       ||       |  |       ||   _   ||  |_|  ||       |");
            sb.AppendLine(" |     |  |  |_|  ||    ___||  _____||  _____|  |    ___||  | |  ||       ||    ___|");
            sb.AppendLine(" |     |  |       ||   |___ | |_____ | |_____   |   | __ |  | |  || || || ||   |___ ");
            sb.AppendLine(" |     |  |   _   ||    ___||_____  ||_____  |  |   ||  ||  |_|  || || || ||    ___|");
            sb.AppendLine(" |     |_ |  | |  ||   |___  _____| | _____| |  |   |_| ||   _   || ||_|| ||   |___ ");
            sb.AppendLine(" |_______||__| |__||_______||_______||_______|  |_______||__| |__||_|   |_||_______|");
            sb.AppendLine();
            sb.AppendLine("                              Rodando em CONSOLE :D");
            sb.AppendLine("                                  By: Westherito");
            sb.AppendLine();
            sb.AppendLine(" COMO JOGAR: Para movimentar as Peças, digite as coordenadas para selecionar a peça ");
            sb.AppendLine(" e depois para direcionar o destino da peça.");
            sb.AppendLine();
            sb.AppendLine("         Exemplo: Um peão está na casa A3, neste caso:");
            sb.AppendLine("         Sua ORIGEM será: A3");
            sb.AppendLine("         E seu DESTINO será: A4");
            sb.AppendLine();
            sb.AppendLine("         OBS: Este jogo contém as seguintes JOGADAS ESPECIAS:");
            sb.AppendLine("         - En Passant");
            sb.AppendLine("         - Promoção");
            sb.AppendLine("         - Roque Pequeno e Grande");
            sb.AppendLine();
            sb.AppendLine("                          Pressione QUALQUER TECLA para continuar...");

            return sb.ToString();

        }
    }
}
