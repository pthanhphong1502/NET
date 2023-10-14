using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using ProjectManagementAPI.Dtos;
using ProjectManagementAPI.Models;
using ProjectManagementAPI.Repository.Interface;

namespace ProjectManagementAPI.Repository
{
    public class ProductRepo : IProduct
    {
        private readonly MyDbContext _context;
        private readonly IMapper _mapper;

        public ProductRepo(MyDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }
        public async Task<int> AddProductAsync(ProductDto model)
        {
            var newProduct = _mapper.Map<Product>(model);
            _context.Products.Add(newProduct);
            await _context.SaveChangesAsync();
            return newProduct.ProductId;
        }

        public async Task DeleteProductAsync(int id)
        {
            var deleteProduct = _context.Products.SingleOrDefault(x => x.ProductId == id);
            if (deleteProduct != null)
            {
                _context.Products.Remove(deleteProduct);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<ProductDto>> GetAllProductAsync()
        {
            var products = await _context.Products.ToListAsync();
            return _mapper.Map<List<ProductDto>>(products);
        }

        public async Task<ProductDto> GetProductAsync(int id)
        {
            var products = await _context.Products.FindAsync(id);
            return _mapper.Map<ProductDto>(products);
        }

        public async Task UpdateProductAsync(int id, ProductDto model)
        {
            if (id == model.ProductId)
            {
                var updateProduct = _mapper.Map<Product>(model);
                _context.Products.Update(updateProduct);
                await _context.SaveChangesAsync();
            }
        }
    }
}
