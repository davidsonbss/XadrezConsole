namespace Tabuleiro;
class Peca
{
    public Posicao Posicao { get; set; }
    public Cor Cor { get; set; }
    public int QtMovimentos { get; set; }
    public TabuleiroBase Tab { get; set; }

    public Peca(TabuleiroBase tab, Cor cor)
    {
        Posicao = null;
        Cor = cor;
        Tab = tab;
        QtMovimentos = 0;
    }
}
