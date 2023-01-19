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
        public void incremtQteMov()//Acrescentando número de movimentos feitos
        {
            QteMov++;
        }
        public void decremtQteMov()//Reduzindo número de movimentos feitos
        {
            QteMov--;
        }


        public bool existMovPos() //Verificando na matrix se existe a peça para execução de mensagens de erro;
        {
            bool[,] mat = MovPossiveis();
            for (int i = 0; i < Tab.Linhas; i++)
            {
                for (int j =0; j < Tab.Colunas; j++)
                {
                    if (mat[i, j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool podeMover(Posicao pos)//Validando se a peça se move apenas onde é permitido
        {
            return MovPossiveis()[pos.Linha, pos.Coluna];
        }

        public abstract bool[,] MovPossiveis();//Metodo que retorna true ou false dependendo do movimento da peça
        ///Nota: ela tem que ser abstrata pois cada peça tem um movimento diferente
    }
}
