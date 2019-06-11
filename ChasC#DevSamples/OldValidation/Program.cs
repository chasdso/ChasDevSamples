using System;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;

namespace Brokeries.DataValidation
{
    class Program
    {
        public string EmailString;
        static void Main(string[] args)
        {

            #region BROKER URL check 
            var client = new MongoClient();
            var db = client.GetDatabase("OurBmsV2");
            var brokersColl = db.GetCollection<Brokers>("Brokers");
            int brokercount = 0;
            int i = 0;
            //var accountscoll = db.GetCollection<Accounts>("Accounts");
            var emailString = new Program();
         
            var brokers = brokersColl.Find(b => b.Name != null).ToListAsync().Result;

            Console.WriteLine("Brokeries -- Broker landing page test from Broker collection:");
            Console.Write("Working...");

            foreach (var broker in brokers)
            {
                brokercount++;
                Console.Write(".");

                try
                {
                    var link = broker.WebLinks[0];

                    try
                    {
                        WebResponse response = TestURL(link);
                        string status = ((HttpWebResponse)response).StatusDescription;
                    }
                    catch (WebException e)
                    {
                        i++;
                        Console.WriteLine();
                        Console.WriteLine(broker.Name + ", " + link + ", " + "\r\nWebException Raised. The following error occured : {0}", e.Status);
                        emailString.EmailSend(e.Status.ToString());
                        Console.WriteLine("This is EMAIL STRING " + emailString.EmailString);
                        
                    }
                    catch (Exception e)
                    {
                        i++;
                        Console.WriteLine();
                        Console.WriteLine(broker.Name + ", " + link + ", " + "\nThe following Exception was raised : {0}", e.Message);
                        emailString.EmailSend(e.Message.ToString());
                        Console.WriteLine("This is EMAIL STRING " + emailString.EmailString);
                        
                    }
                }
                catch (Exception e)
                {
                    i++;
                    Console.WriteLine();
                    Console.WriteLine(broker.Name + ", NULL URL" + "\nThe following Exception was raised : {0}", e.Message);
                    emailString.EmailSend(e.Message.ToString());
                    Console.WriteLine("This is EMAIL STRING " + emailString.EmailString);
                    
                }
                
            }
            Console.WriteLine("Total broker links examined: " + brokercount);
            Console.WriteLine("Total broker link issues: " + i);
            Console.WriteLine("Broker landing page test done.");
            Console.ReadKey();
        }
            #endregion

            #region ACCOUNTS URL check 
            //    var accClient = new MongoClient();
            //    var accDB = accClient.GetDatabase("OurBmsV2");
            //    var accountsColl = accDB.GetCollection<Accounts>("Accounts");
            //    int accCount = 0;
            //    int t = 0;
            //    //var accountscoll = db.GetCollection<Accounts>("Accounts");

            //    var accounts = accountsColl.Find(b => b.Name != null).ToListAsync().Result;

            //    Console.WriteLine("Brokeries -- Accounts URL test from Accounts collection:");
            //    Console.Write("Working...");

            //    foreach (var account in accounts)
            //    {
            //        accCount++;
            //        Console.Write(".");
            //        Console.WriteLine("WEBSITE: " + account.Website);

            //        try
            //        {
            //            var link = account.WebLinks[0];
            //            Console.WriteLine("WEBLINKS[0]: " + account.WebLinks[0]);

            //            //try
            //            //{
            //            //    WebResponse response = TestURL(link);
            //            //    string status = ((HttpWebResponse)response).StatusDescription;
            //            //}
            //            //catch (WebException e)
            //            //{
            //            //    t++;
            //            //    Console.WriteLine();
            //            //    Console.WriteLine(account.Name + ", " + link + ", " + "\r\nWebException Raised. The following error occured : {0}", e.Status);
            //            //}
            //            //catch (Exception e)
            //            //{
            //            //    t++;
            //            //    Console.WriteLine();
            //            //    Console.WriteLine(account.Name + ", " + link + ", " + "\nThe following Exception was raised : {0}", e.Message);
            //            //}
            //        }
            //        catch (Exception e)
            //        {
            //            t++;
            //            Console.WriteLine();
            //            Console.WriteLine(account.Name + ", NULL URL" + "\nThe following Exception was raised : {0}", e.Message);
            //        }
            //    }
            //    Console.WriteLine("Total account links exammined: " + accCount);
            //    Console.WriteLine("Total account link issues: " + t);
            //    Console.WriteLine("Account URL test done.");
            //    Console.ReadKey();
            //}
            #endregion
        public static WebResponse TestURL(String url)
        {
            WebRequest request = WebRequest.Create(url);
            request.Credentials = CredentialCache.DefaultCredentials;
            WebResponse response = request.GetResponse();
            return response;

        }
        public void EmailSend(string addText)
        {
            EmailString = EmailString + addText;
        }


    }


public class Brokers
{
    public Object _id { get; set; }
    public DateTime Start { get; set; }
    public DateTime Finish { get; set; }
    public int Type { get; set; }
    public DateTime LastUpdated { get; set; }
    public Object UserId { get; set; }
    public Object FirmId { get; set; }
    public Object IdentityId { get; set; }
    public Linkedidentity[] LinkedIdentities { get; set; }
    public bool Regulated { get; set; }
    public bool FundsSegregation { get; set; }
    public bool IslamicSwapFreeAccount { get; set; }
    public bool AccountforMoneyManagers { get; set; }
    public bool PortfolioManagementAccount { get; set; }
    public bool RetirementAccount { get; set; }
    public bool NoAccountMaintenanceFees { get; set; }
    public bool PlatformGuides { get; set; }
    public bool Seminars { get; set; }
    public bool Webinars { get; set; }
    public bool Tutorials { get; set; }
    public bool PersonalCoaching { get; set; }
    public bool NewsFeed { get; set; }
    public bool Support247 { get; set; }
    public bool FullSupportFlag { get; set; }
    public bool PhoneSupportFlag { get; set; }
    public bool PhoneDealingFlag { get; set; }
    public bool CallBackSupportFlag { get; set; }
    public bool EmailSupportFlag { get; set; }
    public bool LiveChatSupportFlag { get; set; }
    public bool SkypeSupportFlag { get; set; }
    public bool PersonalAccountManagerFlag { get; set; }
    public string Foundation { get; set; }
    public string StatusEntityLevel { get; set; }
    public string ClientsCoverage { get; set; }
    public string Regulators { get; set; }
    public string NotAcceptingClientsFrom { get; set; }
    public string WebsiteLanguages { get; set; }
    public string AllAccountTypes { get; set; }
    public string AccountOpeningProcess { get; set; }
    public string TimeRequiredToOpenAccount { get; set; }
    public string AccountBasecurrencies { get; set; }
    public string FundingOptions { get; set; }
    public string MemberofExchanges { get; set; }
    public string ExcecutionPartners { get; set; }
    public string UnderlyingsCovered { get; set; }
    public string SupportLanguages { get; set; }
    public string Phone { get; set; }
    public string Fax { get; set; }
    public string Email { get; set; }
    public string Skype { get; set; }
    public string[] WebLinks { get; set; }
    public string WebSite { get; set; }
    public string Disclaimer { get; set; }
    public string Lastupdate { get; set; }
    public object IntheMoneyPayout { get; set; }
    public object OutoftheMoneyPayout { get; set; }
    public object ExpiryTimes { get; set; }
    public Address Address { get; set; }
    public string Name { get; set; }
    public int TradingPlatformPresence { get; set; }
    public int BrokerProductFlags { get; set; }
    public int EntityLevel { get; set; }
    public int[] ProfileType { get; set; }
    public bool UsClientsAllowed { get; set; }
    public bool SupportsDemoAccounts { get; set; }
    public object InstrumentCount { get; set; }
    public string ImagePath { get; set; }
    public bool FinancialCalendarFlag { get; set; }
    public bool ScreenerFlag { get; set; }
    public bool MarketAnalysisFlag { get; set; }
    public bool TradeStrategiesFlag { get; set; }
    public bool OnlineCommunityFlag { get; set; }
    public bool TradingChannelsWebFlag { get; set; }
    public bool TradingChannelsDesktopFlag { get; set; }
    public bool TradingChannelsMobileFlag { get; set; }
    public bool IntegratedModulesNewsFlag { get; set; }
    public bool IntegratedModulesChartsFlag { get; set; }
    public bool IntegratedModulesIndicatorsAndStudiesFlag { get; set; }
    public bool IntegratedModulesCustomIndicatorsFlag { get; set; }
    public bool TradingFeaturesOneClickTradingFlag { get; set; }
    public bool TradingFeaturesChartTradingFlag { get; set; }
    public bool TradingFeaturesHedgingFlag { get; set; }
    public bool TradingFeaturesScalpingFlag { get; set; }
    public bool TradingFeaturesFractionalPipsFlag { get; set; }
    public bool TradingFeaturesGuaranteedStopLossesFlag { get; set; }
    public bool AutoTradingRobotsTradingFlag { get; set; }
    public bool AutoTradingSocialTradingFlag { get; set; }
    public bool AutoTradingCustomAutoTradingSystemFlag { get; set; }
    public bool AutoTradingDDECapabilitiesFlag { get; set; }
    public bool AutoTradingOrderTypesFlag { get; set; }
    public bool AutoTradingMarketOrderFlag { get; set; }
    public bool AutoTradingLimitOrderFlag { get; set; }
    public bool AutoTradingStopOrderFlag { get; set; }
    public bool AutoTradingTrailingStopOrderFlag { get; set; }
    public bool AutoTradingOCOOrdersFlag { get; set; }
    public bool MeantForDayTradingFlag { get; set; }
    public bool MeantForSwingTradingFlag { get; set; }
    public bool MeantForMidTermTradingFlag { get; set; }
    public bool MeantForLongTermInvestingFlag { get; set; }
    public bool MiscellaneousMultiLanguageFlag { get; set; }
    public bool MiscellaneousLiveSupportFlag { get; set; }
    public object Description { get; set; }
    public object[] TradePlatforms { get; set; }
    public bool NewsFlag { get; set; }
    public bool AlertsEmailFlag { get; set; }
    public bool AlertsSMSFlag { get; set; }
    public int TradingPlatform { get; set; }
}

public class Address
{
    public string StreetAddress { get; set; }
    public string PostalCode { get; set; }
    public string CountryRegion { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Phone { get; set; }
    public string Locality { get; set; }
    public string NotResolvedLocation { get; set; }
    public string AdminDistrict { get; set; }
    public object Longitude { get; set; }
    public object Lattitude { get; set; }
    public string CountryIsoCode { get; set; }
}

public class Linkedidentity
{
    public int RelationType { get; set; }
    public Object LinkedIdentityId { get; set; }
}

public class Accounts
{
    public Object _id { get; set; }
    public DateTime Start { get; set; }
    public DateTime Finish { get; set; }
    public int Type { get; set; }
    public DateTime LastUpdated { get; set; }
    public Object UserId { get; set; }
    public Object FirmId { get; set; }
    public Object IdentityId { get; set; }
    public Linkedidentity[] LinkedIdentities { get; set; }
    public string Name { get; set; }
    public string Website { get; set; }
    public int ProfileType { get; set; }
    public int Rank { get; set; }
    public double MinDeposit { get; set; }
    public double MarginMinDeposit { get; set; }
    public double MaxLeverage { get; set; }
    public double TradeCommission { get; set; }
    public string Commissions { get; set; }
    public double AverageEurUsdSpread { get; set; }
    public double AverageUSDJPYSpread { get; set; }
    public double AverageGBPUSDSpread { get; set; }
    public double AverageUSDCADSpread { get; set; }
    public double AverageXAUUSDSpread { get; set; }
    public double AverageAUDUSDSpread { get; set; }
    public double AverageUSDCHFSpread { get; set; }
    public int ExecutionType { get; set; }
    public bool SupportsOptions { get; set; }
    public bool IsCommissionVolumeBased { get; set; }
    public bool SupportOptions { get; set; }
    public double IncentivizedCommission { get; set; }
    public object Incentive { get; set; }
    public double ExchangeCommissions { get; set; }
    public double MarginRate { get; set; }
    public double AssistedTradeFee { get; set; }
    public double ContractFee { get; set; }
    public double OptionsRegulatoryFee { get; set; }
    public double MinBondValue { get; set; }
    public double MaxBondValue { get; set; }
    public double OutgoingAccountTransferPartialFee { get; set; }
    public double OutgoingAccountTransferFullFee { get; set; }
    public double IncomingWireTransferFee { get; set; }
    public double OutgoingWireTransferFee { get; set; }
    public double CheckCopyFee { get; set; }
    public double CheckRequestFee { get; set; }
    public double StopPaymentRequestFee { get; set; }
    public object Description { get; set; }
    public Address Address { get; set; }
    public object Vrstaspreada { get; set; }
    public bool DealingDeskDD { get; set; }
    public bool NonDealingDeskSTP { get; set; }
    public bool STPInstantExecution { get; set; }
    public string[] WebLinks { get; set; }
    public bool STPDirectMarketAccess { get; set; }
    public bool ECNElectronicCommunicationNetwork { get; set; }
    public object LiquidityProvidersLPs { get; set; }
}

}
