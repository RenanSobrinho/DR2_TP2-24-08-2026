using System;
using System.Globalization;

class Program
{
    static void Main()
    {
        int opcao;

        do
        {
            Console.Clear();
            Console.WriteLine("===== MENU DE EXERCÍCIOS - DR2 TP2 =====");
            Console.WriteLine("1  - Cálculo de Idade Precisa");
            Console.WriteLine("2  - Dias até o Próximo Aniversário");
            Console.WriteLine("3  - Diferença Entre Duas Datas");
            Console.WriteLine("4  - Formulário de Cadastro Simples");
            Console.WriteLine("5  - Conversor de Temperatura");
            Console.WriteLine("6  - Cálculo de IMC");
            Console.WriteLine("7  - Verificador de Número Par ou Ímpar");
            Console.WriteLine("8  - Classificação de Nota Escolar");
            Console.WriteLine("9  - Calculadora de Salário Líquido");
            Console.WriteLine("10 - Contagem Regressiva");
            Console.WriteLine("11 - Tabuada Interativa");
            Console.WriteLine("12 - Jogo de Adivinhação");
            Console.WriteLine("0  - Sair");
            Console.Write("\nEscolha o exercício: ");

            opcao = int.Parse(Console.ReadLine());
            Console.WriteLine();

            switch (opcao)
            {
                case 1: Exercicio1(); break;
                case 2: Exercicio2(); break;
                case 3: Exercicio3(); break;
                case 4: Exercicio4(); break;
                case 5: Exercicio5(); break;
                case 6: Exercicio6(); break;
                case 7: Exercicio7(); break;
                case 8: Exercicio8(); break;
                case 9: Exercicio9(); break;
                case 10: Exercicio10(); break;
                case 11: Exercicio11(); break;
                case 12: Exercicio12(); break;
                case 0: Console.WriteLine("Encerrando..."); break;
                default: Console.WriteLine("Opção inválida!"); break;
            }

            if (opcao != 0)
            {
                Console.WriteLine("\nPressione ENTER para voltar ao menu...");
                Console.ReadLine();
            }

        } while (opcao != 0);
    }

    // ===== EXERCÍCIO 1 =====
    static void Exercicio1()
    {
        Console.Write("Digite sua data de nascimento (dd/MM/yyyy): ");
        DateTime nascimento = DateTime.Parse(Console.ReadLine());
        DateTime hoje = DateTime.Today;

        int anos = hoje.Year - nascimento.Year;
        int meses = hoje.Month - nascimento.Month;
        int dias = hoje.Day - nascimento.Day;

        if (dias < 0)
        {
            meses--;
            dias += DateTime.DaysInMonth(hoje.Year, hoje.Month == 1 ? 12 : hoje.Month - 1);
        }

        if (meses < 0)
        {
            anos--;
            meses += 12;
        }

        Console.WriteLine($"\nVocê tem {anos} anos, {meses} meses e {dias} dias.");
    }

    // ===== EXERCÍCIO 2 =====
    static void Exercicio2()
    {
        Console.Write("Digite sua data de nascimento (dd/MM/yyyy): ");
        DateTime nascimento = DateTime.Parse(Console.ReadLine());
        DateTime hoje = DateTime.Today;

        DateTime proximoAniversario = new DateTime(hoje.Year, nascimento.Month, nascimento.Day);

        if (proximoAniversario < hoje)
        {
            proximoAniversario = proximoAniversario.AddYears(1);
        }

        int diasRestantes = (proximoAniversario - hoje).Days;

        Console.WriteLine($"\nFaltam {diasRestantes} dias para o seu próximo aniversário.");
    }

    // ===== EXERCÍCIO 3 =====
    static void Exercicio3()
    {
        Console.Write("Digite a primeira data (dd/MM/yyyy): ");
        DateTime data1 = DateTime.Parse(Console.ReadLine());

        Console.Write("Digite a segunda data (dd/MM/yyyy): ");
        DateTime data2 = DateTime.Parse(Console.ReadLine());

        if (data2 < data1)
        {
            DateTime temp = data1;
            data1 = data2;
            data2 = temp;
        }

        TimeSpan diferenca = data2 - data1;

        int anos = data2.Year - data1.Year;
        int meses = data2.Month - data1.Month;
        int dias = data2.Day - data1.Day;

        if (dias < 0)
        {
            meses--;
            dias += DateTime.DaysInMonth(data2.Year, data2.Month == 1 ? 12 : data2.Month - 1);
        }

        if (meses < 0)
        {
            anos--;
            meses += 12;
        }

        Console.WriteLine($"\nDiferença total: {diferenca.Days} dias");
        Console.WriteLine($"Ou seja: {anos} anos, {meses} meses e {dias} dias.");
    }

    // ===== EXERCÍCIO 4 =====
    static void Exercicio4()
    {
        Console.Write("Digite seu nome: ");
        string nome = Console.ReadLine();

        Console.Write("Digite sua idade: ");
        string idade = Console.ReadLine();

        Console.Write("Digite seu telefone: ");
        string telefone = Console.ReadLine();

        Console.Write("Digite seu e-mail: ");
        string email = Console.ReadLine();

        Console.WriteLine("\n===== DADOS CADASTRADOS =====");
        Console.WriteLine($"Nome: {nome}");
        Console.WriteLine($"Idade: {idade}");
        Console.WriteLine($"Telefone: {telefone}");
        Console.WriteLine($"E-mail: {email}");
    }

    // ===== EXERCÍCIO 5 =====
    static void Exercicio5()
    {
        Console.Write("Digite a temperatura em Celsius: ");
        double celsius = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

        double fahrenheit = celsius * 9 / 5 + 32;
        double kelvin = celsius + 273.15;

        Console.WriteLine($"\n{celsius:F2}°C equivale a:");
        Console.WriteLine($"Fahrenheit: {fahrenheit:F2}°F");
        Console.WriteLine($"Kelvin: {kelvin:F2}K");
    }

    // ===== EXERCÍCIO 6 =====
    static void Exercicio6()
    {
        Console.Write("Digite seu peso (kg): ");
        double peso = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

        Console.Write("Digite sua altura (m): ");
        double altura = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

        double imc = peso / (altura * altura);

        Console.WriteLine($"\nSeu IMC é: {imc:F2}");

        if (imc < 18.5)
            Console.WriteLine("Classificação: Abaixo do peso");
        else if (imc < 25)
            Console.WriteLine("Classificação: Peso normal");
        else if (imc < 30)
            Console.WriteLine("Classificação: Sobrepeso");
        else if (imc < 35)
            Console.WriteLine("Classificação: Obesidade grau I");
        else if (imc < 40)
            Console.WriteLine("Classificação: Obesidade grau II");
        else
            Console.WriteLine("Classificação: Obesidade grau III");
    }

    // ===== EXERCÍCIO 7 =====
    static void Exercicio7()
    {
        Console.Write("Digite um número inteiro: ");
        int numero = int.Parse(Console.ReadLine());

        if (numero % 2 == 0)
            Console.WriteLine($"O número {numero} é PAR.");
        else
            Console.WriteLine($"O número {numero} é ÍMPAR.");
    }

    // ===== EXERCÍCIO 8 =====
    static void Exercicio8()
    {
        Console.Write("Digite uma nota de 0 a 10: ");
        double nota = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

        if (nota < 5)
            Console.WriteLine("Classificação: Insuficiente");
        else if (nota < 7)
            Console.WriteLine("Classificação: Regular");
        else if (nota < 9)
            Console.WriteLine("Classificação: Bom");
        else
            Console.WriteLine("Classificação: Excelente");
    }

    // ===== EXERCÍCIO 9 =====
    static void Exercicio9()
    {
        Console.Write("Digite o salário bruto: R$ ");
        double salarioBruto = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

        double imposto;

        if (salarioBruto <= 2259.20)
            imposto = 0;
        else if (salarioBruto <= 2826.65)
            imposto = salarioBruto * 0.075;
        else if (salarioBruto <= 3751.05)
            imposto = salarioBruto * 0.15;
        else if (salarioBruto <= 4664.68)
            imposto = salarioBruto * 0.225;
        else
            imposto = salarioBruto * 0.275;

        double salarioLiquido = salarioBruto - imposto;

        Console.WriteLine($"\nSalário bruto: R$ {salarioBruto:F2}");
        Console.WriteLine($"Desconto de imposto: R$ {imposto:F2}");
        Console.WriteLine($"Salário líquido: R$ {salarioLiquido:F2}");
    }

    // ===== EXERCÍCIO 10 =====
    static void Exercicio10()
    {
        Console.Write("Digite um número para iniciar a contagem regressiva: ");
        int numero = int.Parse(Console.ReadLine());

        Console.Write("\nContagem: ");
        for (int i = numero; i >= 0; i--)
        {
            Console.Write(i);
            if (i > 0) Console.Write(", ");
        }
        Console.WriteLine();
    }

    // ===== EXERCÍCIO 11 =====
    static void Exercicio11()
    {
        Console.Write("Digite um número para ver sua tabuada: ");
        int numero = int.Parse(Console.ReadLine());

        Console.WriteLine($"\n===== TABUADA DE {numero} =====");
        for (int i = 1; i <= 10; i++)
        {
            Console.WriteLine($"{numero} x {i} = {numero * i}");
        }
    }

    // ===== EXERCÍCIO 12 =====
    static void Exercicio12()
    {
        Random random = new Random();
        int numeroSecreto = random.Next(1, 101);
        int palpite;
        int tentativas = 0;

        Console.WriteLine("===== JOGO DE ADIVINHAÇÃO =====");
        Console.WriteLine("Adivinhe o número entre 1 e 100!");

        do
        {
            Console.Write("Digite seu palpite: ");
            palpite = int.Parse(Console.ReadLine());
            tentativas++;

            if (palpite > numeroSecreto)
                Console.WriteLine($"O número secreto é MENOR que {palpite}");
            else if (palpite < numeroSecreto)
                Console.WriteLine($"O número secreto é MAIOR que {palpite}");
            else
                Console.WriteLine($"Parabéns! Você acertou em {tentativas} tentativa(s)!");
        } while (palpite != numeroSecreto);
    }
}
