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
    class Siat
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
            reference.AddTransform(new XmlDsigC14NWithCommentsTransform());
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

        public MemoryStream CanonicalizeXml2(XmlDocument doc)
        {
            XmlDsigC14NTransform c = new XmlDsigC14NTransform();
            c.LoadInput(doc);
            return (MemoryStream)c.GetOutput(typeof(MemoryStream));
        }

        public string ByteArrayToString(byte[] ba)
        {
            StringBuilder hex = new StringBuilder(ba.Length * 2);
            foreach (byte b in ba)
                hex.AppendFormat(" {0:x2}", b);
            return hex.ToString();
        }

        public static string ByteArrayToHexString(byte[] ba)
        {
            var hex = new StringBuilder(ba.Length * 2);
            foreach (byte b in ba)
                hex.AppendFormat(" {0:x2}", b);
            return hex.ToString();
        }

        public static void SaveXml(XmlDocument doc, string fileName)
        {
            using (var fs = File.Create(fileName))
            {
                var bom = "<?xml version=\"1.0\" encoding=\"UTF-8\" standalone=\"yes\"?>";
                var bytes = System.Text.Encoding.UTF8.GetBytes(bom);
                fs.Write(bytes, 0, bytes.Length);

                bytes = new byte[] { 0xA };
                fs.Write(bytes, 0, bytes.Length);

                bytes = System.Text.Encoding.UTF8.GetBytes(doc.DocumentElement.OuterXml);
                fs.Write(bytes, 0, bytes.Length);
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

        public string GetModulus11CheckDigit(string n)
        {
            var factor = 2;
            var sum = 0;
            for (var i = n.Length - 1; i >= 0; i--)
            {
                var d = int.Parse(n[i].ToString());
                sum += d * factor++;
                if (factor == 8)
                    factor = 2;
            }

            var remainder = sum % 11;
            if (remainder == 0)
                return sum + "0";
            if (remainder == 1)
                throw new InvalidOperationException("Invalid Modulus11. No se puede calcular el digito de chequeo para esta secuencia.");
            return (11 - remainder).ToString();
        }

        public string GetModulus11CheckDigit2(string number)
        {
            int Sum = 0;
            for (int i = number.Length - 1, Multiplier = 2; i >= 0; i--)
            {
                Sum += (int)char.GetNumericValue(number[i]) * Multiplier;

                if (++Multiplier == 8) Multiplier = 2;
            }
            string Validator = (11 - (Sum % 11)).ToString();

            if (Validator == "11")
                Validator = "0";
            else if (Validator == "10")
                Validator = "X";

            return Validator;
        }

        public string GetModulus11CheckDigitPaceno(string number)
        {
            return GetModulus11CheckDigitPaceno(number, 1, 9, false);
        }

        public string GetModulus11CheckDigitPaceno(string cadena, int numDig, int limMult, bool x10)
        {
            int mult, suma, i, n, dig;
            if (!x10)
                numDig = 1;

            for (n = 1; n <= numDig; n++)
            {
                suma = 0;
                mult = 2;

                for (i = cadena.Length - 1; i >= 0; i--)
                {
                    var ss = cadena.Substring(i, 1);
                    suma += (mult * int.Parse(ss));

                    if (++mult > limMult)
                        mult = 2;
                }

                if (x10)
                    dig = ((suma * 10) % 11) % 10;
                else
                    dig = suma % 11;

                if (dig == 10)
                    cadena += "1";

                if (dig == 11)
                    cadena += "0";

                if (dig < 10)
                    cadena += dig.ToString();
            }

            return cadena.Substring(cadena.Length - 1, numDig);

        }

        public string GetCUF(string nit, string date, string sucursal, byte modalidad, byte tipoEmision, byte tipoFactura, byte tipoDocumentoSector, string numeroFactura, string puntoVenta)
        {
            if (string.IsNullOrEmpty(sucursal))
                throw new ArgumentException("Invalid argument value.", nameof(sucursal));
            if (sucursal.Length > 4)
                throw new ArgumentException("Invalid argument value.", nameof(sucursal));
            if (!int.TryParse(sucursal, out _))
                throw new ArgumentException("Invalid argument value.", nameof(sucursal));
            if (modalidad > 3)
                throw new ArgumentException("Invalid argument value.", nameof(modalidad));
            if (tipoEmision > 3)
                throw new ArgumentException("Invalid argument value.", nameof(tipoEmision));
            if (tipoFactura > 3)
                throw new ArgumentException("Invalid argument value.", nameof(tipoFactura));
            if (tipoDocumentoSector > 24)
                throw new ArgumentException("Invalid argument value.", nameof(tipoDocumentoSector));
            if (string.IsNullOrEmpty(numeroFactura))
                throw new ArgumentException("Invalid argument value.", nameof(numeroFactura));
            if (numeroFactura.Length > 10)
                throw new ArgumentException("Invalid argument value.", nameof(numeroFactura));
            if (!int.TryParse(numeroFactura, out _))
                throw new ArgumentException("Invalid argument value.", nameof(numeroFactura));
            if (string.IsNullOrEmpty(puntoVenta))
                throw new ArgumentException("Invalid argument value.", nameof(puntoVenta));
            if (puntoVenta.Length > 4)
                throw new ArgumentException("Invalid argument value.", nameof(puntoVenta));
            if (!int.TryParse(puntoVenta, out _))
                throw new ArgumentException("Invalid argument value.", nameof(puntoVenta));

            if (date.Length != 17)
                throw new InvalidOperationException("Invalid date format.");

            var x = nit.PadLeft(13, '0')
                + date
                + sucursal.PadLeft(4, '0')
                + modalidad.ToString()
                + tipoEmision.ToString()
                + tipoFactura.ToString()
                + tipoDocumentoSector.ToString().PadLeft(2, '0')
                + numeroFactura.PadLeft(10, '0')
                + puntoVenta.PadLeft(4, '0');
            x += GetModulus11CheckDigitPaceno(x);
            var bi = System.Numerics.BigInteger.Parse(x);
            return bi.ToString("X");
        }

        public static string GetDateCufFormat(DateTime date)
        {
            return date.ToString("yyyyMMddHHmmssfff");
        }

        public string GetCUFIvan(string nit, string fecha, int sucursal, int modalidad, int temision, int tipoFactura, int tipoDocumentoSector, int numeroFactura, int puntoVenta)
        {
            var cadena = System.Numerics.BigInteger.Parse(nit).ToString("D13");
            if (fecha.Length < 17)
                cadena += fecha + int.Parse("0").ToString("D" + (17 - fecha.Length));
            else
                cadena += fecha;
            cadena += sucursal.ToString("D4");
            cadena += modalidad;
            cadena += temision;
            cadena += tipoFactura;
            cadena += tipoDocumentoSector.ToString("D2");
            cadena += numeroFactura.ToString("D10");
            cadena += puntoVenta.ToString("D4");

            cadena += GetModulus11CheckDigitPaceno(cadena);

            var cuf = System.Numerics.BigInteger.Parse(cadena);
            return cuf.ToString("X");
        }
    }
}
