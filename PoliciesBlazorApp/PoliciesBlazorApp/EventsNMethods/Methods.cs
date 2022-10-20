//Clase que contiene métodos invocados desde index.razor

namespace PoliciesBlazorApp.EventsNMethods
{
    using PoliciesBlazorApp.Models;
    public static class Methods
    {

        //Método para checar el vencimiento de la póliza
        public static Boolean IsActivePolicy(Data model)
        {
            var date = model.Clipert.SendingDateASE;
            var limitTerm = date.AddDays(Convert.ToDouble(model.Term));
            TimeSpan days = limitTerm - DateTime.Now;

            if (days.Days < 0)
            {
                return false;
            }
            return true;
        }
    }
}
