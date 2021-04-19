using System;
using System.Collections.Generic;

namespace DIO.Bank
{
	class Program
	{
		static List<Conta> listContas = new List<Conta>();
		static List<Banco> listBancos = new List<Banco>();
		static void Main(string[] args)
		{
			// Cria lista de bancos
			Banco Caixa = new Banco(001, "Banco do Brasil");
			Banco BB = new Banco(104, "Caixa Exonômixa Federal");
			Banco Bradesco = new Banco(237, "Banco Bradesco S.A.");
			Banco BMG = new Banco(318, "Banco BMG S.A");

            listBancos.Add(Caixa);
			listBancos.Add(BB);
			listBancos.Add(Bradesco);
			listBancos.Add(BMG);
			string opcaoUsuario;

			do
			{
                opcaoUsuario = ObterOpcaoUsuario();

				switch (opcaoUsuario)
				{
					case "1":
						ListarContas();
						break;
					case "2":
						InserirConta();
						break;
					case "3":
						Transferir();
						break;
					case "4":
						Sacar();
						break;
					case "5":
						Depositar();
						break;
                    case "C":
						Console.Clear();
						break;
				}
				
			} while (opcaoUsuario.ToUpper() != "X");
			
			Console.WriteLine("Obrigado por utilizar nossos serviços.");
			Console.ReadLine();
		}

		private static void Depositar()
		{
			Console.Write("Digite o número da conta: ");
			int indiceConta = int.Parse(Console.ReadLine());

			Console.Write("Digite o valor a ser depositado: ");
			double valorDeposito = double.Parse(Console.ReadLine());

            listContas[indiceConta].Depositar(valorDeposito);
		}

		private static void Sacar()
		{
			Console.Write("Digite o número da conta: ");
			int indiceConta = int.Parse(Console.ReadLine());

			Console.Write("Digite o valor a ser sacado: ");
			double valorSaque = double.Parse(Console.ReadLine());

            listContas[indiceConta].Sacar(valorSaque);
		}

		private static void Transferir()
		{
			Console.Write("Digite o número da conta de origem: ");
			int indiceContaOrigem = int.Parse(Console.ReadLine());

            Console.Write("Digite o número da conta de destino: ");
			int indiceContaDestino = int.Parse(Console.ReadLine());

			Console.Write("Digite o valor a ser transferido: ");
			double valorTransferencia = double.Parse(Console.ReadLine());

            listContas[indiceContaOrigem].Transferir(valorTransferencia, listContas[indiceContaDestino]);
		}

		private static void InserirConta()
		{
			Console.WriteLine("Inserir nova conta");
			try
			{
				// Lista a tabela de bancos
				Console.WriteLine("\n*** LISTA DE BANCOS ***");
				foreach (var b in listBancos)
				{
					Console.WriteLine(b.ToString());
				}
				Console.WriteLine("---------------------------");
				// Solicita o código do banco
				Console.Write("Digite o código do banco: ");
				int iCodigoBanco = int.Parse(Console.ReadLine());
				// Verifica se o banco existe
				Banco banco = listBancos.Find(delegate(Banco p1) { return p1.CodigoBanco == iCodigoBanco; });
				if (banco.CodigoBanco == 0)
				{
					Console.WriteLine("Atenção! Banco não cadastrado.");
					Console.WriteLine("Pressione uma tecla para continuar...");
					Console.ReadLine();
					Console.Clear();
					return;
				}

				Console.Write("Digite 1 para Conta Fisica ou 2 para Juridica: ");
				int entradaTipoConta = int.Parse(Console.ReadLine());

				Console.Write("Digite o Nome do Cliente: ");
				string entradaNome = Console.ReadLine();

				Console.Write("Digite o saldo inicial: ");
				double entradaSaldo = double.Parse(Console.ReadLine());

				Console.Write("Digite o crédito: ");
				double entradaCredito = double.Parse(Console.ReadLine());

				Conta novaConta = new Conta(tipoConta: (TipoConta)entradaTipoConta,
											saldo: entradaSaldo,
											credito: entradaCredito,
											nome: entradaNome,
											codigobanco: iCodigoBanco);

				listContas.Add(novaConta);
			}
			catch (Exception ex)
			{
				Console.WriteLine("ERRO: " + ex.Message);
				Console.WriteLine("Pressione uma tecla para continuar...");
				Console.ReadLine();
				Console.Clear();
				return;
			}

		}

		private static void ListarContas()
		{
			Console.WriteLine("Listar contas");

			if (listContas.Count == 0)
			{
				Console.WriteLine("Nenhuma conta cadastrada.");
				return;
			}

			for (int i = 0; i < listContas.Count; i++)
			{
				Conta conta = listContas[i];
				Banco banco = listBancos.Find(delegate(Banco p1) { return p1.CodigoBanco == conta.indexCodigoBanco(); });

				Console.Write("Conta: {0} | ", i);
				Console.WriteLine("Banco: {0} - {1}", banco.CodigoBanco, banco.NomeBanco);
				Console.WriteLine(conta);
			}
		}

		private static string ObterOpcaoUsuario()
		{
			Console.WriteLine();
			Console.WriteLine("DIO Bank a seu dispor!!!");
			Console.WriteLine("Informe a opção desejada:");

			Console.WriteLine("1- Listar contas");
			Console.WriteLine("2- Inserir nova conta");
			Console.WriteLine("3- Transferir");
			Console.WriteLine("4- Sacar");
			Console.WriteLine("5- Depositar");
            Console.WriteLine("C- Limpar Tela");
			Console.WriteLine("X- Sair");
			Console.WriteLine();

			string opcaoUsuario = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcaoUsuario;
		}
	}
}
