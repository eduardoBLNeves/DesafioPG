using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MarvelPaschoalotto.Models;
namespace MarvelPaschoalotto.Repositories
{
    public interface IMarvel
    {
        public Task<List<Marvel>> GetList();
        public Task<Marvel> Get(int id);
    }
}
