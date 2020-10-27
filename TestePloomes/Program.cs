using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TestePloomes
{
    class Program
    {
        private static string _url;
        private static string _user_key;

        static void Main(string[] args)
        {
            _url = $"https://api2.ploomes.com";

            Console.WriteLine("Informe sua chave de acesso (User-Key):");

            _user_key = Console.ReadLine();
            

            string opcao = null;

            EscreverMenu();

            while ((opcao = Console.ReadLine()) != "sair")
            {
                switch (opcao)
                {
                    case "1":
                        AdicionarContato();
                        break;
                    case "2":
                        ExcluirContato();
                        break;
                    case "3":
                        CriarNegociacao();
                        break;
                    case "4":
                        CriarTasks();
                        break;
                    case "5":
                        AlteraNegociacao();
                            break;
                    /*case "6":
                        FinalizarTarefa();
                        break;*/
                    default:
                        Console.WriteLine();
                        Console.WriteLine("Opção Inválida!");
                        Console.ReadKey();
                        break;
                }

                EscreverMenu();
            }
        }

        private static void EscreverMenu()
        {
            Console.Clear();

            Console.WriteLine("Digite a opção desejada:");
            Console.WriteLine();
            Console.WriteLine("1 - Adicionar contato");
            Console.WriteLine("2 - Excluir contato");
            Console.WriteLine("3 - Nova negociacao");
            Console.WriteLine("4 - Nova tarefa numa negociação");
            Console.WriteLine("5 - Alterar negociacao");
            //Console.WriteLine("6 - Finalizar uma negociacao");
            Console.WriteLine("sair - Finalizar a aplicacao");



        }

        private static void ExcluirContato()
        {
            Console.Clear();

            Console.WriteLine("Digite o ID do Contato:");

            var gerenciador =
                CriarGerenciadorDeContato();

            gerenciador.ApagarContato(Convert.ToInt32(Console.ReadLine()));
        }

        private static void AdicionarContato()
        {
            Console.Clear();
            Console.WriteLine("Cadastrando o contato...");
            
            ContatoPOST novoContato = new ContatoPOST();

            Console.WriteLine("Digite o Nome do Contato:");
            novoContato.Name = Console.ReadLine();

            Console.WriteLine("Digite o Endereço do Contato:");
            novoContato.Neighborhood = Console.ReadLine();

            Console.WriteLine("Digite o CEP do Contato:");
            novoContato.ZipCode = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Digite o ID de origem do Contato:");
            novoContato.OriginId = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Digite o ID de companhia do Contato:");
            novoContato.CompanyId = Console.ReadLine();

            Console.WriteLine("Digite o numero do endereço da rua do Contato:");
            novoContato.StreetAddressNumber = Console.ReadLine();

            Console.WriteLine("Digite o TypeID do Contato:");
            novoContato.TypeId = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Digite o Telefone do Contato:");
            novoContato.Phones =
                new Phone[]
                {
                    new Phone()
                    {
                        CountryId = 0,
                        PhoneNumber = "",
                        TypeId = 0
                    }
                };

            novoContato.OtherProperties =
                new Otherproperty[]
                {
                    new Otherproperty
                    {
                         FieldKey ="",
                         IntegerValue = 0,
                         StringValue = ""
                    }
                };
        

            var gerenciador =
                CriarGerenciadorDeContato();

            var contatoCriado =
                gerenciador.AdicionarContato(novoContato);
        }

        private static void CriarNegociacao()
        {

            DealsPOST novaNegociacao = new DealsPOST();

            Console.Clear();
            
            Console.WriteLine("Digite o nome da negociacao: ");
            novaNegociacao.Title = Console.ReadLine();
            Console.WriteLine("Digite o ID  do contato da negociacao: ");
            novaNegociacao.ContactId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Digite o amount: ");
            novaNegociacao.Amount = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Digite o id de estágio: ");
            novaNegociacao.StageId = Convert.ToInt32(Console.ReadLine());

            novaNegociacao.OtherProperties =
               new Otherproperty[]
               {
                    new Otherproperty
                    {
                         FieldKey = "",
                         IntegerValue = 0,
                         StringValue = ""
                    }
               };

            var gerenciador =
                CriarGerenciadorDeContato();
            gerenciador.CriarNegociacao(novaNegociacao);
                

        }
        private static void CriarTasks()
        {
            TasksPOST novaTask = new TasksPOST();

            Console.Clear();

            Console.WriteLine("Digite o nome da tarefa: ");
            novaTask.Title = Console.ReadLine();
            Console.WriteLine("Digite a descricao: ");
            novaTask.Description = Console.ReadLine();
            
            Console.WriteLine("Digite o ID do contato: ");
            novaTask.ContactId = Convert.ToInt32(Console.ReadLine());

            novaTask.OtherProperties =
               new Otherproperty[]
               {
                    new Otherproperty
                    {
                         FieldKey = "",
                         IntegerValue = 0,
                         StringValue = ""
                    }
               };

            var gerenciador =
                CriarGerenciadorDeContato();
            gerenciador.CriarTask(novaTask);
        }

        private static void AlteraNegociacao()
        {
            DealsPATCH alterarNegociacao = new DealsPATCH();

            Console.Clear();

            Console.WriteLine("Digite o nome da negociacao: ");
            alterarNegociacao.Title = Console.ReadLine();
            Console.WriteLine("Digite o ID  do contato da negociacao: ");
            alterarNegociacao.ContactId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Digite o amount: ");
            alterarNegociacao.Amount = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Digite o id de estágio: ");
            alterarNegociacao.StageId = Convert.ToInt32(Console.ReadLine());

            alterarNegociacao.OtherProperties =
               new Otherproperty[]
               {
                    new Otherproperty
                    {
                         FieldKey = "",
                         IntegerValue = 0,
                         StringValue = ""
                    }
               };

            var gerenciador =
                CriarGerenciadorDeContato();
            gerenciador.AlteraNegociacao(alterarNegociacao);
        }

        /* private static void FinalizarTarefa()
        {
            TasksGET finalizarTask = new TasksGET();

            Console.Clear();

            Console.WriteLine("Digite o ID da tarefa que deseja finalizar");
            
            finalizarTask.Id = Convert.ToInt32(Console.ReadLine());
            finalizarTask.Finished = true;
            var gerenciador =
                CriarGerenciadorDeContato();
            gerenciador.FinalizarTarefa(finalizarTask);

           
        }*/

        private static GerenciadorDeContato CriarGerenciadorDeContato()
        {
            return new GerenciadorDeContato(_url, _user_key);
        }
    }

}


