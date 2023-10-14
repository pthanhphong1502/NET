using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectManagementAPI.Dtos;
using ProjectManagementAPI.Repository.Interface;

namespace ProjectManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProduct _productRepository;

        public ProductController(IProduct productRepository)
        {
            _productRepository = productRepository;
        }

        [AllowAnonymous]
        [HttpGet("GetAllProducts")]
        public async Task<ActionResult> GetAllProducts()
        {
            try
            {
                return Ok(await _productRepository.GetAllProductAsync());
            }
            catch
            {
                return BadRequest();
            }
        }

        [AllowAnonymous]
        [HttpGet("GetBy{id}")]
        public async Task<ActionResult> GetProductById(int id)
        {
            var posts = await _productRepository.GetProductAsync(id);
            return posts == null ? NotFound() : Ok(posts);

        }
        [HttpPost("AddProduct")]
        public async Task<ActionResult> AddNewProduct(ProductDto model)
        {
            var newPost = await _productRepository.AddProductAsync(model);
            var posts = await _productRepository.GetProductAsync(newPost);
            return posts == null ? NotFound() : Ok(posts);
        }
        [HttpPut("UpdateProduct{id}")]
        public async Task<IActionResult> UpdatePost(int id, ProductDto model)
        {
            if (id != model.ProductId)
            {
                return NotFound();
            }
            await _productRepository.UpdateProductAsync(id, model);
            return Ok();
        }
        [HttpDelete("DeleteBy{id}")]
        public async Task<IActionResult> DeletePost(int id)
        {
            var post = await _productRepository.GetProductAsync(id);

            if (post == null)
            {
                return NotFound();
            }
            await _productRepository.DeleteProductAsync(id);
            return Ok();
        }
    }
}
