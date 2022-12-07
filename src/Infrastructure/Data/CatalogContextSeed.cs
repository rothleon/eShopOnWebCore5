using Microsoft.EntityFrameworkCore;
using Microsoft.eShopWeb.ApplicationCore.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Microsoft.eShopWeb.Infrastructure.Data
{
    public class CatalogContextSeed
    {
        public static async Task SeedAsync(CatalogContext catalogContext,
            ILoggerFactory loggerFactory, int retry = 0)
        {
            var retryForAvailability = retry;
            try
            {
                if (catalogContext.Database.IsSqlServer())
                {
                    catalogContext.Database.Migrate();
                }

                if (!await catalogContext.CatalogBrands.AnyAsync())
                {
                    await catalogContext.CatalogBrands.AddRangeAsync(
                        GetPreconfiguredCatalogBrands());

                    await catalogContext.SaveChangesAsync();
                }

                if (!await catalogContext.CatalogTypes.AnyAsync())
                {
                    await catalogContext.CatalogTypes.AddRangeAsync(
                        GetPreconfiguredCatalogTypes());

                    await catalogContext.SaveChangesAsync();
                }

                if (!await catalogContext.CatalogItems.AnyAsync())
                {
                    await catalogContext.CatalogItems.AddRangeAsync(
                        GetPreconfiguredItems());

                    await catalogContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                if (retryForAvailability >= 10) throw;

                retryForAvailability++;
                var log = loggerFactory.CreateLogger<CatalogContextSeed>();
                log.LogError(ex.Message);
                await SeedAsync(catalogContext, loggerFactory, retryForAvailability);
                throw;
            }
        }

        //Sprint 1 - Replace the items in the catalog with items from another vendor. - Leon Roth

        static IEnumerable<CatalogBrand> GetPreconfiguredCatalogBrands()
        {
            return new List<CatalogBrand>
            {
                new("Bear"),
                new("Deer"),
                new("Giraffe"),
                new("Gorilla"),
                new("Sloth")
            };
        }

        /*
        static IEnumerable<CatalogBrand> GetPreconfiguredCatalogBrands()
        {
            return new List<CatalogBrand>
            {
                new("Azure"),
                new(".NET"),
                new("Visual Studio"),
                new("SQL Server"),
                new("Other")
            };
        }
        */

        //Sprint 1 - Replace the items in the catalog with items from another vendor. - Leon Roth


        static IEnumerable<CatalogType> GetPreconfiguredCatalogTypes()
        {
            return new List<CatalogType>
            {
                new("Drinkware"),
                new("Apparel"),
                new("Ornament"),
                new("Plush")
            };
        }

        /*
        static IEnumerable<CatalogType> GetPreconfiguredCatalogTypes()
        {
            return new List<CatalogType>
            {
                new("Mug"),
                new("T-Shirt"),
                new("Sheet"),
                new("USB Memory Stick")
            };
        }
        */

        //Sprint 1 - Replace the items in the catalog with items from another vendor. - Leon Roth

        static IEnumerable<CatalogItem> GetPreconfiguredItems()
        {
            return new List<CatalogItem>
            {
                new(1,1, "Floral Bear Tumbler", "Floral Bear Tumbler", 29.99M,  "http://catalogbaseurltobereplaced/images/products/floralbeartumbler.png"),
                new(3,1, "Wood Black Bear Ornament", "Wood Black Bear Ornament", 11.99M, "http://catalogbaseurltobereplaced/images/products/blackbearornament.png"),
                new(4,1, "Black Bear Plush", "Black Bear Plush", 24.99M,  "http://catalogbaseurltobereplaced/images/products/blackbearplush.png"),
                new(2,2, "Adult Pudu T-shirt", "Adult Pudu T-shirt", 24.99M, "http://catalogbaseurltobereplaced/images/products/puduadultshirt.png"),
                new(4,2, "Fawn Plush", "Fawn Plush", 24.99M, "http://catalogbaseurltobereplaced/images/products/fawnplush.png"),
                new(3,3, "Wood Giraffe Ornament", "Wood Giraffe Ornament", 11.99M, "http://catalogbaseurltobereplaced/images/products/giraffeornament.png"),
                new(2,3, "Giraffe Umbrella Hat", "Giraffe Umbrella Hat",  9.99M, "http://catalogbaseurltobereplaced/images/products/giraffeumbrellahat.png"),
                new(4,3, "Safari Giraffe Plush", "Safari Giraffe Plush", 14.99M, "http://catalogbaseurltobereplaced/images/products/safarigiraffeplush.png"),
                new(4,4, "Gorilla Mom And Baby Plush", "Gorilla Mom And Baby Plush", 36.99M, "http://catalogbaseurltobereplaced/images/products/gorillamomandbabyplush.png"),
                new(1,4, "Gorilla Shot Glass", "Gorilla Shot Glass", 8.99M, "http://catalogbaseurltobereplaced/images/products/gorillashotglass.png"),
                new(3,5, "Wood Sloth Ornament", "Wood Sloth Ornament", 11.99M, "http://catalogbaseurltobereplaced/images/products/slothornament.png"),
                new(4,5, "Hanging Sloth Plush", "Hanging Sloth Plush", 24.99M, "http://catalogbaseurltobereplaced/images/products/hangingslothplush.png")
            };
        }

        /*
        static IEnumerable<CatalogItem> GetPreconfiguredItems()
        {
            return new List<CatalogItem>
            {
                new(2,2, ".NET Bot Black Sweatshirt", ".NET Bot Black Sweatshirt", 19.5M,  "http://catalogbaseurltobereplaced/images/products/1.png"),
                new(1,2, ".NET Black & White Mug", ".NET Black & White Mug", 8.50M, "http://catalogbaseurltobereplaced/images/products/2.png"),
                new(2,5, "Prism White T-Shirt", "Prism White T-Shirt", 12,  "http://catalogbaseurltobereplaced/images/products/3.png"),
                new(2,2, ".NET Foundation Sweatshirt", ".NET Foundation Sweatshirt", 12, "http://catalogbaseurltobereplaced/images/products/4.png"),
                new(3,5, "Roslyn Red Sheet", "Roslyn Red Sheet", 8.5M, "http://catalogbaseurltobereplaced/images/products/5.png"),
                new(2,2, ".NET Blue Sweatshirt", ".NET Blue Sweatshirt", 12, "http://catalogbaseurltobereplaced/images/products/6.png"),
                new(2,5, "Roslyn Red T-Shirt", "Roslyn Red T-Shirt",  12, "http://catalogbaseurltobereplaced/images/products/7.png"),
                new(2,5, "Kudu Purple Sweatshirt", "Kudu Purple Sweatshirt", 8.5M, "http://catalogbaseurltobereplaced/images/products/8.png"),
                new(1,5, "Cup<T> White Mug", "Cup<T> White Mug", 12, "http://catalogbaseurltobereplaced/images/products/9.png"),
                new(3,2, ".NET Foundation Sheet", ".NET Foundation Sheet", 12, "http://catalogbaseurltobereplaced/images/products/10.png"),
                new(3,2, "Cup<T> Sheet", "Cup<T> Sheet", 8.5M, "http://catalogbaseurltobereplaced/images/products/11.png"),
                new(2,5, "Prism White TShirt", "Prism White TShirt", 12, "http://catalogbaseurltobereplaced/images/products/12.png")
            };
        }
        */
    }
}
