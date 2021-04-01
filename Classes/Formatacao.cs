using MarvelPaschoalotto.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarvelPaschoalotto.Classes
{
    public class Formatacao
    {
        /// <summary>
        /// Método responsavel pela formatação dos dados para o objeto Marvel
        /// </summary>
        /// <param name="retornoStringJSON">Um JSON em formato string.</param>
        public List<Marvel> FormataJSON(string retornoStringJSON)
        {
            //Converte a string para objeto JSON, remove os dados não utilizados e cria a lista de retorno
            JObject objetoJSON = JObject.Parse(retornoStringJSON);
            List<JToken> results = objetoJSON["data"]["results"].Children().ToList();
            List<Marvel> personagensMarvel = new List<Marvel>();

            foreach (JToken result in results)
            {
                //Declara o valor às variaveis
                int id = result["id"].Value<int>();
                string name = result["name"].Value<string>();
                string description = result["description"].Value<string>();
                List<Items> comics = result["comics"]["items"].ToObject<List<Items>>();
                List<Items> series = result["series"]["items"].ToObject<List<Items>>();
                List<Items> stories = result["stories"]["items"].ToObject<List<Items>>();
                List<Items> events = result["events"]["items"].ToObject<List<Items>>();

                //Cria o objeto e o adiciona na lista
                Marvel personagem = new Marvel()
                {
                    id = id,
                    name = name,
                    description = description,
                    comics = comics,
                    series = series,
                    stories = stories,
                    events = events
                };
                personagensMarvel.Add(personagem);
            }

            //Após formatar, envia para o método que gerará o arquivo de texto
            new Arquivamento().SalvaTxt(personagensMarvel);
            return personagensMarvel;
        }



        /// <summary>
        /// Método responsavel pela formatação do arquivo de texto
        /// </summary>
        /// <param name="itensMarvel">Uma lista do modelo Marvel para tratamento</param>
        public string FormataArquivoTxt(List<Marvel> itensMarvel)
        {
            string retorno = "";


            foreach (Marvel item in itensMarvel)
            {
                retorno += "ID: " + item.id.ToString() + ",";
                retorno += "\n";
                retorno += "NOME: " + item.name + ",";
                retorno += "\n";
                retorno += "DESCRIÇÃO: " + item.description + ",";
                retorno += "\n";
                retorno += "COMICS: \n";
                foreach (var comicsItem in item.comics)
                {
                    retorno += "\t-" + comicsItem.name + ";\n";
                }
                retorno += "\n";
                retorno += "SERIES: \n";
                foreach (var seriesItem in item.comics)
                {
                    retorno += "\t-" + seriesItem.name + ";\n";
                }
                retorno += "\n";
                retorno += "STORIES: \n";
                foreach (var storiesItem in item.comics)
                {
                    retorno += "\t-" + storiesItem.name + ";\n";
                }
                retorno += "\n";
                retorno += "EVENTS: \n";
                foreach (var eventsItem in item.comics)
                {
                    retorno += "\t-" + eventsItem.name + ";\n";
                }
                retorno += "\n";
                retorno += "-----------------------------------------------------------------------------------------------";
                retorno += "\n\n";

            }


            return retorno;
        }
    }
}
