namespace Tabuleiro;
class Peca
{
    public Posicao Posicao { get; set; }
    public Cor Cor { get; set; }
    public int QtMovimentos { get; set; }
    public TabuleiroBase Tab { get; set; }

    public Peca(Posicao posicao, TabuleiroBase tab, Cor cor)
    {
        Posicao = posicao;
        Cor = cor;
        Tab = tab;
        QtMovimentos = 0;
    }
}
