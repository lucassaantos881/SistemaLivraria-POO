using System;
namespace SistemaLivraria{

public abstract class Livro : Produto{
   protected int id;
   public int Id { 
            
            
            get { return id; }
            set
            {
                if (value < 0){
                    throw new ArgumentException("ERRO: Id não pode ser negativo!!");
                }
                id = value;
            }
        
        }


   protected string autor;
   public string Autor{

            get { return autor; }

            set { if (string.IsNullOrWhiteSpace(value)){
                    throw new ArgumentException("ERRO: Autor não pode ser vazio!!");
                }
                autor = value;
            }
        
        
        }

    public Livro(int id, string nome, double preco, string autor):base(nome, preco){
            Id = id;
            Autor = autor;
    }


    public abstract double CalcularTotal();
}
}