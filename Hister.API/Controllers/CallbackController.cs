using Hister.API.Model;
using Microsoft.AspNetCore.Mvc;
using SpotifyAPI.Web;

namespace Hister.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CallbackController : ControllerBase
    {
        [HttpGet]
        public async Task<SongInfoDto> GetRandomSong()
        {
            var config = SpotifyClientConfig
              .CreateDefault()
              .WithAuthenticator(new ClientCredentialsAuthenticator("af53d6d0a9d44b9490fe9e52a273c691", "6187a1fb6a7042aeafcdb868082c9018"));

            var spotify = new SpotifyClient(config);

            var track = await spotify.Tracks.Get("1s6ux0lNiTziSrd7iUAADH");

            return new SongInfoDto
            {
                Artist = string.Join(',', track.Artists.Select(x => x.Name)),
                Name = track.Name,
                ReleaseYear = track.Album.ReleaseDate,
                SongUrl = track.Uri
            };
        }
    }
}
