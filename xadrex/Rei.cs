using tabuleiro;

namespace xadrex
{
    class Rei : Peca
    {
        public Rei(Cor cor, Tabuleiro tab) : base(cor,tab)
        {

        }

        public override string ToString()
        {
            return "R"; 
        }
    }
}
