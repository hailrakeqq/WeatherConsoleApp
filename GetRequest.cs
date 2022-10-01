using System.Data;
namespace weatherConsoleApp
{
    using System.Net;
    using Newtonsoft.Json.Linq;
    using Newtonsoft.Json;
    public class GetRequest
    {
        HttpWebRequest _request;
        string _address;
        public string Responce { get; set; }

        public GetRequest(string address) { _address = address; }

        public void Run()
        {
            _request = (HttpWebRequest)WebRequest.Create(_address);
            _request.Method = "Get";

            try
            {
                HttpWebResponse response = (HttpWebResponse)_request.GetResponse();
                var stream = response.GetResponseStream();
                if (stream != null) Responce = new StreamReader(stream).ReadToEnd();
            }
            catch (System.Exception)
            {
            }
        }
    }
}