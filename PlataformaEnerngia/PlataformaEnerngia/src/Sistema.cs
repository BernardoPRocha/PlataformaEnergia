using System;
using System.Collections.Generic;

namespace PlataformaEnergia
{
    public class Sistema
    {
        private LogEventos log = new LogEventos();
        private List<Usuario> usuarios = new List<Usuario>
        {
            new Usuario("Bernardo", "99209"),
            new Usuario("Gabriel", "550788"),
            new Usuario("Levy", "98655")
        };

        public void RegistrarFalha()
        {
            try
            {
                Console.Write("Digite o local da falha: ");
                string local = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(local)) throw new ArgumentException("Local inválido.");

                Console.Write("Descreva a falha: ");
                string descricao = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(descricao)) throw new ArgumentException("Descrição inválida.");

                var falha = new FalhaEnergia(local, descricao);
                log.AdicionarEvento(falha);
                Console.WriteLine("Falha registrada com sucesso.\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}\n");
            }
        }

        public void GerarRelatorio()
        {
            Console.WriteLine("\n--- RELATÓRIO DE FALHAS ---");
            log.ExibirLogs();
        }

        public void SimularAtaque()
        {
            Console.Write("Digite o tipo de ataque (ex: ransomware): ");
            string tipo = Console.ReadLine();
            var ataque = new SimuladorAtaque(tipo);
            log.AdicionarEvento(ataque);
            Console.WriteLine("Ataque simulado com sucesso.\n");
        }

        public bool FazerLogin()
        {
            Console.WriteLine("--- Login ---");
            Console.Write("Usuário: ");
            string nome = Console.ReadLine();

            Console.Write("Senha: ");
            string senha = Console.ReadLine();

            foreach (var usuario in usuarios)
            {
                if (usuario.Nome == nome && usuario.Senha == senha)
                {
                    Console.WriteLine("Login bem-sucedido!\n");
                    return true;
                }
            }

            Console.WriteLine("Usuário ou senha incorretos.\n");
            return false;
        }

        public void Menu()
        {
            if (!FazerLogin())
            {
                Console.WriteLine("Acesso negado. Encerrando o sistema...");
                return;
            }

            while (true)
            {
                Console.WriteLine("1. Registrar falha de energia");
                Console.WriteLine("2. Gerar relatório de eventos");
                Console.WriteLine("3. Simular ataque cibernético");
                Console.WriteLine("4. Sair");
                Console.Write("Escolha uma opção: ");

                string opcao = Console.ReadLine();
                switch (opcao)
                {
                    case "1": RegistrarFalha(); break;
                    case "2": GerarRelatorio(); break;
                    case "3": SimularAtaque(); break;
                    case "4": return;
                    default: Console.WriteLine("Opção inválida.\n"); break;
                }
            }
        }
    }
}
