using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using TabuleiroXadrez;

namespace Xadrez;

internal class PartidaXadrez
{
    public Tabuleiro Tab { get; private set; }
    public bool Terminada { get; private set; }
    public int Turno { get; private set; }
    public Cor JogadorAtual { get; private set; }
    private HashSet<Peca> Pecas;
    private HashSet<Peca> Capturadas;
    public bool Xeque { get; private set; }

    public PartidaXadrez()
    {
        Tab = new Tabuleiro(8, 8);
        Turno = 1;
        JogadorAtual = Cor.Branca;
        Terminada = false;
        Pecas = new HashSet<Peca>();
        Capturadas = new HashSet<Peca>();
        ColocarPecas();
        Xeque = false;
    }

    public Peca ExecutaMovimento(Posicao origem, Posicao destino)
    {
        Peca p = Tab.RemoverPeca(origem);
        p.IncrementarQtMovimentos();
        Peca pecaCapturada = Tab.RemoverPeca(destino);
        Tab.ColocarPeca(p, destino);
        if (pecaCapturada != null)
            Capturadas.Add(pecaCapturada);
        return pecaCapturada;
    }

    public void DesfazMovimento(Posicao origem, Posicao destino, Peca pecaCaptuada)
    {
        Peca p = Tab.RemoverPeca(destino);
        p.DecrementarQtMovimentos();
        if (pecaCaptuada != null)
        {
            Tab.ColocarPeca(pecaCaptuada, destino);
            Capturadas.Remove(pecaCaptuada);
        }
        Tab.ColocarPeca(p, origem);
    }

    public void RealizaJogada(Posicao origem, Posicao destino)
    {
        Peca pecaCapturada = ExecutaMovimento(origem, destino);
        if (EstaEmXeque(JogadorAtual))
        {
            DesfazMovimento(origem, destino, pecaCapturada);
            throw new TabuleiroException("Você não pode se colocar em xeque!");
        }

        if (EstaEmXeque(Adversario(JogadorAtual)))
            Xeque = true;
        else
            Xeque = false;
        
        Turno++;
        MudarJogador();
    }

    public void ValidarPosicaoOrigem(Posicao pos)
    {
        if (Tab.PecaPasso(pos) is null)
            throw new TabuleiroException("Não existe peça na posição de origem escolhida!");
        if (JogadorAtual != Tab.PecaPasso(pos).Cor)
            throw new TabuleiroException("A peça de origem escohida não é sua!");
        if (!Tab.PecaPasso(pos).ExisteMovimentosPossiveis())
            throw new TabuleiroException("Não há movimentos possíveis para a peça de origem escolhida!");
    }

    public void ValidarPosicaoDestino(Posicao origem, Posicao destino)
    {
        if (!Tab.PecaPasso(origem).PodeMoverPara(destino))
            throw new TabuleiroException("Posição de destino inválida!");
    }

    private void MudarJogador()
    {
        if (JogadorAtual == Cor.Branca)
            JogadorAtual = Cor.Preta;
        else
            JogadorAtual = Cor.Branca;
    }

    public HashSet<Peca> PecasCapturadas(Cor cor)
    {
        HashSet<Peca> aux = new HashSet<Peca>();
        foreach (Peca x in Capturadas)
        {
            if (x.Cor == cor)
                aux.Add(x);
        }
        
        return aux;
    }

    public HashSet<Peca> PecasEmJogo(Cor cor)
    {
        HashSet<Peca> aux = new HashSet<Peca>();
        foreach (Peca x in Pecas)
        {
            if (x.Cor == cor)
                aux.Add(x);
        }
        aux.ExceptWith(PecasCapturadas(cor));
        return aux;
    }

    private Cor Adversario(Cor cor)
    {
        if(cor == Cor.Branca)
        {
            return Cor.Preta;
        }
        else
        {
            return Cor.Branca;
        }
    }

    private Peca Rei(Cor cor)
    {
        foreach (Peca x in PecasEmJogo(cor))
        {
            if(x is Rei)
                return x;
        }
        return null;
    }

    public bool EstaEmXeque(Cor cor)
    {
        Peca r = Rei(cor);
        if (r == null)
            throw new TabuleiroException("Não tem rei da cor " + cor + " no tabuleiro");

        foreach (Peca x in PecasEmJogo(Adversario(cor)))
        {
            bool[,] mat = x.MovimentosPossiveis();
            if (mat[r.Posicao.Linha, r.Posicao.Coluna])
                return true;
        }
        return false;
    }

    public void ColocarNovaPeca(char coluna, int linha, Peca peca)
    {
        Tab.ColocarPeca(peca, new PosicaoXadrez(coluna, linha).ToPosicao());
        Pecas.Add(peca);
    }

    private void ColocarPecas()
    {
        ColocarNovaPeca('c', 1, new Torre(Tab, Cor.Branca));
        ColocarNovaPeca('c', 2, new Torre(Tab, Cor.Branca));
        ColocarNovaPeca('d', 2, new Torre(Tab, Cor.Branca));
        ColocarNovaPeca('e', 2, new Torre(Tab, Cor.Branca));
        ColocarNovaPeca('e', 1, new Torre(Tab, Cor.Branca));
        ColocarNovaPeca('d', 1, new Rei(Tab, Cor.Branca));

        ColocarNovaPeca('c', 7, new Torre(Tab, Cor.Preta));
        ColocarNovaPeca('c', 8, new Torre(Tab, Cor.Preta));
        ColocarNovaPeca('d', 7, new Torre(Tab, Cor.Preta));
        ColocarNovaPeca('e', 7, new Torre(Tab, Cor.Preta));
        ColocarNovaPeca('e', 8, new Torre(Tab, Cor.Preta));
        ColocarNovaPeca('d', 8, new Rei(Tab, Cor.Preta));

    }
}
