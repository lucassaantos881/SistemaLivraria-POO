using System;
namespace SistemaLivraria{

public class LivroDigital : Livro{

    public string Formato { get; set; }

    public LivroDigital(int id, string nome, double preco, string autor, string formato):base(id, nome, preco, autor)
    {
          Formato = formato;
    }

    public override double CalcularTotal()
    {
        double desconto = Preco * 0.15;
        return Preco - desconto;
    }

    }
}