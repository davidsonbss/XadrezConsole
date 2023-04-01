namespace Tabuleiro;
internal class TabuleiroBase
{
    public int Linhas { get; set; }
    public int Counas { get; set; }

    private Peca[,] _pecas;

    public TabuleiroBase(int linhas, int colunas)
    {
        Linhas = linhas;
        Counas = colunas;
        _pecas = new Peca[linhas, colunas];
    }
}
