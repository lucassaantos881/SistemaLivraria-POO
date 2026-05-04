using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Runtime.InteropServices;

namespace SistemaLivraria
{

    class Livraria
    {

        static void Main()
        {

            int quantidade = 0;
            int id;
            char escolha = 'y';
            bool sistemaRodando = true;

            string funcionario = "admin";
            int senhaFuncionario = 12345;

            string cliente = "cliente";
            int senhaCliente = 12345678;

            string login = string.Empty;
            int senha = 0;



            Pedido pedido = new Pedido();
            GestorPedido gp = new GestorPedido();
            GestorLivraria gestorLivraria = new GestorLivraria();

            while (sistemaRodando)
            {
                try
                {
                    Console.WriteLine();
                    login = ConsoleUtils.LerString("Digite o nome do usuário: ");
                    senha = ConsoleUtils.LerInteiro("Digite a senha: ");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                if (login == cliente && senha == senhaCliente)
                {
                    do
                    {

                        ///LÓGICA CARRINHO CLIENTE!!!
                        
                        do
                        {
                            int opcaoCliente = 0;

                            gestorLivraria.MostrarCatalogo();

                            Console.WriteLine();

                            try
                            {

                                Console.WriteLine();
                                Console.WriteLine("BEM VINDO A SEÇÃO DE LIVROS, SELECIONE UMA DAS OPÇÕES!!");
                                Console.WriteLine("[1] - ADICIONAR LIVROS");
                                Console.WriteLine("[2] - REMOVER LIVROS");
                                Console.WriteLine("[3] - CONSULTAR LIVRO POR ID");
                                Console.WriteLine();
                                opcaoCliente = ConsoleUtils.LerInteiro("ESCOLHA UMA OPÇÃO: ");
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }

                            switch (opcaoCliente)
                            {

                                case 1:

                                    try
                                    {

                                        id = ConsoleUtils.LerInteiro("Digite o ID do livro: ");
                                        Console.WriteLine();

                                        quantidade = ConsoleUtils.LerInteiro("Qual a quantidade que será inserida?: ");

                                        gestorLivraria.AdicionarLivros(id, quantidade);

                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine(ex.Message);
                                    }



                                    break;

                                case 2:

                                    try
                                    {

                                        id = ConsoleUtils.LerInteiro("Digite exatamente o ID do livro que será removido: ");
                                        gestorLivraria.RemoverLivros(id);


                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine(ex.Message);
                                    }

                                    break;


                                case 3:
                                    try
                                    {
                                        id = ConsoleUtils.LerInteiro("Digite exatamente o ID do livro que será consultado: ");
                                        gestorLivraria.ConsultarLivro(id);
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine(ex.Message);
                                    }

                                    break;

                                default:

                                    Console.WriteLine("Saindo!!");

                                    break;


                            }

                            try
                            {
                                Console.WriteLine();
                                escolha = ConsoleUtils.LerCaractere("Deseja realizar nova consulta em seu pedido? [y/n]: ");
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }


                        } while (escolha == 'y' || escolha == 'Y');
                        int idConta = 0;
                        string nomeCliente = string.Empty;
                        string numeroTelefone = string.Empty;

                        try
                        {
                            Console.WriteLine();
                            idConta = ConsoleUtils.LerInteiro("Digite o id da conta: ");
                            nomeCliente = ConsoleUtils.LerString("Digite o seu nome: ");
                            numeroTelefone = ConsoleUtils.LerString("Digite o seu número de telefone: ");
                            Console.WriteLine();
                            escolha = ConsoleUtils.LerCaractere("DESEJA FINALIZAR SEU PEDIDO? (APÓS CONFIRMAÇÃO, SÓ É POSSÍVEL CANCELAR APÓS ENTREGA) [y/n]: ");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }


                        if (escolha == 'y' || escolha == 'Y')
                        {
                            gp.AdicionarPedido(gestorLivraria, idConta, nomeCliente, numeroTelefone);

                        }

                        Console.WriteLine("...");
                        Console.WriteLine($"STATUS CARRINHO: {Status.PENDENTE}");
                        gp.MostrarPedido(quantidade);
                        Console.WriteLine();
                        Console.WriteLine("-------------------------------");
                        Console.WriteLine("PAGAMENTO CONCLUÍDO!! AGUARDE O ENVIO...");

                        Console.WriteLine();
                        Console.WriteLine($"STATUS CARRINHO: {Status.PROCESSANDO_PEDIDO}");
                        Console.WriteLine("Obrigado por comprar conosco, volte sempre!!");

                        try
                        {
                            Console.WriteLine();
                            escolha = ConsoleUtils.LerCaractere("Deseja adicionar um novo pedido? [y/n]: ");
                            Console.WriteLine("SAINDO!!");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }

                    } while (escolha == 'y' || escolha == 'Y');

                }
                else if (login == funcionario && senha == senhaFuncionario)
                {
                    try
                    {
                        do
                        {
                            Console.WriteLine();
                            Console.WriteLine("BEM VINDO A SEÇÃO DE LIVROS, SELECIONE UMA DAS OPÇÕES!!");
                            Console.WriteLine("[1] - CONSULTAR PEDIDOS PENDENTES");
                            Console.WriteLine("[2] - DESPACHAR PEDIDOS");
                            Console.WriteLine();
                        
                            Console.WriteLine();
                            int opcaoFuncionario = ConsoleUtils.LerInteiro("ESCOLHA UMA OPÇÃO: ");

                            switch (opcaoFuncionario)
                            {
                                case 1:

                                    gp.PedidosPendentes();

                                    Console.WriteLine();
                                    escolha = ConsoleUtils.LerCaractere("Os pedidos estão corretos? [y/n]: ");


                                    break;

                                case 2:

                                    gp.DespacharPedido();

                                    Console.WriteLine();
                                    char desfazer = ConsoleUtils.LerCaractere("TEM CERTEZA QUE DESEJA DESFAZER ÚLTIMO DESPACHE? [y/n]: ");
                                    if (desfazer == 'y' || desfazer == 'Y')
                                    {
                                        senhaFuncionario = ConsoleUtils.LerInteiro("DIGITE A SENHA PARA CONFIRMAR: ");
                                        gp.DesfazerDespacho();
                                    }

                                    break;
                            }

                            Console.WriteLine();
                            escolha = ConsoleUtils.LerCaractere("DESEJA REALIZAR NOVA CONSULTA? [y/n]: ");
                            
                        } while (escolha == 'y' || escolha == 'Y');

                        Console.WriteLine();
                        escolha = ConsoleUtils.LerCaractere("Deseja realizar novo login? [y/n]: ");
                        if (escolha == 'n' || escolha == 'N')
                        {
                            sistemaRodando = false;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                Console.ReadKey();



            }
        }
    }
}


