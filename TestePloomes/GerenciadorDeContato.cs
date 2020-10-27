using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TestePloomes
{
    class GerenciadorDeContato : ComunicadorComAPI_Ploomes
    {
        public GerenciadorDeContato(string url, string chaveDeAutenticacao) : base(url, chaveDeAutenticacao)
        {
        }

        internal ContatoGET AdicionarContato(ContatoPOST contato)
        {
            string resposta = 
                ExecutarMetodo("/Contacts", JsonConvert.SerializeObject(contato), "POST");

            var desserializado =
                JsonConvert.DeserializeObject<RespostaDoCriarNovoCliente>(resposta);

            return desserializado.value[0];
        }

        internal void ApagarContato(int id)
        {
            ExecutarMetodo($"/Contacts({id})", null, "DELETE");
        }

        internal DealsGET CriarNegociacao(DealsPOST negociacao)
        {
            string resposta =
               ExecutarMetodo("/Deals", JsonConvert.SerializeObject(negociacao), "POST");

            var desserializado =
                JsonConvert.DeserializeObject<RespostaDoCriarNovaNegociacao>(resposta);

            return desserializado.value[0];
        }
        internal TasksGET CriarTask(TasksPOST novaTask)
        {
            string resposta =
               ExecutarMetodo("/Tasks", JsonConvert.SerializeObject(novaTask), "POST");

            

            var desserializado =
                JsonConvert.DeserializeObject<RespostaDoCriarNovaTask>(resposta);

            return desserializado.value[0];
        }
        

        internal DealsPATCH AlteraNegociacao(DealsPATCH alterarNegociacao)
        {
            string resposta =
               ExecutarMetodo($"/Deals({alterarNegociacao.ContactId})", JsonConvert.SerializeObject(alterarNegociacao), "PATCH");

            var desserializado =
                JsonConvert.DeserializeObject<RespostaDoAlterarNegociacao>(resposta);

            return desserializado.value[0];
        }

        internal void FinalizarTarefa(TasksGET finalizarTask)
        {
            string resposta =
               ExecutarMetodo("/Tasks", JsonConvert.SerializeObject(finalizarTask), "POST");
        }
    }

    
}
