// See https://aka.ms/new-console-template for more information


/*
Uma App para movimentações financeiras
Para Pessoas Físicas e Pessoas Jurídicas
Com lista das movimentações de todos os clientes
E descontos de taxas de R$ 2,00 para movimentações de PJ e R$ 1,00 para PF

# herança, polimorfismo e encapsulamento

*/


#region Código
using JMBank;


List<Cliente> Clientes = new List<Cliente>();
ConsultarCliente();

//Se o código do cliente não existit, perguntar se deseja cadastrar um novo cliente
void ConsultarCliente() {
    Console.WriteLine("Olá, bem vindo ao JMBank!");
    Console.WriteLine("Digite o seu código: ");
    string codigo = Console.ReadLine();
    Cliente cliente = null;

    foreach (Cliente cli in Clientes) {
        if (cli == codigo) {
            cliente = cli;
        }
    }
    if (cliente == null) {
        Console.WriteLine("Este cliente não existe. Deseja cadastrar outro? Digite S ou N");
        string cadastrarCliente = Console.ReadLine();
        if (cadastrarCliente == "S") {
            Console.WriteLine("Digite o seu código: ");
            string codigoClienteNovo = Console.ReadLine();
            Console.WriteLine("Digite seu nome: ");
            string nomeClienteNovo = Console.ReadLine();
            Console.WriteLine("Digite PF ou PJ");
            string tipoPossoa = Console.ReadLine();
            if (tipoPossoa == "PF")
                cliente = new PessoaFisica(codigoClienteNovo, nomeClienteNovo);
            else
                cliente = new PessoaJuridica(codigoClienteNovo, nomeClienteNovo);
            Clientes.Add(cliente);
            ExibirMenu(cliente);
        }
        else
            ConsultarCliente();
    }
}

void ExibirMenu(Cliente cliente) {
    Console.WriteLine($"Olá {cliente.Nome}");
    Console.WriteLine($"Digite a opção desejada: ");
    Console.WriteLine($"1 - Extrato");
    Console.WriteLine($"2 - Extrato");
    Console.WriteLine($"3 - Depósito");

    string menu = Console.ReadLine();

    switch (menu) {
        case "1":
            ExibirExtrato(cliente);
            break;
        case "2":
            RealizarSaque(cliente);
            break;
        case "3":
            RealizarDeposito(cliente);
            break;
        default:
            Console.WriteLine("Digite a opção desejada.");
            ExibirMenu(cliente);
            break;
    }
}

void ExibirExtrato(Cliente cliente) {
    Console.WriteLine("------------ EXTRATO -----------");

    foreach (Movimentacao mov in cliente.Movimentacoes) {
        Console.WriteLine($"{mov.Tipo} - {mov.Valor}");
    }

    Console.WriteLine("Deseja exibir o menu novamente? Digite S ou N");
    string exibirMenu = Console.ReadLine();
    if (exibirMenu == "S") {
        ExibirMenu(cliente);
    }
    else {
        Console.WriteLine("Deseja consultar outro cliente? Digite S ou N");
        string consultarCliente = Console.ReadLine();
        if (consultarCliente == "S") {
            ConsultarCliente();
        }
    }
}

void RealizarSaque(Cliente cliente) {
    Console.WriteLine("Digite o valor que deseja sacar: ");
    string valor = Console.ReadLine();
    ciente.RealizarSaque(Convert.ToDecimal(valor));
    Console.WriteLine("Deseja realizar outra transição? Digite S ou N");
    string realizarOutraTransacao = Console.ReadLine();
    if (realizarOutraTransacao == "S")
        ExibirMenu(cliente);
    else
        Console.WriteLine("Foi um prazer lhe atender! Até mais!");
}

void RealizarDeposito(Cliente cliente) {
    Console.WriteLine("Digite o valor que deseja depositar:");
    string valor = Console.ReadLine();
    ciente.RealizarDeposito(Convert.ToDecimal(valor));
    Console.WriteLine("Deseja realizar outra transição? Digite S ou N");
    string realizarOutraTransacao = Console.ReadLine();
    if (realizarOutraTransacao == "S")
        ExibirMenu(cliente);
    else
        Console.WriteLine("Foi um prazer lhe atender! Até mais!");
}
#endregion FimCodigo