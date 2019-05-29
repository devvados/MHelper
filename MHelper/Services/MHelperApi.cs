using System;
using System.Threading;
using System.Threading.Tasks;
using MHelper.DTO;
using Refit;

namespace MHelper.Services
{
    public class MHelperApi : IHttpApi
    {
        public static IHttpApi apiService;
        static string baseUrl = "http://10.0.2.2:8080";

        public static IHttpApi GetApiService()
        {
            apiService = RestService.For<IHttpApi>(baseUrl);
            return apiService;
        }

        public Task<EvaluateResponse> GetDerivative([Body] EvaluateRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<EvaluateResponse> GetExpressionValue([Body] EvaluateRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<EvaluateResponse> GetIntegral([Body] EvaluateRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
