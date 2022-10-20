

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
            static readonly string Url = "/insurance/v1/policies";
            static string Url2 = "/api/PoliciesCollection";
            static HttpClient Http = new() { BaseAddress = new Uri("https://localhost:44391") };
        #endregion

        //Servicio para cargar info de las pólizas
        public static async Task LoadPoliciesAsync()
        {
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Get, Url);
                request.Headers.Add("Session-Id", "10000057cpbas096");
                using var httpResponse = await Http.SendAsync(request);

                PoliciesList = await httpResponse.Content.ReadFromJsonAsync<BillingData>();

                //PoliciesList = await Http.GetFromJsonAsync<List<BillingData>>(Url);
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        //Servicio para hacer el patch de pólizas
        public static async Task<Boolean> PatchPoliciesAsync(Policy policy)
        {
            PatchPolicies[] model = new[] { new PatchPolicies(policy) };

            var json = JsonConvert.SerializeObject(model);
            var body = new StringContent(json, Encoding.UTF8, "application/json");

            var request = new HttpRequestMessage(HttpMethod.Patch, Url);

            request.Headers.Add("Session-Id", "10000057cpbas096");
            request.Content = body;

            using var httpResponse = await Http.SendAsync(request);

            return httpResponse.IsSuccessStatusCode ? true : false;
        }

        //Servicio para hacer el post de comentarios
        public static async Task<Boolean> PostCommentAsync(PolicyCommentPost model)
        {
            var json = JsonConvert.SerializeObject(model);
            var body = new StringContent(json, Encoding.UTF8, "application/json");

            var request = new HttpRequestMessage(HttpMethod.Post, Url);
            request.Headers.Add("Session-Id", "10000057cpbas096");
            request.Content = body;
            using var httpResponse = await Http.SendAsync(request);

            return httpResponse.IsSuccessStatusCode ? true : false;
        }
    }
}
