using Ardalis.Specification;
using Microsoft.eShopWeb.ApplicationCore.Entities;

namespace Microsoft.eShopWeb.ApplicationCore.Specifications
{
    public class CatalogFilterSpecification : Specification<CatalogItem>
    {
        //Sprint 1 - Add an additional filter to the main page besides Brand and Type. - Leon Roth
        public CatalogFilterSpecification(int? brandId, int? typeId, int? materialId)
        {
            Query.Where(i => (!brandId.HasValue || i.CatalogBrandId == brandId) &&
                (!typeId.HasValue || i.CatalogTypeId == typeId) &&
                (!materialId.HasValue || i.CatalogMaterialId == materialId)
                );
        }
    }
}
