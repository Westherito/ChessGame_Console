namespace tabuleiro
{
    class Posicao //Configuração de Posição
    {
        public int Linha { get; set; }
        public int Coluna { get; set; }

        //Construtor para definir a posição
        public Posicao(int linha, int coluna)
        {
            Linha = linha;
            Coluna = coluna;
        }
    }
}
