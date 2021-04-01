using MarvelPaschoalotto.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MarvelPaschoalotto.Classes;

namespace MarvelPaschoalotto.Repositories
{
    public class MarvelRepository:IMarvel
    {
        #region Region Declaração de Variaveis
        //Por segurança, a declaração do HASH e KEY da API ocorre em um campo privado, somente leitura.
        private readonly string hashAPI = "8be15a064f1557728066139e0619aaf6";
        private readonly string keyAPI = "473da253b3977826288936c4a61c0991";

        private readonly IConfiguration _appSettings;

        //Declaração da URL da API de forma global
        readonly string apiBaseUrl;
        readonly string apiDiretorioPersonagens;

        #endregion


        //Método Construtor
        public MarvelRepository(IConfiguration appSettings)
        {
            _appSettings = appSettings;
            apiBaseUrl = _appSettings.GetSection("URLMarvel").Value;
            apiDiretorioPersonagens = _appSettings.GetSection("DiretorioPersonagens").Value;
        }

        /// <summary>
        /// Método responsavel pelo retorno de uma lista de informações dos personagens Marvel
        /// </summary>
        /// 
        /// <returns>Uma lista do modelo Marvel</returns>
        public async Task<List<Marvel>> GetList()
        {
            string urlCompleta = apiBaseUrl;
            urlCompleta += apiDiretorioPersonagens.Replace("_APIKEY_", keyAPI).Replace("_APIHASH_", hashAPI);
            List<Marvel> retorno = await new WebRequest().RequisitorWeb(urlCompleta);
            return retorno;
        }

        /// <summary>
        /// Método responsavel pelo retorno das informações de um único personagem Marvel
        /// </summary>
        /// <param name="id">O ID do personagem Marvel</param>
        /// <returns>Uma instância do modelo Marvel</returns>
        public async Task<Marvel> Get(int id)
        {
            string urlCompleta = apiBaseUrl;
            urlCompleta += apiDiretorioPersonagens.Replace("_APIKEY_", keyAPI).Replace("_APIHASH_", hashAPI);
            urlCompleta += "&id=" + id;

            var retorno = await new WebRequest().RequisitorWeb(urlCompleta);
            return retorno.FirstOrDefault(); 
        }
    }
}
