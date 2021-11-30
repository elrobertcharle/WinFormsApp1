using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace WinFormsApp1
{
    class Class2
    {
        //public void SignData(RSA rsa)
        //{
        //    var text = "Hola que bola";

        //    byte[] signature;

        //    using (rsa)       //OJOOOO
        //    {
        //        //var p = service.ExportParameters(true);
        //        //var docx = XDocument.Parse(service.ToXmlString(true));

        //        var bytes = System.Text.Encoding.UTF8.GetBytes(text);
        //        var sha256 = SHA256.Create();
        //        var hash = sha256.ComputeHash(bytes);

        //        signature = rsa.SignHash(hash, System.Security.Cryptography.HashAlgorithmName.SHA256, System.Security.Cryptography.RSASignaturePadding.Pkcs1);
        //    }


        //}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="doc"></param>
        /// <param name="rsa">Private Key</param>
        /// <param name="certificate">Publi Key</param>
        public void SingXml(XmlDocument doc, RSA rsa, X509Certificate2 certificate)
        {
            var signedXml = new SignedXml(doc);
            signedXml.SigningKey = rsa;

            signedXml.SignedInfo.CanonicalizationMethod = SignedXml.XmlDsigC14NTransformUrl;
            //XmlDsigExcC14NTransform canMethod = (XmlDsigExcC14NTransform)signedXml.SignedInfo.CanonicalizationMethodObject;
            //canMethod.InclusiveNamespacesPrefixList = "";

            var reference = new Reference();
            reference.Uri = "";
            reference.AddTransform(new XmlDsigEnvelopedSignatureTransform());
            reference.AddTransform(new XmlDsigC14NTransform());
            signedXml.AddReference(reference);

            var keyInfo = new KeyInfo();
            keyInfo.AddClause(new KeyInfoX509Data(certificate));
            signedXml.KeyInfo = keyInfo;

            signedXml.ComputeSignature();
            var xmlSigElement = signedXml.GetXml();
            doc.DocumentElement.AppendChild(doc.ImportNode(xmlSigElement, true));
        }

        //public bool VerifyXmlSig(string fileName, X509Certificate2 certificate)
        //{
        //    var doc = new XmlDocument();
        //    doc.Load(fileName);
        //    return VerifyXmlSig(doc, certificate);
        //}

        //public bool VerifyXmlSig(XmlDocument doc, X509Certificate2 certificate)
        //{
        //    var signedXml = new SignedXml(doc);
        //    var sigNode = doc.GetElementsByTagName("Signature")[0];
        //    signedXml.LoadXml((XmlElement)sigNode);
        //    return signedXml.CheckSignature(certificate, true);
        //}

        public bool VerifyXmlSig(XmlDocument doc)
        {
            var signedXml = new SignedXml(doc);
            var sigNode = doc.GetElementsByTagName("Signature")[0];
            signedXml.LoadXml((XmlElement)sigNode);
            return signedXml.CheckSignature();
        }

        //public RSA GetRSAPrivateKeyFromFile(string fileName)
        //{

        //}

        public void CompressFile(string originalFileName, string compressedFileName)
        {
            using (FileStream originalFileStream = File.Open(originalFileName, FileMode.Open))
            using (FileStream compressedFileStream = File.Create(compressedFileName))
            using (var compressor = new GZipStream(compressedFileStream, CompressionMode.Compress))
            {
                originalFileStream.CopyTo(compressor);
            }
        }

        public XmlDocument CanonicalizeXml(XmlDocument doc)
        {
            XmlDsigC14NTransform c = new XmlDsigC14NTransform();
            c.LoadInput(doc);
            using (var s = (Stream)c.GetOutput(typeof(Stream)))
            {
                var result = new XmlDocument();
                result.Load(s);
                return result;
            }
        }

        public static void SaveXml(XmlDocument doc, string fileName)
        {
            doc.CreateXmlDeclaration("1.0", "UTF-8", "yes");
            XmlWriterSettings settings = new XmlWriterSettings { Indent = true, Encoding = Encoding.UTF8 };
            using (XmlWriter writer = XmlWriter.Create(fileName, settings))
            {
                writer.WriteStartDocument(true);
                doc.Save(writer);
            }
        }

        public static void RemoveBOM(string source)
        {
            var tempFileName = @"d:\del\temp";
            using (var s = File.OpenRead(source))
            {
                using (var target = File.OpenWrite(tempFileName))
                {
                    byte[] buff = new byte[1024];
                    s.Read(buff, 0, 3);
                    target.Write(buff, 0, 3);
                    s.Seek(43, SeekOrigin.Begin);
                    int read;
                    while ((read = s.Read(buff, 0, 1024)) > 0)
                        target.Write(buff, 0, read);
                }
            }
        }

        //public Stream CanonicalizeXmlStream(XmlDocument doc)
        //{
        //    XmlDsigC14NTransform c = new XmlDsigC14NTransform();
        //    c.LoadInput(doc);
        //    return (Stream)c.GetOutput(typeof(Stream));
        //}
    }
}
