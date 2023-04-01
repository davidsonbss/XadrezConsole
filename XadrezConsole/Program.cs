using Tabuleiro;

internal class Program
{
    private static void Main(string[] args)
    {
        TabuleiroBase tabuleiro =  new TabuleiroBase(8 ,8);

        Posicao P;

        P = new Posicao(3, 4);

        Console.WriteLine("Posição: " + P);
    }
}