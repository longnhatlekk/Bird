using BirdPlatForm.BirdPlatform;
using BirdPlatForm.Product;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.AccessControl;

namespace BirdPlatForm.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly BirdPlatFormContext _context;
        private readonly IHomeViewProductService _homeViewProductService;
        

        public ProductsController(BirdPlatFormContext context, IHomeViewProductService homeViewProductService)
        {
            _context = context;
            _homeViewProductService = homeViewProductService;
        }

        [HttpGet("BestSeller_Product")]
        public async Task<IActionResult> GetByQuantitySold()
        {
            var product = await _homeViewProductService.GetAllByQuantitySold();
            return Ok(product);
        }


        [HttpGet("Hot_Product")]
        public async Task<IActionResult> GetProductByRateAndQuantitySold()
        {
            {
                var product = await _homeViewProductService.GetProductByRateAndQuantitySold();
                return Ok(product);
            }

        }

        [HttpGet("Detail_Product")]
        public async Task<IActionResult> GetProductById(int id)
        {
                var product = await _homeViewProductService.GetProductById(id);
            if (product == null)
            
                return BadRequest("Cannot find product");
            
            return Ok(product);
            }

        }
    }

