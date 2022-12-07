using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Spotify.Models
{
    public class TokenResponse
    {
        [JsonPropertyName("access_token")]
        public string Token { get; set; }

        [JsonPropertyName("token_type")]
        public string TokenType { get; set; }
        [JsonPropertyName("scope")]
        public string Scope { get; set; }
        [JsonPropertyName("expires_in")]
        public string ExpiresIn { get; set; }
        [JsonPropertyName("refresh_token")]
        public string RefreshToken { get; set; }
    }
}
