using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace MaheApi.Dto
{
    public static class ApiCall
    {
        public static string GetApi(string ApiUrl)
        {

            var responseString = "";
            var request = (HttpWebRequest)WebRequest.Create(ApiUrl);
            request.Method = "GET";
            request.ContentType = "application/json";

            using (var response1 = request.GetResponse())
            {
                using (var reader = new StreamReader(response1.GetResponseStream()))
                {
                    responseString = reader.ReadToEnd();
                }
            }
            return responseString;

        }
        public static string PostApi(string ApiUrl, string postData = "")
        {

            var request = (HttpWebRequest)WebRequest.Create(ApiUrl);
            var data = Encoding.ASCII.GetBytes(postData);
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = data.Length;
            using (var stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }
            var response = (HttpWebResponse)request.GetResponse();
            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
            return responseString;
        }

    }
}

class Program
{
    static void Main(string[] args)
    {
        Consume_WebAPI().Wait();
    }

    static async Task Consume_WebAPI()
    {
        var client = new HttpClient();
        client.BaseAddress = new Uri("https://localhost:44316/Web");
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        HttpResponseMessage response = await client.GetAsync("api/employee/list");
        if (response.IsSuccessStatusCode)
        {
            dynamic result = await response.Content.ReadAsStringAsync();
            Rootobject rootObject = JsonConvert.DeserializeObject put here less sign Rootobject put here greater sign(result);

            foreach (var item in rootObject.Studentsname)
            {
                Console.WriteLine("{0}\t${1}\t{2}", item.Studentsname);
            }

            Console.ReadKey();
        }
    }
}
public class Rootobject
{
    public List put here less sign Employee put here greater sign public IEnumerable<object> Studentsname { get; internal set; }

    Employee { get; set; }
    }

   