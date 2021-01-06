using AcademyApi.Data;
using Api.Resources.Product;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Api.Controllers
{
    [ApiController]
    [Route("product")]
    public class ProductController : ControllerBase
    {
        private readonly ApiDbContext _db;
        private readonly IMapper _mapper;
        public ProductController(ApiDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var products = _db.Products.ToList();

            var productResource = _mapper.Map<IEnumerable<ProductResource>>(products);

            return Ok(productResource);
        }
    }
}
