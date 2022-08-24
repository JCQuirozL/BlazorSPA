
namespace LeerCSV
{
    using LeerCSV.Models;
    using Newtonsoft.Json;
    using RestSharp;
    using System.Net;

    public class Service
    {
        //método para crear un nuevo registro en la tabla PolicyFileCollection
        public static Boolean CreatePFC(ClipertDataCSV[] model)
        {
            var body = JsonConvert.SerializeObject(model);
            var client = new RestClient("https://localhost:7002/api/PoliciesCollectionFile/Policies");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("application/json", body, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                return true;
            }

            return false;
        }

        public static Boolean CreatePIService(LeasingVM[] model)
        {
            var body = JsonConvert.SerializeObject(model);
            var client = new RestClient("https://localhost:7002/api/PoliciesInformationService/Policies");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("application/json", body, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                return true;
            }

            return false;
        }

        //Obtener arreglo de pólizas
        //Simula servicio SAP que consulta información sobre las pólizas del lado de Leasing
        public static List<LeasingVM> GetPoliciesList(List<string> Params)
        {
            var body = JsonConvert.SerializeObject(Params);
            var getPoliciesClient = new RestClient("https://localhost:7171/api/PIService/Policies");
            getPoliciesClient.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("application/json", body, ParameterType.RequestBody);
            IRestResponse response = getPoliciesClient.Execute(request);
            
            var Result = JsonConvert.DeserializeObject<List<LeasingVM>>(response.Content);

            if (Result != null && response.StatusCode== HttpStatusCode.OK)
            {
                return Result;
            }

            throw response.ErrorException;



        }
    }
}
