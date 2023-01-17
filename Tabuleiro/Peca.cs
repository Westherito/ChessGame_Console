namespace tabuleiro
{
    abstract class Peca //Configuração de peças e suas caracteristicas
    {
        public Posicao Posicao { get; set; }
        public Cor Cor { get; protected set; }
        public int QteMov { get; protected set; }
        public Tabuleiro Tab { get; protected set; }    
        public Peca(Cor cor, Tabuleiro tab) //Criação de peças
        {
            Posicao = null;
            Cor = cor;
            Tab = tab;
            QteMov = 0;
        }
        public void incremtQteMov()//Número de movimentos feitos
        {
            QteMov++;
        }
        public abstract bool[,] MovPossiveis();//Metodo que retorna true ou false dependendo do movimento da peça
        ///Nota: ela tem que ser abstrata pois cada peça tem um movimento diferente
    }
}
