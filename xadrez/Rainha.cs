using ChessGame_console.tabuleiro.Enum;
using tabuleiro;
namespace xadrez
{
    internal class Rainha : Peca
    {
        public Rainha(Cor cor, Tabuleiro tab) : base(cor, tab)//A peça receberá estes atributos
        {

        }

        public override string ToString()//Figura da Peça
        {
            return "D";
        }
        private bool checkMov(Posicao pos)//Checagem de movimento de uma peca na matrix para movimentação
        {
            Peca p = Tab.peca(pos);
            return p == null || p.Cor != Cor;
        }
        public override bool[,] MovPossiveis()//Função para checar os movimentos da Rainha/Dama em relação ao jogo
        {
            bool[,] mat = new bool[Tab.Linhas, Tab.Colunas];

            Posicao pos = new Posicao(0, 0);

            //Cima
            pos.definirVarlores(Posicao.Linha - 1, Posicao.Coluna);
            while (Tab.PosValida(pos) && checkMov(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (Tab.peca(pos) != null && Tab.peca(pos).Cor != Cor)
                {
                    break;
                }
                pos.definirVarlores(pos.Linha - 1, pos.Coluna); 
            }

            //Cima direita
            pos.definirVarlores(Posicao.Linha - 1, Posicao.Coluna + 1);
            while (Tab.PosValida(pos) && checkMov(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (Tab.peca(pos) != null && Tab.peca(pos).Cor != Cor)
                {
                    break;
                }
                pos.definirVarlores(pos.Linha - 1, pos.Coluna + 1);
            }

            //Direita
            pos.definirVarlores(Posicao.Linha, Posicao.Coluna + 1);
            while (Tab.PosValida(pos) && checkMov(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (Tab.peca(pos) != null && Tab.peca(pos).Cor != Cor)
                {
                    break;
                }
                pos.definirVarlores(pos.Linha, pos.Coluna + 1);
            }

            //Baixo Direita
            pos.definirVarlores(Posicao.Linha + 1, Posicao.Coluna + 1);
            while (Tab.PosValida(pos) && checkMov(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (Tab.peca(pos) != null && Tab.peca(pos).Cor != Cor)
                {
                    break;
                }
                pos.definirVarlores(pos.Linha + 1, pos.Coluna + 1);
            }

            //Baixo
            pos.definirVarlores(Posicao.Linha + 1, Posicao.Coluna);
            while (Tab.PosValida(pos) && checkMov(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (Tab.peca(pos) != null && Tab.peca(pos).Cor != Cor)
                {
                    break;
                }
                pos.definirVarlores(pos.Linha + 1, pos.Coluna);
            }

            //Baixo Esquerda
            pos.definirVarlores(Posicao.Linha + 1, Posicao.Coluna - 1);
            while (Tab.PosValida(pos) && checkMov(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (Tab.peca(pos) != null && Tab.peca(pos).Cor != Cor)
                {
                    break;
                }
                pos.definirVarlores(pos.Linha + 1, pos.Coluna - 1);
            }

            //Esquerda
            pos.definirVarlores(Posicao.Linha, Posicao.Coluna - 1);
            while (Tab.PosValida(pos) && checkMov(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (Tab.peca(pos) != null && Tab.peca(pos).Cor != Cor)
                {
                    break;
                }
                pos.definirVarlores(pos.Linha, pos.Coluna - 1);
            }

            //Esquerda Cima
            pos.definirVarlores(Posicao.Linha - 1, Posicao.Coluna - 1);
            while (Tab.PosValida(pos) && checkMov(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (Tab.peca(pos) != null && Tab.peca(pos).Cor != Cor)
                {
                    break;
                }
                pos.definirVarlores(pos.Linha - 1, pos.Coluna - 1);
            }
            return mat;
        }
    }
}
