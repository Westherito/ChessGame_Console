using System;
using tabuleiro;
namespace xadrez
{
    class PartidaXadrez
    {
        public Tabuleiro Tab { get; private set; }
        public int Turno { get; private set; }
        public Cor JogadorAtual { get; private set; }
        public bool Termina { get; private set; } //Para terminar o jogo

        public PartidaXadrez()//Otimizar o tabuleiro em um construtor
        {
            Tab = new Tabuleiro(8, 8);
            Turno = 1;
            JogadorAtual = Cor.Branca;
            ColocarPecas();
        }

        public void executaMov(Posicao origem,  Posicao destino)//executar o movimento conforme o usuário digitar
        {
            Peca p = Tab.RetirPeca(origem);
            p.incremtQteMov();
            Peca PecaCapt = Tab.RetirPeca(destino);
            Tab.ColocPeca(p, destino);
        }
        public void realizaJogada(Posicao origem, Posicao destino)//Incrementar a passagem de turno e mudança de jogador
        {
            executaMov(origem, destino);
            Turno++;
            mudaJogador();

        }
        public void validaPosOrigem(Posicao pos)//erros em caso de escolhas feitas na origem
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
        public void validaPosDestino(Posicao origem, Posicao destino)//erros em caso de escolhas feitas na origem
        {
            if (!Tab.peca(origem).podeMover(destino))
            {
                throw new TabuleiroException("Posição Inválida");
            }
        }
        private void mudaJogador()
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
        public void ColocarPecas() //Peças de xadrez e suas posições
        {
            //Peças do jogador 1
            Tab.ColocPeca(new Torre(Cor.Branca, Tab), new PosicaoXadrez('a',1).convertPos());
            //Tab.ColocPeca(new Cavalo(Cor.Branca, Tab), new PosicaoXadrez('b', 1).convertPos());
            //Tab.ColocPeca(new Bispo(Cor.Branca, Tab), new PosicaoXadrez('c', 1).convertPos());
            Tab.ColocPeca(new Rei(Cor.Branca, Tab), new PosicaoXadrez('d', 1).convertPos());
            //Tab.ColocPeca(new Rainha(Cor.Branca, Tab), new PosicaoXadrez('e', 1).convertPos());
            //Tab.ColocPeca(new Bispo(Cor.Branca, Tab), new PosicaoXadrez('f', 1).convertPos());
            //Tab.ColocPeca(new Cavalo(Cor.Branca, Tab), new PosicaoXadrez('g', 1).convertPos());
            Tab.ColocPeca(new Torre(Cor.Branca, Tab), new PosicaoXadrez('h', 1).convertPos());
            /*Tab.ColocPeca(new Peao(Cor.Branca, Tab), new PosicaoXadrez('a', 2).convertPos());
            Tab.ColocPeca(new Peao(Cor.Branca, Tab), new PosicaoXadrez('b', 2).convertPos());
            Tab.ColocPeca(new Peao(Cor.Branca, Tab), new PosicaoXadrez('c', 2).convertPos());
            Tab.ColocPeca(new Peao(Cor.Branca, Tab), new PosicaoXadrez('d', 2).convertPos());
            Tab.ColocPeca(new Peao(Cor.Branca, Tab), new PosicaoXadrez('e', 2).convertPos());
            Tab.ColocPeca(new Peao(Cor.Branca, Tab), new PosicaoXadrez('f', 2).convertPos());
            Tab.ColocPeca(new Peao(Cor.Branca, Tab), new PosicaoXadrez('g', 2).convertPos());
            Tab.ColocPeca(new Peao(Cor.Branca, Tab), new PosicaoXadrez('h', 2).convertPos());*/

            //Peças do jogador 2
            Tab.ColocPeca(new Torre(Cor.Preta, Tab), new PosicaoXadrez('a', 8).convertPos());
            //Tab.ColocPeca(new Cavalo(Cor.Preta, Tab), new PosicaoXadrez('b', 8).convertPos());
            //Tab.ColocPeca(new Bispo(Cor.Preta, Tab), new PosicaoXadrez('c', 8).convertPos());
            Tab.ColocPeca(new Rei(Cor.Preta, Tab), new PosicaoXadrez('d', 8).convertPos());
            //Tab.ColocPeca(new Rainha(Cor.Preta, Tab), new PosicaoXadrez('e', 8).convertPos());
            //Tab.ColocPeca(new Bispo(Cor.Preta, Tab), new PosicaoXadrez('f', 8).convertPos());
            //Tab.ColocPeca(new Cavalo(Cor.Preta, Tab), new PosicaoXadrez('g', 8).convertPos());
            Tab.ColocPeca(new Torre(Cor.Preta, Tab), new PosicaoXadrez('h', 8).convertPos());
            /*Tab.ColocPeca(new Peao(Cor.Preta, Tab), new PosicaoXadrez('a', 7).convertPos());
            Tab.ColocPeca(new Peao(Cor.Preta, Tab), new PosicaoXadrez('b', 7).convertPos());
            Tab.ColocPeca(new Peao(Cor.Preta, Tab), new PosicaoXadrez('c', 7).convertPos());
            Tab.ColocPeca(new Peao(Cor.Preta, Tab), new PosicaoXadrez('d', 7).convertPos());
            Tab.ColocPeca(new Peao(Cor.Preta, Tab), new PosicaoXadrez('e', 7).convertPos());
            Tab.ColocPeca(new Peao(Cor.Preta, Tab), new PosicaoXadrez('f', 7).convertPos());
            Tab.ColocPeca(new Peao(Cor.Preta, Tab), new PosicaoXadrez('g', 7).convertPos());
            Tab.ColocPeca(new Peao(Cor.Preta, Tab), new PosicaoXadrez('h', 7).convertPos());*/
        }
    }
}
