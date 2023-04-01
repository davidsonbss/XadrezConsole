using Tabuleiro;
namespace XadrezConsole;

internal class Tela
{
    public static void ImprimirTabuleiro(TabuleiroBase tab)
    {
        for (int i = 0; i < tab.Linhas; i++)
        {
            for (int j = 0; j < tab.Counas; j++)
            {
                if(tab.GetPeca(i, j) is null)
                    Console.Write("- ");
                else                
                    Console.Write(tab.GetPeca(i,j) + " ");
            }
            Console.WriteLine();
        }
    }
}
