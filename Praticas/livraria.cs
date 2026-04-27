using System;
using System.Collections.Generic;
using System.Linq.Expressions;
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
                    Console.WriteLine("[4] - CONSULTAR LIVRO POR ID");
                    Console.WriteLine();
                    opcao = ConsoleUtils.LerInteiro("ESCOLHA UMA OPÇÃO: ");
            }
            catch (Exception e){
                Console.WriteLine(e.Message);
            }

            switch (opcao){
                case 1:
                    try{
                            while (escolha == 'y' || escolha == 'Y') {
                                id = ConsoleUtils.LerInteiro("Digite o ID do livro: ");
                                Console.WriteLine();

                                nome = ConsoleUtils.LerString("Digite o nome do livro: ");
                                preco = ConsoleUtils.LerDouble("Digite o preço do livro: ");
                                autor = ConsoleUtils.LerString("Nome do autor: ");
                                quantidade = ConsoleUtils.LerInteiro("Qual a quantidade que será inserida?: ");
                                tipoLivro = ConsoleUtils.LerString("Digite o tipo do livro (FISICO ou DIGITAL): ");


                                if (tipoLivro.ToUpper() == "FISICO")
                                {
                                    Console.WriteLine();
                                    tipoCapa = ConsoleUtils.LerString("Digite o tipo de capa do livro (DURA/SIMPLES): ");
                                    LivroFisico livroFisico = new LivroFisico(id, nome, preco, autor, tipoCapa, quantidade);
                                    gestorLivraria.AdicionarLivros(livroFisico);
                                }
                                else if (tipoLivro.ToUpper() == "DIGITAL")
                                {
                                    Console.WriteLine();
                                    formato = ConsoleUtils.LerString("Digite o formato do livro (PDF/EPUB): ");
                                    LivroDigital livroDigital = new LivroDigital(id, nome, preco, autor, formato, quantidade);
                                    gestorLivraria.AdicionarLivros(livroDigital);
                                }
                                else
                                {
                                    Console.WriteLine("Tipo de livro inválido. POR FAVOR, digite o tipo correto (FISICO ou DIGITAL).");
                                    break;
                                }

                                Console.WriteLine();
                                escolha = ConsoleUtils.LerCaractere("Deseja adicionar mais um livro? [y/n]: ");
                                Console.WriteLine();
                            }

                        }
                        catch (Exception e){
                        Console.WriteLine(e.Message);
                    }


                break;

                case 2 :
                    try{

                       while (escolha == 'y' || escolha == 'Y') {

                                id = ConsoleUtils.LerInteiro("Digite exatamente o ID do livro que será removido: ");
                                gestorLivraria.RemoverLivros(id);

                                Console.WriteLine();
                                escolha = ConsoleUtils.LerCaractere("Deseja remover mais um livro? [y/n]: ");
                                Console.WriteLine();
                            }
                            
                        
                
                    }catch (Exception e){
                        Console.WriteLine(e.Message);
                    }
                break;


                case 3:
                    gestorLivraria.FiltrarLivros();

                break;

                 case 4:
                        id = ConsoleUtils.LerInteiro("Digite exatamente o ID do livro que será consultado: ");
                        gestorLivraria.ConsultarLivro(id);

                        Console.WriteLine();
                        escolha = ConsoleUtils.LerCaractere("Deseja consultar mais um livro? [y/n]: ");
                        Console.WriteLine();

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
     
    }

}
}



