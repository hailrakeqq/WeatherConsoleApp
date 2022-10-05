using System.Security.AccessControl;
namespace WeatherConsoleApp
{
    using System.Net;
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