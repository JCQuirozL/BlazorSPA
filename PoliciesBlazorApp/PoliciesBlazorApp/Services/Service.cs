

namespace PoliciesBlazorApp.Services
{
    using Newtonsoft.Json;
    using PoliciesBlazorApp.Models;
    using PoliciesBlazorApp.Responses;
    using System.Net.Http.Json;
    using System.Text;

    public static class Service
    {
        #region Globales
        public static BillingData PoliciesList = new();

        //QA
        static string Url = "/insurances/insurances/v1/policies";

        //Dev
        //static string Url = "/insurances/v1/policies";

        //static string Url2 = "/api/PoliciesCollection";
        //static HttpClient Http = new() { BaseAddress = new Uri("https://localhost:44391") };
        static HttpClient Http = new() { BaseAddress = new Uri(@"https://lsnga1mxc.facileasing.com.mx") };

        //QA
        static HttpClient HttpComments = new() { BaseAddress = new Uri("http://lsnga1mxc.facileasing.com.mx:8052") };

        //Dev
        //static HttpClient HttpComments = new() { BaseAddress = new Uri("http://localhost:55416") };

        #endregion

        //Servicio para cargar info de las pólizas
        public static async Task<BillingData> LoadPoliciesAsync()
        {
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Get, Url);
                request.Headers.Add("Session-Id", "10000057cpbas096");
                using var httpResponse = await Http.SendAsync(request);

                PoliciesList = await httpResponse.Content.ReadFromJsonAsync<BillingData>();

                return PoliciesList;
                //PoliciesList = await Http.GetFromJsonAsync<List<BillingData>>(Url);
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        //Servicio para hacer el patch de pólizas
        public static async Task<Boolean> PatchPoliciesAsync(PatchPolicies[] policy)
        {
            //PatchPolicies[] model = new[] { new PatchPolicies(policy) };

            var json = JsonConvert.SerializeObject(policy);
            var body = new StringContent(json, Encoding.UTF8, "application/json");

            var request = new HttpRequestMessage(HttpMethod.Patch, Url);

            request.Headers.Add("Session-Id", "10000057cpbas096");
            request.Content = body;

            using var httpResponse = await Http.SendAsync(request);

            return httpResponse.IsSuccessStatusCode;
        }

        //Servicio para hacer el post de comentarios
        public static async Task<Boolean> PostCommentAsync(PolicyComment model)
        {
            try
            {
                var json = JsonConvert.SerializeObject(model);
                var body = new StringContent(json, Encoding.UTF8, "application/json");

                //QA
                var request = new HttpRequestMessage(HttpMethod.Post, $"/common/notes/v1/leasings/srcINSidd{model.PolicyId}/comments");

                //dev
                //var request = new HttpRequestMessage(HttpMethod.Post, $"/notes/v1/leasings/srcINSidd{model.PolicyId}/comments");

                request.Headers.Add("Session-Id", "10000057cpbas096");
                request.Content = body;
                using var httpResponse = await HttpComments.SendAsync(request);

                return httpResponse.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {

                throw;
            }

        }
    }
}
