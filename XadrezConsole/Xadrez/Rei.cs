﻿using Tabuleiro;
namespace Xadrez;
class Rei: Peca
{
	public Rei(TabuleiroBase tab, Cor cor) : base(tab, cor)
	{
	}

    public override string ToString()
    {
        return "R";
    }
}
