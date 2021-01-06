using AcademyApi.Data;
using Api.Resources.Category;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Api.Controllers
{
    [Route("category")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ApiDbContext _db;
        private readonly IMapper _mapper;
        public CategoryController(ApiDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var categories = _db.Categories.Include(x => x.Products);

            var categoryResource = _mapper.Map<IEnumerable<CategoryResource>>(categories);

            return Ok(categoryResource);
        }
    }
}
