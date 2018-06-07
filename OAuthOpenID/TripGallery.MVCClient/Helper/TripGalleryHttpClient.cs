using IdentityModel.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TripGallery.Constants;

namespace TripGallery.MVCClient.Helper
{
    public class TripGalleryHttpClient
    {

        public static HttpClient GetClient()
        {
            HttpClient client = new HttpClient();
            var accessToken = RequestAccessTokenClientCredentials();
            client.BaseAddress = new Uri(Constants.Constants.TripGalleryAPI);
            client.DefaultRequestHeaders.Accept.Clear();

            client.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json")
                );

            client.SetBearerToken(accessToken);

            return client;
        }


        private static string RequestAccessTokenClientCredentials()
        {
            var tokenClient = new TokenClient(
                Constants.Constants.TripGallerySTSTokenEndPoint,
                "ClientOne",
                Constants.Constants.TripGalleryClientSecret
                );

            //var client = new OAuth2Client();
            //tokenClient.Address = Constants.Constants.TripGallerySTSTokenEndPoint;

            var tokenResponse = tokenClient.RequestClientCredentialsAsync("gallerymanagement").Result;

            return tokenResponse.AccessToken;
        }
    }
}
