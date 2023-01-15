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
        public Peca peca(int linhas, int colunas) //Metodo para acessar as peças de modo seguro
        {
            return Pecas[linhas,colunas];
        }
        public Peca peca(Posicao pos) //Posição das peças pela classe Posição
        {
            return Pecas[pos.Linha, pos.Coluna];
        }
        public bool PosValida(Posicao pos) //Validando se a posição existe no tabuleiro
        {
            if (pos.Linha < 0 || pos.Linha >= Linhas || pos.Coluna < 0 || pos.Coluna >= Colunas)
            {
                return false;
            }
            return true;
        }
        public void ErroPosicao(Posicao pos) //Exibindo mensagem de erro de posição
        {
            if (!PosValida(pos))
            {
                throw new TabuleiroException("Posição Inválida!");
            }
        }
        public bool ExistPeca(Posicao pos)
        {
            ErroPosicao(pos); //Verificando primeiro se teve erro de posição
            return peca(pos) != null; //Retornando peça
        }
        public void ColocPeca(Peca p, Posicao pos)//Método para colocação de peças, em qual tabuleiro, e a posição
        {
            if (ExistPeca(pos))
            {
                throw new TabuleiroException("Já existe uma peça nessa posição!"); //Exibindo erro caso ja tiver uma peça
            }
            Pecas[pos.Linha, pos.Coluna] = p;
            p.Posicao = pos;
        }
        public Peca RetirPeca(Posicao pos)
        {
            if(peca(pos) == null)
            {
                return null;
            }
            Peca aux = peca(pos);
            aux.Posicao = null;
            Pecas[pos.Linha,pos.Coluna] = null;
            return aux;
        }
    }
}
