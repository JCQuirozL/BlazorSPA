//Clase que contiene eventos que son invocados desde el index.razor

namespace PoliciesBlazorApp.EventsNMethods
{
    using Blazorise;
    using Blazorise.DataGrid;
    using PoliciesBlazorApp.Models;

    public static class Events
    {
        #region Globales
            public static string? PolicyFilter { get; set; } = null;
            public static DateTime? StartDateFilter { get; set; } = null;
            static public DateTime? EndDateFilter { get; set; } = null;
            public static int ValidatedFilter { get; set; } = 2;
        #endregion

        //Evento para pintar de diferente color la póliza si a ésta le quedan sólo 5 días de vigencia
        public static void OnRowStyling(Data policy, DataGridRowStyling style)
        {
            //obtenemos la fecha de emisión de la póliza
            var date = policy.Clipert.SendingDateASE;

            //obtenemos la fecha de vencimiento
            var limitTerm = date.AddDays(Convert.ToDouble(policy.Term));

            //extraemos los días que restantes de vigencia que le queda a la póliza
            TimeSpan term = limitTerm - DateTime.Now;

            //hacemos la validación, se valida que sea mayor a cero porque la resta puede ser negativa
            if (((term.Days < 5) && (term.Days >= 0)) && !policy.Validated)
            {
                style.Background = Background.Default;
                style.Style = "color: #d90707";
            }

        }


        //Evento para pintar el fondo de la fila seleccionada de color 'secondary'
        public static void OnSelectedRowStyling(Data policy, DataGridRowStyling style)
        {
            style.Color = Color.Secondary;
        }


        //Evento para pintar el fondo de la fila 
        public static void OnRowStylingComments(PolicyCommentVM comments, DataGridRowStyling style)
        {
            style.Background = Background.Default;
        }

        ////Evento para pintar el fondo de la fila seleccionada de color 'secondary'
        public static void OnSelectedRowStylingComments(PolicyCommentVM comments, DataGridRowStyling style)
        {
            style.Color = Color.Secondary;
        }


        //Evento para bindear los parámetros de búsqueda
        public static Boolean OnCustomFilter(Data model)
        {

            // We want to accept empty value as valid or otherwise
            // datagrid will not show anything.
            //if ((string.IsNullOrEmpty(PolicyFilter)) || (StartDateFilter == null) || (EndDateFilter == null) || (ValidatedFilter.Equals(null)))
            //return true;



            //All params
            if ((StartDateFilter != null) && (EndDateFilter != null) && (PolicyFilter != null) && (ValidatedFilter == 1))

                return model.Policy.Contains(PolicyFilter, StringComparison.OrdinalIgnoreCase) &&
            (model.Clipert.SendingDateASE >= StartDateFilter && model.Clipert.SendingDateASE <= EndDateFilter) &&
            (model.Validated) && Methods.IsActivePolicy(model) == true;


            if ((StartDateFilter != null) && (EndDateFilter != null) && (PolicyFilter != null) && (ValidatedFilter == 2))

                return model.Policy.Contains(PolicyFilter, StringComparison.OrdinalIgnoreCase) &&
            (model.Clipert.SendingDateASE >= StartDateFilter && model.Clipert.SendingDateASE <= EndDateFilter) &&
            (model.Validated == false) && Methods.IsActivePolicy(model) == true;


            if ((StartDateFilter != null) && (EndDateFilter != null) && (PolicyFilter != null) && (ValidatedFilter == 3))

                return model.Policy.Contains(PolicyFilter, StringComparison.OrdinalIgnoreCase) &&
            (model.Clipert.SendingDateASE >= StartDateFilter && model.Clipert.SendingDateASE <= EndDateFilter) && !Methods.IsActivePolicy(model) == true;


            //With emission date and Policy number
            if ((StartDateFilter != null) && (EndDateFilter != null) && (PolicyFilter != null) && (ValidatedFilter == 0))

                return model.Policy.Contains(PolicyFilter, StringComparison.OrdinalIgnoreCase) &&
            (model.Clipert.SendingDateASE >= StartDateFilter && model.Clipert.SendingDateASE <= EndDateFilter) && Methods.IsActivePolicy(model) == true;


            //Policy and validation
            if (ValidatedFilter == 1 && PolicyFilter != null)

                return model.Policy.Contains(PolicyFilter, StringComparison.OrdinalIgnoreCase) &&
                (model.Validated == true) && Methods.IsActivePolicy(model) == true;

            if (ValidatedFilter == 2 && PolicyFilter != null)

                return model.Policy.Contains(PolicyFilter, StringComparison.OrdinalIgnoreCase) &&
                (model.Validated == false) && Methods.IsActivePolicy(model) == true;

            if (ValidatedFilter == 3 && PolicyFilter != null)

                return model.Policy.Contains(PolicyFilter, StringComparison.OrdinalIgnoreCase) &&
                (model.Validated == false) && !Methods.IsActivePolicy(model) == true;


            //Date
            if ((StartDateFilter != null) && (EndDateFilter != null) && (ValidatedFilter == 0))
                return (model.Clipert.SendingDateASE >= StartDateFilter && model.Clipert.SendingDateASE <= EndDateFilter) && Methods.IsActivePolicy(model) == true;


            //Policy number
            if (PolicyFilter != null && ValidatedFilter == 0)
                return model.Policy.Contains(PolicyFilter, StringComparison.OrdinalIgnoreCase) && Methods.IsActivePolicy(model);


            //validation status
            if (ValidatedFilter == 1)
                return (model.Validated) && Methods.IsActivePolicy(model) == true;


            if (ValidatedFilter == 2)
                return (model.Validated == false) && Methods.IsActivePolicy(model) == true;


            if (ValidatedFilter == 0)
                return (Methods.IsActivePolicy(model)) == true;


            if (ValidatedFilter == 3)
                return (!Methods.IsActivePolicy(model)) == true;


            return (Methods.IsActivePolicy(model)) == true;
        }



    }
}














