namespace Aula05.Models;

public class Conta
{
    // 1. Campos/Propriedades: 
    // Usamos 'public' para que o Program.cs consiga ler esses dados.
    // Usamos 'get; private set;' para que outros arquivos leiam, 
    // mas apenas a classe Conta possa alterar os valores.
    private string Titular;
    private bool StatusConta;
    private decimal Saldo;

    // Construtor: constrói a conta com um titular e define o status e saldo iniciais
    public Conta(string titular)
    {
        if (string.IsNullOrWhiteSpace(titular))
        {
            throw new ArgumentException("O nome do titular não pode ser nulo ou vazio.");
        }

        Titular = titular;
        Saldo = 0.00m;      // Saldo inicial zerado
        StatusConta = true; // Ativa por padrão
    }
    // Métodos: Ações que a conta pode realizar (depositar, sacar, etc.)
    public void Depositar(decimal valor)
    {
        if (valor <= 0 || !StatusConta)
        {
            throw new ArgumentException("O valor do depósito deve ser positivo e a conta deve estar ativa.");
        }

        Saldo += valor;
        Console.WriteLine($"Depósito de {valor:C} realizado com sucesso!");
    }

    public void Sacar(decimal valor)
    {
        // //smell code: muitos critérios de validação em uma única linha, o que pode dificultar a leitura e manutenção do código.
        // if (valor <= 0 || !StatusConta || Saldo < valor)
        // {
        //     throw new ArgumentException("O valor do saque deve ser positivo e maior que o saldo disponível, e a conta deve estar ativa.");
        // }
        if (valor <= 0)
        {
            throw new ArgumentException("O valor do saque deve ser positivo.");
        }
        if (!StatusConta)
        {
            throw new InvalidOperationException("A conta deve estar ativa para realizar saques.");
        }
        if (Saldo < valor)
        {
            throw new InvalidOperationException("Saldo insuficiente para realizar o saque.");
        }

        Saldo -= valor;
        Console.WriteLine($"Saque de {valor:C} realizado com sucesso!");
        Console.WriteLine($"Seu saldo atual é de {Saldo:C}");
    }

    public void InativarConta()
    {
        if (!StatusConta)
        {
            throw new InvalidOperationException("A conta já está inativa.");
        }
        if (Saldo > 0 || Saldo < 0)
        {
            throw new InvalidOperationException("A conta não pode ser inativada enquanto houver saldo disponível ou a conta estiver em débito.");
        }
        StatusConta = false;
        Console.WriteLine("A conta foi inativada.");
    }
    
    public void ApresentarDados()
    {
        Console.WriteLine($"Titular: {Titular}");
        Console.WriteLine($"Saldo: {Saldo:C}");
        Console.WriteLine($"Status da Conta: {(StatusConta ? "Ativa" : "Inativa")}");
    }

    //como o Titular é private temos que retornar por um método para leitura.
    public string RetornarTitular()
    {
        return Titular;
    }
    
    public decimal RetornarSaldo()
    {
        return Saldo;
    }
}



