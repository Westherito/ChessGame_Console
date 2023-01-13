namespace tabuleiro
{
    class Peca //Configuração de peças e suas caracteristicas
    {
        public Posicao Posicao { get; set; }
        public Cor Cor { get; protected set; }
        public int QteMov { get; protected set; }
        public Tabuleiro Tab { get; protected set; }
        
        //Construtor para criação de peças
        public Peca(Posicao posicao, Cor cor, Tabuleiro tab)
        {
            Posicao = posicao;
            Cor = cor;
            Tab = tab;
            QteMov = 0;
        }



    }
}
