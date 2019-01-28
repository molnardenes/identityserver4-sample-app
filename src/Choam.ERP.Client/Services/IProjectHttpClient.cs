using System.Net.Http;
using System.Threading.Tasks;

namespace Choam.ERP.Client.Services
{
    public interface IProjectHttpClient
    {
        Task<HttpClient> GetClient();
    }
}