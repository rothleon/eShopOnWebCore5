namespace Microsoft.eShopWeb.Web.ViewModels
{
    public class CatalogItemViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PictureUri { get; set; }
        public decimal Price { get; set; }

        //Sprint 1 - Add a new attribute, like color or gender, to catalog items. - Leon Roth
        public string Material { get; set; }

    }
}
