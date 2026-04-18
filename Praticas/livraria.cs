using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace SistemaLivraria{

class Livraria{

    static void Main(){

        int quantidade;
        string nome, autor;
        double preco;
        int id;
        char escolha = 'y';
        string tipoLivro = string.Empty;
        string tipoCapa = string.Empty;
        string formato = string.Empty;

            GestorLivraria gestorLivraria = new GestorLivraria();
            do
            {
            int opcao = 0;

            try{

                    Console.WriteLine();
                    Console.WriteLine("BEM VINDO AO CARRINHO, SELECIONE UMA DAS OPÇÕES!!");
                    Console.WriteLine("[1] - ADICIONAR LIVROS");
                    Console.WriteLine("[2] - REMOVER LIVROS");
                    Console.WriteLine("[3] - MOSTRAR LISTA DE LIVROS");
                    Console.WriteLine();
                    opcao = ConsoleUtils.LerInteiro("ESCOLHA UMA OPÇÃO: ");
            }
            catch (Exception e){
                Console.WriteLine(e.Message);
            }

            switch (opcao){
                case 1:
                    try{
                     quantidade = ConsoleUtils.LerInteiro("Quantos livros serão adicionados?: ");
                        for(int i = 0; i < quantidade; i++){
                            Console.WriteLine();
                            Console.WriteLine($"LIVRO {i + 1}:");
                            id = ConsoleUtils.LerInteiro("Digite o ID do livro: ");
                            nome = ConsoleUtils.LerString("Digite o nome do livro: ");
                            preco = ConsoleUtils.LerDouble("Digite o preço do livro: ");
                            autor = ConsoleUtils.LerString("Nome do autor: ");

                            Console.WriteLine();
                            
                            tipoLivro = ConsoleUtils.LerString("Digite o tipo do livro (FISICO ou DIGITAL): ");


                                if (tipoLivro.ToUpper() == "FISICO"){
                                    tipoCapa = ConsoleUtils.LerString("Digite o tipo de capa do livro: ");
                                    LivroFisico livroFisico = new LivroFisico(id, nome, preco, autor, tipoCapa);
                                    gestorLivraria.AdicionarLivros(livroFisico);
                                } else if (tipoLivro.ToUpper() == "DIGITAL")
                                {
                                   formato = ConsoleUtils.LerString("Digite o formato do livro: ");
                                   LivroDigital livroDigital = new LivroDigital(id, nome, preco, autor, formato);
                                    gestorLivraria.AdicionarLivros(livroDigital);
                                }
                                else{
                                    Console.WriteLine("Tipo de livro inválido. POR FAVOR, digite o tipo correto (FISICO ou DIGITAL).");
                                    continue;
                                }
                        }

                    }catch (Exception e){
                        Console.WriteLine(e.Message);
                    }


                break;

                case 2 :
                    try{
                        
                            quantidade = ConsoleUtils.LerInteiro("Quantos livros serão removidos?: ");

                            for(int i = 0; i < quantidade; i++){
                                id = ConsoleUtils.LerInteiro("Digite exatamente o ID do livro que será removido: ");
                                gestorLivraria.RemoverLivros(id);
                            }
                        
                
                    }catch (Exception e){
                        Console.WriteLine(e.Message);
                    }
                break;


                case 3:

                    
                    gestorLivraria.MostrarLista();
                    Console.WriteLine();
                    gestorLivraria.FiltrarLivros();

                break;

              default:

                Console.WriteLine("Saindo!!");
              break;

        
        }

            try{
                Console.WriteLine();
                escolha = ConsoleUtils.LerCaractere("Deseja adicionar/consultar ou remover livros? [y/n]: ");
            }catch (Exception e){
                Console.WriteLine(e.Message);
            }
        
        
        }while(escolha == 'y' || escolha == 'Y');

        Console.WriteLine();
        Console.WriteLine("PROCESSANDO ITENS, AGUARDE...");
        Console.WriteLine("...");
        Console.WriteLine($"STATUS CARRINHO: {Status.PENDENTE}");
        Console.WriteLine();

        
        
        Console.WriteLine("LIVROS COMPRADOS:");
        Console.WriteLine($"TOTAL A PAGAR: R${gestorLivraria.CalcularTotal().ToString("N2")}");

        Console.WriteLine();
        Console.WriteLine($"STATUS CARRINHO: {Status.FINALIZADO}");
        Console.WriteLine("Obrigado por comprar conosco, volte sempre!!");



            Console.ReadKey();
        
            


         

        ;

    }

}
}



