using MarvelPaschoalotto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MarvelPaschoalotto.Classes
{
    public class WebRequest
    {
        /// <summary>
        /// Método responsavel por disparar a requisição e enviar seu retorno para a formatação
        /// </summary>
        /// <param name="url">URL para a requisição WEB</param>
        /// <returns></returns>
        public async Task<List<Marvel>> RequisitorWeb(string url)
        {

            //Faz a requisição
            var client = new HttpClient();
            var retornoRequest = await client.GetStringAsync(url);

            //Envia o retorno da requisição para o método de formatação e efetua o return
            List<Marvel> retornoFormatado = new Formatacao().FormataJSON(retornoRequest);
            return retornoFormatado;
        }
    }
}
