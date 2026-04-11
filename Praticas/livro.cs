using System;
namespace SistemaLivraria{

public class Livro : Produto{
   public string Autor{get; set;}

    public Livro(string nome, double preco, string autor):base(nome, preco){
        Autor = autor;
    }
    
}
}