using Microsoft.Extensions.Configuration;
using RestSharpSpecflowFramework.Configuration;
using RestSharpSpecflowFramework.Drivers;
using RestSharpSpecflowFramework.Support;
using TechTalk.SpecFlow;

namespace RestSharpSpecflowFramework.Hooks
{
    [Binding]
    public sealed class Hooks
    {
        [BeforeTestRun]
        public static void Setup()
        {
            string parentDirectory = PathFinder.GetPath();
            ConfigManager config = new ConfigManager();
            ConfigurationBuilder configbuilder = new ConfigurationBuilder();
            configbuilder.AddJsonFile(parentDirectory + "\\RestSharpSpecflowFramework\\config.json");
            IConfigurationRoot configuration = configbuilder.Build();
            configuration.Bind(config);
            APIHelper.baseURL = config.ApiBaseURL;

            RestSharpManager.InitializeEndpoint(APIHelper.baseURL);
        }

        [AfterScenario]
        public static void ClearRequest()
        {
            RestSharpManager.ClearRequest();
        }
    }
}