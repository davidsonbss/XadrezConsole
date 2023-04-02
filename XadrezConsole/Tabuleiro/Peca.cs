namespace TabuleiroXadrez;
class Peca
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
}
