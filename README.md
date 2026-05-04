📚 Sistema de Gestão de Livraria (C# / POO & Estruturas de Dados)
Este projeto é um sistema de console robusto desenvolvido em C# que simula o fluxo completo de uma livraria, desde a navegação no catálogo até o processamento de pedidos e gestão de despacho. O foco principal é a aplicação prática de Programação Orientada a Objetos (POO) aliada a estruturas de dados avançadas para otimização de performance e fluxo de trabalho.

🚀 Evolução Técnica: Estruturas de Dados Avançadas
O projeto evoluiu de uma lista simples para uma arquitetura que utiliza a estrutura de dados correta para cada necessidade de negócio, garantindo escalabilidade e eficiência.

🧠 Estruturas Aplicadas e Porquês:
Dictionary<int, Livro> (O catálogo): Busca e remoção de itens com complexidade O(1) (tempo constante) via ID único.

Queue<Pedido> (A Fila de Despacho): Implementação da lógica FIFO (First-In, First-Out) para garantir que os pedidos sejam processados na ordem correta de chegada.

Stack<Pedido> (Histórico de Desfazer): Aplicação do conceito LIFO (Last-In, First-Out) para permitir que o funcionário desfaça o último despacho realizado (mecanismo de Undo).

HashSet<Livro> (O Carrinho): Utilizado para garantir que o carrinho de um pedido não contenha duplicatas de referências de objetos, otimizando a integridade dos dados.

🛠️ Funcionalidades e Fluxos
👤 Módulo do Cliente
Catálogo Persistente: O estoque é mantido vivo entre diferentes sessões de login, atualizando em tempo real após cada venda.

Check-out Inteligente: O cálculo do total é encapsulado na classe Pedido, respeitando as regras de livros Físicos (frete) e Digitais (descontos).

👨‍💼 Módulo do Funcionário
Gestão de Fila: Visualização e processamento (despacho) dos pedidos pendentes.

Sistema de Undo (Ctrl+Z): Capacidade de desfazer um despacho acidental, movendo o pedido da Pilha de histórico de volta para a Fila de pendentes.

💻 Destaques de Código
Encapsulamento e Polimorfismo
O sistema utiliza polimorfismo para tratar diferentes tipos de livros sem a necessidade de múltiplos if/else no cálculo final. Abaixo, o método no Gestor de Pedidos que consolida o carrinho em um objeto Pedido e o insere na fila:

C#
// Instanciação e conversão do carrinho temporário em um Pedido definitivo
Pedido p = new Pedido();

p.IdPedido = id;
p.dataPedido = DateTime.Now;
p.NomeCliente = nome;
p.TelefoneCliente = numeroTelefone;

// Snapshot do carrinho: criamos uma nova coleção baseada no estado atual
p.NovoPedidoLivro = new HashSet<Livro>(gl.PedidoLivro);

// Limpeza do carrinho global para o próximo atendimento
gl.PedidoLivro.Clear();

// Entrada na fila de logística (FIFO)
filaPedidos.Enqueue(p);
🏗️ Conceitos de POO Aplicados
Abstração: Modelagem fiel de entidades do mundo real.

Herança: Especialização de produtos (Livro -> Físico/Digital).

Encapsulamento: Proteção de estados e validações de estoque.

Responsabilidade Única (SRP): Cada classe cuida apenas do que lhe compete (O Pedido calcula seu total, o Gestor organiza a fila).

⚙️ Como Executar
Clone o repositório.

Abra o arquivo .sln no Visual Studio ou VS Code.

Execute o projeto e utilize as credenciais configuradas no Main (admin / cliente) para testar os diferentes fluxos.