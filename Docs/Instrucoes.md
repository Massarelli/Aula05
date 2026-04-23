Para visualização rápida ctrl+shift+v

from weasyprint import HTML

# Conteúdo do Markdown
markdown_content = """# Resumo de Lógica: Orientação a Objetos (Aula 05)

Este documento consolida o fluxo de trabalho e o raciocínio lógico utilizados na construção do programa de Gerenciamento de Contas.

---

## 1. O Projeto (A Classe `Conta.cs`)
É onde você define as **regras de existência** do objeto.

* **A Base (Atributos/Propriedades):** "O que uma conta tem?". No nosso caso: *Titular*, *Saldo* e *Status*.
* **O Nascimento (Construtor):** "O que é obrigatório para ela existir?". Definimos que uma conta não nasce sem um *Titular*.
* **Os Comportamentos (Métodos):** "O que ela pode fazer e quais as travas de segurança?". 
    * `Depositar()`: Só aceita valores positivos e conta ativa.
    * `Sacar()`: Verifica saldo disponível e status da conta.
    * `InativarConta()`: Impede o fechamento se houver saldo ou pendências.

## 2. A Preparação (O topo do `Program.cs`)
* **O Endereço (`using`):** Você avisa ao programa: *"Vou usar as ferramentas que guardei na pasta Models"*. Sem isso, o programa não encontra a planta da `Conta`.

## 3. A Execução (O corpo do `Program.cs`)
* **A Instância (`new`):** É o comando que materializa o projeto na memória. 
    * **Sem o `new`**: A classe é apenas um texto (planta).
    * **Com o `new`**: Ela vira um objeto real que ocupa espaço e guarda valores.
* **A Orquestração:** É a chamada dos métodos na ordem lógica. O `Program.cs` funciona como o controle remoto do objeto criado.

---

## 💡 Uma analogia para nunca mais esquecer
Imagine que você é um engenheiro em uma fábrica de automóveis:

| Conceito OO | Analogia com Carro |
| :--- | :--- |
| **Classe** | **A Planta Azul:** O desenho técnico que diz que o carro tem 4 rodas e motor. Você não pode dirigir o desenho. |
| **Construtor** | **A Linha de Montagem:** Garante que o carro só saia da fábrica se tiver os itens obrigatórios (chassi, motor). |
| **Instância (`new`)** | **O Carro Real:** O veículo que sai da fábrica e vai para sua garagem. Agora ele existe fisicamente e ocupa espaço. |
| **Métodos** | **Pedais e Botões:** Ações como `Acelerar()` ou `Frear()`. |
| **Validações** | **Sistemas de Segurança:** O carro não acelera se estiver sem combustível ou não freia se o sistema detectar que já está parado. |

---
*Estudo de Caso: Aula05 - C# .NET*
"""

# Criando o arquivo .md
with open("resumo_logica_oo_aula05.md", "w", encoding="utf-8") as f:
    f.write(markdown_content)