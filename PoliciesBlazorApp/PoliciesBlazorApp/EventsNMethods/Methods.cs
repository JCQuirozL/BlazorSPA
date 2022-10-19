

namespace PoliciesBlazorApp.EventsNMethods
{
    using PoliciesBlazorApp.Models;
    public static class Methods
    {
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
