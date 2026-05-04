using System;
namespace SistemaLivraria{

public class LivroDigital : Livro{

    public string Formato { get; set; }

    public LivroDigital(int id, string nome, double preco, string autor, string formato, int quantidade):base(id, nome, preco, autor, quantidade )
    {
          Formato = formato;
    }

    public override double CalculoPrecoUnitario()
    {
        
        double desconto = Preco * 0.15;
        return Preco - desconto;
    }

    }
}