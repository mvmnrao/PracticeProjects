using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using IdentityServer3.Core.Configuration;
using System.Security.Cryptography.X509Certificates;
using IdentityServer3.Core.Services.InMemory;
using System.Collections.Generic;
using IdentityServer3.Core.Models;
using System.Security.Cryptography;
using System.Web.Hosting;
using System.IO;

[assembly: OwinStartup(typeof(FullStack.OAuth.Startup))]

namespace FullStack.OAuth
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // Generating Certificate: Run below command in powershell
            // New-SelfSignedCertificate -DnsName "<siteAddress>", "<siteAddress>" -CertStoreLocation "cert:\CurrentUser\My"
            
            X509Certificate2 cert = GenerateCertificate.GetX509Certificate2();

            IdentityServerServiceFactory factory = new IdentityServerServiceFactory();
            factory.UseInMemoryUsers(FactoryClass.GetInMemoryUsers());
            factory.UseInMemoryScopes(FactoryClass.GetInMemoryScopes());
            factory.UseInMemoryClients(FactoryClass.GetInMemoryClients());
            
            var options = new IdentityServerOptions();
            options = new IdentityServerOptions
            {
                SigningCertificate = new X509Certificate2(Path.Combine(HostingEnvironment.MapPath("~"), "idsrv3test.pfx"), "idsrv3test"), //cert.GetRawCertData()
                RequireSsl = false,
                Factory = factory
            };

            app.UseIdentityServer(options);


            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888
        }

        //private X509Certificate2 GenerateCertificate(string certName)
        //{
        //    var keypairgen = new RsaKeyPairGenerator();
        //    keypairgen.Init(new KeyGenerationParameters(new SecureRandom(new CryptoApiRandomGenerator()), 1024));

        //    var keypair = keypairgen.GenerateKeyPair();

        //    var gen = new X509V3CertificateGenerator();

        //    var CN = new X509Name("CN=" + certName);
        //    var SN = BigInteger.ProbablePrime(120, new Random());

        //    gen.SetSerialNumber(SN);
        //    gen.SetSubjectDN(CN);
        //    gen.SetIssuerDN(CN);
        //    gen.SetNotAfter(DateTime.MaxValue);
        //    gen.SetNotBefore(DateTime.Now.Subtract(new TimeSpan(7, 0, 0, 0)));
        //    gen.SetSignatureAlgorithm("MD5WithRSA");
        //    gen.SetPublicKey(keypair.Public);

        //    var newCert = gen.Generate(keypair.Private);

        //    return new X509Certificate2(DotNetUtilities.ToX509Certificate((Org.BouncyCastle.X509.X509Certificate)newCert));
        //}
    }
}
