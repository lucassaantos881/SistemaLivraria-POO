using System;
namespace SistemaLivraria
{

    public class GestorLivraria
    {

        public GestorLivraria()
        {

        }

        private List<Livro> livros = new List<Livro>();

        public void AdicionarLivros(Livro newLivro)
        {
            livros.Add(newLivro);
        }

        public void FiltrarLivros()
        {

            //Cria duas listas, e utiliza o método OfType para filtrar os livros físicos e digitais, depois exibe cada uma das listas usando o foreach.
            var listaLivrosFisicos = livros.OfType<LivroFisico>().ToList();
            var listaLivrosDigitais = livros.OfType<LivroDigital>().ToList();
            Console.WriteLine("LIVROS FÍSICOS:");
            foreach (var livroFisico in listaLivrosFisicos)
            {
                Console.WriteLine($"ID:{livroFisico.Id},{livroFisico.Nome.ToUpper()}, R${livroFisico.Preco.ToString("N2")}, {livroFisico.Autor.ToUpper()}, {livroFisico.TipoCapa.ToUpper()}, Valor com Frete: R${livroFisico.CalcularTotal().ToString("N2")}");
            }
            Console.WriteLine();
            Console.WriteLine("\nLIVROS DIGITAIS:");
            foreach (var livroDigital in listaLivrosDigitais)
            {
                Console.WriteLine($"ID: {livroDigital.Id},{livroDigital.Nome.ToUpper()}, R${livroDigital.Preco.ToString("N2")}, {livroDigital.Autor.ToUpper()}, {livroDigital.Formato.ToUpper()}, Valor com Desconto: R${livroDigital.CalcularTotal().ToString("N2")}");
            }
        }

        public void RemoverLivros(int entrada)
        {

            //Percorre a lista do último índice até o primeiro e valida se a entrada é igual ao índice i referente ao nome que está na lista
            for (int i = livros.Count - 1; i >= 0; i--)
            {
                if (entrada == livros[i].Id)
                {
                    livros.RemoveAt(i);
                }
            }
        }

        public void MostrarLista()
        {
            foreach (var listaCompleta in livros)
            {
                Console.WriteLine($"ID: {listaCompleta.Id}, {listaCompleta.Nome.ToUpper()}, R${listaCompleta.Preco.ToString("N2")}, {listaCompleta.Autor.ToUpper()}");
            }
        }

        public double CalcularTotal()
        {
            double valorFinal = 0;
            double totalFisico = 0;
            double totalDigital = 0;

            var listaLivrosFisicos = livros.OfType<LivroFisico>().ToList();
            var listaLivrosDigitais = livros.OfType<LivroDigital>().ToList();

            foreach (var livroFisico in listaLivrosFisicos)
            {
                totalFisico += livroFisico.CalcularTotal();

            }

            foreach (var livroDigital in listaLivrosDigitais)
            {
                totalDigital += livroDigital.CalcularTotal();
                
            }

            valorFinal = totalFisico + totalDigital;

            return valorFinal;



        }
    }
}