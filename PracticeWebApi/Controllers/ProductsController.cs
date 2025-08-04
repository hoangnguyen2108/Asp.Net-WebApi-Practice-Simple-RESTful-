using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PracticeWebApi.Data;
using PracticeWebApi.Dto;
using PracticeWebApi.Model;

namespace PracticeWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;


        public ProductsController(IMapper mapper,ApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetProducts()
        {
            var listProduct = await _context.Products.ToListAsync();
            var model = _mapper.Map<List<ProductDto>>(listProduct);
            return Ok(model);
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetProduct(int id)
        {
            var singleproduct = await _context.Products.FindAsync(id);
            var product = _mapper.Map<ProductDto>(singleproduct);
            return Ok(product);
        }

        //Create
        // PUT: api/Products/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, ProductDto product)
        {
            var model = await _context.Products.FindAsync(id);
            if(model == null)
            {
                return NotFound();
            }

            var fix = _mapper.Map(product,model);
            await _context.SaveChangesAsync();
            var update = _mapper.Map<ProductDto>(fix);
          
            return Ok(update);
        }

        // POST: api/Products
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProductDto>> PostProduct(ProductDto product)
        {
            var model = _mapper.Map<Product>(product);
            _context.Products.Add(model);
            await _context.SaveChangesAsync();
            var update = _mapper.Map<ProductDto>(model);

            return CreatedAtAction(nameof(GetProduct), new { id = model.Productid }, update);
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var singleproduct = await _context.Products.FindAsync(id);
            var product = _mapper.Map<Product>(singleproduct);

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        
    }
}
