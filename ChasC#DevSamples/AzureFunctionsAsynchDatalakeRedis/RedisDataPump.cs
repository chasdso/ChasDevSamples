using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Csc.Res.Azure.DataLake;

using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace Csc.Res.DataLake
{
    public class RedisDataPump
    {
        private static Dictionary<string, object> logProperties = new Dictionary<string, object>()
        {
        };

        [FunctionName(nameof(RedisDataPump))]
        public static async Task Run(
            [TimerTrigger("%RedisDataPumpSchedule%", RunOnStartup = true)]TimerInfo myTimer,
            ILogger log)
        {
            // Get startTicks
            long startTicks = DateTime.UtcNow.Ticks;

            using (log.BeginScope(logProperties))
            // This DataLake client is used for writing exceptions that occur inside RedisDataPump. Do NOT remove it.
            using (DataLakeClient dataLake = new DataLakeClient(log))
            {
                try
                {
                    List<Task> tasks = new List<Task>();

                    // Pump and dump Redis lists (default: res-datalake)
                    tasks.Add(new DataLakeClient(log).FlushRedis(startTicks, 55000));

                    // Named
                    tasks.Add(new DataLakeClient(log, Extension.ToString(Res.ServiceName.AccountsPayableInvoiceInbound)).FlushRedis(startTicks, 55000));
                    tasks.Add(new DataLakeClient(log, Extension.ToString(Res.ServiceName.AccountsPayableInvoiceOutbound)).FlushRedis(startTicks, 55000));
                    tasks.Add(new DataLakeClient(log, Extension.ToString(Res.ServiceName.AccountsPayablePayInbound)).FlushRedis(startTicks, 55000));
                    tasks.Add(new DataLakeClient(log, Extension.ToString(Res.ServiceName.AdvanceShippingNoticeInbound)).FlushRedis(startTicks, 55000));
                    tasks.Add(new DataLakeClient(log, Extension.ToString(Res.ServiceName.Adyen)).FlushRedis(startTicks, 55000));
                    tasks.Add(new DataLakeClient(log, Extension.ToString(Res.ServiceName.Coupon)).FlushRedis(startTicks, 55000));
                    tasks.Add(new DataLakeClient(log, Extension.ToString(Res.ServiceName.CouponDeliveryOutbound)).FlushRedis(startTicks, 55000));
                    tasks.Add(new DataLakeClient(log, Extension.ToString(Res.ServiceName.CustomerInbound)).FlushRedis(startTicks, 55000));
                    tasks.Add(new DataLakeClient(log, Extension.ToString(Res.ServiceName.CustomerOutbound)).FlushRedis(startTicks, 55000));
                    tasks.Add(new DataLakeClient(log, Extension.ToString(Res.ServiceName.DropshipOrderInbound)).FlushRedis(startTicks, 55000));
                    tasks.Add(new DataLakeClient(log, Extension.ToString(Res.ServiceName.EdiPurchaseOrder)).FlushRedis(startTicks, 55000));
                    tasks.Add(new DataLakeClient(log, Extension.ToString(Res.ServiceName.EmployeeInbound)).FlushRedis(startTicks, 55000));
                    tasks.Add(new DataLakeClient(log, Extension.ToString(Res.ServiceName.FraudOutbound)).FlushRedis(startTicks, 55000));
                    tasks.Add(new DataLakeClient(log, Extension.ToString(Res.ServiceName.GeneralLedgerOutbound)).FlushRedis(startTicks, 55000));
                    tasks.Add(new DataLakeClient(log, Extension.ToString(Res.ServiceName.GenericApi)).FlushRedis(startTicks, 55000));
                    tasks.Add(new DataLakeClient(log, Extension.ToString(Res.ServiceName.GenericInbound)).FlushRedis(startTicks, 55000));
                    tasks.Add(new DataLakeClient(log, Extension.ToString(Res.ServiceName.GenericOutbound)).FlushRedis(startTicks, 55000));
                    tasks.Add(new DataLakeClient(log, Extension.ToString(Res.ServiceName.Invalid)).FlushRedis(startTicks, 55000));
                    tasks.Add(new DataLakeClient(log, Extension.ToString(Res.ServiceName.InventoryInbound)).FlushRedis(startTicks, 55000));
                    tasks.Add(new DataLakeClient(log, Extension.ToString(Res.ServiceName.InventoryOutbound)).FlushRedis(startTicks, 55000));
                    tasks.Add(new DataLakeClient(log, Extension.ToString(Res.ServiceName.Loyalty)).FlushRedis(startTicks, 55000));
                    tasks.Add(new DataLakeClient(log, Extension.ToString(Res.ServiceName.LoyaltyInbound)).FlushRedis(startTicks, 55000));
                    tasks.Add(new DataLakeClient(log, Extension.ToString(Res.ServiceName.LoyaltyOutbound)).FlushRedis(startTicks, 55000));
                    tasks.Add(new DataLakeClient(log, Extension.ToString(Res.ServiceName.MapleLake)).FlushRedis(startTicks, 55000));
                    tasks.Add(new DataLakeClient(log, Extension.ToString(Res.ServiceName.PricingOutbound)).FlushRedis(startTicks, 55000));
                    tasks.Add(new DataLakeClient(log, Extension.ToString(Res.ServiceName.ProductInbound)).FlushRedis(startTicks, 55000));
                    tasks.Add(new DataLakeClient(log, Extension.ToString(Res.ServiceName.ProductOutbound)).FlushRedis(startTicks, 55000));
                    tasks.Add(new DataLakeClient(log, Extension.ToString(Res.ServiceName.PurchaseAgreementOutbound)).FlushRedis(startTicks, 55000));
                    tasks.Add(new DataLakeClient(log, Extension.ToString(Res.ServiceName.PurchaseOrderConfirmInbound)).FlushRedis(startTicks, 55000));
                    tasks.Add(new DataLakeClient(log, Extension.ToString(Res.ServiceName.PurchaseOrderInbound)).FlushRedis(startTicks, 55000));
                    tasks.Add(new DataLakeClient(log, Extension.ToString(Res.ServiceName.SalesOrderConfirmOutbound)).FlushRedis(startTicks, 55000));
                    tasks.Add(new DataLakeClient(log, Extension.ToString(Res.ServiceName.SalesOrderDropshipOutbound)).FlushRedis(startTicks, 55000));
                    tasks.Add(new DataLakeClient(log, Extension.ToString(Res.ServiceName.SalesOrderInbound)).FlushRedis(startTicks, 55000));
                    tasks.Add(new DataLakeClient(log, Extension.ToString(Res.ServiceName.SalesOrderOutbound)).FlushRedis(startTicks, 55000));
                    tasks.Add(new DataLakeClient(log, Extension.ToString(Res.ServiceName.SalesOrderReturnInbound)).FlushRedis(startTicks, 55000));
                    tasks.Add(new DataLakeClient(log, Extension.ToString(Res.ServiceName.SalesOrderReturnOutbound)).FlushRedis(startTicks, 55000));
                    tasks.Add(new DataLakeClient(log, Extension.ToString(Res.ServiceName.SalesOrderSurveyOutbound)).FlushRedis(startTicks, 55000));
                    tasks.Add(new DataLakeClient(log, Extension.ToString(Res.ServiceName.SapReturnOrderInbound)).FlushRedis(startTicks, 55000));
                    tasks.Add(new DataLakeClient(log, Extension.ToString(Res.ServiceName.SapSalesOrderUpdateInbound)).FlushRedis(startTicks, 55000));
                    tasks.Add(new DataLakeClient(log, Extension.ToString(Res.ServiceName.SupportImport)).FlushRedis(startTicks, 55000));
                    tasks.Add(new DataLakeClient(log, Extension.ToString(Res.ServiceName.SvsGiftCardOutbound)).FlushRedis(startTicks, 55000));
                    tasks.Add(new DataLakeClient(log, Extension.ToString(Res.ServiceName.TaxwareOutbound)).FlushRedis(startTicks, 55000));
                    tasks.Add(new DataLakeClient(log, Extension.ToString(Res.ServiceName.TradeAgreementInbound_Map)).FlushRedis(startTicks, 55000));
                    tasks.Add(new DataLakeClient(log, Extension.ToString(Res.ServiceName.TradeAgreementInbound_Purch)).FlushRedis(startTicks, 55000));
                    tasks.Add(new DataLakeClient(log, Extension.ToString(Res.ServiceName.TradeAgreementOutbound)).FlushRedis(startTicks, 55000));

                    // Wait for all Tasks
                    Task.WaitAll(tasks.ToArray());
                }
                catch (Exception ex)
                {
                    await RecoveryMessage.SendAsync(new RecoveryMessage()
                    {
                        ServiceName = ServiceName.DataLake,
                        FamilyName = Extension.ToString(FamilyName.DataLake),
                        FunctionName = nameof(RedisDataPump),
                        MethodName = nameof(Run),
                        ResourceGroup = Extension.ToString(Res.ServiceName.DataLake),
                        Exception = ex,
                    }, dataLake, log);
                }
            }
        }
    }
}