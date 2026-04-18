using System;
namespace SistemaLivraria{

public class LivroFisico : Livro{

    public string TipoCapa { get; set; }

    public LivroFisico(int id, string nome, double preco, string autor, string tipoCapa) : base(id, nome, preco, autor)
        {
            TipoCapa = tipoCapa;
    }

    public override double CalcularTotal()
    {
        double valorFrete = 15.00; // Valor fixo para o frete
        return Preco + valorFrete;
    }

    }
}