using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.eShopWeb.Web.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Microsoft.eShopWeb.Web.Services
{
    public interface ICatalogViewModelService
    {
        Task<CatalogIndexViewModel> GetCatalogItems(int pageIndex, int itemsPage, int? brandId, int? typeId, int? materialId);
        Task<IEnumerable<SelectListItem>> GetBrands();
        Task<IEnumerable<SelectListItem>> GetTypes();

        //Sprint 1 - Add an additional filter to the main page besides Brand and Type. - Leon Roth
        Task<IEnumerable<SelectListItem>> GetMaterials();
    }
}
