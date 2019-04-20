using System;
using System.Threading;
using System.Threading.Tasks;
using MHelper.DTO;
using Refit;

namespace MHelper.Services
{
    public interface IHttpApi
    {
        [Get("/basic-auth/{username}/{password}")]
        Task<AuthResult> BasicAuth(string username, string password, [Header("Authorization")] string authToken, CancellationToken ctx);
    }
}
