using Blazorise;

namespace PoliciesBlazorApp.Attrib
{
    public record Colores : Color
    {
        public static readonly Color AzulBBVA = new Color("blueBBVA");
        public static readonly Color DetailsColor = new Color("DetailsColor");
        public Colores(string name) : base(name)
        {
        }

        protected Colores(Color original) : base(original)
        {
        }
    }
}
