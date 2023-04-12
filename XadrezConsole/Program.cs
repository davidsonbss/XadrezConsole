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

            while (!partida.Terminada)
            {
                Console.Clear();
                Tela.ImprimirTabuleiro(partida.Tab);

                Console.WriteLine();
                Console.Write("Origem: ");
                Posicao origem = Tela.LerPosicaoXadrez().ToPosicao();

                bool[,] posicoesPossiveis = partida.Tab.PecaPasso(origem).MovimentosPossiveis();

                Console.Clear();
                Tela.ImprimirTabuleiro(partida.Tab, posicoesPossiveis);

                Console.WriteLine();
                Console.Write("Destino: ");
                Posicao destino = Tela.LerPosicaoXadrez().ToPosicao();

                partida.ExecutaMovimento(origem, destino);
            }


            

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}