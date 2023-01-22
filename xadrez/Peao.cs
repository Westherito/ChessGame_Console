using tabuleiro;

namespace xadrez
{
    class Peao : Peca
    {
        public Peao(Cor cor, Tabuleiro tab) : base(cor, tab)
        {

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
                pos.definirVarlores(Posicao.Linha - 1, Posicao.Coluna);
                if (Tab.PosValida(pos) && espacoLivre(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }
                pos.definirVarlores(Posicao.Linha - 2, Posicao.Coluna);
                if (Tab.PosValida(pos) && espacoLivre(pos) && QteMov == 0)
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }
                pos.definirVarlores(Posicao.Linha - 1, Posicao.Coluna - 1);
                if (Tab.PosValida(pos) && checkPecaInimiga(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }
                pos.definirVarlores(Posicao.Linha - 1, Posicao.Coluna + 1);
                if (Tab.PosValida(pos) && checkPecaInimiga(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }
            }
            else
            {
                pos.definirVarlores(Posicao.Linha + 1, Posicao.Coluna);
                if (Tab.PosValida(pos) && espacoLivre(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }
                pos.definirVarlores(Posicao.Linha + 2, Posicao.Coluna);
                if (Tab.PosValida(pos) && espacoLivre(pos) && QteMov == 0)
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }
                pos.definirVarlores(Posicao.Linha + 1, Posicao.Coluna - 1);
                if (Tab.PosValida(pos) && checkPecaInimiga(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }
                pos.definirVarlores(Posicao.Linha + 1, Posicao.Coluna + 1);
                if (Tab.PosValida(pos) && checkPecaInimiga(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }
            }
            return mat;
        }
    }
}
