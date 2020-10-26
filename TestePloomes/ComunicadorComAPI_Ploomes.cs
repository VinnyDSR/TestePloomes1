using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TestePloomes
{
    abstract class ComunicadorComAPI_Ploomes
    {
        private string _url;
        private string _chaveDeAutenticacao;

        public ComunicadorComAPI_Ploomes(string url, string chaveDeAutenticacao)
        {
            this._url = url;
            this._chaveDeAutenticacao = chaveDeAutenticacao;
        }

        protected string ExecutarMetodo(string complementoDeURL, string dados, string tipo)
        {
            string resultado = null;

            string urlFormada = $"{this._url}{complementoDeURL}";

            var requisicao = (HttpWebRequest)WebRequest.Create(urlFormada);

            requisicao.ContentType = "application/json; charset=utf-8";
            requisicao.ReadWriteTimeout = 100000;
            requisicao.Headers["User-Key"] = this._chaveDeAutenticacao;

            requisicao.Method = tipo;

            if (!string.IsNullOrEmpty(dados))
            {
                byte[] buffer = Encoding.UTF8.GetBytes(dados);

                requisicao.ContentLength = buffer.Length;

                using (var strm = requisicao.GetRequestStream())
                {
                    strm.Write(buffer, 0, buffer.Length);

                    strm.Flush();
                    strm.Close();
                }
            }

            var respostaDoServidor =
                (HttpWebResponse)requisicao.GetResponse();

            using (var resposta = respostaDoServidor.GetResponseStream())
            {
                using (var str = new StreamReader(resposta))
                {
                    resultado = str.ReadToEnd();
                }
            }

            return resultado;
        }
    }
}
