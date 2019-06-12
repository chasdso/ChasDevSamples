namespace Csc.Res.Datalake
{
    public static class DatalakeRead
    {
        /*
        [FunctionName("ReadData")]
        public static async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req, ILogger log)
        {
            log.LogInformation("Datalake read started");

            try
            {
                string filename = req.Query["filename"];
                log.LogInformation($"Datalake filename: {filename}.");

                var datalakeClient = new DataLakeAdlsClientService();

                return (ActionResult)new OkObjectResult(await datalakeClient.Read(filename));
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.GetExceptionLog());
            }
        }
        */
    }
}