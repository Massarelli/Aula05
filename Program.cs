using Aula05.Models;

// 1. Criar instância da classe conta
var conta1 = new Conta("Maria");

// Confirmar que ela foi criada
conta1.ApresentarDados();

Console.WriteLine("\nTentando sacar um valor maior que o saldo disponível...");
try
{
    conta1.Sacar(10.00m);
}
catch (Exception ex)
{
    // capturando a exceção e exibindo a mensagem de erro
    Console.WriteLine($"Erro: {ex.Message}");
}

Console.WriteLine("\nDepositando um valor positivo...");
try
{
    conta1.Depositar(100.00m);
}
catch (Exception ex)
{
    Console.WriteLine($"Erro: {ex.Message}");
}

Console.WriteLine("\nTentando sacar um valor negativo...");
try
{
    conta1.Sacar(-20.00m);
}
catch (Exception ex)
{
    Console.WriteLine($"Erro: {ex.Message}");
}

Console.WriteLine("\nTentando inativar a conta com saldo disponível...");
try
{
    conta1.InativarConta();
}
catch (Exception ex)
{
    Console.WriteLine($"Erro: {ex.Message}");
}

Console.WriteLine("\nSacando o valor total para zerar o saldo...");
try
{
    conta1.Sacar(100.00m);
}
catch (Exception ex)
{
    Console.WriteLine($"Erro: {ex.Message}");
}

Console.WriteLine("\nInativando a conta...");
try
{
    conta1.InativarConta();
}
catch (Exception ex)
{
    Console.WriteLine($"Erro: {ex.Message}");
}

/*
Para consolidar, veja esse resumo mental do seu processo:

1. O Projeto (A Classe Conta.cs)
É onde você define as regras de existência.

A Base (Atributos): "O que uma conta tem?" (Titular, Saldo).

O Nascimento (Construtor): "O que é obrigatório para ela existir?" (Um nome).

Os Comportamentos (Métodos): "O que ela pode fazer e quais as travas de segurança?" (Depositar, Sacar, Inativar).

2. A Preparação (O topo do Program.cs)
O Endereço (using): Você avisa ao programa: "Vou usar as ferramentas que guardei naquela pasta Models".

3. A Execução (O corpo do Program.cs)
A Instância (new): É o comando que pega o projeto e materializa na memória. Sem o new, a classe é apenas um texto; com o new, ela vira um objeto real que guarda valores.

A Orquestração: Você chama os métodos na ordem que a vida real exige (não dá para sacar antes de depositar, não dá para inativar com dinheiro dentro).

Uma analogia para nunca mais esquecer:
Imagine que você é um engenheiro de uma fábrica de carros:

A Classe: É a planta azul (o desenho técnico). Ela diz que o carro tem 4 rodas e motor, mas você não pode dirigir a planta.

O Construtor: É a linha de montagem. Ela garante que nenhum carro saia da fábrica sem chassi ou motor.

A Instância (new): É o momento em que um carro real sai da fábrica e vai para a sua garagem. Agora ele ocupa um lugar no mundo (memória).

Os Métodos: São os pedais e botões. Você pisa no acelerador (Acelerar()) ou freia (Frear()). Mas se você tentar acelerar sem ligar o carro, ou frear com o carro desligado, o sistema de segurança (as validações) vai impedir que algo ruim aconteça.
*/