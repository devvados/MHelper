using System;
using System.Threading;
using System.Threading.Tasks;
using MHelper.DTO;
using Refit;

namespace MHelper.Services
{
    public class MHelperApi : IHttpApi
    {
        public Task<AuthResult> BasicAuth(string username, string password, [Header("Authorization")] string authToken, CancellationToken ctx)
        {
            throw new NotImplementedException();
        }

        [Get("/derivative/{expression}")]
        public Task<HttpResponseMessage> GetDerivative([Header("Derivative")] string expression, CancellationToken ctx)
        {
            throw new NotImplementedException();
        }

        [Get("/calculate/{expression}")]
        public Task<HttpResponseMessage> GetExpressionValue([Header("Calculate")] string expression, CancellationToken ctx)
        {
            throw new NotImplementedException();
        }

        [Get("/integrate/{expression}")]
        public Task<HttpResponseMessage> GetIntegral([Header("Integral")] string expression, CancellationToken ctx)
        {
            throw new NotImplementedException();
        }
    }
}
