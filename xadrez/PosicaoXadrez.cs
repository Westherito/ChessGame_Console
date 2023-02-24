using tabuleiro;
namespace xadrez
{
    class PosicaoXadrez //Auxiliando a orientação do tabuleiro com as regras de xadrez
    {
        public char Coluna { get; set; }
        public int Linha { get; set;}

        public PosicaoXadrez(char coluna, int linha)//Recebendo Valores digitados pelo usuário
        {
            Coluna = coluna;
            Linha = linha;
        }
        public Posicao convertPos()//Convertendo as cordenadas do xadrez para matriz
        {
            return new Posicao(8 - Linha, Coluna - 'a');
        }
    }
}
