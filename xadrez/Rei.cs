using tabuleiro;
namespace xadrez
{
    class Rei : Peca
    {
        private PartidaXadrez Partida;
        public Rei(Cor cor, Tabuleiro tab, PartidaXadrez partida) : base(cor,tab)
        {
            Partida = partida;
        }
        public override string ToString()
        {
            return "R"; 
        }
        private bool checkMov(Posicao pos)//Checagem de movimento de uma peca na matrix para movimentação
        {
            Peca p = Tab.peca(pos);
            return p == null || p.Cor != Cor;
        }
        private bool checkTorreRoque(Posicao pos)
        {
            Peca p = Tab.peca(pos);
            return p != null && p is Torre && p.Cor == Cor && p.QteMov == 0;
        }
        public override bool[,] MovPossiveis()//Função para checar os movimentos do rei em relação ao jogo
        {
            bool[,] mat = new bool[Tab.Linhas, Tab.Colunas];

            Posicao pos = new Posicao(0, 0);

            //Cima
            pos.definirVarlores(Posicao.Linha - 1, Posicao.Coluna);
            if (Tab.PosValida(pos) && checkMov(pos))
            {
                mat[pos.Linha,pos.Coluna] = true;
            }
            //Cima Direita 
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
            //Cima Esquerda
            pos.definirVarlores(Posicao.Linha - 1, Posicao.Coluna - 1);
            if (Tab.PosValida(pos) && checkMov(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            // #Jogadas Especiais: Roque 
            if (QteMov == 0 && !Partida.Xeque)//Verificando se está em xeque
            {
                // #Jogadas Especiais: Roque pequeno
                Posicao PosT1 = new Posicao(Posicao.Linha, Posicao.Coluna + 3);
                if (checkTorreRoque(PosT1))
                {
                    Posicao p1 = new Posicao(Posicao.Linha, Posicao.Coluna + 1);
                    Posicao p2 = new Posicao(Posicao.Linha, Posicao.Coluna + 2);
                    if (Tab.peca(p1) == null && Tab.peca(p2) == null)
                    {
                        mat[Posicao.Linha,Posicao.Coluna + 2] = true;
                    }
                }
                // #Jogadas Especiais: Roque Grande
                Posicao PosT2 = new Posicao(Posicao.Linha, Posicao.Coluna - 4);
                if (checkTorreRoque(PosT2))
                {
                    Posicao p1 = new Posicao(Posicao.Linha, Posicao.Coluna - 1);
                    Posicao p2 = new Posicao(Posicao.Linha, Posicao.Coluna - 2);
                    Posicao p3 = new Posicao(Posicao.Linha, Posicao.Coluna - 3);
                    if (Tab.peca(p1) == null && Tab.peca(p2) == null && Tab.peca(p3) == null)
                    {
                        mat[Posicao.Linha, Posicao.Coluna - 2] = true;
                    }
                }
            }

            return mat;
        }
    }
}
