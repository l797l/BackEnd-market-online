using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication2.DBContext.Modules;

namespace WebApplication2.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        readonly AppDBContext _appDbContext;

        public ProductController(AppDBContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpGet("ReutrnAllProduct")]
        public async Task<IActionResult> AllProduct()
        {
            var AllProduct = await _appDbContext.Product.ToListAsync();
            var AllImg = await _appDbContext.ImgProduct.ToListAsync();
            List<FullProductDto> productDto = new List<FullProductDto>();

            foreach (var product in AllProduct)
            {
                productDto.Add(new FullProductDto
                {
                    Id = product.Id,
                    Name = product.Name,
                    Price = product.Price,
                    Description = product.Description,
                    DataTime = product.DateTime,
                    ImageUrl = AllImg
                        .Where(x => x.ProductId == product.Id)
                        .Select(x => x.LinkImg)
                        .ToList()
                });

            }

            return Ok(productDto);
        }

        [HttpPost("AddProduct")]
        public async Task<IActionResult> AddProduct([FromForm] ProductDto productDto)
        {
            if (productDto.Name == null || productDto.Name.Length == 0 ||
                productDto.Price == null || productDto.Image == null)
            {
                return BadRequest("Is Empty");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var Product = new Product
            {
                Name = productDto.Name,
                Price = productDto.Price,
            };
            await _appDbContext.Product.AddAsync(Product);
            await _appDbContext.SaveChangesAsync();

            var urls = new List<string>();

            foreach (var img in productDto.Image)
            {
                if (img == null || img.Length == 0)
                    continue;

                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(img.FileName);

                var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images");

                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }

                var filePath = Path.Combine(uploadsFolder, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await img.CopyToAsync(stream);
                }

                var url = $"{Request.Scheme}://{Request.Host}/images/{fileName}";
                urls.Add(url);
            }


            foreach (var url in urls)
            {
                var Img = new ImgProduct
                {
                    ProductId = Product.Id,
                    LinkImg = url
                };
                await _appDbContext.ImgProduct.AddAsync(Img);
            }

            await _appDbContext.SaveChangesAsync();


            return Created();

        }

        [HttpDelete("DeleteProduct")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _appDbContext.Product.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            _appDbContext.Product.Remove(product);
            var ImgToProduct = _appDbContext.ImgProduct.Where(x => x.ProductId == id).ToList();
            foreach (var img in ImgToProduct)
            {
                var filePath = Path.Combine(
                    Directory.GetCurrentDirectory(),
                    "wwwroot",
                    img.LinkImg.TrimStart('/')
                );

                if (System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath);
                }
            }

            await _appDbContext.SaveChangesAsync();
            return Ok();
        }
    }
}
