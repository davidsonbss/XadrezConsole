using Tabuleiro;
using XadrezConsole;

internal class Program
{
    private static void Main(string[] args)
    {
        TabuleiroBase tabuleiro =  new TabuleiroBase(8 ,8);

        Tela.ImprimirTabuleiro(tabuleiro);

        Posicao P;

        P = new Posicao(3, 4);

        Console.WriteLine("Posição: " + P);
    }
}