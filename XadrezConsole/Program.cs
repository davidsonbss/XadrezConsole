using Tabuleiro;
using Xadrez;
using XadrezConsole;

internal class Program
{
    private static void Main(string[] args)
    {
        TabuleiroBase tabuleiro = new TabuleiroBase(8, 8);

        tabuleiro.ColocarPeca(new Torre(tabuleiro, Cor.Preta), new Posicao(0, 0));
        tabuleiro.ColocarPeca(new Torre(tabuleiro, Cor.Preta), new Posicao(1, 3));
        tabuleiro.ColocarPeca(new Rei(tabuleiro, Cor.Preta), new Posicao(2, 4));


        Tela.ImprimirTabuleiro(tabuleiro);

        Posicao P;

        P = new Posicao(3, 4);

        Console.WriteLine("Posição: " + P);
    }
}