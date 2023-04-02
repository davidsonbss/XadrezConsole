using TabuleiroXadrez;
using Xadrez;

namespace XadrezConsole;

internal class Program
{
    private static void Main(string[] args)
    {
        try
        {

            Tabuleiro tabuleiro = new Tabuleiro(8, 8);

            tabuleiro.ColocarPeca(new Torre(tabuleiro, Cor.Preta), new Posicao(0, 0));
            tabuleiro.ColocarPeca(new Torre(tabuleiro, Cor.Preta), new Posicao(1, 3));
            tabuleiro.ColocarPeca(new Rei(tabuleiro, Cor.Preta), new Posicao(0, 7));
            tabuleiro.ColocarPeca(new Rei(tabuleiro, Cor.Branca), new Posicao(3, 5));
            tabuleiro.ColocarPeca(new Torre(tabuleiro, Cor.Branca), new Posicao(5, 2));


            Tela.ImprimirTabuleiro(tabuleiro);

            Console.WriteLine();
            Posicao P = new Posicao(3, 4);
            Console.WriteLine("Posição: " + P);

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}