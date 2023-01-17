using tabuleiro;

namespace xadrez
{
    internal class Rainha : Peca
    {
        public Rainha(Cor cor, Tabuleiro tab) : base(cor, tab)
        {

        }

        public override string ToString()
        {
            return "D";
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

            //Cima
            pos.definirVarlores(Posicao.Linha - 1, Posicao.Coluna);
            if (Tab.PosValida(pos) && checkMov(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            //Cima direita
            pos.definirVarlores(Posicao.Linha - 1, Posicao.Coluna + 1);
            if (Tab.PosValida(pos) && checkMov(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            //Direita
            pos.definirVarlores(Posicao.Linha, Posicao.Coluna + 1);
            if (Tab.PosValida(pos) && checkMov(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            //Baixo Direita
            pos.definirVarlores(Posicao.Linha + 1, Posicao.Coluna + 1);
            if (Tab.PosValida(pos) && checkMov(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            //Baixo
            pos.definirVarlores(Posicao.Linha + 1, Posicao.Coluna);
            if (Tab.PosValida(pos) && checkMov(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            //Baixo Esquerda
            pos.definirVarlores(Posicao.Linha + 1, Posicao.Coluna - 1);
            if (Tab.PosValida(pos) && checkMov(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            //Esquerda
            pos.definirVarlores(Posicao.Linha, Posicao.Coluna - 1);
            if (Tab.PosValida(pos) && checkMov(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            //Esquerda Cima
            pos.definirVarlores(Posicao.Linha - 1, Posicao.Coluna - 1);
            if (Tab.PosValida(pos) && checkMov(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            return mat;
        }
    }
}
