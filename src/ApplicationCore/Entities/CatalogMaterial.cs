using Microsoft.eShopWeb.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.eShopWeb.ApplicationCore.Entities
{
    public class CatalogMaterial : BaseEntity, IAggregateRoot
    {
        //Sprint 1 - Add a new attribute, like color or gender, to catalog items. - Leon Roth
        public string Material { get; private set; }
        public CatalogMaterial(string material)
        {
            Material = material;
        }
        public override string ToString()
        {
            return Material;
        }
    
    
    
    }

  
}
