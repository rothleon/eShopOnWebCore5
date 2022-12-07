using Ardalis.GuardClauses;
using Microsoft.eShopWeb.ApplicationCore.Interfaces;
using System;

namespace Microsoft.eShopWeb.ApplicationCore.Entities
{
    public class CatalogItem : BaseEntity, IAggregateRoot
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public string PictureUri { get; private set; }
        public int CatalogTypeId { get; private set; }
        public CatalogType CatalogType { get; private set; }
        public int CatalogBrandId { get; private set; }
        public CatalogBrand CatalogBrand { get; private set; }

        //Sprint 1 - Add a new attribute, like color or gender, to catalog items. - Leon Roth
        public int CatalogMaterialId { get; private set; }
        public CatalogMaterial CatalogMaterial { get; private set; }

        public CatalogItem(int catalogTypeId,
            int catalogBrandId,
         
            //Sprint 1 - Add a new attribute, like color or gender, to catalog items. - Leon Roth
            int catalogMaterialId,
            
            string description,
            string name,
            decimal price,
            string pictureUri)
        {
            CatalogTypeId = catalogTypeId;
            CatalogBrandId = catalogBrandId;

            //Sprint 1 - Add a new attribute, like color or gender, to catalog items. - Leon Roth
            CatalogMaterialId = catalogMaterialId;

            Description = description;
            Name = name;
            Price = price;
            PictureUri = pictureUri;
        }

        //Brute force material assignment
        public CatalogItem(int catalogTypeId,
            int catalogBrandId,

            //Sprint 1 - Add a new attribute, like color or gender, to catalog items. - Leon Roth
            int catalogMaterialId,

            string description,
            string name,
            decimal price,
            string pictureUri,
            CatalogMaterial catalogMaterial)
        {
            CatalogTypeId = catalogTypeId;
            CatalogBrandId = catalogBrandId;

            //Sprint 1 - Add a new attribute, like color or gender, to catalog items. - Leon Roth
            CatalogMaterialId = catalogMaterialId;

            Description = description;
            Name = name;
            Price = price;
            PictureUri = pictureUri;
            CatalogMaterial = catalogMaterial;
        }

        public void UpdateDetails(string name, string description, decimal price)
        {
            Guard.Against.NullOrEmpty(name, nameof(name));
            Guard.Against.NullOrEmpty(description, nameof(description));
            Guard.Against.NegativeOrZero(price, nameof(price));

            Name = name;
            Description = description;
            Price = price;
        }

        public void UpdateBrand(int catalogBrandId)
        {
            Guard.Against.Zero(catalogBrandId, nameof(catalogBrandId));
            CatalogBrandId = catalogBrandId;
        }

        //Sprint 1 - Add a new attribute, like color or gender, to catalog items. - Leon Roth
        public void UpdateMaterial(int catalogMaterialId)
        {
            Guard.Against.Zero(catalogMaterialId, nameof(catalogMaterialId));
            CatalogMaterialId = catalogMaterialId;
        }

        public void UpdateType(int catalogTypeId)
        {
            Guard.Against.Zero(catalogTypeId, nameof(catalogTypeId));
            CatalogTypeId = catalogTypeId;
        }

        public void UpdatePictureUri(string pictureName)
        {
            if (string.IsNullOrEmpty(pictureName))
            {
                PictureUri = string.Empty;
                return;
            }
            PictureUri = $"images\\products\\{pictureName}?{new DateTime().Ticks}";
        }
    }
}