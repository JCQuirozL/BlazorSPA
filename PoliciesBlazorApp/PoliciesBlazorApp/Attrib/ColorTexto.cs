using Blazorise;

namespace PoliciesBlazorApp.Attrib
{
    public record ColorTexto : TextColor
    {
        public static readonly TextColor DetailsColor = new TextColor("detailsColor");
        public ColorTexto(string name) : base(name)
        {
        }

        protected ColorTexto(TextColor original) : base(original)
        {
        }
    }
}
