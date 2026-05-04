using System;
namespace SistemaLivraria { 
	public class GestorPedido
	{
		public GestorPedido()
		{
		}

		private Queue<Pedido> filaPedidos = new Queue<Pedido>();
        private Stack<Pedido> desfazerDespacho = new Stack<Pedido>();
       
        public void AdicionarPedido(GestorLivraria gl, int id, string nome, string numeroTelefone)
        {
            

            Pedido p = new Pedido();
            p.IdPedido = id;
            p.dataPedido = DateTime.Now;
            p.NomeCliente = nome;
            p.TelefoneCliente = numeroTelefone;
            p.NovoPedidoLivro = new HashSet<Livro>(gl.PedidoLivro);
            gl.PedidoLivro.Clear();
            filaPedidos.Enqueue(p);

            
        }

        public void PedidosPendentes()
        {
            Console.WriteLine("CONSULTA FILA PEDIDOS");
            foreach (var item in filaPedidos)
            {
                if (filaPedidos.Count() > 0)
                {
                    Console.WriteLine($"ID CLIENTE: {item.IdPedido} -- DATA PEDIDO: {item.dataPedido} -- NOME CLIENTE: {item.NomeCliente.ToUpper()}");
                    Console.WriteLine("-------------------------------------------------");
                }
                
            }

        }

        public void DesfazerDespacho()
        {

            if (desfazerDespacho.Count() > 0)
            {

                var pedidoRecuperado = desfazerDespacho.Pop();
                Console.WriteLine($"DESPACHO DESFEITO!!");
                filaPedidos.Enqueue(pedidoRecuperado);
            }
            else
            {
                Console.WriteLine("NADA PARA DESFAZER");
            }
            
        }



        public void DespacharPedido()
		{

            Console.WriteLine("DESPACHANDO PEDIDO");
            while (filaPedidos.Count > 0) {
                var pedidoDespachado = filaPedidos.Dequeue();
                desfazerDespacho.Push(pedidoDespachado);

                DateTime dataAtual = DateTime.Now;
                Console.WriteLine($"PEDIDO: {pedidoDespachado.IdPedido} DESPACHADO ÀS {dataAtual}!");
                Console.WriteLine("-------------------------------------------------");
            }
            
		}

       

        public void MostrarPedido(int quantidade)
        {
            foreach (var pedido in filaPedidos)
            {
                Console.WriteLine($"---ID CONTA: {pedido.IdPedido}----");
                Console.WriteLine($"---PEDIDO DE: {pedido.NomeCliente.ToUpper()}----");
                Console.WriteLine($"---DATA DO PEDIDO: {pedido.dataPedido}----");
                Console.WriteLine($"---NÚMERO TELEFONE: {pedido.TelefoneCliente}");
                Console.WriteLine();
                
                double total = pedido.CalcularTotalPedido(quantidade);
                Console.WriteLine($"Total do Pedido {pedido.IdPedido}: R$ {total:N2}");

                foreach (var livro in pedido.NovoPedidoLivro)
                {
                    

                    if (livro is LivroDigital digital)
                    {
                        Console.WriteLine($"ID LIVRO: {digital.Id} -- NOME LIVRO: {digital.Nome.ToUpper()} -- AUTOR: {digital.Autor.ToUpper()} -- PREÇO COM DESCONTO: R${digital.CalculoPrecoUnitario()} -- FORMATO: {digital.Formato} -- QUANTIDADE: {quantidade}x");
                    }
                    else if (livro is LivroFisico fisico)
                    {
                        Console.WriteLine($"ID LIVRO: {fisico.Id} -- NOME LIVRO: {fisico.Nome.ToUpper()} -- AUTOR: {fisico.Autor.ToUpper()}  -- PREÇO COM FRETE: R${fisico.CalculoPrecoUnitario()} -- CAPA: {fisico.TipoCapa} -- QUANTIDADE: {quantidade}x");
                    }

                    
                }

                
                   


    }
        }




    }

}