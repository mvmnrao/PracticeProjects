using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;

namespace FullStack.OAuth
{
    public class GenerateCertificate
    {
        public static X509Certificate2 GetX509Certificate2()
        {
            // https://github.com/IdentityServer/IdentityServer3.Samples/tree/master/source/Certificates
            // https://social.msdn.microsoft.com/Forums/vstudio/en-US/f2b005b8-c1ab-4c0c-8ea6-77b03c8fa120/creatingsetting-x509certificate2privatekey-from-key-file?forum=netfxbcl
            // https://gallery.technet.microsoft.com/scriptcenter/Self-signed-certificate-5920a7c6
            // https://support.microsoft.com/en-in/help/889651/how-to-assign-a-private-key-to-a-new-certificate-after-you-use-the-cer

            return GetCertificateFromStore("CN=idsrv3test");
        }

        private static X509Certificate2 GetCertificateFromStore(string certName)
        {
            // Get the certificate store for the current user.
            X509Store store = new X509Store(StoreLocation.LocalMachine);
            try
            {
                store.Open(OpenFlags.ReadOnly);

                // Place all certificates in an X509Certificate2Collection object.
                X509Certificate2Collection certCollection = store.Certificates;
                // If using a certificate with a trusted root you do not need to FindByTimeValid, instead:
                // currentCerts.Find(X509FindType.FindBySubjectDistinguishedName, certName, true);
                X509Certificate2Collection currentCerts = certCollection.Find(X509FindType.FindByTimeValid, DateTime.Now, false);
                X509Certificate2Collection signingCert = currentCerts.Find(X509FindType.FindBySubjectDistinguishedName, certName, false);
                if (signingCert.Count == 0)
                {
                    return null;
                }

                X509Certificate2 cert = signingCert[0];

                // Return the first certificate in the collection, has the right name and is current.
                return cert;
            }
            finally
            {
                store.Close();
            }

        }

        ///// <summary>
        ///// Based on:
        ///// http://stackoverflow.com/questions/3770233/is-it-possible-to-programmatically-generate-an-x509-certificate-using-only-c
        ///// http://web.archive.org/web/20100504192226/http://www.fkollmann.de/v2/post/Creating-certificates-using-BouncyCastle.aspx
        ///// </summary>
        //public class CertificateGenerator
        //{
            //public static X509Certificate
            //    GenerateCertificate(string subjectName, out AsymmetricCipherKeyPair kp)
            //{
            //    var kpgen = new RsaKeyPairGenerator();

            //    // certificate strength 1024 bits
            //    kpgen.Init(new KeyGenerationParameters(
            //          new SecureRandom(new CryptoApiRandomGenerator()), 1024));

            //    kp = kpgen.GenerateKeyPair();

            //    var gen = new X509V3CertificateGenerator();

            //    var certName = new X509Name("CN=" + subjectName);
            //    var serialNo = BigInteger.ProbablePrime(120, new Random());

            //    gen.SetSerialNumber(serialNo);
            //    gen.SetSubjectDN(certName);
            //    gen.SetIssuerDN(certName);
            //    gen.SetNotAfter(DateTime.Now.AddYears(100));
            //    gen.SetNotBefore(DateTime.Now.Subtract(new TimeSpan(7, 0, 0, 0)));
            //    gen.SetSignatureAlgorithm("SHA1withRSA");
            //    gen.SetPublicKey(kp.Public);

            //    gen.AddExtension(
            //        X509Extensions.AuthorityKeyIdentifier.Id,
            //        false,
            //        new AuthorityKeyIdentifier(
            //            SubjectPublicKeyInfoFactory.CreateSubjectPublicKeyInfo(kp.Public),
            //            new GeneralNames(new GeneralName(certName)),
            //            serialNo));

            //    /* 
            //     1.3.6.1.5.5.7.3.1 - id_kp_serverAuth 
            //     1.3.6.1.5.5.7.3.2 - id_kp_clientAuth 
            //     1.3.6.1.5.5.7.3.3 - id_kp_codeSigning 
            //     1.3.6.1.5.5.7.3.4 - id_kp_emailProtection 
            //     1.3.6.1.5.5.7.3.5 - id-kp-ipsecEndSystem 
            //     1.3.6.1.5.5.7.3.6 - id-kp-ipsecTunnel 
            //     1.3.6.1.5.5.7.3.7 - id-kp-ipsecUser 
            //     1.3.6.1.5.5.7.3.8 - id_kp_timeStamping 
            //     1.3.6.1.5.5.7.3.9 - OCSPSigning
            //     */
            //    gen.AddExtension(
            //        X509Extensions.ExtendedKeyUsage.Id,
            //        false,
            //        new ExtendedKeyUsage(new[] { KeyPurposeID.IdKPServerAuth }));

            //    var newCert = gen.Generate(kp.Private);

            //    return newCert;
            //}
        }
}