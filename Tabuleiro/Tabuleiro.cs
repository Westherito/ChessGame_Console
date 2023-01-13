namespace tabuleiro
{
    class Tabuleiro //Configuração de tabuleiro
    {
        public int Linhas { get; set; }
        public int Colunas { get; set; }
        private Peca[,] Pecas { get; set; }
        public Tabuleiro(int linhas, int colunas) //Criação de matriz para mapear o tabuleiro
        {
            Linhas = linhas;
            Colunas = colunas;
            Pecas = new Peca[linhas,colunas];
        }
        public Peca peca(int linhas, int colunas) //metodo para acessar as peças de modo seguro
        {
            return Pecas[linhas,colunas];
        }

        public void ColocPeca(Peca p, Posicao pos)// Método para colocação de peças, em qual tabuleiro, e a posição
        {
            Pecas[pos.Linha, pos.Coluna] = p;
            p.Posicao = pos;
        }

    }
}
