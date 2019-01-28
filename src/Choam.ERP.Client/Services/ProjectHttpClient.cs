using Microsoft.AspNetCore.Http;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Choam.ERP.Client.Services
{
    public class ProjectHttpClient : IProjectHttpClient
    {
        private readonly IHttpContextAccessor httpContextAccessor;
        private HttpClient httpClient = new HttpClient();

        public ProjectHttpClient(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
        }

        public async Task<HttpClient> GetClient()
        {
            this.httpClient.BaseAddress = new Uri("https://localhost:44333/");
            this.httpClient.DefaultRequestHeaders.Accept.Clear();
            this.httpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            return this.httpClient;
        }
    }
}