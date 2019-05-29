using System;
using System.Threading;
using System.Threading.Tasks;
using MHelper.DTO;
using Refit;

namespace MHelper.Services
{
    [Headers("Accept: application/json")]
    public interface IHttpApi
    { 
        [Post("/derivative")]
        Task<EvaluateResponse> GetDerivative([Body] EvaluateRequest request);

        [Post("/calculate")]
        Task<EvaluateResponse> GetExpressionValue([Body] EvaluateRequest request);

        [Post("/integrate")]
        Task<EvaluateResponse> GetIntegral([Body] EvaluateRequest request);
    }
}
