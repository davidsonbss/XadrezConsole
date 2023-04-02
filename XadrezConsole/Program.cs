using TabuleiroXadrez;
using Xadrez;

namespace XadrezConsole;

internal class Program
{
    private static void Main(string[] args)
    {
        try
        {

            PartidaXadrez partida = new PartidaXadrez();

            Tela.ImprimirTabuleiro(partida.Tab);

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