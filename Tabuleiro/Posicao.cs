namespace tabuleiro
{
    class Posicao //Configuração de Posição
    {
        public int Linha { get; set; }
        public int Coluna { get; set; }
        public Posicao(int linha, int coluna) //Construtor para definir a posição
        {
            Linha = linha;
            Coluna = coluna;
        }
    }
}
