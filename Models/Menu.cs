using System.ComponentModel;
using System.Linq;
// using System.Runtime.CompilerServices; // Obrigatório para o FirstOrDefault funcionar

namespace Aula05.Models;



public class Menu
{

    private List<Conta> Contas;

    public Menu()
    {
        Contas = new List<Conta>();
    
        // // ... captura o nome do titular (na real seria CPF)
        // Console.Write("Digite o nome do titular para buscar: ");
        // string busca = Console.ReadLine() ?? "";

        // // O 'c' representa cada 'Conta' dentro da sua lista 'Contas'
        // Conta? contaEncontrada = Contas.FirstOrDefault(c => c.RetornarTitular() == busca);

        // if (contaEncontrada != null)
        // {
        //     Console.WriteLine($"Conta encontrada! Saldo: {contaEncontrada.RetornarSaldo():C}");
        // }
        // else
        // {
        //     Console.WriteLine("Titular não encontrado na lista.");
        // }
    }

    private Conta? BuscarContaPorTitular(string titular)
    {
        for(int indice = 0; indice < Contas.Count(); indice++)
        {
            if(Contas[indice].RetornarTitular() == titular)
            {
                return Contas[indice];
            }
        }
        return null;
    }
    public void CriarNovaConta()
    {
        Console.WriteLine();
        Console.WriteLine("##################");
        Console.WriteLine("Criação de contas ");
        Console.WriteLine("##################");
        Console.WriteLine();

        Console.WriteLine("Para continuar, informe os dados abaixo: ");
        Console.WriteLine("Nome do titular: ");
        string input = Console.ReadLine() ?? string.Empty;

        try
        {
            Conta conta = new Conta(input);
            Contas.Add(conta);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
            return;
        }

        Console.WriteLine();
        Console.WriteLine("Conta criada com sucesso!");
        Console.WriteLine();
    }

    public void DepositarValores()
    {
        Console.WriteLine();
        Console.WriteLine("##################");
        Console.WriteLine("Depositar valores ");
        Console.WriteLine("##################");
        Console.WriteLine();

        Console.WriteLine("Informe o valor para o depósito: ");
        string input = Console.ReadLine() ?? string.Empty;
        decimal valorADepositar = decimal.Parse(input);

        Console.WriteLine("Informe o titular da conta: ");
        input = Console.ReadLine() ?? string.Empty;

        Conta? contaEncontrada = BuscarContaPorTitular(input);

        if(contaEncontrada == null)
        {
            Console.WriteLine();
            Console.WriteLine("Titular não encontrado na lista.");
            return;
        }

        try
        {
            contaEncontrada.Depositar(valorADepositar);
        }
        catch(ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
            return;
        }

        contaEncontrada.Depositar(valorADepositar);
        Console.WriteLine("Depósito realizado com sucesso!");
        contaEncontrada.ApresentarDados();
    }

    public void SacarValores()
    {
        Console.WriteLine();
        Console.WriteLine("##################");
        Console.WriteLine("   Sacar valores  ");
        Console.WriteLine("##################");
        Console.WriteLine();

        // 1. Pedimos o titular primeiro para validar a existência da conta
        Console.WriteLine("Informe o titular da conta: ");
        string inputNome = Console.ReadLine() ?? string.Empty;

        Conta? contaEncontrada = BuscarContaPorTitular(inputNome);

        if (contaEncontrada == null)
        {
            Console.WriteLine();
            Console.WriteLine("Titular não encontrado na lista.");
            return;
        }

        // 2. Se encontrou, pedimos o valor do saque
        Console.WriteLine($"Saldo disponível: {contaEncontrada.RetornarSaldo():C}");
        Console.WriteLine("Informe o valor para o saque: ");
        string inputValor = Console.ReadLine() ?? string.Empty;
        decimal valorASacar = decimal.Parse(inputValor);

        try
        {
            // 3. Chamamos o método Sacar da classe Conta
            // O bloco try vai capturar se o valor for negativo ou maior que o saldo
            contaEncontrada.Sacar(valorASacar); 
            
            Console.WriteLine();
            Console.WriteLine("Saque realizado com sucesso!");
            contaEncontrada.ApresentarDados();
        }
        catch (FormatException)
        {
            Console.WriteLine("Erro: O valor informado deve ser numérico.");
        }
        catch (ArgumentException ex)
        {
            // Captura as regras de negócio (saldo insuficiente, valor negativo, etc)
            Console.WriteLine();
            Console.WriteLine($"Erro na operação: {ex.Message}");
        }
        
        Console.WriteLine();
    }

    public void ListarContasCriadas()
    {
        Console.WriteLine();
        Console.WriteLine("##################");
        Console.WriteLine("   Listar contas  ");
        Console.WriteLine("##################");
        Console.WriteLine();

        for(int index=0; index < Contas.Count; index++)
        {
            Console.WriteLine($"Conta {index + 1}:");
            Contas[index].ApresentarDados();
            Console.WriteLine();
        }
    }
        public void InativarConta()
    {
        Console.WriteLine();
        Console.WriteLine("##################");
        Console.WriteLine("   Inativar conta  ");
        Console.WriteLine("##################");
        Console.WriteLine();

        // 1. Pedimos o titular primeiro para validar a existência da conta
        Console.WriteLine("Informe o titular da conta: ");
        string inputNome = Console.ReadLine() ?? string.Empty;

        Conta? contaEncontrada = BuscarContaPorTitular(inputNome);

        if (contaEncontrada == null)
        {
            Console.WriteLine();
            Console.WriteLine("Titular não encontrado na lista.");
            return;
        }

        try
        {
            contaEncontrada.InativarConta();
            Console.WriteLine();
            Console.WriteLine("Conta inativada com sucesso!");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine();
            Console.WriteLine($"Erro na operação: {ex.Message}");
        }
    }

}




    
    // public void DepositarValores()
    // {
    // Console.Clear();
    // Console.WriteLine("--- Operação de Depósito ---");

    // Console.Write("Informe o nome do titular: ");
    // string titular = Console.ReadLine() ?? "";

    // // 1. Localiza a conta na lista do Menu
    // var conta = _contas.FirstOrDefault(c => c.Titular == nome);

    // if (conta == null)
    // {
    //     Console.WriteLine("Erro: Titular não encontrado.");
    //     return;
    // }

    // // 2. Pergunta o valor
    // Console.Write("Valor do depósito: ");
    // if (decimal.TryParse(Console.ReadLine(), out decimal valor))
    // {
    //     try 
    //     {
    //         // 3. CHAMA o método que você criou em Conta.cs
    //         conta.Depositar(valor); 
    //     }
    //     catch (ArgumentException ex)
    //     {
    //         // O Menu captura o erro que o seu método disparou (throw)
    //         Console.WriteLine($"Erro na operação: {ex.Message}");
    //     }
    // }
    // else
    // {
    //     Console.WriteLine("Valor inválido.");
    // }
    
    // Console.ReadKey();
    // }

}
