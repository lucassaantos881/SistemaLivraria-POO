# 📚 Sistema de Gestão de Livraria

Este é um projeto de console desenvolvido em **C#** que simula o fluxo de um carrinho de compras de uma livraria, aplicando conceitos fundamentais de Programação Orientada a Objetos.

## 🛠️ Tecnologias e Conceitos Aplicados
- **C# / .NET 8**
- **Herança e Abstração:** Classe base `Produto` e classe derivada `Livro`.
- **Encapsulamento:** Uso de propriedades com validação (`get`/`set`) para evitar preços negativos.
- **Coleções Genéricas:** Gerenciamento de dados com `List<T>`.
- **Tratamento de Exceções:** Uso de `try-catch` para garantir que o programa não feche em caso de erros de entrada.

## 🚀 Destaque Técnico: Remoção Segura de Itens
Um dos desafios deste projeto foi a remoção de itens de uma lista durante a iteração. Implementei uma lógica de **percorrer a lista em ordem reversa** (do último índice para o primeiro). 

Isso garante que, ao remover um item, o deslocamento dos índices dos elementos restantes não afete a integridade do loop, evitando erros de "Index Out of Range".

```csharp
// Exemplo da lógica utilizada:
for(int i = livros.Count - 1; i >= 0; i--) {
    if (entrada == livros[i].Nome) {
        livros.RemoveAt(i);
    }
}