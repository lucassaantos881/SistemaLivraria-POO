# 📚 Sistema de Gestão de Livraria (C# / POO)

Este projeto é um sistema de console robusto desenvolvido em **C#** que simula o fluxo de um carrinho de compras de uma livraria. O objetivo principal foi aplicar os pilares da **Programação Orientada a Objetos (POO)** em um cenário real.

## 🚀 Evolução Técnica e Refatoração

Recentemente, o projeto passou por uma grande refatoração. Saímos de uma lógica linear para uma arquitetura baseada em classes, permitindo que o sistema seja facilmente escalável.

### 🧠 Conceitos de POO Aplicados:
* **Abstração e Herança:** Criação de uma classe base `Produto` e classes derivadas especializadas como `LivroFisico` e `LivroDigital`.
* **Polimorfismo:** Implementação de métodos sobrescritos (`override`) para calcular o total da compra. O sistema decide automaticamente se aplica **taxa de frete** (Físico) ou **desconto promocional** (Digital).
* **Encapsulamento:** Uso de propriedades com validações para garantir a integridade dos dados (como preços e quantidades).
* **Coleções Genéricas:** Uso de `List<T>` e LINQ (`OfType`) para filtragem e manipulação eficiente dos itens.

## 🛠️ Funcionalidades

- [x] **Adição Dinâmica:** Cadastro de livros físicos e digitais com atributos específicos.
- [x] **Remoção Segura:** Exclusão de itens da lista via **ID único**, utilizando iteração reversa para manter a integridade dos índices.
- [x] **Processamento de Checkout:** Simulação de status do pedido (Pendente -> Finalizado) com cálculo automático de impostos e descontos.
- [x] **Listagem de Itens:** Exibição detalhada dos livros no carrinho, incluindo informações específicas de cada tipo.
- [ ] **Futuro:** Implementação de persistência de dados (banco de dados ou arquivos) para manter o histórico de compras.

## 💻 Exemplo de Código (Destaque)

Para evitar o erro de `Index Out of Range` ao remover itens, utilizei a lógica de percorrer a lista de trás para frente:

```csharp
// Remoção segura por ID
for (int i = livros.Count - 1; i >= 0; i--) {
    if (entradaId == livros[i].Id) {
        livros.RemoveAt(i);
    }
}