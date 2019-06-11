using System;
using Microsoft.Azure.EventGrid.Models;
using System.Collections.Generic;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Net.Http;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace Csc.Res.Generic.TestHarness
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<string> MessageList = new List<string>();



        public MainWindow()
        {
            InitializeComponent();
            IterationTextBox.Text = "1";
            List<string> LoadedMessages = PrepData();
            ListMessages.ItemsSource = LoadedMessages;

        }

        private async void executeAsync_Click(object sender, RoutedEventArgs e)
        {
            int N = 1;
            int Iterations = System.Convert.ToInt32(IterationTextBox.Text);

            int EnvSelection = GetRadioSelection<int>(0, rP0, rP1, rP2, rP3);
            string Subscription = GetSubscription(EnvSelection);

            

            do
            {
                foreach (Object SelectedItem in ListMessages.SelectedItems)
                {
                    //HttpResponseMessage Response = await TestEventGridMessageParallelAsync(SelectedItem);
                    //ResultsWindow.Text += Response.StatusCode;
                    N += 1;

                }
            } while(N <= Iterations);

            ResultsWindow.Text += EnvSelection + Environment.NewLine;
            ResultsWindow.Text += Subscription + Environment.NewLine;
            ResultsWindow.Text += "N = " + N + Environment.NewLine;

        }
        private List<string> PrepData()
        {

            ResultsWindow.Text = "";

            MessageList.Add("CustomerOutbound");
            MessageList.Add("GenericOutbound");
            MessageList.Add("SalesOrder-Outbound");
            MessageList.Add("GenericInbound");


            return MessageList;

        }

        public string ReadJSONPayload(string EnvChoice)
        {
            List<EventGridModel> items = new List<EventGridModel>();

            string FilePath = "C:\\Dev\\Repos\\RES\\src\\Csc.Res.Generic.TestHarness\\WPF_WebApp\\Resources\\"+ EnvChoice + ".json";

            string jsonstring = "";
            using (StreamReader r = new StreamReader(FilePath))
                {
                jsonstring = r.ReadToEnd();
                }
            //    EventMessage = Jobj.ToString();

            //    PostStream(Url, EventMessage);

            //string Url = "https://generic-outbound.westus2-1.eventgrid.azure.net/api/events";
            return jsonstring;
        }
        //private async Task PostAsync()
        //{
        //    List<string> websites = PrepData();

        //    foreach (string site in websites)
        //    {
        //        WebsiteDataModel results = await Task.Run(() => DownloadWebsite(site));
        //        ReportWebsiteInfo(results);
        //    }
        //}

        //private async Task<HttpResponseMessage> TestEventGridMessageParallelAsync(object Selection)

        //{


        //    return await httpClient.PostAsync(endpoint, content);


        //    List<Task<WebsiteDataModel>> tasks = new List<Task<WebsiteDataModel>>();

        //    foreach (string Selection in ResultsWindow.Selection)
        //    {
        //        tasks.Add(DownloadWebsiteAsync(site));
        //    }

        //    var results = await Task.WhenAll(tasks);

        //    foreach (var item in results)
        //    {
        //        ReportWebsiteInfo(item);
        //    }
        //    string endpoint = "https://customeroutbound.westus2-1.eventgrid.azure.net/api/events";
        //    var httpClient = new HttpClient();
        //    httpClient.DefaultRequestHeaders.Add("aeg-sas-key", "z+3aK6Vhd1LZYjD5GF8oEs5tDV6BnvreJDqipsHYBxo=");
        //    List<CustomEvent> events = new List<CustomEvent>();
        //    var customEvent = new CustomEvent();
        //    customEvent.Id = Guid.NewGuid();
        //    customEvent.EventType = "Customer service outbound;Create";
        //    customEvent.Topic = "/subscriptions/19e28071-4309-4ccf-849c-3dc88e0be4a2/resourceGroups/ent-eventgrid/providers/Microsoft.EventGrid/topics/customeroutbound";
        //    customEvent.MetadataVersion = 1;
        //    customEvent.EventTime = DateTime.UtcNow;
        //    customEvent.Subject = "Customer service outbound;1002";
        //    customEvent.Data = new string[] { "1002-001589" };
        //    events.Add(customEvent);
        //    string jsonContent = JsonConvert.SerializeObject(events);
        //    Console.WriteLine(jsonContent);
        //    var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
        //    //Console.WriteLine();
        //    //Console.WriteLine(httpClient.ToString());

        //}

        private string GetSubscription(int EnvSel)
        {
            string Sandbox = "3c7e752f-12dd-43d3-831a-8fd6a6061ad0";
            string DevTest = "19e28071-4309-4ccf-849c-3dc88e0be4a2";
            string Prod = "cd60f8af-df83-4943-a031-fffb06023319";
            string C1SIT2NA = "a8a4c15a-0cf2-4017-be9e-fe3b8cd3b4ef";

            string Subscription = "";

            switch (EnvSel)
            {
                case 0:
                    Subscription = Sandbox;
                    break;
                case 1:
                    Subscription = DevTest;
                    break;
                case 2:
                    Subscription = Prod;
                    break;
                case 3:
                    Subscription = C1SIT2NA;
                    break;
            }

            string SubscriptionStr = "subscriptions/" + Subscription;
            return SubscriptionStr;

        }

        //private async Task PostParallelAsync()
        //{

        //}

        //private void RunDownloadSync()
        //{
        //    List<string> websites = PrepData();

        //    foreach (string site in websites)
        //    {
        //        WebsiteDataModel results = DownloadWebsite(site);
        //        ReportWebsiteInfo(results);
        //    }
        //}

        //private WebsiteDataModel DownloadWebsite(string websiteURL)
        //{
        //    WebsiteDataModel output = new WebsiteDataModel();
        //    WebClient client = new WebClient();

        //    output.WebsiteUrl = websiteURL;
        //    output.WebsiteData = client.DownloadString(websiteURL);

        //    return output;
        //}

        //private async Task<WebsiteDataModel> DownloadWebsiteAsync(string websiteURL)
        //{
        //    WebsiteDataModel output = new WebsiteDataModel();
        //    WebClient client = new WebClient();

        //    output.WebsiteUrl = websiteURL;
        //    output.WebsiteData = await client.DownloadStringTaskAsync(websiteURL);

        //    return output;
        //}

        //private void ReportWebsiteInfo(WebsiteDataModel data)
        //{
        //    ResultsWindow.Text += $"{ data.WebsiteUrl } downloaded: { data.WebsiteData.Length } characters long.{ Environment.NewLine }";
        //}

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private object selectedItem;
        private ListBox ItemsHost;
        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            PayloadWindow.Text = "";
            var buff = sender as ListBox;

            if (selectedItem != null)
                if (ItemsHost != buff)
                    ItemsHost.SelectedItem = null;

            ItemsHost = buff;

            if (e.AddedItems.Count > 0)
            { 
                selectedItem = e.AddedItems[0];
                //fill datagrid here using EnvSelection to read json file and write json into datagrid
                string EnvSelection = selectedItem.ToString();

                string jsonstringreturned = ReadJSONPayload(EnvSelection);
                dynamic array = JsonConvert.DeserializeObject(jsonstringreturned);

                foreach (var item in array)
                {
                    
                    PayloadWindow.Text += item;
                }
            }
        }

        private void IterationTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            Int32 selectionStart = textBox.SelectionStart;
            Int32 selectionLength = textBox.SelectionLength;
            String newText = String.Empty;
            int count = 0;
            foreach (Char c in textBox.Text.ToCharArray())
            {
                if (Char.IsDigit(c) || Char.IsControl(c) || (c == '.' && count == 0))
                {
                    newText += c;
                    if (c == '.')
                        count += 1;
                }
            }
            textBox.Text = newText;
            textBox.SelectionStart = selectionStart <= textBox.Text.Length ? selectionStart : textBox.Text.Length;
        }
        public T GetRadioSelection<T>(T defaultValue, params RadioButton[] buttons)
        {
            foreach (RadioButton button in buttons)
            {
                if (button.IsChecked == true)
                {
                    if (button.Tag is string && typeof(T) != typeof(string))
                    {
                        string value = (string)button.Tag;
                        return (T)System.Convert.ChangeType(value, typeof(T));
                    }

                    return (T)button.Tag;
                }
            }
        return defaultValue;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ResultsWindow.Text = "";
        }
    }
}
