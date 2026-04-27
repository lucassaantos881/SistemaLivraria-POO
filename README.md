# 📚 Sistema de Gestão de Livraria (C# / POO & Performance)

Este projeto é um sistema de console robusto desenvolvido em **C#** que simula o fluxo de um carrinho de compras de uma livraria. O foco principal é a aplicação prática de **Programação Orientada a Objetos (POO)** aliada a **estruturas de dados eficientes**.

## 🚀 Evolução Técnica e Refatoração (Dictionary & Performance)

Recentemente, o projeto passou por uma profunda refatoração estrutural. Substituímos o uso de listas lineares por um **Dicionário (`Dictionary<int, T>`)**, transformando a busca e remoção de itens em operações de **complexidade O(1)** (tempo constante).

### 🧠 Conceitos de POO e Estruturas Aplicados:
* **Abstração e Herança:** Classes base e derivadas para representar diferentes tipos de produtos.
* **Polimorfismo:** Métodos sobrescritos para cálculos automáticos de frete (Físico) e descontos (Digital).
* **Encapsulamento Avançado:** Propriedades com lógica de validação (`throw new ArgumentException`) para proteger o estado dos objetos.
* **Performance com Dictionary:** Uso de chaves únicas (ID) para acesso instantâneo aos dados, eliminando laços de repetição desnecessários em buscas.
* **Pattern Matching:** Uso de `is` com variáveis temporárias para filtragem de tipos de forma segura e moderna.

## 🛠️ Funcionalidades

- [x] **Adição Inteligente:** Cadastro via Dicionário, garantindo que não existam IDs duplicados no sistema.
- [x] **Busca Instantânea:** Consulta de livros por ID utilizando `TryGetValue`, garantindo performance máxima.
- [x] **Remoção de Alta Performance:** Exclusão de itens via chave única, sem necessidade de percorrer toda a coleção ou usar iteração reversa.
- [x] **Processamento de Checkout:** Cálculo automático do total considerando as regras de negócio de cada tipo de livro.
- [x] **Listagem Filtrada:** Exibição detalhada separando livros físicos de digitais em tempo de execução.

## 💻 Destaque Técnico: Busca e Remoção O(1)

Com a migração para `Dictionary`, o sistema ganhou em escalabilidade. A recuperação de dados agora é direta pela chave:

```csharp
// Exemplo de busca instantânea (O desafio superado)
if (_livros.TryGetValue(idBuscado, out var livro)) 
{
    Console.WriteLine($"Livro encontrado: {livro.Nome}");
}
else 
{
    Console.WriteLine("ID não localizado.");
}

// Remoção direta por chave única
_livros.Remove(idParaRemover);