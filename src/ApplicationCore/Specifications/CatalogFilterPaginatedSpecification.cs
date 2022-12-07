using Ardalis.Specification;
using Microsoft.eShopWeb.ApplicationCore.Entities;

namespace Microsoft.eShopWeb.ApplicationCore.Specifications
{
    public class CatalogFilterPaginatedSpecification : Specification<CatalogItem>
    {
        //Sprint 1 - Add an additional filter to the main page besides Brand and Type. - Leon Roth
        public CatalogFilterPaginatedSpecification(int skip, int take, int? brandId, int? typeId, int? materialId)
            : base()
        {
            if (take == 0)
            {
                take = int.MaxValue;
            }
            Query
                .Where
                (i => (!brandId.HasValue || i.CatalogBrandId == brandId) &&
                (!typeId.HasValue || i.CatalogTypeId == typeId) &&
                (!materialId.HasValue || i.CatalogMaterialId == materialId)
                )
                .Skip(skip).Take(take);
        }
    }
}
