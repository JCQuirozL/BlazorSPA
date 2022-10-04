using Blazorise;
using Microsoft.AspNetCore.Components;

namespace PoliciesBlazorApp.Attrib
{
    public class Botones:Button
    {
        private Color customColor = Colores.AzulBBVA;

        //
        // Resumen:
        //     Gets or sets the button color.
        [Parameter]
        public Color CustomColorolor
        {
            get
            {
                return customColor;
            }
            set
            {
                customColor = value;
                DirtyClasses();
            }
        }
    }
}
