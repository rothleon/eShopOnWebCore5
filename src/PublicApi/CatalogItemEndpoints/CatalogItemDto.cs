namespace Microsoft.eShopWeb.PublicApi.CatalogItemEndpoints
{
    public class CatalogItemDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string PictureUri { get; set; }
        public int CatalogTypeId { get; set; }
        public int CatalogBrandId { get; set; }

        //Sprint 1 - Add a new attribute, like color or gender, to catalog items. - Leon Roth
        public int CatalogMaterialId { get; set; }
    }
}
