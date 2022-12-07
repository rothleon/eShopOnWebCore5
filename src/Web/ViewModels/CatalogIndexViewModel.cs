using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Microsoft.eShopWeb.Web.ViewModels
{
    public class CatalogIndexViewModel
    {
        public List<CatalogItemViewModel> CatalogItems { get; set; }
        public List<SelectListItem> Brands { get; set; }
        public List<SelectListItem> Types { get; set; }

        //Sprint 1 - Add a new attribute, like color or gender, to catalog items. - Leon Roth
        public List<SelectListItem> Materials { get; set; }

        public int? BrandFilterApplied { get; set; }
        public int? TypesFilterApplied { get; set; }


        //Sprint 1 - Add a new attribute, like color or gender, to catalog items. - Leon Roth
        public int? MaterialsFilterApplied { get; set; }



        public PaginationInfoViewModel PaginationInfo { get; set; }
    }
}
