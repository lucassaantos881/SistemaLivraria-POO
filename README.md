# 📚 Sistema de Gestão de Livraria

> Projeto de console em C# focado em Programação Orientada a Objetos e Estruturas de Dados Avançadas.

Este sistema simula o fluxo completo de uma livraria, integrando desde a navegação no catálogo até a gestão logística de pedidos, priorizando performance e boas práticas de engenharia de software.

---

## 🚀 Evolução Técnica: Estruturas de Dados
O projeto utiliza a estrutura ideal para cada necessidade de negócio, otimizando a complexidade computacional:

| Estrutura | Aplicação | Por que? | Complexidade |
| :--- | :--- | :--- | :--- |
| `Dictionary<int, Livro>` | Catálogo | Busca e remoção instantânea via ID. | **O(1)** |
| `Queue<Pedido>` | Fila de Despacho | Ordem de chegada rigorosa (**FIFO**). | **O(1)** |
| `Stack<Pedido>` | Histórico/Undo | Desfazer a última ação (**LIFO**). | **O(1)** |
| `HashSet<Livro>` | Carrinho | Evita duplicidade de itens no mesmo pedido. | **O(1)** |

---

## 🛠️ Funcionalidades

### 👤 Módulo do Cliente
* **Catálogo Dinâmico:** Estoque atualizado em tempo real.
* **Check-out Inteligente:** Cálculo automatizado de frete para livros físicos e descontos para livros digitais via Polimorfismo.

### 👨‍💼 Módulo do Funcionário
* **Gestão de Logística:** Visualização e processamento da fila de pedidos.
* **Sistema de Undo (Ctrl+Z):** Reverte um despacho acidental, movendo o pedido do histórico de volta para a fila ativa.

---

## 🏗️ Conceitos de POO Aplicados

- **Abstração:** Modelagem fiel das entidades de negócio.
- **Herança:** Especialização de `Livro` para `Físico` e `Digital`.
- **Polimorfismo:** Tratamento genérico de tipos de livros no cálculo do total.
- **Encapsulamento:** Proteção de estados e validações de estoque.
- **SRP (Responsabilidade Única):** Classes com funções bem definidas (ex: `Pedido` calcula, `Gestor` organiza).

---

## 💻 Destaque de Código

Exemplo de conversão do