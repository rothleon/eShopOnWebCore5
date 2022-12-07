using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.eShopWeb.ApplicationCore.Entities;
using Microsoft.eShopWeb.ApplicationCore.Interfaces;
using Swashbuckle.AspNetCore.Annotations;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.eShopWeb.PublicApi.CatalogMaterialEndpoints
{
    public class List : BaseAsyncEndpoint
        .WithoutRequest
        .WithResponse<ListCatalogMaterialsResponse>
    {
        private readonly IRepository<CatalogMaterial> _catalogMaterialRepository;
        private readonly IMapper _mapper;

        public List(IRepository<CatalogMaterial> catalogMaterialRepository,
            IMapper mapper)
        {
            _catalogMaterialRepository = catalogMaterialRepository;
            _mapper = mapper;
        }

        [HttpGet("api/catalog-materials")]
        [SwaggerOperation(
            Summary = "List Catalog Materials",
            Description = "List Catalog Materials",
            OperationId = "catalog-materials.List",
            Tags = new[] { "CatalogMaterialEndpoints" })
        ]
        public override async Task<ActionResult<ListCatalogMaterialsResponse>> HandleAsync(CancellationToken cancellationToken)
        {
            var response = new ListCatalogMaterialsResponse();

            var items = await _catalogMaterialRepository.ListAsync(cancellationToken);

            response.CatalogMaterials.AddRange(items.Select(_mapper.Map<CatalogMaterialDto>));

            return Ok(response);
        }
    }
}
