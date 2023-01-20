
using System.Collections.Generic;
using System.Security.Cryptography;
using tabuleiro;
namespace xadrez
{
    class PartidaXadrez
    {
        public Tabuleiro Tab { get; private set; } 
        public int Turno { get; private set; } //Definindo o turno
        public Cor JogadorAtual { get; private set; } //Definir jogador com base nas cores
        public bool Termina { get; private set; } //Definir o término do jogo
        public bool Xeque { get; private set; } //Definir o término do jogo
        private HashSet<Peca> Pecas;
        private HashSet<Peca> PecasCapturadas;

        public PartidaXadrez()//Otimizar o tabuleiro em um construtor
        {
            Tab = new Tabuleiro(8, 8);
            Turno = 1;
            JogadorAtual = Cor.Branca;
            Termina = false;
            Xeque = false;
            Pecas = new HashSet<Peca>();
            PecasCapturadas= new HashSet<Peca>();
            ColocarPecas();
        }
        private Cor Adversario(Cor cor)
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
        private Peca rei(Cor cor)
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

        public bool verificarXeque(Cor cor)
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

        public bool verificarXequemate(Cor cor)
        {
            if (!verificarXeque(cor))
            {
                return false;
            }

            foreach (Peca x in pecasEmJogo(cor))
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

        public Peca executaMov(Posicao origem,  Posicao destino)//executar o movimento conforme o usuário digitar
        {
            Peca p = Tab.RetirPeca(origem);
            p.incremtQteMov();
            Peca PecaCapt = Tab.RetirPeca(destino);
            Tab.ColocPeca(p, destino);
            if(PecaCapt !=null)
            {
                PecasCapturadas.Add(PecaCapt);
            }
            return PecaCapt;
        }
        public void realizaJogada(Posicao origem, Posicao destino)//Relizando a jogada
        {
            Peca pecaCapt = executaMov(origem, destino);
            if (verificarXeque(JogadorAtual))//Desfazendo jogada em caso de xeque
            {
                retornarMov(origem, destino, pecaCapt);
                throw new TabuleiroException("Você não pode se colocar em Xeque!");
            }
            if (verificarXeque(Adversario(JogadorAtual)))
            {
                Xeque = true;
            }
            else
            {
                Xeque = false;
            }
            //caso de xequemate, termina o jogo
            if (verificarXequemate(Adversario(JogadorAtual)))
            {
                Termina = true;
            }
            else
            {
                Turno++;
                mudaJogador();
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
        public void retornarMov(Posicao origem, Posicao destino, Peca pecaCapt)
        {
            Peca p = Tab.RetirPeca(destino);
            p.decremtQteMov();
            if (pecaCapt != null)
            {
                Tab.ColocPeca(pecaCapt, destino);
                PecasCapturadas.Remove(pecaCapt);
            }
            Tab.ColocPeca(p, origem);
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
            colocarnovaPeca('b', 1, new Torre(Cor.Preta, Tab));
            colocarnovaPeca('a', 1, new Rei(Cor.Preta, Tab));
            colocarnovaPeca('c', 2, new Torre(Cor.Branca, Tab));
            colocarnovaPeca('b', 8, new Torre(Cor.Branca, Tab));
            colocarnovaPeca('c', 8, new Rei(Cor.Branca, Tab));
            //Peças do jogador 1
            /*colocarnovaPeca('a', 1, new Torre(Cor.Branca, Tab));
            colocarnovaPeca('b', 1, new Cavalo(Cor.Branca, Tab));
            colocarnovaPeca('c', 1, new Bispo(Cor.Branca, Tab));
            colocarnovaPeca('d', 1, new Rei(Cor.Branca, Tab));
            colocarnovaPeca('e', 1, new Rainha(Cor.Branca, Tab));
            colocarnovaPeca('h', 1, new Torre(Cor.Branca, Tab));
            colocarnovaPeca('g', 1, new Cavalo(Cor.Branca, Tab));
            colocarnovaPeca('f', 1, new Bispo(Cor.Branca, Tab));
            colocarnovaPeca('a', 2, new Peao(Cor.Branca, Tab));
            colocarnovaPeca('b', 2, new Peao(Cor.Branca, Tab));
            colocarnovaPeca('c', 2, new Peao(Cor.Branca, Tab));
            colocarnovaPeca('d', 2, new Peao(Cor.Branca, Tab));
            colocarnovaPeca('e', 2, new Peao(Cor.Branca, Tab));
            colocarnovaPeca('f', 2, new Peao(Cor.Branca, Tab));
            colocarnovaPeca('g', 2, new Peao(Cor.Branca, Tab));
            colocarnovaPeca('h', 2, new Peao(Cor.Branca, Tab));

            //Peças do jogador 2
            colocarnovaPeca('a', 8, new Torre(Cor.Preta, Tab));
            colocarnovaPeca('b', 8, new Cavalo(Cor.Preta, Tab));
            colocarnovaPeca('c', 8, new Bispo(Cor.Preta, Tab));
            colocarnovaPeca('d', 8, new Rei(Cor.Preta, Tab));
            colocarnovaPeca('e', 8, new Rainha(Cor.Preta, Tab));
            colocarnovaPeca('h', 8, new Torre(Cor.Preta, Tab));
            colocarnovaPeca('g', 8, new Cavalo(Cor.Preta, Tab));
            colocarnovaPeca('f', 8, new Bispo(Cor.Preta, Tab));
            colocarnovaPeca('a', 7, new Peao(Cor.Preta, Tab));
            colocarnovaPeca('b', 7, new Peao(Cor.Preta, Tab));
            colocarnovaPeca('c', 7, new Peao(Cor.Preta, Tab));
            colocarnovaPeca('d', 7, new Peao(Cor.Preta, Tab));
            colocarnovaPeca('e', 7, new Peao(Cor.Preta, Tab));
            colocarnovaPeca('f', 7, new Peao(Cor.Preta, Tab));
            colocarnovaPeca('g', 7, new Peao(Cor.Preta, Tab));
            colocarnovaPeca('h', 7, new Peao(Cor.Preta, Tab));*/
        }
    }
}
