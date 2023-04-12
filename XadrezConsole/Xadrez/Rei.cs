﻿using TabuleiroXadrez;
namespace Xadrez;
class Rei : Peca
{
    public Rei(Tabuleiro tab, Cor cor) : base(tab, cor)
    {
    }

    public override string ToString()
    {
        return "R";
    }

    private bool PodeMover(Posicao pos)
    {
        Peca p = Tab.PecaPasso(pos);
        return p == null || p.Cor != Cor;
    }

    public override bool[,] MovimentosPossiveis()
    {
        bool[,] mat = new bool[Tab.Linhas, Tab.Colunas];

        Posicao pos = new Posicao(0, 0);

        // Acima
        pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna);
        if (Tab.PosicaoValida(pos) && PodeMover(pos))
            mat[pos.Linha, pos.Coluna] = true;
        // Ne
        pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna + 1);
        if (Tab.PosicaoValida(pos) && PodeMover(pos))
            mat[pos.Linha, pos.Coluna] = true;
        // Direita
        pos.DefinirValores(Posicao.Linha, Posicao.Coluna + 1);
        if (Tab.PosicaoValida(pos) && PodeMover(pos))
            mat[pos.Linha, pos.Coluna] = true;
        // Se
        pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna + 1);
        if (Tab.PosicaoValida(pos) && PodeMover(pos))
            mat[pos.Linha, pos.Coluna] = true;
        // abaixo
        pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna);
        if (Tab.PosicaoValida(pos) && PodeMover(pos))
            mat[pos.Linha, pos.Coluna] = true;
        // So
        pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna - 1);
        if (Tab.PosicaoValida(pos) && PodeMover(pos))
            mat[pos.Linha, pos.Coluna] = true;
        // Esquerda
        pos.DefinirValores(Posicao.Linha, Posicao.Coluna - 1);
        if (Tab.PosicaoValida(pos) && PodeMover(pos))
            mat[pos.Linha, pos.Coluna] = true;
        // No
        pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna - 1);
        if (Tab.PosicaoValida(pos) && PodeMover(pos))
            mat[pos.Linha, pos.Coluna] = true;

        return mat;
    }
}
