using Application.Contracts.Services;
using System;
using System.Threading.Tasks;
using RestSharp;


namespace InfrastructureServices.Services
{
    public class SmsService:ISmsService
    {

        public async Task<bool> SendVerificationCode(string phoneNumber, string code)
        {
            var client = new RestClient("http://188.0.240.110/api/select");
            var request = new RestRequest(Method.POST);
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("undefined", "{\"op\" : \"patternV2\"" +
                                              ",\"user\" : \"ashkan35\"" +
                                              ",\"pass\":  \"As12348765\"" +
                                              ",\"fromNum\" : \"3000505\"" +
                                              $",\"toNum\": \"{phoneNumber}\"" +
                                              ",\"patternCode\": \"9cazjii4gn\"" +
                                              ",\"inputData\" : {\"VerificationCode\": \""+code+"\"}}"
                , ParameterType.RequestBody);
            IRestResponse response =await client.ExecuteAsync(request);
            return response.IsSuccessful;
        }
    }
}