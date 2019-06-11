using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Threading.Tasks;
using System.Net;
using System.IO;

namespace Brokeries.DataValidation
{
    class Program
    {
        public string EmailString { get; set; }
        public string ResponseCode { get; set; }
        public string ResponseStatusDescription { get; set; }

        public WebResponse Response;
        static void Main(string[] args)
        {

            AnalyzeBrokerURLs(args).Wait();
        }
        static async Task AnalyzeBrokerURLs(string[] args)
        {
            var client = new MongoClient();
            var db = client.GetDatabase("OurBmsV2");
            var brokersColl = db.GetCollection<Brokers>("Brokers");
            //grab MongoDB collection
            var brokers = brokersColl.Find(b => b.Name != null).ToListAsync().Result;

            //initialize counters
            int i = 0;
            int brokercount = 0;


            //Known good WORKING below
            //Grab system date time and create instance of Program to build EmailString
            DateTime beginDateTime = DateTime.Now;
            var urlProgram = new Program();
            var culture = new CultureInfo("en-US");
            urlProgram.EmailString = urlProgram.EmailString + "Brokeries.DataValidation ran on: " + beginDateTime.ToString(culture) +
                ".\r\nThis program validates broker URLs, comparing URLs from our Brokeries BROKERS collection against the live sites from the Brokers.\r\n\n" +
                                 "Below is a list of links that needs to be cleaned up:\r\n\n";


            //validate broker data
            foreach (var broker in brokers)
            {
                brokercount++;

                //Known good WORKING below for full URL query and email build
                try
                {
                    var link = broker.WebLinks[0];

                    try
                    {
                        //WebResponse response = TestUrl(urlProgram, link);
                        //string header = ((HttpWebResponse)response).GetResponseHeader();

                    }
                    catch (WebException e)
                    {
                       break;
                        //i++;
                        //string exceptionString = broker.Name + " main broker landing page URL broken (or redirect please fix): " + link + "\r\nWebException Raised, the following error occured : " + e.Status + "\r\n\n";
                        //string statusCode = ((HttpWebResponse)response).StatusCode.ToString();
                        //string status = ((HttpWebResponse)response).StatusDescription;
                        //emailString.EmailString = emailString.EmailString + statusCode;
                        //emailString.EmailString = emailString.EmailString + status;
                        //emailString.EmailString = emailString.EmailString + exceptionString;
                     }
                    catch (Exception e)
                    {
                        break;
                        //i++;
                        //string exceptionString = broker.Name + " main broker landing page URL broken (or redirect please fix): " + link + "\r\nException Raised, the following error occured : " + e.Message + "\r\n\n";
                        //emailString.EmailBuildString(exceptionString);
                    }
                }
                catch (Exception e)
                {
                    break;
                    //i++;
                    //string exceptionString = broker.Name + " main broker landing page URL is missing (NULL value returned.\r\nException Raised, the following error occured : " + e.Message + "\r\n\n";
                    //emailString.EmailBuildString(exceptionString);

                }

            }
            //Known good WORKING below closing and sending email
            //string closingMessage = "Total broker links examined: " + brokercount + "\r\n";
            //emailString.EmailBuildString(closingMessage);
            //closingMessage = "Total broker link issues: " + i + "\r\n";
            //emailString.EmailBuildString(closingMessage);
            //closingMessage = "Broker landing page test done.";
            //emailString.EmailBuildString(closingMessage);
            //DateTime endDateTime = DateTime.Now;
            //closingMessage = "Brokeries.DataValidation completed on: " + endDateTime.ToString(culture) + ".\r\n";
            //emailString.EmailBuildString(closingMessage);
            //Console.WriteLine(emailString.EmailString);
            Console.ReadKey();
            //Email sendIt = new Email();
            //sendIt.Send(emailString.EmailString);
        }

        static void TestUrl(Program urlProgramPass, String url)
        {
            WebRequest request = WebRequest.Create(url);
            request.Credentials = CredentialCache.DefaultCredentials;
            try
            {
                urlProgramPass.Response = request.GetResponse();
            }
            catch (WebException e)
            {
                urlProgramPass.ResponseCode = ((HttpWebResponse)urlProgramPass.Response).StatusCode.ToString();
                urlProgramPass.ResponseStatusDescription = ((HttpWebResponse)urlProgramPass.Response).StatusDescription.ToString();
            }
            catch (Exception e)
            {

                //Console.WriteLine(e);
            throw;
            }


        }


    }
}
