using System;
namespace SistemaLivraria{

public static class ConsoleUtils{
    
    public static int LerInteiro(string mensagem){
        int tentativas = 0;
        int inteiroValido;

        while (tentativas < 3){
            Console.Write(mensagem);
            // Lê e, se for nulo, vira string vazia para a validação barrar
            string entrada = Console.ReadLine() ?? "";

            if (int.TryParse(entrada,out inteiroValido) && inteiroValido >= 0){
                return inteiroValido;
            }

            tentativas++;
            Console.WriteLine($"Valor incorreto, tente novamente ({3 - tentativas} restantes)");
        }
        
        throw new ArgumentException("ERRO: Entrada digitadas incorretamente repetidas vezes, tente novamente mais tarde!!");
        
    }

     public static double LerDouble(string mensagem){
        int tentativas = 0;
        double decimalValido;

        while (tentativas < 3){
            Console.Write(mensagem);
            string entrada = Console.ReadLine()!;

            if (double.TryParse(entrada,out decimalValido) && decimalValido >= 0){
                return decimalValido;
            }

            tentativas++;
            Console.WriteLine($"Valor incorreto, tente novamente ({3 - tentativas} restantes)");
        }
        
        throw new ArgumentException("ERRO: Entrada digitadas incorretamente repetidas vezes, tente novamente mais tarde!!");
        
    }

    public static string LerString(string mensagem){
        int tentativas = 0;

        while (tentativas < 3){
            Console.Write(mensagem);
            // Lê e, se for nulo, vira string vazia para a validação barrar
            string entrada = Console.ReadLine() ?? "";

            //-----Valida se a entrada é nula, vazia ou somente com espaços
            if (!string.IsNullOrWhiteSpace(entrada)){
                return entrada;
            }

            tentativas++;
            Console.WriteLine($"Valor incorreto, tente novamente ({3 - tentativas} restantes)");

        }     

        throw new ArgumentException("ERRO: Entrada digitadas incorretamente repetidas vezes, tente novamente mais tarde!!");

    }

    public static char LerCaractere(string mensagem){
        int tentativas = 0;
        char caractereValido;

        while (tentativas < 3){
            Console.Write(mensagem);
            string entrada = Console.ReadLine()!;

            
            if (char.TryParse(entrada, out caractereValido)){
                return caractereValido;
            }

            tentativas++;
            Console.WriteLine($"Valor incorreto, tente novamente ({3 - tentativas} restantes)");

        }     

        throw new ArgumentException("ERRO: Entrada digitadas incorretamente repetidas vezes, tente novamente mais tarde!!");
      
    }

    
}
}