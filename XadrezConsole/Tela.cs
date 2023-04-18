using TabuleiroXadrez;
using Xadrez;

namespace XadrezConsole;
class Tela
{
    readonly static ConsoleColor _backgroundDefault = ConsoleColor.Black;
    readonly static ConsoleColor _corPecaPreta = ConsoleColor.Black;
    readonly static ConsoleColor _corPecaBranca = ConsoleColor.White;
    readonly static ConsoleColor _fundoCapturadas = ConsoleColor.DarkGray;

    public static void ImprimirPartida(PartidaXadrez partida)
    {
        ImprimirTabuleiro(partida.Tab);
        Console.WriteLine();
        ImprimirPecasCapturadas(partida);
        Console.WriteLine();
        Console.WriteLine("Turno: " + partida.Turno);
        Console.WriteLine("Aguardando jogada: " + partida.JogadorAtual);
        if (partida.Xeque)
        {
            Console.WriteLine("XEQUE!");
        }
    }

    public static void ImprimirPecasCapturadas(PartidaXadrez partida)
    {
        Console.WriteLine("Peças capturadas:");
        Console.Write("Brancas: ");
        ImprimirPecasConjunto(partida.PecasCapturadas(Cor.Branca));
        Console.Write("Pretas: ");
        ImprimirPecasConjunto(partida.PecasCapturadas(Cor.Preta));
    }

    public static void ImprimirPecasConjunto(HashSet<Peca> conjunto)
    {
        Console.Write("[");
        Console.BackgroundColor = _fundoCapturadas;
       
        if(conjunto.Any(x => x.Cor == Cor.Branca))
            Console.ForegroundColor = _corPecaBranca;
        else
            Console.ForegroundColor = _corPecaPreta;
        
        foreach (Peca x in conjunto)
            Console.Write(x + " ");
        
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.BackgroundColor = _backgroundDefault;
        Console.Write("]\n");
    }

    public static void ImprimirTabuleiro(Tabuleiro tab)
    {
        Console.BackgroundColor = _backgroundDefault;

        for (int i = 0; i < tab.Linhas; i++)
        {
            Console.Write(8 - i + " ");
            for (int j = 0; j < tab.Colunas; j++)
            {
                ImprimirFundoTabuleiro(i, j, false);

                ImprimirPeca(tab.PecaPasso(i, j));

            }
            Console.BackgroundColor = _backgroundDefault;
            Console.WriteLine();
        }
        Console.WriteLine("  a b c d e f g h");
    }

    public static void ImprimirTabuleiro(Tabuleiro tab, bool[,] posicoesPossiveis)
    {
        Console.BackgroundColor = _backgroundDefault;

        for (int i = 0; i < tab.Linhas; i++)
        {
            Console.Write(8 - i + " ");
            for (int j = 0; j < tab.Colunas; j++)
            {

                ImprimirFundoTabuleiro(i, j, posicoesPossiveis[i, j]);

                ImprimirPeca(tab.PecaPasso(i, j));

            }
            Console.BackgroundColor = _backgroundDefault;
            Console.WriteLine();
        }
        Console.WriteLine("  a b c d e f g h");
    }



    public static PosicaoXadrez LerPosicaoXadrez()
    {
        string s = Console.ReadLine();
        char coluna = s[0];
        int linha = int.Parse(s[1].ToString());

        return new PosicaoXadrez(coluna, linha);
    }

    public static void ImprimirPeca(Peca peca)
    {
        ConsoleColor aux = Console.ForegroundColor;

        if (peca is null)
            Console.Write("  ");
        else
        {
            if (peca.Cor == Cor.Branca)
            {
                Console.ForegroundColor = _corPecaBranca;
                Console.Write(peca);
            }
            else
            {
                Console.ForegroundColor = _corPecaPreta;
                Console.Write(peca);
            }
            Console.Write(" ");
            Console.ForegroundColor = aux;
        }
    }

    public static void ImprimirFundoTabuleiro(int i, int j, bool posicaoPossivelDestque)
    {
        if (i % 2 == 0)
        {
            if (j % 2 == 0)
            {
                if (posicaoPossivelDestque)
                    Console.BackgroundColor = ConsoleColor.Gray;
                else
                    Console.BackgroundColor = ConsoleColor.Cyan;
            }
            else
            {
                if (posicaoPossivelDestque)
                    Console.BackgroundColor = ConsoleColor.DarkGray;
                else
                    Console.BackgroundColor = ConsoleColor.DarkGreen;
            }
        }

        if (i % 2 != 0)
        {
            if (j % 2 == 0)
            {
                if (posicaoPossivelDestque)
                    Console.BackgroundColor = ConsoleColor.DarkGray;
                else
                    Console.BackgroundColor = ConsoleColor.DarkGreen;
            }
            else
            {
                if (posicaoPossivelDestque)
                    Console.BackgroundColor = ConsoleColor.Gray;
                else
                    Console.BackgroundColor = ConsoleColor.Cyan;
            }
        }
    }
}
