using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Csc.Res.Generic.TestHarness
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = 0;
            int EventGridChoice = 100;

            do
            {
                //TODO: Refactor to proper lists when implementing multiple flows in phase 2
                int IntOption = 1;
                string StrOption = "Customer service outbound;1002";


                if (EventGridChoice == 100)
                {
                    Console.WriteLine("Select a flow:");
                    Console.WriteLine("{0}: {1}", IntOption, StrOption);
                    EventGridChoice = Convert.ToInt32(Console.ReadLine());
                }
                switch (EventGridChoice)
                {
                    case 1:
                        Console.WriteLine("Running {0}: {1}", IntOption, StrOption);
                        N = 1;
                        break;
                    default:
                        Console.WriteLine("Not a valid selection. Please enter number of flow listed above.");
                        EventGridChoice = Convert.ToInt32(Console.ReadLine());
                        break;
                }
            } while (N != 1);

            var PostReturn = TestEventGridMessageAsync().Result;
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine(PostReturn);
            Console.ReadLine();

            //string Url = "https://generic-outbound.westus2-1.eventgrid.azure.net/api/events";
            //string FilePath = "C:\\Dev\\Repos\\RES\\src\\Csc.Res.Generic.TestHarness\\EventMessage.json";
            //string EventMessage = string.Empty;
            //using (StreamReader R = new StreamReader(FilePath))
            //{
            //    var Json = R.ReadToEnd();
            //    var Jobj = JObject.Parse(Json);
            //    EventMessage = Jobj.ToString();

            //    PostStream(Url, EventMessage);

        }

        private static void PostStream(string UrlString, string EventString)
        {
            var Client = new HttpClient();
            //Client.DefaultRequestHeaders.Add("Authorization", "CR1eOgKSKDMLkivY2BqFWsY/63vQ8KGd8yCyen2XvNc=");
            HttpContent EventContent = new StringContent(EventString);
            var PostResult = Client.PostAsync(UrlString, EventContent).Result;
            string TestHttpContent = EventContent.ToString();
            Console.WriteLine(EventString);
            Console.ReadLine();
            Console.WriteLine(PostResult);
            Console.ReadLine();

        }

        private static async Task<HttpResponseMessage> TestEventGridMessageAsync()

        {

            string endpoint = "https://customeroutbound.westus2-1.eventgrid.azure.net/api/events";
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("aeg-sas-key", "z+3aK6Vhd1LZYjD5GF8oEs5tDV6BnvreJDqipsHYBxo=");
            List<EventGridModel> events = new List<EventGridModel>();
            var customEvent = new EventGridModel();
            customEvent.Id = Guid.NewGuid();
            customEvent.EventType = "Customer service outbound;Create";
            customEvent.Topic = "/subscriptions/19e28071-4309-4ccf-849c-3dc88e0be4a2/resourceGroups/ent-eventgrid/providers/Microsoft.EventGrid/topics/customeroutbound";
            customEvent.MetadataVersion = 1;
            customEvent.EventTime = DateTime.UtcNow;
            customEvent.Subject = "Customer service outbound;1002";
            customEvent.Data = new string[] { "1002-001589" };
            events.Add(customEvent);
            string jsonContent = JsonConvert.SerializeObject(events);
            Console.WriteLine(jsonContent);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            //Console.WriteLine();
            //Console.WriteLine(httpClient.ToString());

            return await httpClient.PostAsync(endpoint, content);



        }
        /// Returns the JSON string presentation of the object

        /// </summary>

        /// <returns>JSON string presentation of the object</returns>

        [ExcludeFromCodeCoverage]

        public string ToJson()

        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }
    }


}
