using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace SistemaLivraria
{
    public class Pedido
    {
        public Pedido()
        {
        }

        public int IdPedido { get; set; }
        public DateTime dataPedido { get; set; }
        public string NomeCliente { get; set; }
        public string TelefoneCliente { get; set; }

        public HashSet<Livro> NovoPedidoLivro = new HashSet<Livro>();


        public double CalcularTotalPedido(int qtd)
        {
            double totalDestePedido = 0;
            foreach (var livro in NovoPedidoLivro) // NovoPedidoLivro aqui é o HashSet de livros do pedido
            {
                // O polimorfismo resolve isso! 
                // Se CalculoPrecoUnitario for virtual/override, você nem precisa de 'is' ou 'if'
                totalDestePedido += (livro.CalculoPrecoUnitario() * qtd);
            }
            return totalDestePedido;
        }

    }

}