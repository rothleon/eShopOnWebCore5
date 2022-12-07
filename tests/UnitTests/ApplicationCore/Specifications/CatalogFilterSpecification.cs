using Microsoft.eShopWeb.ApplicationCore.Entities;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Microsoft.eShopWeb.UnitTests.ApplicationCore.Specifications
{
    public class CatalogFilterSpecification
    {
        [Theory]
        [InlineData(null, null, 5, 0)]
        [InlineData(1, null, 3, 0)]
        [InlineData(2, null, 2, 0)]
        [InlineData(null, 1, 2, 0)]
        [InlineData(null, 3, 1, 0)]
        [InlineData(1, 3, 1, 0)]
        [InlineData(2, 3, 0, 0)]
        public void MatchesExpectedNumberOfItems(int? brandId, int? typeId, int? materialId, int expectedCount)
        {
            var spec = new eShopWeb.ApplicationCore.Specifications.CatalogFilterSpecification(brandId, typeId, materialId);

            var result = GetTestItemCollection()
                .AsQueryable()
                .Where(spec.WhereExpressions.FirstOrDefault());

            Assert.Equal(expectedCount, result.Count());
        }

        public List<CatalogItem> GetTestItemCollection()
        {
            return new List<CatalogItem>()
            {
                new CatalogItem(1, 1, 1, "Description", "Name", 0, "FakePath"),
                new CatalogItem(2, 1, 1, "Description", "Name", 0, "FakePath"),
                new CatalogItem(3, 1, 1, "Description", "Name", 0, "FakePath"),
                new CatalogItem(1, 2, 1, "Description", "Name", 0, "FakePath"),
                new CatalogItem(2, 2, 1, "Description", "Name", 0, "FakePath"),  
            };
        }
    }
}
