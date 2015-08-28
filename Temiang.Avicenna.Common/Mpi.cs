using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
//using System.Web.UI;
using System.Xml;
using System.Xml.Serialization;
//using MPI;
using Temiang.Avicenna.Common;
using Temiang.Avicenna.BusinessObject.Mpi;
using Temiang.Avicenna.BusinessObject;
using System.Web;
using System.Configuration;


namespace Temiang.Avicenna.Common
{
    public class Mpi
    {
        private const string _apiKey = "fa7d1528df8e20e0276d0692c7dfb0f7";
        private const string _secret = "06c219e5bc8378f3a8a3f83b4b7e4649";
        private string token = string.Empty;
        List<KeyValuePair<string, string>> pasienList = new List<KeyValuePair<string, string>>();

        private static string MpiUrlApi
        {
            get
            {
                //return AppParameter.GetParameterValue(AppParameter.ParameterItem.MpiUrlApi);
                return ConfigurationManager.AppSettings["MpiUrl"].ToString();
            }
        }

        public static StreamReader SendData(string postData)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(MpiUrlApi);

            request.Method = "POST";
            request.AllowAutoRedirect = true;
            request.ContentType = "application/x-www-form-urlencoded";
            Encoding utf8 = new UTF8Encoding();
            byte[] content = utf8.GetBytes(postData);
            using (Stream requestStream = request.GetRequestStream())
            {
                requestStream.Write(content, 0, content.Length);
            }
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            StreamReader sr = new StreamReader(response.GetResponseStream());
            return sr;
        }
        private static MemoryStream ConvertToStream(string data)
        {
            // convert string to stream
            byte[] byteArray = Encoding.ASCII.GetBytes(data);
            MemoryStream stream = new MemoryStream(byteArray);
            return stream;

        }

        //private static string MD5Hash(string data)
        //{
        //    //create new instance of md5
        //    MD5 md5 = MD5.Create();

        //    //convert the input text to array of bytes
        //    byte[] hashData = md5.ComputeHash(Encoding.Default.GetBytes(data));

        //    //create new instance of StringBuilder to save hashed data
        //    StringBuilder returnValue = new StringBuilder();

        //    //loop for each byte and add it to StringBuilder
        //    for (int i = 0; i < hashData.Length; i++)
        //    {
        //        returnValue.Append(hashData[i].ToString());
        //    }

        //    // return hexadecimal string
        //    return returnValue.ToString();
        //}

        public static string CreateRequest(string queryString)
        {
            //IP Address from kencana perceptive
            string UrlRequest = ConfigurationManager.AppSettings["MpiUrl"].ToString() + queryString;
            // url dipindah ke web.config
            // url training : http://172.16.5.10/mpi/api.php?
            //url live : http://192.168.107.100/mpi/api.php?
            //string UrlRequest = "http://192.168.107.100/mpi/api.php?" + queryString;
            //IP Address for dummy test
            //if (HttpContext.Current.IsDebuggingEnabled)
            //UrlRequest = UrlRequest + queryString;
            //IP Address for live production
            //string UrlRequest = "http://192.168.13.10/mpi/api.php?" + queryString;
            return (UrlRequest);
        }

        public static XmlDocument MakeRequest(string requestUrl)
        {
            try
            {
                HttpWebRequest request = WebRequest.Create(requestUrl) as HttpWebRequest;
                request.Method = "POST";
                request.AllowAutoRedirect = true;
                request.ContentType = "application/x-www-form-urlencoded";
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(response.GetResponseStream());
                return (xmlDoc);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                Console.Read();
                return null;
            }
        }

        public static string MD5Hash(string data)
        {
            MD5 md5 = MD5CryptoServiceProvider.Create();
            byte[] dataMd5 = md5.ComputeHash(Encoding.Default.GetBytes(data));
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < dataMd5.Length; i++)
                sb.AppendFormat("{0:x2}", dataMd5[i]);
            return sb.ToString();
        }

        // Token Generating
        public static string Token()
        {
            string token = string.Empty;
            string method = "auth";
            string rand = ((Int32)(DateTime.Now.Subtract(new DateTime(1970, 1, 1))).TotalSeconds).ToString().Trim();
            //Int32 unixTimestamp = (Int32)(DateTime.Now.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
            //rand = unixTimestamp.ToString().Trim();

            string auth_sig = MD5Hash(string.Concat(_secret, _apiKey, rand));
            string postData = string.Format("method={0}&api_key={1}&rand={2}&auth_sig={3}", method, _apiKey, rand,
                                            auth_sig);
            //txtApiSig.Text = postData;
            string locationsRequest = CreateRequest(postData);
            XmlDocument locationsResponse = MakeRequest(locationsRequest);
            var nsmgr = new XmlNamespaceManager(locationsResponse.NameTable);
            nsmgr.AddNamespace("xsl", "http://www.w3.org/1999/XSL/Transform");
            XmlNodeList authElement = locationsResponse.SelectNodes("auth", nsmgr);
            if (authElement.Count >= 1)
            {
                foreach (XmlNode authItemElement in authElement)
                {
                    string isResponseOK = authItemElement.SelectSingleNode("response", nsmgr).InnerText;
                    string isSuccess = authItemElement.SelectSingleNode("status", nsmgr).InnerText;
                    if (isResponseOK == "ok" && isSuccess == "login success")
                        token = authItemElement.SelectSingleNode("token", nsmgr).InnerText;
                    else
                        token = string.Empty;
                }
            }
            return token;
        }

        public static void ProcessResponse(XmlDocument locationsResponse)
        {
            //Create namespace manager
            //XmlNamespaceManager nsmgr = new XmlNamespaceManager(locationsResponse.NameTable);
            //nsmgr.AddNamespace("rest", "http://schemas.microsoft.com/search/local/ws/rest/v1");

            //Get formatted addresses: Option 1
            //Get all locations in the response and then extract the formatted address for each location
            XmlNodeList locationElements = locationsResponse.SelectNodes("//rest:Location");
            Console.WriteLine("Show all formatted addresses: Option 1");
            foreach (XmlNode location in locationElements)
            {
                Console.WriteLine(location.SelectSingleNode(".//rest:FormattedAddress").InnerText);
            }
            Console.WriteLine();

            //Get formatted addresses: Option 2
            //Get all formatted addresses directly. This works because there is only one formatted address for each location.
            XmlNodeList formattedAddressElements = locationsResponse.SelectNodes("//rest:FormattedAddress");
            Console.WriteLine("Show all formatted addresses: Option 2");
            foreach (XmlNode formattedAddress in formattedAddressElements)
            {
                Console.WriteLine(formattedAddress.InnerText);
            }
            Console.WriteLine();

            //Get the Geocode Points to use for display for each Location
            XmlNodeList locationElementsForGP = locationsResponse.SelectNodes("//rest:Location");
            Console.WriteLine("Show Goeocode Point Data");
            foreach (XmlNode location in locationElements)
            {
                XmlNodeList displayGeocodePoints = location.SelectNodes(".//rest:GeocodePoint/rest:UsageType[.='Display']/parent::node()");
                Console.Write(location.SelectSingleNode(".//rest:FormattedAddress").InnerText);
                Console.WriteLine(" has " + displayGeocodePoints.Count.ToString() + " display geocode point(s).");
            }
            Console.WriteLine();

            //Get all locations that have a MatchCode=Good and Confidence=High
            XmlNodeList matchCodeGoodElements = locationsResponse.SelectNodes("//rest:Location/rest:MatchCode[.='Good']/parent::node()");
            Console.WriteLine("Show all addresses with MatchCode=Good and Confidence=High");
            foreach (XmlNode location in matchCodeGoodElements)
            {
                if (location.SelectSingleNode(".//rest:Confidence").InnerText == "High")
                {
                    Console.WriteLine(location.SelectSingleNode(".//rest:FormattedAddress").InnerText);
                }
            }

            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }

        public static int SortKeyAscending(KeyValuePair<string, string> a, KeyValuePair<string, string> b)
        {
            return a.Key.CompareTo(b.Key);
        }

        public static int SortValueAscending(KeyValuePair<string, string> a, KeyValuePair<string, string> b)
        {
            return a.Value.CompareTo(b.Value);
        }

        public static XmlDocument Post(List<KeyValuePair<string, string>> arguments)
        {
            arguments.Sort(SortKeyAscending);
            string prePost = string.Empty;
            string postData = string.Empty;
            string apiSign = string.Empty;
            if (string.IsNullOrEmpty(Token()))
                return null;
            else
                prePost = Token();
            foreach (var attrib in arguments)
            {
                if (string.IsNullOrEmpty(attrib.Key) || string.IsNullOrEmpty(attrib.Value))
                    continue;
                prePost = prePost + attrib.Key + attrib.Value;
            }
            foreach (var attrib in arguments)
            {
                if (string.IsNullOrEmpty(attrib.Key) || string.IsNullOrEmpty(attrib.Value))
                    continue;
                postData = postData + attrib.Key + "=" + attrib.Value + "&";
            }
            postData = postData + "api_sig=" + MD5Hash(prePost);
            string Request = CreateRequest(postData);
            XmlDocument Response = MakeRequest(Request);
            return Response;
        }



        //**********SEARCH PATIENT BY MR NO*************//
        public static bool searchPatientByMedicalNo(string medicalNo)
        {
            string prePost = string.Empty;
            string postData = string.Empty;
            string apiSign = string.Empty;
            if (string.IsNullOrEmpty(Token()))
                return false;
            else
                prePost = Token();
            var QueryStrings = new List<KeyValuePair<string, string>>();
            QueryStrings.Add(new KeyValuePair<string, string>("method", "pasien_cari"));
            QueryStrings.Add(new KeyValuePair<string, string>("mrn", medicalNo));
            QueryStrings.Add(new KeyValuePair<string, string>("api_key", _apiKey));
            QueryStrings.Add(new KeyValuePair<string, string>("v", "1.0"));
            XmlDocument Result = Post(QueryStrings);

            var nsmgr = new XmlNamespaceManager(Result.NameTable);
            nsmgr.AddNamespace("xsl", "http://www.w3.org/1999/XSL/Transform");
            XmlNodeList responsesElement = Result.SelectNodes("response", nsmgr);
            if (responsesElement.Count >= 1)
            {
                foreach (XmlNode responseElement in responsesElement)
                {
                    XmlNode pat = responseElement.SelectSingleNode("patients", nsmgr);
                    int patCount = Convert.ToInt32(pat.Attributes["count"].Value);
                    if (patCount == 0)
                        return false;
                    XmlNodeList patientsElement = responseElement.SelectNodes("patients", nsmgr);
                    //if (patientsElement.Count >= 1)
                    //{
                    foreach (XmlNode patientElement in patientsElement)
                    {
                        //int patientCount = Convert.ToInt32(patientElement.Attributes["count"].Value);
                        //if (patientCount == 0)
                        //    return false;
                        XmlNodeList pasienElement = patientElement.SelectNodes("patient", nsmgr);
                        //Label1.Text = pasienElement.Count.ToString();
                        foreach (XmlNode pasien in pasienElement)
                        {
                            //txtArg2Name.Text += pasien.Attributes["person_nm"].Value + " ";
                            if (!string.IsNullOrEmpty(pasien.Attributes["person_nm"].Value))
                                return true;
                        }
                    }
                    //}
                }
            }
            else
                return false;
            return true;
        }

        //Get PatientID from existing mrno on mpi server
        public static List<KeyValuePair<string, string>> searchResultPatientByMedicalNo(string medicalNo)
        {
            string prePost = string.Empty;
            string postData = string.Empty;
            string apiSign = string.Empty;
            if (string.IsNullOrEmpty(Token()))
                return null;
            else
                prePost = Token();
            var QueryStrings = new List<KeyValuePair<string, string>>();
            QueryStrings.Add(new KeyValuePair<string, string>("method", "pasien_cari"));
            QueryStrings.Add(new KeyValuePair<string, string>("mrn", medicalNo));
            QueryStrings.Add(new KeyValuePair<string, string>("api_key", _apiKey));
            QueryStrings.Add(new KeyValuePair<string, string>("v", "1.0"));
            XmlDocument Result = Post(QueryStrings);

            var nsmgr = new XmlNamespaceManager(Result.NameTable);
            nsmgr.AddNamespace("xsl", "http://www.w3.org/1999/XSL/Transform");
            XmlNodeList responsesElement = Result.SelectNodes("response", nsmgr);
            if (responsesElement.Count >= 1)
            {
                foreach (XmlNode responseElement in responsesElement)
                {
                    XmlNode pat = responseElement.SelectSingleNode("patients", nsmgr);
                    int patCount = Convert.ToInt32(pat.Attributes["count"].Value);
                    if (patCount == 0)
                        return null;
                    XmlNodeList patientsElement = responseElement.SelectNodes("patients", nsmgr);
                    //if (patientsElement.Count >= 1)
                    //{
                    foreach (XmlNode patientElement in patientsElement)
                    {
                        //int patientCount = Convert.ToInt32(patientElement.Attributes["count"].Value);
                        //if (patientCount == 0)
                        //    return false;
                        XmlNodeList pasienElement = patientElement.SelectNodes("patient", nsmgr);
                        //Label1.Text = pasienElement.Count.ToString();
                        var Responses = new List<KeyValuePair<string, string>>();
                        foreach (XmlNode pasien in pasienElement)
                        {
                            //txtArg2Name.Text += pasien.Attributes["person_nm"].Value + " ";
                            if (string.IsNullOrEmpty(pasien.Attributes["patient_id"].Value))
                                return null;

                            //string patient_id = patientElement.SelectSingleNode("patient_id", nsmgr).InnerText;
                            string patient_id = pasien.Attributes["patient_id"].Value;
                            string person_nm = pasien.Attributes["person_nm"].Value;
                            Responses.Add(new KeyValuePair<string, string>(patient_id, person_nm));
                        }
                        if (Responses.Count > 0)
                            return Responses;
                    }
                    return null;
                    //}
                }
                return null;
            }
            else
                return null;
        }



        //****PASIEN LAMA - Request patient ID for new patient with existing mr no****//
        public static List<KeyValuePair<string, string>> PasienLama()
        {
            string prePost = string.Empty;
            string postData = string.Empty;
            string apiSign = string.Empty;
            if (string.IsNullOrEmpty(Token()))
                return null;
            else
                prePost = Token();
            var QueryStrings = new List<KeyValuePair<string, string>>();
            QueryStrings.Add(new KeyValuePair<string, string>("method", "pasien_lama"));
            QueryStrings.Add(new KeyValuePair<string, string>("api_key", _apiKey));
            QueryStrings.Add(new KeyValuePair<string, string>("v", "1.0"));
            XmlDocument Result = Post(QueryStrings);

            var nsmgr = new XmlNamespaceManager(Result.NameTable);
            nsmgr.AddNamespace("xsl", "http://www.w3.org/1999/XSL/Transform");
            XmlNodeList responsesElement = Result.SelectNodes("response", nsmgr);
            var Responses = new List<KeyValuePair<string, string>>();
            if (responsesElement.Count >= 1)
            {
                foreach (XmlNode responseElement in responsesElement)
                {
                    XmlNodeList patientsElement = responseElement.SelectNodes("patient", nsmgr);
                    if (patientsElement.Count >= 1)
                    {
                        foreach (XmlNode patientElement in patientsElement)
                        {
                            string patient_id = patientElement.SelectSingleNode("patient_id", nsmgr).InnerText;
                            string person_id = patientElement.SelectSingleNode("person_id", nsmgr).InnerText;
                            Responses.Add(new KeyValuePair<string, string>(patient_id, person_id));
                        }
                    }
                }
            }
            else
                return null;
            return Responses;
        }



        //****PASIEN BARU - Request patient ID for new patient****//
        public static List<KeyValuePair<string, string>> PasienBaru()
        {
            string prePost = string.Empty;
            string postData = string.Empty;
            string apiSign = string.Empty;
            if (string.IsNullOrEmpty(Token()))
                return null;
            else
                prePost = Token();
            var QueryStrings = new List<KeyValuePair<string, string>>();
            QueryStrings.Add(new KeyValuePair<string, string>("method", "pasien_baru"));
            QueryStrings.Add(new KeyValuePair<string, string>("api_key", _apiKey));
            QueryStrings.Add(new KeyValuePair<string, string>("v", "1.0"));
            QueryStrings.Add(new KeyValuePair<string, string>("org_id", "553"));
            XmlDocument Result = Post(QueryStrings);

            var nsmgr = new XmlNamespaceManager(Result.NameTable);
            nsmgr.AddNamespace("xsl", "http://www.w3.org/1999/XSL/Transform");
            XmlNodeList responsesElement = Result.SelectNodes("response", nsmgr);
            var Responses = new List<KeyValuePair<string, string>>();
            if (responsesElement.Count >= 1)
            {
                foreach (XmlNode responseElement in responsesElement)
                {
                    if (responseElement.SelectSingleNode("status", nsmgr).InnerText.Trim() != "success")
                        return null;
                    XmlNodeList patientsElement = responseElement.SelectNodes("patient", nsmgr);
                    if (patientsElement.Count >= 1)
                    {
                        foreach (XmlNode patientElement in patientsElement)
                        {
                            string patient_id = patientElement.SelectSingleNode("patient_id", nsmgr).InnerText;
                            string person_id = patientElement.SelectSingleNode("person_id", nsmgr).InnerText;
                            string mrn = patientElement.SelectSingleNode("mrn", nsmgr).InnerText;
                            Responses.Add(new KeyValuePair<string, string>(patient_id, person_id));
                            Responses.Add(new KeyValuePair<string, string>("mrn", mrn));
                        }
                    }
                }
            }
            else
                return null;
            return Responses;
        }



        //***PASIEN UPDATE-Updating/Inserting patient data***//
        public static bool PasienUpdate(string patientID, List<KeyValuePair<string, string>> attributes)
        {
            string prePost = string.Empty;
            string postData = string.Empty;
            string apiSign = string.Empty;
            if (string.IsNullOrEmpty(Token()))
                return false;
            else
                prePost = Token();
            var QueryStrings = new List<KeyValuePair<string, string>>();
            QueryStrings.Add(new KeyValuePair<string, string>("method", "pasien_update"));
            QueryStrings.Add(new KeyValuePair<string, string>("api_key", _apiKey));
            QueryStrings.Add(new KeyValuePair<string, string>("v", "1.0"));
            QueryStrings.Add(new KeyValuePair<string, string>("patient_id", patientID));
            foreach (var element in attributes)
            {
                QueryStrings.Add(new KeyValuePair<string, string>(element.Key, element.Value));
            }
            XmlDocument Result = Post(QueryStrings);

            var nsmgr = new XmlNamespaceManager(Result.NameTable);
            nsmgr.AddNamespace("xsl", "http://www.w3.org/1999/XSL/Transform");
            XmlNodeList responsesElement = Result.SelectNodes("response", nsmgr);
            var Responses = new List<KeyValuePair<string, string>>();
            if (responsesElement.Count >= 1)
            {
                foreach (XmlNode responseElement in responsesElement)
                {
                    if (responseElement.SelectSingleNode("status", nsmgr).InnerText != "success")
                        return false;
                    else
                        return true;
                    //XmlNodeList patientsElement = responseElement.SelectNodes("patient", nsmgr);
                    //if (patientsElement.Count >= 1)
                    //{
                    //    foreach (XmlNode patientElement in patientsElement)
                    //    {
                    //        string patient_id = patientElement.SelectSingleNode("patient_id", nsmgr).Value;
                    //        string person_id = patientElement.SelectSingleNode("person_id", nsmgr).Value;
                    //        Responses.Add(new KeyValuePair<string, string>(patient_id, person_id));
                    //    }
                    //}
                }
                return true;
            }
            else
                return false;
        }


        //**************PASIEN KUNJUNGAN BARU**************//
        //Kencana, org_id=687
        public static List<KeyValuePair<string, string>> pasien_kunjungan_baru(string patient_id, string org_id)
        {
            org_id = "687";
            string prePost = string.Empty;
            string postData = string.Empty;
            string apiSign = string.Empty;
            if (string.IsNullOrEmpty(Token()))
                return null;
            else
                prePost = Token();
            var QueryStrings = new List<KeyValuePair<string, string>>();
            QueryStrings.Add(new KeyValuePair<string, string>("method", "pasien_kunjungan_baru"));
            QueryStrings.Add(new KeyValuePair<string, string>("api_key", _apiKey));
            QueryStrings.Add(new KeyValuePair<string, string>("v", "1.0"));
            QueryStrings.Add(new KeyValuePair<string, string>("patient_id", patient_id));
            QueryStrings.Add(new KeyValuePair<string, string>("org_id", org_id));
            XmlDocument Result = Post(QueryStrings);

            var nsmgr = new XmlNamespaceManager(Result.NameTable);
            nsmgr.AddNamespace("xsl", "http://www.w3.org/1999/XSL/Transform");
            XmlNodeList responsesElement = Result.SelectNodes("response", nsmgr);
            var Responses = new List<KeyValuePair<string, string>>();
            if (responsesElement.Count >= 1)
            {
                foreach (XmlNode responseElement in responsesElement)
                {
                    if (responseElement.SelectSingleNode("status", nsmgr).InnerText.Trim() != "success")
                        return null;
                    XmlNodeList patientsElement = responseElement.SelectNodes("admission", nsmgr);
                    if (patientsElement.Count >= 1)
                    {
                        foreach (XmlNode patientElement in patientsElement)
                        {
                            //string patient_id = patientElement.SelectSingleNode("patient_id", nsmgr).InnerText;
                            string admission_id = string.Empty;
                            if (patientElement.SelectSingleNode("admission_id", nsmgr) != null)
                                admission_id = patientElement.SelectSingleNode("admission_id", nsmgr).InnerText;
                            else
                                return null;
                            //string mrn = patientElement.SelectSingleNode("mrn", nsmgr).InnerText;
                            Responses.Add(new KeyValuePair<string, string>(patient_id, admission_id));
                            //Responses.Add(new KeyValuePair<string, string>("admission_id", admission_id));
                        }
                    }
                }
            }
            else
                return null;
            return Responses;
        }

        //******************PASIEN KUNJUNGAN UPDATE******************//        
        public static bool pasien_kunjungan_update(string patientID, string admission_id, List<KeyValuePair<string, string>> attributes)
        {
            string prePost = string.Empty;
            string postData = string.Empty;
            string apiSign = string.Empty;
            if (string.IsNullOrEmpty(Token()))
                return false;
            else
                prePost = Token();
            var QueryStrings = new List<KeyValuePair<string, string>>();
            QueryStrings.Add(new KeyValuePair<string, string>("method", "pasien_kunjungan_update"));
            QueryStrings.Add(new KeyValuePair<string, string>("api_key", _apiKey));
            QueryStrings.Add(new KeyValuePair<string, string>("v", "1.0"));
            QueryStrings.Add(new KeyValuePair<string, string>("patient_id", patientID));
            QueryStrings.Add(new KeyValuePair<string, string>("admission_id", admission_id));
            foreach (var element in attributes)
            {
                QueryStrings.Add(new KeyValuePair<string, string>(element.Key, element.Value));
            }
            XmlDocument Result = Post(QueryStrings);

            var nsmgr = new XmlNamespaceManager(Result.NameTable);
            nsmgr.AddNamespace("xsl", "http://www.w3.org/1999/XSL/Transform");
            XmlNodeList responsesElement = Result.SelectNodes("response", nsmgr);
            var Responses = new List<KeyValuePair<string, string>>();
            if (responsesElement.Count >= 1)
            {
                foreach (XmlNode responseElement in responsesElement)
                {
                    if (responseElement.SelectSingleNode("status", nsmgr).InnerText != "success")
                        return false;
                    else
                        return true;
                    //XmlNodeList patientsElement = responseElement.SelectNodes("patient", nsmgr);
                    //if (patientsElement.Count >= 1)
                    //{
                    //    foreach (XmlNode patientElement in patientsElement)
                    //    {
                    //        string patient_id = patientElement.SelectSingleNode("patient_id", nsmgr).Value;
                    //        string person_id = patientElement.SelectSingleNode("person_id", nsmgr).Value;
                    //        Responses.Add(new KeyValuePair<string, string>(patient_id, person_id));
                    //    }
                    //}
                }
                return true;
            }
            else
                return false;
        }

        //***********************PASIEN KUNJUNGAN DISCHARGE*****************************************************
        private static bool pasien_kunjungan_discharge(string patientID, string admission_id, List<KeyValuePair<string, string>> attributes)
        {
            string prePost = string.Empty;
            string postData = string.Empty;
            string apiSign = string.Empty;
            if (string.IsNullOrEmpty(Token()))
                return false;
            else
                prePost = Token();
            var QueryStrings = new List<KeyValuePair<string, string>>();
            QueryStrings.Add(new KeyValuePair<string, string>("method", "pasien_kunjungan_discharge"));
            QueryStrings.Add(new KeyValuePair<string, string>("api_key", _apiKey));
            QueryStrings.Add(new KeyValuePair<string, string>("v", "1.0"));
            QueryStrings.Add(new KeyValuePair<string, string>("patient_id", patientID));
            QueryStrings.Add(new KeyValuePair<string, string>("admission_id", admission_id));
            QueryStrings.Add(new KeyValuePair<string, string>("discharge", "home"));
            foreach (var element in attributes)
            {
                QueryStrings.Add(new KeyValuePair<string, string>(element.Key, element.Value));
            }
            XmlDocument Result = Post(QueryStrings);

            var nsmgr = new XmlNamespaceManager(Result.NameTable);
            nsmgr.AddNamespace("xsl", "http://www.w3.org/1999/XSL/Transform");
            XmlNodeList responsesElement = Result.SelectNodes("response", nsmgr);
            var Responses = new List<KeyValuePair<string, string>>();
            if (responsesElement.Count >= 1)
            {
                foreach (XmlNode responseElement in responsesElement)
                {
                    if (responseElement.SelectSingleNode("status", nsmgr).InnerText != "success")
                        return false;
                    else
                        return true;
                    //XmlNodeList patientsElement = responseElement.SelectNodes("patient", nsmgr);
                    //if (patientsElement.Count >= 1)
                    //{
                    //    foreach (XmlNode patientElement in patientsElement)
                    //    {
                    //        string patient_id = patientElement.SelectSingleNode("patient_id", nsmgr).Value;
                    //        string person_id = patientElement.SelectSingleNode("person_id", nsmgr).Value;
                    //        Responses.Add(new KeyValuePair<string, string>(patient_id, person_id));
                    //    }
                    //}
                }
                return true;
            }
            else
                return false;
        }

        //******************PASIEN KUNJUNGAN BATAL******************// 
        public static bool pasien_kunjungan_batal(string patient_id, string admission_id, string cancel_reason)
        {
            //org_id = "687";
            string prePost = string.Empty;
            string postData = string.Empty;
            string apiSign = string.Empty;
            if (string.IsNullOrEmpty(Token()))
                return false;
            else
                prePost = Token();
            var QueryStrings = new List<KeyValuePair<string, string>>();
            QueryStrings.Add(new KeyValuePair<string, string>("method", "pasien_kunjungan_batal"));
            QueryStrings.Add(new KeyValuePair<string, string>("api_key", _apiKey));
            QueryStrings.Add(new KeyValuePair<string, string>("v", "1.0"));
            QueryStrings.Add(new KeyValuePair<string, string>("patient_id", patient_id));
            QueryStrings.Add(new KeyValuePair<string, string>("admission_id", admission_id));
            if (!string.IsNullOrEmpty(cancel_reason))
                QueryStrings.Add(new KeyValuePair<string, string>("cancel_reason", cancel_reason));
            XmlDocument Result = Post(QueryStrings);

            var nsmgr = new XmlNamespaceManager(Result.NameTable);
            nsmgr.AddNamespace("xsl", "http://www.w3.org/1999/XSL/Transform");
            XmlNodeList responsesElement = Result.SelectNodes("response", nsmgr);
            var Responses = new List<KeyValuePair<string, string>>();
            if (responsesElement.Count >= 1)
            {
                foreach (XmlNode responseElement in responsesElement)
                {
                    if (responseElement.SelectSingleNode("status", nsmgr).InnerText.Trim() != "success")
                        return false;
                    else
                        return true;
                }
                return true;
            }
            else
                return false;
        }

        //******************CARI PASIEN KUNJUNGAN******************//
        //Kencana, org_id=687
        public static bool search_pasien_kunjungan(string patient_id)
        {
            string prePost = string.Empty;
            string postData = string.Empty;
            string apiSign = string.Empty;
            if (string.IsNullOrEmpty(Token()))
                return false;
            else
                prePost = Token();
            var QueryStrings = new List<KeyValuePair<string, string>>();
            QueryStrings.Add(new KeyValuePair<string, string>("method", "pasien_kunjungan"));
            QueryStrings.Add(new KeyValuePair<string, string>("patient_id", patient_id));
            //QueryStrings.Add(new KeyValuePair<string, string>("limit", "0"));
            QueryStrings.Add(new KeyValuePair<string, string>("api_key", _apiKey));
            QueryStrings.Add(new KeyValuePair<string, string>("v", "1.0"));
            XmlDocument Result = Post(QueryStrings);

            var nsmgr = new XmlNamespaceManager(Result.NameTable);
            nsmgr.AddNamespace("xsl", "http://www.w3.org/1999/XSL/Transform");
            XmlNodeList responsesElement = Result.SelectNodes("response", nsmgr);
            if (responsesElement.Count >= 1)
            {
                foreach (XmlNode responseElement in responsesElement)
                {
                    if (responseElement.SelectSingleNode("status", nsmgr).InnerText.Trim() != "success")
                    {
                        return false;
                    }

                    XmlNode pat = responseElement.SelectSingleNode("patient", nsmgr);
                    //int patCount = Convert.ToInt32(pat.Attributes["count"].Value);

                    //if (patCount == 0)
                    //    return false;
                    if (pat.SelectNodes("admission", nsmgr) == null)
                        return false;

                    foreach (XmlNode admissionsElement in pat.SelectNodes("admission", nsmgr))
                    {
                        int admissionID = 0;
                        if (admissionID < Convert.ToInt32(admissionsElement.Attributes["admission_id"].Value))
                            admissionID = Convert.ToInt32(admissionsElement.Attributes["admission_id"].Value);

                        if (admissionID == 0)
                            return false;
                        return true;
                    }
                    //}
                }
            }
            else
                return false;
            return true;
        }

        public static bool search_pasien_kunjungan(string patient_id, string admission_id)
        {
            string prePost = string.Empty;
            string postData = string.Empty;
            string apiSign = string.Empty;
            if (string.IsNullOrEmpty(Token()))
                return false;
            else
                prePost = Token();
            var QueryStrings = new List<KeyValuePair<string, string>>();
            QueryStrings.Add(new KeyValuePair<string, string>("method", "pasien_kunjungan"));
            QueryStrings.Add(new KeyValuePair<string, string>("patient_id", patient_id));
            QueryStrings.Add(new KeyValuePair<string, string>("admission_id", admission_id));
            //QueryStrings.Add(new KeyValuePair<string, string>("limit", "0"));
            QueryStrings.Add(new KeyValuePair<string, string>("api_key", _apiKey));
            QueryStrings.Add(new KeyValuePair<string, string>("v", "1.0"));
            XmlDocument Result = Post(QueryStrings);

            var nsmgr = new XmlNamespaceManager(Result.NameTable);
            nsmgr.AddNamespace("xsl", "http://www.w3.org/1999/XSL/Transform");
            XmlNodeList responsesElement = Result.SelectNodes("response", nsmgr);
            //XmlNodeList AdmissionElement = Result.SelectNodes("//response/admission/admission_org_id", nsmgr);
            //if (AdmissionElement.Count == 0)
            //    return false;
            //else
            //    return true;
            if (responsesElement.Count >= 1)
            {
                foreach (XmlNode responseElement in responsesElement)
                {
                    if (responseElement.SelectSingleNode("status", nsmgr).InnerText.Trim() != "success")
                    {
                        return false;
                    }

                    XmlNodeList admission = responseElement.SelectNodes("admission", nsmgr);
                    if (admission.Count == 0)
                        return false;
                    else
                        return true;

                    //foreach (XmlNode admissionsElement in pat.SelectNodes("admission", nsmgr))
                    //{
                    //    int admissionID = 0;
                    //    if (admissionID < Convert.ToInt32(admissionsElement.Attributes["admission_id"].Value))
                    //        admissionID = Convert.ToInt32(admissionsElement.Attributes["admission_id"].Value);

                    //    if (admissionID == 0)
                    //        return false;
                    //    return true;
                    //}
                    //}
                }
            }
            else
                return false;
            return true;
        }


        //private static string Token()
        //{
        //    string method = "Auth";
        //    string rand = new Random().Next().ToString();
        //    string auth_sig = MD5Hash(string.Concat(_secret, _apiKey, rand));
        //    string postData = string.Format("method={0}&api_key={1}&rand={2}&auth_sig={3}", method, _apiKey, rand,
        //                                    auth_sig);

        //    StreamReader sr = SendData(postData);
        //    XmlSerializer serial = new XmlSerializer(typeof(Auth));
        //    Auth result = (Auth)serial.Deserialize(sr);
        //    sr.Close();

        //    return result.Token;
        //}


        public static DataTable SearchPatientByKeywords(string search, string tanggal)
        {
            XmlDocument xmlDoc = new XmlDocument();
            using (StreamReader sr = SendData("method=pasien_cari&keywords=" + search + "&dob=" + tanggal))
            {
                MemoryStream memoryStream = ConvertToStream(sr.ReadToEnd());
                xmlDoc.Load(memoryStream);
                sr.Close();
                memoryStream.Dispose();
            }
            XmlNodeList nodeList = xmlDoc.SelectNodes("/response/patients/patient");
            DataTable dtb = XmlHelper.GetDataTable(nodeList);
            return dtb;
        }

        public static DataTable SearchPatient(string search)
        {
            XmlDocument xmlDoc = new XmlDocument();
            using (StreamReader sr = SendData("method=pasien_cari&keywords=" + search))
            {
                MemoryStream memoryStream = ConvertToStream(sr.ReadToEnd());
                xmlDoc.Load(memoryStream);
                sr.Close();
                memoryStream.Dispose();
            }
            XmlNodeList nodeList = xmlDoc.SelectNodes("/response/patients/patient");
            DataTable dtb = XmlHelper.GetDataTable(nodeList);
            return dtb;
        }

        public static Hashtable PatientDetil(string id)
        {
            XmlDocument xmlDoc = new XmlDocument();
            using (StreamReader sr = SendData("method=pasien_detil&patient_id=" + id))
            {
                MemoryStream memoryStream = ConvertToStream(sr.ReadToEnd());
                xmlDoc.Load(memoryStream);
                sr.Close();
                memoryStream.Dispose();
            }
            Hashtable patient = new Hashtable();
            XmlNode node = xmlDoc.LastChild.SelectSingleNode("patient");
            if (node != null)
                foreach (XmlElement childNode in node.ChildNodes)
                {
                    patient.Add(childNode.Name, childNode.InnerText);
                }
            return patient;

        }

        //public static PatientSearch SearchPatient(string search)
        //{
        //    ////string token = Token();
        //    //string method = "patient_cari";
        //    //string rand = new Random().Next().ToString();
        //    ////-- Search Arg
        //    ////fullname = "Agus";
        //    ////mrn = "";
        //    //string gender = "";
        //    //string address = "";
        //    //string phone = "";
        //    //string regional_cd = "";
        //    //// string keywords = "";

        //    //string uname = "admin";
        //    //string uid = "admin";

        //    //ArrayList arrayList = new ArrayList();
        //    //arrayList.Add("method" + method);
        //    //arrayList.Add("rand" + rand);

        //    //if (keywords != string.Empty)
        //    //    arrayList.Add("keywords" + keywords);

        //    ////if (mrn != string.Empty)
        //    ////    arrayList.Add("mrn" + mrn);

        //    //arrayList.Add("uname" + uname);
        //    //arrayList.Add("uid" + uid);
        //    //arrayList.Add("v1.0");
        //    //arrayList.Sort();
        //    //string apiSig = "";//token;
        //    //foreach (string item in arrayList)
        //    //{
        //    //    apiSig = string.Concat(apiSig, item);
        //    //}

        //    //apiSig = MD5Hash(apiSig);
        //    //string postData =
        //    //    string.Format(
        //    //        "method={0}&api_key={1}&rand={2}&v=v1.0&fullname={3}&mrn={4}&uname={5}&uid={6}&api_sig={7}",
        //    //        method, _apiKey, rand, fullname, mrn, uname, uid, apiSig);

        //    StreamReader sr = SendData("method=pasien_cari&keywords="+search);
        //    MemoryStream memoryStream = ConvertToStream(sr.ReadToEnd());
        //    //string content = sr.ReadToEnd();
        //    XmlSerializer serial = new XmlSerializer(typeof(PatientSearch));
        //    XmlDocument xmlDoc = new XmlDocument();
        //    xmlDoc.Load(memoryStream);


        //    PatientSearch result = (PatientSearch)serial.Deserialize(memoryStream);
        //    sr.Close();

        //    return result;
        //}

        //Return patient kunjungan result as xmldocument
        public static XmlDocument searchPatientKunjungan(string RscmPatientID)
        {
            string prePost = string.Empty;
            string postData = string.Empty;
            string apiSign = string.Empty;
            if (string.IsNullOrEmpty(Token()))
                return null;
            else
                prePost = Token();
            var QueryStrings = new List<KeyValuePair<string, string>>();
            QueryStrings.Add(new KeyValuePair<string, string>("method", "pasien_kunjungan"));
            QueryStrings.Add(new KeyValuePair<string, string>("api_key", _apiKey));
            QueryStrings.Add(new KeyValuePair<string, string>("v", "1.0"));
            QueryStrings.Add(new KeyValuePair<string, string>("patient_id", RscmPatientID));
            QueryStrings.Add(new KeyValuePair<string, string>("limit", "0"));
            XmlDocument Result = Post(QueryStrings);
            return Result;
        }

        //Return search patient as xmldocument
        public static XmlDocument searchPatient(string MedicalNo)
        {
            string prePost = string.Empty;
            string postData = string.Empty;
            string apiSign = string.Empty;
            if (string.IsNullOrEmpty(Token()))
                return null;
            else
                prePost = Token();
            var QueryStrings = new List<KeyValuePair<string, string>>();
            QueryStrings.Add(new KeyValuePair<string, string>("method", "pasien_cari"));
            QueryStrings.Add(new KeyValuePair<string, string>("api_key", _apiKey));
            QueryStrings.Add(new KeyValuePair<string, string>("v", "1.0"));
            QueryStrings.Add(new KeyValuePair<string, string>("mrn", MedicalNo));
            XmlDocument Result = Post(QueryStrings);
            return Result;
        }

        //Return patient kunjungan detil result as xmldocument
        public static XmlDocument PatientKunjunganDetil(string RscmPatientID, string AdmissionID)
        {
            string prePost = string.Empty;
            string postData = string.Empty;
            string apiSign = string.Empty;
            if (string.IsNullOrEmpty(Token()))
                return null;
            else
                prePost = Token();
            var QueryStrings = new List<KeyValuePair<string, string>>();
            QueryStrings.Add(new KeyValuePair<string, string>("method", "pasien_kunjungan_detil"));
            QueryStrings.Add(new KeyValuePair<string, string>("api_key", _apiKey));
            QueryStrings.Add(new KeyValuePair<string, string>("v", "1.0"));
            QueryStrings.Add(new KeyValuePair<string, string>("patient_id", RscmPatientID));
            QueryStrings.Add(new KeyValuePair<string, string>("admission_id", AdmissionID));
            XmlDocument Result = Post(QueryStrings);
            return Result;
        }

        public static Temiang.Avicenna.BusinessObject.Mpi.PasienKunjungan.response ListPasienKunjungan(string RscmPatientID)
        {
            XmlDocument pasien_kunjungan = new XmlDocument();
            pasien_kunjungan = searchPatientKunjungan(RscmPatientID);
            XmlSerializer ser = new XmlSerializer(typeof(Temiang.Avicenna.BusinessObject.Mpi.PasienKunjungan.response));
            var wrapper = (Temiang.Avicenna.BusinessObject.Mpi.PasienKunjungan.response)ser.Deserialize(new XmlNodeReader(pasien_kunjungan));
            return wrapper;
        }

        public static Temiang.Avicenna.BusinessObject.Mpi.PasienCari.response ListPasienCari(string MedicalNo)
        {
            XmlDocument pasien_cari = new XmlDocument();
            pasien_cari = searchPatient(MedicalNo);
            XmlSerializer ser = new XmlSerializer(typeof(Temiang.Avicenna.BusinessObject.Mpi.PasienCari.response));
            var wrapper = (Temiang.Avicenna.BusinessObject.Mpi.PasienCari.response)ser.Deserialize(new XmlNodeReader(pasien_cari));
            return wrapper;
        }

        public static Temiang.Avicenna.BusinessObject.Mpi.PasienCari.response ListPasienKunjunganDetil(string RscmPatientID, string AdmissionID)
        {
            XmlDocument pasien_kunjungan_detil = new XmlDocument();
            pasien_kunjungan_detil = PatientKunjunganDetil(RscmPatientID, AdmissionID);
            XmlSerializer ser = new XmlSerializer(typeof(Temiang.Avicenna.BusinessObject.Mpi.PasienKunjunganDetil.response));
            var wrapper = (Temiang.Avicenna.BusinessObject.Mpi.PasienCari.response)ser.Deserialize(new XmlNodeReader(pasien_kunjungan_detil));
            return wrapper;
        }

        public static void PatientDischarge(string rscmpatientid, string admissionid, DateTime Discharge_Dttm, string Discharge_Org_Id, string Discharge_Info_Txt)
        {
            //string patient_id = kunjungan.PatientId;            
            string discharge_dttm = ((DateTime)Discharge_Dttm).ToString("yyyy-MM-dd HH:mm:ss");
            //string discharge_org_nm = "RSCM KENCANA";            
            if (Discharge_Info_Txt.Length >= 255)
                Discharge_Info_Txt = Discharge_Info_Txt.Substring(0, 255);
            List<KeyValuePair<string, string>> discharge_kunjungan = new List<KeyValuePair<string, string>>();
            discharge_kunjungan.Add(new KeyValuePair<string, string>("inpatient_ind", "1"));
            discharge_kunjungan.Add(new KeyValuePair<string, string>("discharge", "home"));
            discharge_kunjungan.Add(new KeyValuePair<string, string>("discharge_dttm", discharge_dttm));
            discharge_kunjungan.Add(new KeyValuePair<string, string>("discharge_org_id", Discharge_Org_Id));
            discharge_kunjungan.Add(new KeyValuePair<string, string>("discharge_info_txt", Discharge_Info_Txt));
            pasien_kunjungan_discharge(rscmpatientid, admissionid, discharge_kunjungan);
        }

        public static string InsertPatientData(Registration reg, Patient pat, List<KeyValuePair<string, string>> RscmPasienIdBaru)
        {
            string RscmPatientID = string.Empty;
            if (RscmPasienIdBaru.Count > 0)
            {
                foreach (var element in RscmPasienIdBaru)
                {
                    var dataPasien = new List<KeyValuePair<string, string>>();
                    dataPasien.Add(new KeyValuePair<string, string>("mrn", pat.MedicalNo));
                    dataPasien.Add(new KeyValuePair<string, string>("person_nm", (pat.FirstName + " " + pat.MiddleName + " " + pat.LastName).Trim()));
                    dataPasien.Add(new KeyValuePair<string, string>("family_nm", pat.ParentSpouseName));
                    dataPasien.Add(new KeyValuePair<string, string>("address_txt", pat.StreetName + "," + pat.District + "," + pat.City + "," + pat.County));
                    dataPasien.Add(new KeyValuePair<string, string>("gender_cd", pat.Sex.ToLower()));
                    dataPasien.Add(new KeyValuePair<string, string>("date_of_birth", (((DateTime)pat.DateOfBirth).Year.ToString().Trim() + "-" + ((DateTime)pat.DateOfBirth).Month.ToString().Trim() + "-" + ((DateTime)pat.DateOfBirth).Day.ToString().Trim())));
                    dataPasien.Add(new KeyValuePair<string, string>("place_of_birth", pat.CityOfBirth.Trim() ?? "Unspecified"));
                    dataPasien.Add(new KeyValuePair<string, string>("postal_cd", pat.ZipCode ?? "11111"));
                    Mpi.PasienUpdate(element.Key, dataPasien);
                    RscmPatientID = element.Key;
                }
            }
            return RscmPatientID;
        }

        public static string InsertKunjunganData(Registration reg, Patient pat, List<KeyValuePair<string, string>> RscmKunjunganBaru)
        {
            string RscmPatientID = string.Empty;
            string AdmissionID = string.Empty;
            List<KeyValuePair<string, string>> Data_Kunjungan_Yang_Akan_dikirim = new List<KeyValuePair<string, string>>();
            foreach (var element in RscmKunjunganBaru)
            {
                RscmPatientID = element.Key;
                AdmissionID = element.Value;
            }
            if (string.IsNullOrEmpty(AdmissionID))
                return string.Empty;
            Data_Kunjungan_Yang_Akan_dikirim.Add(new KeyValuePair<string, string>("admission_dttm", ((DateTime)reg.RegistrationDate).ToString("yyyy-MM-dd") + " " + reg.RegistrationTime + ":00"));
            Data_Kunjungan_Yang_Akan_dikirim.Add(new KeyValuePair<string, string>("discharge_dttm", "0000-00-00 00:00:00"));
            Data_Kunjungan_Yang_Akan_dikirim.Add(new KeyValuePair<string, string>("admission_org_id", "687"));
            Data_Kunjungan_Yang_Akan_dikirim.Add(new KeyValuePair<string, string>("admission_org_nm", "RSCM KENCANA"));
            MpiPayplanMapping mpm = new MpiPayplanMapping();
            mpm.es.Connection.Name = "HIS_INTEROP";
            string PayplanId = string.Empty;
            string PayplanNm = string.Empty;
            if (mpm.LoadByPrimaryKey(reg.GuarantorID))
            {
                PayplanId = mpm.PayplanId;
                PayplanNm = mpm.PayplanNm;
            }
            Data_Kunjungan_Yang_Akan_dikirim.Add(new KeyValuePair<string, string>("payplan_id", PayplanId));
            Data_Kunjungan_Yang_Akan_dikirim.Add(new KeyValuePair<string, string>("payplan_nm", PayplanNm));
            Guarantor g = new Guarantor();
            if (g.LoadByPrimaryKey(reg.GuarantorID))            
                Data_Kunjungan_Yang_Akan_dikirim.Add(new KeyValuePair<string, string>("guarantor_nm", g.GuarantorName));
            if (reg.BedID != null)            
                Data_Kunjungan_Yang_Akan_dikirim.Add(new KeyValuePair<string, string>("inpatient_bed_id", reg.BedID));
            if (reg.RoomID != null)            
                Data_Kunjungan_Yang_Akan_dikirim.Add(new KeyValuePair<string, string>("inpatient_bed_nm", reg.RoomID + "," + reg.BedID));            
            if (reg.ParamedicID != null)            
                Data_Kunjungan_Yang_Akan_dikirim.Add(new KeyValuePair<string, string>("doctor_id1", reg.ParamedicID));
            if (reg.SRRegistrationType == "IPR")
                Data_Kunjungan_Yang_Akan_dikirim.Add(new KeyValuePair<string, string>("inpatient_ind", "1"));
            else
                Data_Kunjungan_Yang_Akan_dikirim.Add(new KeyValuePair<string, string>("inpatient_ind", "0"));
            Data_Kunjungan_Yang_Akan_dikirim.Add(new KeyValuePair<string, string>("created_dttm", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));
            Data_Kunjungan_Yang_Akan_dikirim.Add(new KeyValuePair<string, string>("created_user_id", "9638"));

            if (Mpi.pasien_kunjungan_update(RscmPatientID, AdmissionID, Data_Kunjungan_Yang_Akan_dikirim))
                return AdmissionID;
            else
                return string.Empty;
        }
    }
}