using TabuleiroXadrez;

namespace XadrezConsole;
class Tela
{
    readonly static ConsoleColor _backgroundDefault = ConsoleColor.Black;
    readonly static ConsoleColor _CorPecaPreta = ConsoleColor.Black;
    readonly static ConsoleColor _CorPecaBranca = ConsoleColor.White;


    public static void ImprimirTabuleiro(Tabuleiro tab)
    {
        Console.BackgroundColor = _backgroundDefault;

        for (int i = 0; i < tab.Linhas; i++)
        {
            Console.Write(8 - i + " ");
            for (int j = 0; j < tab.Colunas; j++)
            {
                ImprimirFundoTabuleiro(i, j);
                if (tab.MovPeca(i, j) is null)
                    Console.Write("  ");
                else
                {
                    ImprimirPeca(tab.MovPeca(i, j));
                    Console.Write(" ");
                }
            }
            Console.BackgroundColor = _backgroundDefault;
            Console.WriteLine();
        }
        Console.WriteLine("  a b c d e f g h");
    }

    public static void ImprimirPeca(Peca peca)
    {
        ConsoleColor aux = Console.ForegroundColor;
        if (peca.Cor == Cor.Branca)
        {
            Console.ForegroundColor = _CorPecaBranca;
            Console.Write(peca);
        }
        else
        {
            Console.ForegroundColor = _CorPecaPreta;
            Console.Write(peca);
        }
        Console.ForegroundColor = aux;
    }

    public static void ImprimirFundoTabuleiro(int i, int j)
    {
        if (i % 2 == 0)
        {
            if (j % 2 == 0)
                Console.BackgroundColor = ConsoleColor.Gray;
            else
                Console.BackgroundColor = ConsoleColor.Green;
        }

        if (i % 2 != 0)
        {
            if (j % 2 == 0)
                Console.BackgroundColor = ConsoleColor.Green;
            else
                Console.BackgroundColor = ConsoleColor.Gray;
        }
    }
}
