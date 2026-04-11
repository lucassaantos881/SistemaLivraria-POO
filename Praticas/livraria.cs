using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace SistemaLivraria{

class Livraria{

    static void Main(){

        int quantidade;
        string nome, autor;
        double preco;
        char escolha;
        string cupom = "Sem cupom";
        char escolhaCupom;

        GestorLivraria gestorLivraria = new GestorLivraria();
        do{
            int opcao = 0;

            try{
                Console.WriteLine();
                Console.WriteLine("BEM VINDO AO CARRINHO, SELECIONE UMA DAS OPÇÕES!!");
                Console.WriteLine("[1] - ADICIONAR LIVROS");
                Console.WriteLine("[2] - REMOVER LIVROS");
                Console.WriteLine("[3] - MOSTRAR LISTA DE LIVROS");
                Console.WriteLine();
                opcao = ConsoleUtils.LetInteiro("ESCOLHA UMA OPÇÃO: ");
            }
            catch (Exception e){
                Console.WriteLine(e.Message);
            }

            switch (opcao){
                case 1:
                    try{
                     quantidade = ConsoleUtils.LetInteiro("Quantos livros serão adicionados?: ");
                        for(int i = 0; i < quantidade; i++){
                            Console.WriteLine();
                            nome = ConsoleUtils.LerString("Digite o nome do livro: ");
                            preco = ConsoleUtils.LetDouble("Digite o preço do livro: ");
                            autor = ConsoleUtils.LerString("Nome do autor: ");
                        
                            Livro livro = new Livro(nome, preco, autor);
                            gestorLivraria.AdicionarLivros(livro);
                        }

                    }catch (Exception e){
                        Console.WriteLine(e.Message);
                    }


                break;

                case 2 :
                    try{
                        
                            quantidade = ConsoleUtils.LetInteiro("Quantos livros serão removidos?: ");

                            for(int i = 0; i < quantidade; i++){
                                nome = ConsoleUtils.LerString("Digite exatamente o nome do livro que será removido: ");
                                gestorLivraria.RemoverLivros(nome);
                            }
                        
                
                    }catch (Exception e){
                        Console.WriteLine(e.Message);
                    }
                break;


                case 3:

                    gestorLivraria.MostrarLista();

                break;

              default:

                Console.WriteLine("Saindo!!");
              break;

        
        }

            Console.WriteLine();
            escolha = ConsoleUtils.LetCaractere("Deseja adicionar/consultar ou remover livros?: ");
        
        
        }while(escolha == 'y' || escolha == 'Y');

        Console.WriteLine();
        Console.WriteLine("CALCULANDO CARRINHO...");
        
    
        escolhaCupom = ConsoleUtils.LetCaractere("Deseja inserir um cupom? [y/n]: ");

         if (escolhaCupom == 'y' || escolhaCupom == 'Y'){
                cupom = ConsoleUtils.LerString("Digite o cupom: ");
                double total = gestorLivraria.CalcularTotal(cupom);
                Console.WriteLine("Total a pagar: R${0}", total.ToString("N2"));
         }else{
                double total = gestorLivraria.CalcularTotal(cupom);
                Console.WriteLine("Total a pagar: R${0}", total.ToString("N2"));
          }


          
        
            


         

        ;

    }

}
}



