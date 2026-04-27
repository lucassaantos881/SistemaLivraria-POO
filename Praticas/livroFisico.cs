using System;
namespace SistemaLivraria{

public class LivroFisico : Livro{

    public string TipoCapa { get; set; }

    public LivroFisico(int id, string nome, double preco, string autor, string tipoCapa, int quantidade) : base(id, nome, preco, autor, quantidade)
        {
            TipoCapa = tipoCapa;
    }

    public override double CalcularTotal()
    {
        double valorFrete = (Preco * Quantidade) + 15.00; // Valor fixo para o frete
        return valorFrete;
    }

    }
}