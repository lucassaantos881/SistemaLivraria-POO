using System;
using System.Collections.Generic;
namespace SistemaLivraria
{

    public class GestorLivraria
    {

        public GestorLivraria()
        {

        }

        public HashSet<Livro> PedidoLivro = new HashSet<Livro>();

        private Dictionary<int, Livro> _livros = new Dictionary<int, Livro>()
        {
            {323, new LivroFisico(323, "Harry Potter e as Reliquias da Morte", 55, "J.K Rowling","DURA", 4) },
            {828, new LivroDigital(828, "Dom Casmurro", 43, "Machado de Assis","PDF" ,3)},
            {451, new LivroDigital(223, "Five Nights at Freddy's", 34, "Scott Cawthon","EPUB" ,1)},
            {534, new LivroFisico(534,"Hamlet", 54, "William Shakespeare","SIMPLES" ,7) },
            {213, new LivroDigital(213, "A Cabana", 54, "William P. Young","PDF" ,5) },
            {101, new LivroFisico(101,"A Culpa é das Estrelas", 54, "John Green","DURA" ,4) }
        }; 

        public void AdicionarLivros(int id, int quantidade)
        {
            
            if (_livros.ContainsKey(id))
            {
                //Analisa se a quantidade inserida pelo usuário é maior que zero e menor ou igual a quantidade existente do ID do livro
                if (quantidade > 0 && quantidade <= _livros[id].Quantidade)
                {
                    _livros[id].Quantidade -= quantidade;
                    PedidoLivro.Add(_livros[id]);


                }else{ 
                    throw new ArgumentException("ERRO: QUANTIDADE MAIOR QUE A DISPONÍVEL");
                
                }
                
            }else {
                throw new ArgumentException("ERRO: ID NÃO CONDIZ COM O ESTOQUE");
            
            }
        }

        public void MostrarCatalogo()
        {

    
            foreach (var item in _livros)
            {
                if (item.Value is LivroFisico fisico)
                {
                    Console.WriteLine();
                    Console.WriteLine($"LIVRO FÍSICO ID: {item.Key}");
                    Console.WriteLine($"NOME: {fisico.Nome.ToUpper()} -- PREÇO: R${fisico.Preco.ToString("N2")} -- AUTOR: {fisico.Autor.ToUpper()} -- TIPO CAPA: {fisico.TipoCapa.ToUpper()} -- QUANTIDADE: {fisico.Quantidade}x");
                    Console.WriteLine();

                } else if (item.Value is LivroDigital digital) {
                    Console.WriteLine();
                    Console.WriteLine($"LIVRO DIGITAL ID: {item.Key}");
                    Console.WriteLine($"NOME: {digital.Nome.ToUpper()} -- PREÇO: R${digital.Preco.ToString("N2")} -- AUTOR: {digital.Autor.ToUpper()} -- FORMATO: {digital.Formato.ToUpper()} -- QUANTIDADE: {digital.Quantidade}x");

                }
            }

            
            
        }

        public void RemoverLivros(int entrada)
        {
            PedidoLivro.RemoveWhere(l => l.Id == entrada);
            
            
        }

        public void ConsultarLivro(int entrada)
        {
            if (_livros.TryGetValue(entrada, out var livro))
            {
                Console.WriteLine("LIVRO ENCONTRADO!!");

                if (livro is LivroFisico f)
                {
                    Console.WriteLine($"NOME: {f.Nome.ToUpper()} -- TIPO: Físico -- CAPA: {f.TipoCapa.ToUpper()} === PREÇO COM FRETE = R${f.CalculoPrecoUnitario().ToString("N2")}");
                
                }
                else if(livro is LivroDigital d){
                    Console.WriteLine($"NOME: {d.Nome.ToUpper()} -- TIPO: Digital -- FORMATO: {d.Formato.ToUpper()} === PREÇO COM DESCONTO = R${d.CalculoPrecoUnitario().ToString("N2")}");
                }
                else
                {
                    throw new ArgumentException("ERRO: ID NÃO ENCONTRADO");
                }
            }
            
        }

        
    }
}
