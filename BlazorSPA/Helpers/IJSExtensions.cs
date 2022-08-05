using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace BlazorSPA.Helpers
{
    public static class IJSExtensions
    {
        public async static Task<object> MostrarMensaje(this IJSRuntime js, string Mensaje)
        {
            return await js.InvokeAsync<object>("Swal.fire", Mensaje);  
        }

        public async static Task<Boolean> Confirm(this IJSRuntime js, string titulo, string mensaje, TipoSweetAlert tipo)
        { 
            return await js.InvokeAsync<Boolean>("CustomConfirm", titulo, mensaje, tipo);
        }

        public enum TipoSweetAlert
        {
            question, warning, error, success, info
        }
    }
}
