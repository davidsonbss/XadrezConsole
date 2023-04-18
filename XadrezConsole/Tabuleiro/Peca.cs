namespace TabuleiroXadrez;
abstract class Peca
{
    public Posicao Posicao { get; set; }
    public Cor Cor { get; set; }
    public int QtMovimentos { get; set; }
    public Tabuleiro Tab { get; set; }

    public Peca(Tabuleiro tab, Cor cor)
    {
        Posicao = null;
        Cor = cor;
        Tab = tab;
        QtMovimentos = 0;
    }

    public void IncrementarQtMovimentos()
    {
        QtMovimentos++;
    }

    public void DecrementarQtMovimentos()
    {
        QtMovimentos--;
    }

    public bool ExisteMovimentosPossiveis()
    {
        bool[,] mat = MovimentosPossiveis();
        for (int i = 0; i < Tab.Linhas; i++)
        {
            for (int j = 0; j < Tab.Linhas; j++)
            {
                if (mat[i, j])
                    return true;
            }
        }
        return false;
    }

    public bool PodeMoverPara(Posicao pos)
    {
        return MovimentosPossiveis()[pos.Linha, pos.Coluna];
    }

    public abstract bool[,] MovimentosPossiveis();

}
