﻿using EntityFramework_Slider.Data;
using EntityFramework_Slider.Models;
using EntityFramework_Slider.Services.interfaces;
using Microsoft.EntityFrameworkCore;

namespace EntityFramework_Slider.Services
{
    public class ProductService : IProductService
    {

        private readonly AppDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public ProductService(AppDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<IEnumerable<Product>> GetAll() => await _context.Products.Include(m => m.Images).ToListAsync();
        

        public async Task<Product> GetById(int id) =>  await _context.Products.FindAsync(id);


        public async Task<Product> GetFullDataById(int id) =>  await _context.Products.Include(m => m.Images).Include(m => m.Category).FirstOrDefaultAsync(m => m.Id == id);
        
    }
}
