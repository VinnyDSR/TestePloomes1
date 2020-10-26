using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
