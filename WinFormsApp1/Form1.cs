using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography.Xml;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        private void RemoveWhiteSpaceContent(XmlElement e)
        {
            if (string.IsNullOrWhiteSpace(e.InnerXml))
            {
                e.InnerText = "";
                e.IsEmpty = false;
            }
            foreach (var c in e.ChildNodes)
                if (c is XmlElement)
                    RemoveWhiteSpaceContent((XmlElement)c);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var c = new Siat();
            textBox1.Text = textBox2.Text + c.GetModulus11CheckDigitPaceno(textBox2.Text);
        }


        private async Task<CufCudResult> GetCufAndCufd(string numeroFactura, string date, byte codigoDocumentoSector, byte tipoFacturaDocumento, byte codigoEmision, byte codigoModalidad, int codigoPuntoVenta, string codigoSistema, int codigoSucursal, string cuis, long nit, int codigoAmbiente)
        {
            var c2 = new ServiceReference2.ServicioFacturacionCodigosClient();
            using (new OperationContextScope(c2.InnerChannel))
            {
                var token = "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzUxMiJ9.eyJzdWIiOiJDb2dub3NzeXMiLCJjb2RpZ29TaXN0ZW1hIjoiNkQwQTYxOEU2QjE3MjdGMDA3ODhFRTciLCJuaXQiOiJINHNJQUFBQUFBQUFBRE0wTURReHRqQTBNRElIQUc2ZVQzVUtBQUFBIiwiaWQiOjQ2ODM1MiwiZXhwIjoxNjY0MzIzMjAwLCJpYXQiOjE2MzI4MzUwNTksIm5pdERlbGVnYWRvIjoxMDE0MzgxMDI3LCJzdWJzaXN0ZW1hIjoiU0ZFIn0.mX5V1nGeH5sCDavLOiJrTeEr6r6v7q6iZsoYYoCijjuJy0GQ9xp74QbD7D7P0RgI0gQ_h9AG90u6wubmQAW-VA";
                HttpRequestMessageProperty requestMessage = new HttpRequestMessageProperty();
                requestMessage.Headers["apikey"] = "TokenApi " + token;
                OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] = requestMessage;

                var cufdResult = await c2.cufdAsync(new ServiceReference2.solicitudCufd
                {
                    nit = nit,
                    codigoAmbiente = codigoAmbiente,
                    codigoModalidad = codigoModalidad,
                    codigoPuntoVenta = codigoPuntoVenta,
                    codigoPuntoVentaSpecified = true,
                    codigoSistema = codigoSistema,
                    codigoSucursal = codigoSucursal,
                    cuis = cuis
                });

                var siat = new Siat();
                var cufp1 = siat.GetCUF(nit.ToString(), date, codigoSucursal.ToString(), codigoModalidad, codigoEmision, tipoFacturaDocumento, codigoDocumentoSector, numeroFactura, codigoPuntoVenta.ToString());
                //var cufp1 = siat.GetCUFIvan(nit.ToString(), boliviaDateTimeStr, codigoSucursal, codigoModalidad, codigoEmision, tipoFacturaDocumento, codigoDocumentoSector, int.Parse(numeroFactura), codigoPuntoVenta);
                var codigoControl = cufdResult.RespuestaCufd.codigoControl;

                return new CufCudResult
                {
                    Cufd = cufdResult.RespuestaCufd.codigo,
                    Cuf = cufp1 + codigoControl
                };
            }
        }

        private readonly long nit = 1014381027;
        private readonly int codigoAmbiente = 2;
        private readonly byte codigoModalidad = 1;
        private readonly int codigoPuntoVenta = 0;
        private readonly string codigoSistema = "6D0A618E6B1727F00788EE7";
        private readonly string cuis = "31629D89";
        private readonly byte codigoEmision = 1;
        private readonly byte tipoFacturaDocumento = 1;
        private readonly byte codigoDocumentoSector = 1;
        private readonly string numeroFactura = "1";
        private readonly int codigoSucursal = 0;

        private readonly string privateKeyFileNamePKCS1 = @"C:\Users\elrob\Desktop\BoliviaImpuestos\CognosCert\del\PK-PKCS1.pem";
        private readonly string privateKeyFileNamePKCS8 = @"C:\Users\elrob\Desktop\BoliviaImpuestos\CognosCert\del\PK-PKCS8.pem";
        private readonly string certificateFileName = @"C:\Users\elrob\Desktop\BoliviaImpuestos\CognosCert\del\CR.pem";
        private readonly string xmlFileName = @"D:\Del\facturaElectronicaCompraVenta.xml";
        private readonly string signedXmlFileName = @"d:\del\facturaElectronicaCompraVentaSigned.xml";
        private readonly string canonicalizeXmldName = @"d:\del\facturaElectronicaCompraVentaCanonicalized.xml";
        private readonly string compressedXmlFileName = @"d:\del\facturaElectronicaCompraVenta.xml.gz";

        private async void SendButton_Click(object sender, EventArgs e)
        {
            byte[] compressedBytes = File.ReadAllBytes(compressedXmlFileName);
            var hash = SHA256.Create().ComputeHash(compressedBytes);

            var c = new ServiceReference1.ServicioFacturacionClient();


            var c2 = new ServiceReference2.ServicioFacturacionCodigosClient();

            var doc = new XmlDocument();
            doc.Load(xmlFileName);

            var p = new ServiceReference1.solicitudRecepcionFactura
            {
                archivo = compressedBytes,
                cuis = cuis,
                fechaEnvio = GetDateFromXml(doc),//DateTime.Now.AddHours(1).ToString("yyyy-MM-ddTHH:mm:ss.fff"),
                codigoSucursal = codigoSucursal,
                codigoAmbiente = codigoAmbiente,
                codigoSistema = codigoSistema,
                codigoPuntoVenta = codigoPuntoVenta,
                cufd = GetCufdFromXml(doc),
                nit = nit,
                codigoEmision = codigoEmision,
                tipoFacturaDocumento = tipoFacturaDocumento,

                codigoDocumentoSector = codigoDocumentoSector,
                codigoModalidad = codigoModalidad,
                codigoPuntoVentaSpecified = true,
                hashArchivo = ByteArrayToHexString(hash),
            };
            var response = await c.recepcionFacturaAsync(p);
            var code = response.RespuestaServicioFacturacion.codigoEstado;
            MessageBox.Show(code.ToString() + " " + (code != 908 ? string.Join(";", response.RespuestaServicioFacturacion.mensajesList.Select(ms => ms.descripcion)) : "OK"));
        }

        private void SingXml(XmlDocument doc, X509Certificate2 certificate)
        {
            var signedXml = new SignedXml(doc);
            signedXml.SigningKey = certificate.PrivateKey;
            var reference = new Reference();
            reference.Uri = "";
            reference.AddTransform(new XmlDsigEnvelopedSignatureTransform());
            signedXml.AddReference(reference);

            var keyInfo = new KeyInfo();
            keyInfo.AddClause(new KeyInfoX509Data(certificate));
            signedXml.KeyInfo = keyInfo;
            signedXml.ComputeSignature();
            var xmlSigElement = signedXml.GetXml();
            doc.DocumentElement.AppendChild(doc.ImportNode(xmlSigElement, true));
        }

        private bool VerifyXmlSig(string fileName, X509Certificate2 certificate)
        {
            var doc = new XmlDocument();
            doc.Load(fileName);
            var signedXml = new SignedXml(doc);
            var sigNode = doc.GetElementsByTagName("Signature")[0];
            signedXml.LoadXml((XmlElement)sigNode);
            return signedXml.CheckSignature(certificate, true);
        }

        public X509Certificate2 GetCertificateFromPEMstring(string publicCert, string privateKey, string password)
        {
            byte[] certBuffer = GetBytesFromPEM(publicCert, PemStringType.Certificate);
            byte[] keyBuffer = GetBytesFromPEM(privateKey, PemStringType.RsaPrivateKey);

            X509Certificate2 certificate = new X509Certificate2(certBuffer, password);

            RSACryptoServiceProvider prov = DecodeRsaPrivateKey(keyBuffer);
            certificate.PrivateKey = prov;

            return certificate;
        }

        public byte[] GetBytesFromPEM(string pemString, PemStringType type)
        {
            string header; string footer;

            switch (type)
            {
                case PemStringType.Certificate:
                    header = "-----BEGIN CERTIFICATE-----";
                    footer = "-----END CERTIFICATE-----";
                    break;
                case PemStringType.RsaPrivateKey:
                    header = "-----BEGIN RSA PRIVATE KEY-----";
                    footer = "-----END RSA PRIVATE KEY-----";
                    break;
                default:
                    return null;
            }

            int start = pemString.IndexOf(header) + header.Length;
            var iof = pemString.IndexOf(footer, start);
            int end = pemString.IndexOf(footer, start) - start;
            return System.Convert.FromBase64String(pemString.Substring(start, end));
        }

        /// <summary>
        /// Decodifica una private key en formato PKCS1
        /// </summary>
        /// <param name="privateKeyBytes"></param>
        /// <returns></returns>
        public static RSACryptoServiceProvider DecodeRsaPrivateKey(byte[] privateKeyBytes)
        {
            MemoryStream ms = new MemoryStream(privateKeyBytes);
            BinaryReader rd = new BinaryReader(ms);

            try
            {
                byte byteValue;
                ushort shortValue;

                shortValue = rd.ReadUInt16();

                switch (shortValue)
                {
                    case 0x8130:
                        // If true, data is little endian since the proper logical seq is 0x30 0x81
                        rd.ReadByte(); //advance 1 byte
                        break;
                    case 0x8230:
                        rd.ReadInt16();  //advance 2 bytes
                        break;
                    default:

                        return null;
                }

                shortValue = rd.ReadUInt16();
                if (shortValue != 0x0102) // (version number)
                {
                    //Debug.Assert(false);     // Improper ASN.1 format, unexpected version number
                    return null;
                }

                byteValue = rd.ReadByte();
                if (byteValue != 0x00)
                {
                    //Debug.Assert(false);     // Improper ASN.1 format
                    return null;
                }

                // The data following the version will be the ASN.1 data itself, which in our case
                // are a sequence of integers.

                // In order to solve a problem with instancing RSACryptoServiceProvider
                // via default constructor on .net 4.0 this is a hack
                CspParameters parms = new CspParameters();
                parms.Flags = CspProviderFlags.NoFlags;
                parms.KeyContainerName = Guid.NewGuid().ToString().ToUpperInvariant();
                parms.ProviderType = ((Environment.OSVersion.Version.Major > 5) || ((Environment.OSVersion.Version.Major == 5) && (Environment.OSVersion.Version.Minor >= 1))) ? 0x18 : 1;

                RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(parms);
                RSAParameters rsAparams = new RSAParameters();

                rsAparams.Modulus = rd.ReadBytes(DecodeIntegerSize(rd));

                // Argh, this is a pain.  From emperical testing it appears to be that RSAParameters doesn't like byte buffers that
                // have their leading zeros removed.  The RFC doesn't address this area that I can see, so it's hard to say that this
                // is a bug, but it sure would be helpful if it allowed that. So, there's some extra code here that knows what the
                // sizes of the various components are supposed to be.  Using these sizes we can ensure the buffer sizes are exactly
                // what the RSAParameters expect.  Thanks, Microsoft.
                RSAParameterTraits traits = new RSAParameterTraits(rsAparams.Modulus.Length * 8);

                rsAparams.Modulus = AlignBytes(rsAparams.Modulus, traits.size_Mod);
                rsAparams.Exponent = AlignBytes(rd.ReadBytes(DecodeIntegerSize(rd)), traits.size_Exp);
                rsAparams.D = AlignBytes(rd.ReadBytes(DecodeIntegerSize(rd)), traits.size_D);
                rsAparams.P = AlignBytes(rd.ReadBytes(DecodeIntegerSize(rd)), traits.size_P);
                rsAparams.Q = AlignBytes(rd.ReadBytes(DecodeIntegerSize(rd)), traits.size_Q);
                rsAparams.DP = AlignBytes(rd.ReadBytes(DecodeIntegerSize(rd)), traits.size_DP);
                rsAparams.DQ = AlignBytes(rd.ReadBytes(DecodeIntegerSize(rd)), traits.size_DQ);
                rsAparams.InverseQ = AlignBytes(rd.ReadBytes(DecodeIntegerSize(rd)), traits.size_InvQ);

                rsa.ImportParameters(rsAparams);
                return rsa;
            }

            finally
            {
                rd.Close();
            }
        }

        public static byte[] AlignBytes(byte[] inputBytes, int alignSize)
        {
            int inputBytesSize = inputBytes.Length;

            if ((alignSize != -1) && (inputBytesSize < alignSize))
            {
                byte[] buf = new byte[alignSize];
                for (int i = 0; i < inputBytesSize; ++i)
                {
                    buf[i + (alignSize - inputBytesSize)] = inputBytes[i];
                }
                return buf;
            }
            else
            {
                return inputBytes;      // Already aligned, or doesn't need alignment
            }
        }

        public static int DecodeIntegerSize(System.IO.BinaryReader rd)
        {
            byte byteValue;
            int count;

            byteValue = rd.ReadByte();
            if (byteValue != 0x02)        // indicates an ASN.1 integer value follows
                return 0;

            byteValue = rd.ReadByte();
            if (byteValue == 0x81)
            {
                count = rd.ReadByte();    // data size is the following byte
            }
            else if (byteValue == 0x82)
            {
                byte hi = rd.ReadByte();  // data size in next 2 bytes
                byte lo = rd.ReadByte();
                count = BitConverter.ToUInt16(new[] { lo, hi }, 0);
            }
            else
            {
                count = byteValue;        // we already have the data size
            }

            //remove high order zeros in data
            while (rd.ReadByte() == 0x00)
            {
                count -= 1;
            }
            rd.BaseStream.Seek(-1, System.IO.SeekOrigin.Current);

            return count;
        }

        private void SignAndCompressButton_Click(object sender, EventArgs e)
        {
            var certificate = new X509Certificate2(certificateFileName);

            //var pkBytes = GetBytesFromPEM(File.ReadAllText(privateKeyFileNamePKCS1, System.Text.Encoding.UTF8), PemStringType.RsaPrivateKey);
            //var rsaPKCS1 = DecodeRsaPrivateKey(pkBytes);

            var rsaPKCS8 = RSA.Create();
            rsaPKCS8.ImportFromPem(File.ReadAllText(privateKeyFileNamePKCS8).ToCharArray());

            var siat = new Siat();

            var doc = new XmlDocument();
            doc.Load(xmlFileName);

            using (var canonicalizedStream = siat.CanonicalizeXml2(doc))
            {
                doc = new XmlDocument();
                doc.Load(canonicalizedStream);

                siat.SingXml(doc, rsaPKCS8, certificate);

                Siat.SaveXml(doc, signedXmlFileName);

                var ok = siat.VerifyXmlSig(doc);

                siat.CompressFile(signedXmlFileName, compressedXmlFileName);

                MessageBox.Show(ok.ToString());
            }
        }

        public string ByteArrayToHexString(byte[] ba)
        {
            var hex = new StringBuilder(ba.Length * 2);
            foreach (byte b in ba)
                hex.AppendFormat("{0:x2}", b);
            return hex.ToString();
        }

        private void VerifySignatureButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                var c2 = new Siat();
                var doc = new XmlDocument();
                doc.Load(openFileDialog1.FileName);
                var ok = c2.VerifyXmlSig(doc);
                MessageBox.Show(ok.ToString());
            }
        }

        private void CompressButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    var c2 = new Siat();
                    c2.CompressFile(openFileDialog1.FileName, saveFileDialog1.FileName);
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "XML|*.xml";
            saveFileDialog1.Filter = "XML|*.xml";
            if (openFileDialog1.ShowDialog() == DialogResult.OK && saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                var certificate = new X509Certificate2(certificateFileName);

                var pkBytes = GetBytesFromPEM(File.ReadAllText(privateKeyFileNamePKCS1, System.Text.Encoding.UTF8), PemStringType.RsaPrivateKey);
                var rsa = DecodeRsaPrivateKey(pkBytes);
                var rsaV8 = RSA.Create();
                rsaV8.ImportFromPem(File.ReadAllText(privateKeyFileNamePKCS8).ToCharArray());

                var c2 = new Siat();

                var doc = new XmlDocument();
                doc.Load(openFileDialog1.FileName);
                c2.SingXml(doc, rsaV8, certificate);

                Siat.SaveXml(doc, saveFileDialog1.FileName);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK && saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                var certificate = new X509Certificate2(certificateFileName);

                var pkBytes = GetBytesFromPEM(File.ReadAllText(privateKeyFileNamePKCS1, System.Text.Encoding.UTF8), PemStringType.RsaPrivateKey);
                var rsaPKCS1 = DecodeRsaPrivateKey(pkBytes);
                var rsaPKCS8 = RSA.Create();
                rsaPKCS8.ImportFromPem(File.ReadAllText(privateKeyFileNamePKCS8).ToCharArray());


                var c2 = new Siat();

                var doc = new XmlDocument();
                doc.Load(openFileDialog1.FileName);
                c2.SingXml(doc, rsaPKCS8, certificate);

                Siat.SaveXml(doc, saveFileDialog1.FileName);
            }
        }

        private void CanonicalizeXmlButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK && saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                var c2 = new Siat();

                var doc = new XmlDocument();
                doc.Load(openFileDialog1.FileName);
                using (var ms = c2.CanonicalizeXml2(doc))
                {
                    doc.Load(ms);
                    Siat.SaveXml(doc, saveFileDialog1.FileName);
                }
            }
        }

        bool _XmlSchemeError;
        private void ValidateXmlButton_Click(object sender, EventArgs e)
        {
            _XmlSchemeError = false;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                XmlSchemaSet schema = new XmlSchemaSet();
                schema.Add("", @"D:\Del\Cognos_XML_XSD\facturaElectronicaCompraVenta.xsd");
                schema.Add("http://www.w3.org/2000/09/xmldsig#", @"D:\Del\Cognos_XML_XSD\SignatureSchema.xsd");
                using (XmlReader rd = XmlReader.Create(openFileDialog1.FileName))
                {
                    XDocument doc = XDocument.Load(rd);
                    doc.Validate(schema, ValidationEventHandler);
                    if (!_XmlSchemeError)
                        MessageBox.Show("OK");
                }
            }
        }

        private void ValidationEventHandler(object sender, ValidationEventArgs e)
        {
            _XmlSchemeError = true;
            XmlSeverityType type = XmlSeverityType.Warning;
            if (Enum.TryParse<XmlSeverityType>("Error", out type))
            {
                if (type == XmlSeverityType.Error) throw new Exception(e.Message);
            }
        }

        private async void GenerateCufButton_Click(object sender, EventArgs e)
        {
            var siat = new Siat();
            var date = DateTime.Now; //DateTime.Now.AddHours(1);
            var dateStr = Siat.GetDateCufFormat(date);
            dateStr = textBox12.Text;
            //dateStr = "20190113163721231"; //test
            var tipoFacturaDocumento = byte.Parse(textBox9.Text);
            var codigoModalidad = byte.Parse(textBox6.Text);
            var codigoEmision = byte.Parse(textBox7.Text);
            var codigoPuntoVenta = textBox11.Text;
            var numeroFactura = textBox10.Text;
            var codigoAmbiente = CodigoAmbienteTextBox.Text;
            var nit = textBox3.Text;
            var codigoDocumentoSector = byte.Parse(textBox14.Text);
            var sucursal = textBox5.Text;
            var cufp1 = siat.GetCUF(nit, dateStr, sucursal, codigoModalidad, codigoEmision, tipoFacturaDocumento, codigoDocumentoSector, numeroFactura, codigoPuntoVenta);
            var cufp1Ivan = siat.GetCUFIvan(nit, dateStr, int.Parse(sucursal), codigoModalidad, codigoEmision, tipoFacturaDocumento, codigoDocumentoSector, int.Parse(numeroFactura), int.Parse(codigoPuntoVenta));
            textBox4.Text = cufp1;
            textBox13.Text = cufp1Ivan;
            var cufCufd = await GetCufAndCufd(numeroFactura, dateStr, codigoDocumentoSector, tipoFacturaDocumento, codigoEmision, codigoModalidad, int.Parse(codigoPuntoVenta), CodigoSistemaTextBox.Text, int.Parse(sucursal), CuisTextBox.Text, long.Parse(nit), int.Parse(codigoAmbiente));
            if (!cufCufd.Cuf.StartsWith(cufp1))
                throw new InvalidOperationException();
            CufdTextBox.Text = cufCufd.Cufd;
        }

        private async void SetCufCufdDateToXmlButton_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "XML|*.xml";
            if (openFileDialog1.ShowDialog() == DialogResult.OK /*&& saveFileDialog1.ShowDialog() == DialogResult.OK*/)
            {
                var date = DateTime.Now.AddHours(1);
                var cufCufd = await GetCufAndCufd(numeroFactura, Siat.GetDateCufFormat(date), codigoDocumentoSector, tipoFacturaDocumento, codigoEmision, codigoModalidad, codigoPuntoVenta, codigoSistema, codigoSucursal, cuis, nit, codigoAmbiente);
                var doc = new XmlDocument();
                doc.Load(openFileDialog1.FileName);
                doc.GetElementsByTagName("cuf")[0].InnerText = cufCufd.Cuf;
                doc.GetElementsByTagName("cufd")[0].InnerText = cufCufd.Cufd;
                doc.GetElementsByTagName("fechaEmision")[0].InnerText = date.ToString("yyyy-MM-ddTHH:mm:ss.fff");
                doc.Save(openFileDialog1.FileName);
            }
        }

        private string GetCufFromXml(XmlDocument doc)
        {
            return doc.GetElementsByTagName("cuf")[0].InnerText;
        }

        private string GetCufdFromXml(XmlDocument doc)
        {
            return doc.GetElementsByTagName("cufd")[0].InnerText;
        }

        private string GetDateFromXml(XmlDocument doc)
        {
            return doc.GetElementsByTagName("fechaEmision")[0].InnerText;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox12.Text = Siat.GetDateCufFormat(DateTime.Now);
        }

    }

    public enum PemStringType
    {
        Certificate,
        RsaPrivateKey
    }
}
