using AcademyApi.Data;
using AcademyApi.Data.Entities;
using Api.Resources.Category;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            var categories = _db.Categories.Include(x => x.ProductCategories).ThenInclude(x => x.Product);

            var categoryResource = _mapper.Map<IEnumerable<CategoryResource>>(categories);

            return Ok(categoryResource);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryResource>> Get(int? id)
        {
            if (id == null) return NotFound();

            Category category = await _db.Categories.Include(x => x.ProductCategories)
                .ThenInclude(x => x.Product).FirstOrDefaultAsync(x => x.Id == id);

            if (category == null) return NotFound(new
            { message = "404 Not Found Oops…! You’re probably looking for something out here." });

            var categoryResource = _mapper.Map<CategoryResource>(category);

            return Ok(categoryResource);
        }

        [Route("post")]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateCategoryResource createCategory)
        {
            var category = _mapper.Map<CreateCategoryResource, Category>(createCategory);

            await _db.Categories.AddAsync(category);

            await _db.SaveChangesAsync();

            var categoryResource = _mapper.Map<Category, CategoryResource>(category);

            return Ok(categoryResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Post(int? id, [FromBody] UpdateCategoryResource updateCategory)
        {
            if (id == null) return NotFound(new
            { message = "404 Not Found Oops…! You’re probably looking for something out here." });

            var category = _mapper.Map<UpdateCategoryResource, Category>(updateCategory);

            await _db.SaveChangesAsync();

            var categoryResource = _mapper.Map<Category, CategoryResource>(category);

            return Ok(categoryResource);
        }
    }
}