using tabuleiro;
namespace xadrez
{
    class Peao : Peca
    {
        private PartidaXadrez Partida;
        public Peao(Cor cor, Tabuleiro tab, PartidaXadrez partida) : base(cor, tab)
        {
            Partida = partida;
        }

        public override string ToString()
        {
            return "P";
        }
        private bool checkMov(Posicao pos)//Checagem de movimento de uma peca na matrix para movimentação
        {
            Peca p = Tab.peca(pos);
            return p == null || p.Cor != Cor;
        }

        private bool checkPecaInimiga(Posicao pos)
        {
            Peca p = Tab.peca(pos);
            return Tab.peca(pos) != null && p.Cor != Cor;
        }

        private bool espacoLivre(Posicao pos)
        {
            return Tab.peca(pos) == null;
        }

        public override bool[,] MovPossiveis()//Função para checar os movimentos do rei em relação ao jogo
        {
            bool[,] mat = new bool[Tab.Linhas, Tab.Colunas];

            Posicao pos = new Posicao(0, 0);
            
            if (Cor == Cor.Branca)
            {
                //Movimento Peão branco
                //para cima
                pos.definirVarlores(Posicao.Linha - 1, Posicao.Coluna);
                if (Tab.PosValida(pos) && espacoLivre(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }
                //Caso a peça não se moveu, pode mover duas casas
                pos.definirVarlores(Posicao.Linha - 2, Posicao.Coluna);
                Posicao pos2 = new Posicao(Posicao.Linha - 1, Posicao.Coluna); 
                if (Tab.PosValida(pos2) && espacoLivre(pos2) && Tab.PosValida(pos) && espacoLivre(pos) && QteMov == 0)
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }
                //Cima/esquerda
                pos.definirVarlores(Posicao.Linha - 1, Posicao.Coluna - 1);
                if (Tab.PosValida(pos) && checkPecaInimiga(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }
                //Cima direita
                pos.definirVarlores(Posicao.Linha - 1, Posicao.Coluna + 1);
                if (Tab.PosValida(pos) && checkPecaInimiga(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }
                //#Jogadas Especiais: En Passant (Peão Branco)
                if (Posicao.Linha == 3)
                {
                    Posicao esquerda = new Posicao(Posicao.Linha, Posicao.Coluna - 1);
                    if (Tab.PosValida(esquerda) && checkPecaInimiga(esquerda) && Tab.peca(esquerda) == Partida.riscoEnPassant)
                    {
                        mat[esquerda.Linha - 1, esquerda.Coluna] = true;
                    }
                    Posicao direita = new Posicao(Posicao.Linha, Posicao.Coluna + 1);
                    if (Tab.PosValida(direita) && checkPecaInimiga(direita) && Tab.peca(direita) == Partida.riscoEnPassant)
                    {
                        mat[direita.Linha - 1, direita.Coluna] = true;
                    }
                }
            }
            else
            {
                //Movimento Peão preto
                //para baixo
                pos.definirVarlores(Posicao.Linha + 1, Posicao.Coluna);
                if (Tab.PosValida(pos) && espacoLivre(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }
                //Caso a peça não se moveu, pode mover duas casas
                pos.definirVarlores(Posicao.Linha + 2, Posicao.Coluna);
                Posicao pos2 = new Posicao(Posicao.Linha + 1, Posicao.Coluna);
                if (Tab.PosValida(pos) && espacoLivre(pos) && QteMov == 0)
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }
                //Baixo/esquerda
                pos.definirVarlores(Posicao.Linha + 1, Posicao.Coluna - 1);
                if (Tab.PosValida(pos) && checkPecaInimiga(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }
                //Baixo/direita
                pos.definirVarlores(Posicao.Linha + 1, Posicao.Coluna + 1);
                if (Tab.PosValida(pos) && checkPecaInimiga(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }
                //#Jogadas Especiais: En Passant (Peão preto)
                if (Posicao.Linha == 4)
                {
                    Posicao esquerda = new Posicao(Posicao.Linha, Posicao.Coluna - 1);
                    if (Tab.PosValida(esquerda) && checkPecaInimiga(esquerda) && Tab.peca(esquerda) == Partida.riscoEnPassant)
                    {
                        mat[esquerda.Linha + 1, esquerda.Coluna] = true;
                    }
                    Posicao direita = new Posicao(Posicao.Linha, Posicao.Coluna + 1);
                    if (Tab.PosValida(direita) && checkPecaInimiga(direita) && Tab.peca(direita) == Partida.riscoEnPassant)
                    {
                        mat[direita.Linha + 1, direita.Coluna] = true;
                    }
                }
            }
            return mat;
        }
    }
}
