using NUnit.Framework;
using RestSharpSpecflowFramework.Drivers;
using System;
using System.Net;
using TechTalk.SpecFlow;

namespace RestSharpSpecflowFramework.StepDefinitions
{
    [Binding]
    public class APIAutomationStepDefinitions
    {
        [Given(@"The test case title is '([^']*)'")]
        public void GivenTheTestCaseTitleIs(string testcase)
        { }

        [When(@"User makes a '([^']*)' call at the '([^']*)'")]
        public void WhenUserMakesACallAtThe(string method, string endpoint)
        {
            APIHelper.endpoint = endpoint;
            APIHelper.method = method;

            RestSharpManager.MakeRequest(method);
        }

        [When(@"User makes a '([^']*)' call at the '([^']*)' for '([^']*)'")]
        public void WhenUserMakesACallAtTheFor(string method, string endpoint, string body)
        {
            APIHelper.endpoint = endpoint;
            APIHelper.body = body;
            APIHelper.method = method;

            RestSharpManager.MakeRequest(method);
        }

        [When(@"User sets '([^']*)' query param value as '([^']*)'")]
        public void WhenUserSetsQueryParamValueAs(string queryParam, string queryParamValue)
        {
            RestSharpManager.SetQueryParam(queryParam, queryParamValue);
        }

        [When(@"User executes the api call")]
        public void WhenUserExecutesTheApiCall()
        {
            RestSharpManager.ExecuteRequest();
        }


        [Then(@"User should expect '([^']*)' response code")]
        public void ThenUserShouldExpectResponseCode(int responseCode)
        {
            int actualResponseCode = (int)(HttpStatusCode)APIHelper.response.StatusCode;
            if (responseCode != actualResponseCode)
            {
                if (APIHelper.method.Equals("get") || APIHelper.method.Equals("delete"))
                {
                    Assert.Fail("Request Endpoint: {0}{1} \n Request Method: {2} \n Expected Response Code: {3} \n Actual Response Code: {4}", APIHelper.baseURL, APIHelper.endpoint, APIHelper.method.ToUpper(), responseCode, actualResponseCode);
                }
                else
                {
                    Assert.Fail("Request Endpoint: {0}{1} \n Request Method: {2} \n Request body: {3} \n Expected Response Body: {4} \n Actual Response Body: {5} \n Expected Response Code: {6} \n Actual Response Code: {7}", APIHelper.baseURL, APIHelper.endpoint, APIHelper.method.ToUpper(), APIHelper.body, actualResponseCode, APIHelper.response.Content, responseCode, actualResponseCode);
                }
            }
        }
    }
}
