using pickPointTest.Contracts.Requests;
using pickPointTest.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace pickPointTest.Services
{
    public interface IPostamatService
    {
        Task<List<Postamat>> GetEnablePostamats();

        Task<Postamat> GetPostamatInfo(PostamatInfoRequest pir);
    }
}
