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
        public void definirVarlores(int linha , int coluna)//Definindo valores de coluna e linha
        {
            Linha = linha;
            Coluna = coluna;
        }
    }
}
