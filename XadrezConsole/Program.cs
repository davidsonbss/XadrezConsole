using Tabuleiro;
using Xadrez;
using XadrezConsole;

internal class Program
{
    private static void Main(string[] args)
    {
        PosicaoXadrez poss = new PosicaoXadrez('c', 7);
        Console.WriteLine(poss.ToPosicao());

        try
        {

            TabuleiroBase tabuleiro = new TabuleiroBase(8, 8);

            tabuleiro.ColocarPeca(new Torre(tabuleiro, Cor.Preta), new Posicao(0, 0));
            tabuleiro.ColocarPeca(new Torre(tabuleiro, Cor.Preta), new Posicao(1, 3));
            tabuleiro.ColocarPeca(new Rei(tabuleiro, Cor.Preta), new Posicao(0, 9));


            Tela.ImprimirTabuleiro(tabuleiro);

            Posicao P;

            P = new Posicao(3, 4);

            Console.WriteLine("Posição: " + P);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}