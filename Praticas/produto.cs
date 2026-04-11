using System;
namespace SistemaLivraria{

public abstract class Produto{
    public string Nome{get; set;}

    protected double preco;
    public double Preco{
        get { return preco;}
    
        set{
           if(value < 0){
                throw new ArgumentException("ERRO: Preco nao pode ser negativo");
            }
            preco = value; 
        }
        
        }

    public Produto(string nome, double preco){
        Nome = nome;
        Preco = preco;
    }

    
}
}