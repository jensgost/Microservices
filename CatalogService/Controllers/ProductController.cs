using Microsoft.AspNetCore.Mvc;
using CatalogService.Data;
using CatalogService.Models.Domain;
using CatalogService.Models.DTO;

namespace CatalogService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        public ProductController(CatalogServiceContext context)
        {
            Context = context;
        }
        private CatalogServiceContext Context { get; }

        [HttpPost]
        public IActionResult CreateProduct(CreateProductDto createCatalogProduct)
        {
            var catalogProduct = new ProductModel(
                createCatalogProduct.Id,
                createCatalogProduct.Name,
                createCatalogProduct.Description,
                createCatalogProduct.ImageUrl,
                createCatalogProduct.Price,
                createCatalogProduct.ArticleNumber
                //Slug.Slugify(createCatalogProduct.Name)
                );

            Context.Add(catalogProduct);
            Context.SaveChanges();

            return NoContent(); // generates 204 no content
        }

        [HttpGet]
        public IEnumerable<CatalogProductDto> GetAll()
        {
            var catalogProductDtos = Context.Products.Select(y => new CatalogProductDto
            {
                Id = y.Id,
                Name = y.Name,
                Description = y.Description,
                ImageUrl = y.ImageUrl,
                Price = y.Price,
                ArticleNumber = y.ArticleNumber,
                //UrlSlug = y.UrlSlug
            });

            return (catalogProductDtos);
        }
    }
    public class CatalogProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public double Price { get; set; }
        public string ArticleNumber { get; set; }
        //public string UrlSlug { get; set; }
    }
 }
