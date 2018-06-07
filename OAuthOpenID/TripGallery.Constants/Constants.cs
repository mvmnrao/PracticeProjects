using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripGallery.Constants
{
    public class Constants
    {
        public const string TripGalleryAPI = "http://localhost:51528/";
        public const string TripGalleryMVC = "http://localhost:51513/";
        public const string TripGalleryMVCSTSCallback = "";
        public const string TripGalleryAngular = "";

        public const string TripGalleryClientSecret = "21B5F798-BE55-42BC-8AA8-0025B903DC3B";

        public const string TripGalleryIssuerUri = "http://tripcompanysts/identity";
        public const string TripGallerySTSOrigin = "http://localhost:44300";
        public const string TripGallerySTS = TripGallerySTSOrigin + "/identity";
        public const string TripGallerySTSTokenEndPoint = TripGallerySTS + "/connect/token";
        public const string TripGallerySTSAuthorizationEndpoint = TripGallerySTS + "/connect/authorize";
        public const string TripGalleryInfoEndpoint = TripGallerySTS + "/connect/userinfo";
        public const string TripGalleryEndSessionEndpoint = TripGallerySTS + "/connect/endsession";
        public const string TripGalleryRevokeTokenEndpoint = TripGallerySTS + "/connect/revocation";
    }
}
