using System;
using tabuleiro;
namespace xadrez
{
    class PartidaXadrez
    {
        public Tabuleiro Tab { get; set; }
        private int Turno;
        private Cor JogadorAtual;
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

        public void ColocarPecas() //Peças de xadrez e suas posições
        {
            Tab.ColocPeca(new Torre(Cor.Branca, Tab), new PosicaoXadrez('a',1).convertPos());
            Tab.ColocPeca(new Cavalo(Cor.Branca, Tab), new PosicaoXadrez('b', 1).convertPos());
            Tab.ColocPeca(new Bispo(Cor.Branca, Tab), new PosicaoXadrez('c', 1).convertPos());
            Tab.ColocPeca(new Rei(Cor.Branca, Tab), new PosicaoXadrez('d', 1).convertPos());
            Tab.ColocPeca(new Rainha(Cor.Branca, Tab), new PosicaoXadrez('e', 1).convertPos());
            Tab.ColocPeca(new Bispo(Cor.Branca, Tab), new PosicaoXadrez('f', 1).convertPos());
            Tab.ColocPeca(new Cavalo(Cor.Branca, Tab), new PosicaoXadrez('g', 1).convertPos());
            Tab.ColocPeca(new Torre(Cor.Branca, Tab), new PosicaoXadrez('h', 1).convertPos());
            Tab.ColocPeca(new Peao(Cor.Branca, Tab), new PosicaoXadrez('a', 2).convertPos());
            Tab.ColocPeca(new Peao(Cor.Branca, Tab), new PosicaoXadrez('b', 2).convertPos());
            Tab.ColocPeca(new Peao(Cor.Branca, Tab), new PosicaoXadrez('c', 2).convertPos());
            Tab.ColocPeca(new Peao(Cor.Branca, Tab), new PosicaoXadrez('d', 2).convertPos());
            Tab.ColocPeca(new Peao(Cor.Branca, Tab), new PosicaoXadrez('e', 2).convertPos());
            Tab.ColocPeca(new Peao(Cor.Branca, Tab), new PosicaoXadrez('f', 2).convertPos());
            Tab.ColocPeca(new Peao(Cor.Branca, Tab), new PosicaoXadrez('g', 2).convertPos());
            Tab.ColocPeca(new Peao(Cor.Branca, Tab), new PosicaoXadrez('h', 2).convertPos());

            Tab.ColocPeca(new Torre(Cor.Preta, Tab), new PosicaoXadrez('a', 8).convertPos());
            Tab.ColocPeca(new Cavalo(Cor.Preta, Tab), new PosicaoXadrez('b', 8).convertPos());
            Tab.ColocPeca(new Bispo(Cor.Preta, Tab), new PosicaoXadrez('c', 8).convertPos());
            Tab.ColocPeca(new Rei(Cor.Preta, Tab), new PosicaoXadrez('d', 8).convertPos());
            Tab.ColocPeca(new Rainha(Cor.Preta, Tab), new PosicaoXadrez('e', 8).convertPos());
            Tab.ColocPeca(new Bispo(Cor.Preta, Tab), new PosicaoXadrez('f', 8).convertPos());
            Tab.ColocPeca(new Cavalo(Cor.Preta, Tab), new PosicaoXadrez('g', 8).convertPos());
            Tab.ColocPeca(new Torre(Cor.Preta, Tab), new PosicaoXadrez('h', 8).convertPos());
            Tab.ColocPeca(new Peao(Cor.Preta, Tab), new PosicaoXadrez('a', 7).convertPos());
            Tab.ColocPeca(new Peao(Cor.Preta, Tab), new PosicaoXadrez('b', 7).convertPos());
            Tab.ColocPeca(new Peao(Cor.Preta, Tab), new PosicaoXadrez('c', 7).convertPos());
            Tab.ColocPeca(new Peao(Cor.Preta, Tab), new PosicaoXadrez('d', 7).convertPos());
            Tab.ColocPeca(new Peao(Cor.Preta, Tab), new PosicaoXadrez('e', 7).convertPos());
            Tab.ColocPeca(new Peao(Cor.Preta, Tab), new PosicaoXadrez('f', 7).convertPos());
            Tab.ColocPeca(new Peao(Cor.Preta, Tab), new PosicaoXadrez('g', 7).convertPos());
            Tab.ColocPeca(new Peao(Cor.Preta, Tab), new PosicaoXadrez('h', 7).convertPos());
        }
    }
}
