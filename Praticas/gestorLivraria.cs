using System;
namespace SistemaLivraria{

public class GestorLivraria{

    public GestorLivraria(){
        
    }
    private List<Livro> livros = new List<Livro>();

    public void AdicionarLivros(Livro newLivro){
        livros.Add(newLivro);
    }

    public void RemoverLivros(string entrada){

        //Percorre a lista do último índice até o primeiro e valida se a entrada é igual ao índice i referente ao nome que está na lista
            for(int i = livros.Count - 1; i >= 0; i--){
                if (entrada == livros[i].Nome){
                    livros.RemoveAt(i);
                }
            }
    }

    public void MostrarLista(){
        foreach (var listaCompleta in livros){
            Console.WriteLine("{0}, {1}, {2}", listaCompleta.Nome, listaCompleta.Preco.ToString("N2"), listaCompleta.Autor);
        }
    }

    public double CalcularTotal(string cupom){
        double total = 0;
        double porcentagem, totalComCupom;

        foreach (var calculo in livros){
            total += calculo.Preco;
        }

        if (cupom.ToUpper() == "LIDO10"){
            porcentagem = total * (10.0 / 100);
            totalComCupom = total - porcentagem;
            return totalComCupom;
        }else if(cupom.ToUpper() == "MESTRE20"){
            porcentagem = total * (20.0 / 100);
            totalComCupom = total - porcentagem;
            return totalComCupom;
        }else{
            return total;
        }
        
        
    }
    
}
}