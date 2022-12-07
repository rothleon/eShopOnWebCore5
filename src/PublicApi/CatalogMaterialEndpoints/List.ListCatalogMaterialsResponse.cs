using System;
using System.Collections.Generic;

namespace Microsoft.eShopWeb.PublicApi.CatalogMaterialEndpoints
{
    public class ListCatalogMaterialsResponse : BaseResponse
    {
        public ListCatalogMaterialsResponse(Guid correlationId) : base(correlationId)
        {
        }

        public ListCatalogMaterialsResponse()
        {
        }

        public List<CatalogMaterialDto> CatalogMaterials { get; set; } = new List<CatalogMaterialDto>();
    }
}
