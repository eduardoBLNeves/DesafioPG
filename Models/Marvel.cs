using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarvelPaschoalotto.Models
{
    /// <summary>
    /// Classe modelo do conteudo GET
    /// </summary>
    public class Marvel
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public List<Items> comics { get; set; }
        public List<Items> series { get; set; }
        public List<Items> stories { get; set; }
        public List<Items> events { get; set; }
    }
    public class Items  {
        public string name { get; set; }
    }
}
