using MarvelPaschoalotto.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MarvelPaschoalotto.Classes
{
    public class Arquivamento
    {
        /// <summary>
        /// Salva o arquivo de texto na raiz do projeto com o nome: personagensmarvel.txt
        /// </summary>
        /// <param name="itensMarvel"></param>
        public void SalvaTxt(List<Marvel> itensMarvel) {
            string nomeArquivo = "personagensmarvel.txt";
            string conteudo = new Formatacao().FormataArquivoTxt(itensMarvel);

            // Escreve (ou sobrescreve) o arquivo de texto
            File.WriteAllText(nomeArquivo,conteudo);
        }

    }
}
