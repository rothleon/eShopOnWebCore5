namespace Microsoft.eShopWeb.PublicApi.CatalogItemEndpoints
{
    public class ListPagedCatalogItemRequest : BaseRequest 
    {
        public int PageSize { get; set; }
        public int PageIndex { get; set; }
        public int? CatalogBrandId { get; set; }
        public int? CatalogTypeId { get; set; }

        //Sprint 1 - Add an additional filter to the main page besides Brand and Type. - Leon Roth
        public int? CatalogMaterialId { get; set; }
    }
}
