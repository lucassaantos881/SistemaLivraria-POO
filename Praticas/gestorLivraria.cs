using System;
namespace SistemaLivraria
{

    public class GestorLivraria
    {

        public GestorLivraria()
        {

        }

        private Dictionary<int, Livro> _livros = new Dictionary<int, Livro>(); 

        public void AdicionarLivros(Livro newLivro)
        {
            if (!_livros.ContainsKey(newLivro.Id))
            {
                _livros.Add(newLivro.Id, newLivro);
            }else {
                throw new ArgumentException("ERRO: ID JÁ EXISTE!!");
            
            }
        }

        public void FiltrarLivros()
        {

    
            foreach (var item in _livros.Values)
            {
                if (item is LivroFisico fisico)
                {
                    Console.WriteLine($"LIVRO FÍSICO ID: {fisico.Id}");
                    Console.WriteLine($"NOME: {fisico.Nome.ToUpper()} -- PREÇO: R${fisico.Preco.ToString("N2")} -- AUTOR: {fisico.Autor.ToUpper()} -- TIPO CAPA: {fisico.TipoCapa.ToUpper()} -- QUANTIDADE: {fisico.Quantidade}x === PREÇO COM FRETE: {fisico.CalcularTotal().ToString("N2")}");
                    Console.WriteLine();

                } else if (item is LivroDigital digital) {
                    Console.WriteLine($"LIVRO DIGITAL ID: {digital.Id}");
                    Console.WriteLine($"NOME: {digital.Nome.ToUpper()} -- PREÇO: R${digital.Preco.ToString("N2")} -- AUTOR: {digital.Autor.ToUpper()} -- FORMATO: {digital.Formato.ToUpper()} -- QUANTIDADE: {digital.Quantidade}x === PREÇO COM DESCONTO: {digital.CalcularTotal().ToString("N2")}");

                }
            }

            
            
        }

        public void RemoverLivros(int entrada)
        {
            if (_livros.Remove(entrada))
            {
                Console.WriteLine($"LIVRO: {entrada} REMOVIDO COM SUCESSO!!!");
            }
            else
            {
                throw new ArgumentException("ERRO: LIVRO NÃO LOCALIZADO, NÃO FOI POSSÍVEL REMOVER!!");
            }
            
            
        }

        public void ConsultarLivro(int entrada)
        {
            if (_livros.TryGetValue(entrada, out var livro))
            {
                Console.WriteLine("LIVRO ENCONTRADO!!");

                if (livro is LivroFisico f)
                {
                    Console.WriteLine($"NOME: {f.Nome.ToUpper()} -- TIPO: Físico -- CAPA: {f.TipoCapa.ToUpper()} === PREÇO COM FRETE = R${f.CalcularTotal().ToString("N2")}");
                
                }
                else if(livro is LivroDigital d){
                    Console.WriteLine($"NOME: {d.Nome.ToUpper()} -- TIPO: Digital -- FORMATO: {d.Formato.ToUpper()} === PREÇO COM DESCONTO = R${d.CalcularTotal().ToString("N2")}");
                }
                else
                {
                    throw new ArgumentException("ERRO: ID NÃO ENCONTRADO");
                }
            }
            
        }

        public double CalcularTotal()
        {
        
            double totalDigital = 0, totalFisico = 0;
     
            foreach (var item in _livros.Values)
            {
                if (item is LivroDigital digital)
                {
                    totalDigital += (digital.CalcularTotal());
                }else if (item is LivroFisico fisico)
                {
                    totalFisico += (fisico.CalcularTotal());
                }
            }

            return totalDigital + totalFisico;




         }
    }
}
