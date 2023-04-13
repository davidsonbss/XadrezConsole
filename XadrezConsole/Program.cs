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
                try
                {
                    Console.Clear();
                    Tela.ImprimirPartida(partida);

                    Console.WriteLine();
                    Console.Write("Origem: ");
                    Posicao origem = Tela.LerPosicaoXadrez().ToPosicao();
                    partida.ValidarPosicaoOrigem(origem);


                    bool[,] posicoesPossiveis = partida.Tab.PecaPasso(origem).MovimentosPossiveis();

                    Console.Clear();
                    Tela.ImprimirTabuleiro(partida.Tab, posicoesPossiveis);

                    Console.WriteLine();
                    Console.Write("Destino: ");
                    Posicao destino = Tela.LerPosicaoXadrez().ToPosicao();
                    partida.ValidarPosicaoDestino(origem, destino);

                    partida.RealizaJogada(origem, destino);

                }
                catch (TabuleiroException e)
                {
                    Console.WriteLine(e.Message);
                    Console.ReadLine();
                }
            }




        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}