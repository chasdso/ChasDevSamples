using System;
using System.Threading.Tasks;

using Csc.Res.Interfaces;
using Csc.Res.Services;

using Microsoft.Azure.ServiceBus;

namespace Csc.Res.Datalake
{
    /// <summary>
    /// Update invoice details from SAP.
    /// </summary>
    public class DatalakeLogging : Base.ResBase
    {
        /*
        [FunctionName("DatalakeLogging")]
        public static async Task Run(
            [ServiceBusTrigger("resoperationalstorage", "resPaylodLogging", Connection = "serviceBusConnection-resoperationalstorage")]Message message)
        {
            await (new DatalakeLogging()).Execute(message);
        }
        */

        private readonly IStorageService datalakeService;

        public DatalakeLogging() : base(Res.FamilyName.DataLake, Res.ServiceName.DataLake)
        {
            datalakeService = new DataLakeAdlsClientService();
        }

        private void ReadMessage(Message message)
        {
            message = message ?? new Message(new byte[0]);

            // Read state to remove previous run values.
            LoggingState.OperationName = GetType().Name;

            // TODO: Because DataLake function is used by our internal code, if we don't have a TransactionId, we have a SERIOUS problem. We should NOT be creating a NewGuid here!
            LoggingState.TransactionId = message.UserProperties.TryGetValue("transactionId", out object transactionId) ? transactionId.ToString() : Guid.NewGuid().ToString("D");

            // This will jelp us to find if the message was processed by application or a User
            LoggingState.AddOrReplaceTelemetryProperty("UserName", message.UserProperties.TryGetValue("UserName", out object userName) ? userName.ToString() : "Unknown");

            LoggingState.AddOrReplaceTelemetryProperty("MessageId", message.MessageId);
            LoggingState.ParentOperationName = message.UserProperties.TryGetValue("sourceSystem", out object _sourceSystem) ? _sourceSystem.ToString() : "Unknown";
            LogFunctionStart();
        }

        public async Task Execute(Message message)
        {
            // Read Message
            ReadMessage(message);

            try
            {
                // Get DataLakePath from user properties
                var datalakeFile = GetDatalakePath(message);

                // Read Payload
                CurrentEvent = TelemetryEvent.ServiceBus_Topic_Read;
                var payload = message.ReadAsString();

                CurrentEvent = TelemetryEvent.DataLake_Write;
                await datalakeService.Write(payload, Convert.ToString(datalakeFile));

                TrackInfo($"{datalakeFile} was successfully added to datalake.", TelemetryEvent.DataLake_Write, "Write Confirmation");
            }
            catch (Exception ex)
            {
                // TODO: we need to consider how we will handle failed DataLake writes. My suggestion - mimic Microsoft's EventGrid implementation and have a backup Storage blob.
                Trace(ex.Message, CurrentEvent, "Failed");
                LoggingState.AddException(ex);
            }
            finally
            {
                LogFunctionEnd();
                Dispose();
            }
        }

        private string GetDatalakePath(Message message)
        {
            // Does message contain DataLakePath?
            if (!message.UserProperties.TryGetValue("datalakePath", out object _datalakePath))
            {
                throw new ArgumentNullException($"{nameof(_datalakePath)} not found in user properties.");
            }

            var datalakePath = Convert.ToString(_datalakePath);

            // Is DataLakePath empty?
            if (string.IsNullOrWhiteSpace(datalakePath))
            {
                throw new ArgumentNullException($"{nameof(datalakePath)} in the message user properties is null or empty.");
            }

            return datalakePath;
        }
    }
}