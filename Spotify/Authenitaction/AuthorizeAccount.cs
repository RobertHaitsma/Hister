using RestSharp;
using Spotify.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Spotify.Authenitaction
{
    public class AuthorizeAccount
    {
        private readonly string _clientId;
        private readonly string _clientSecret;
        private readonly string _redirectUri;
        private readonly string _authUrl;
        private readonly string _tokenhUrl;

        public AuthorizeAccount(string clientId, string clientSecret, string redirectUri, string authUrl, string tokenhUrl)
        {
            _clientId = clientId;
            _clientSecret = clientSecret;
            _redirectUri = redirectUri;
            _authUrl = authUrl;
            _tokenhUrl = tokenhUrl;
        }

        public async Task CallAuthorize()
        {
            var client = new RestClient(_authUrl);
            RestRequest request = new RestRequest() { Method = Method.Get };

            request.AddHeader("client_id", _clientId);
            request.AddHeader("response_type", "code");
            request.AddHeader("redirect_uri", "https://localhost:7293/api/callback");

            var response = client.Execute(request);
        }

        public async Task<TokenResponse> GetToken(string code, string state)
        {
            var client = new RestClient(_tokenhUrl);
            RestRequest request = new RestRequest() { Method = Method.Post };

            request.AddHeader("grant_type", "authorization_code");
            request.AddHeader("code", code);
            request.AddHeader("redirect_uri", "https://localhost:7293/api/callback");

            var response = client.Execute(request);

            var tokenResponse = JsonSerializer.Deserialize<TokenResponse>(response.Content);

            return tokenResponse;
        }
    }
}
