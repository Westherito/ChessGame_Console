using tabuleiro;
namespace xadrez
{
    class Cavalo : Peca
    {
        public Cavalo(Cor cor, Tabuleiro tab) : base(cor, tab)
        {

        }

        public override string ToString()
        {
            return "C";
        }
        private bool checkMov(Posicao pos)//Checagem de movimento de uma peca na matrix para movimentação
        {
            Peca p = Tab.peca(pos);
            return p == null || p.Cor != Cor;
        }
        public override bool[,] MovPossiveis()//Função para checar os movimentos do rei em relação ao jogo
        {
            bool[,] mat = new bool[Tab.Linhas, Tab.Colunas];

            Posicao pos = new Posicao(0, 0);

            
            pos.definirVarlores(Posicao.Linha - 1, Posicao.Coluna - 2);
            if (Tab.PosValida(pos) && checkMov(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            
            pos.definirVarlores(Posicao.Linha - 1, Posicao.Coluna + 2);
            if (Tab.PosValida(pos) && checkMov(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            
            pos.definirVarlores(Posicao.Linha - 2, Posicao.Coluna - 1);
            if (Tab.PosValida(pos) && checkMov(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            
            pos.definirVarlores(Posicao.Linha - 2, Posicao.Coluna + 1);
            if (Tab.PosValida(pos) && checkMov(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            pos.definirVarlores(Posicao.Linha + 1, Posicao.Coluna - 2);
            if (Tab.PosValida(pos) && checkMov(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            pos.definirVarlores(Posicao.Linha + 1, Posicao.Coluna + 2);
            if (Tab.PosValida(pos) && checkMov(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            pos.definirVarlores(Posicao.Linha + 2, Posicao.Coluna - 1);
            if (Tab.PosValida(pos) && checkMov(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            pos.definirVarlores(Posicao.Linha + 2, Posicao.Coluna + 1);
            if (Tab.PosValida(pos) && checkMov(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            return mat;
        }
    }
}
