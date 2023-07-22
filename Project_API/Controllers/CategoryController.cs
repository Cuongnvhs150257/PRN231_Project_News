using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project_API.DTO;
using Project_API.Models;

namespace Project_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {

        private readonly IMapper _mapper;
        private PRN_ProjectContext _context;

        public CategoryController(IMapper mapper, PRN_ProjectContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        [Route("GetAllCategory")]
        [HttpGet]
        public IActionResult GetAllCate()
        {
            List<Category> listCate = _context.Categories.ToList();

            return Ok(listCate);
        }

        [Route("GetCategoryById/Id")]
        [HttpGet]
        public IActionResult GetCateByName(int id)
        {
            List<Category> listCate = _context.Categories.Where(c => c.CategoryId == id).ToList();

            return Ok(listCate);
        }

        [Route("GetCategoryByName/name")]
        [HttpGet]
        public IActionResult GetCateByName(string name)
        {
            List<Category> listCate = _context.Categories.Where(c => c.CategoryName.Contains(name)).ToList();

            return Ok(listCate);
        }

        [Route("CreateCate")]
        [HttpPost]
        public IActionResult CreateCate(string cateName) 
        {
            var newCate = new Category();
            try
            {
                if (cateName == null)
                {
                    return BadRequest();
                }

                
                newCate.CategoryName = cateName;
                _context.Categories.Add(newCate);
                var rowAffect = _context.SaveChanges();

                if (rowAffect == 0)
                {
                    return BadRequest();
                }

                return Ok(newCate);

            }
            catch (Exception)
            {

                return Conflict();
            }

            return Ok(newCate);
        }

       
        [Route("DeleteCate/id")]
        [HttpDelete]
        public async Task<IActionResult> DeleteCate(int id)
        {
            try
            {
                var exsitCate = _context.Categories.FirstOrDefault(x => x.CategoryId == id);
                if (exsitCate == null)
                {
                    return NotFound("Does not have category ! Plz check again!");
                }           

                _context.Categories.Remove(exsitCate);
                var rowAffected = _context.SaveChanges();
                return Ok(rowAffected);
            }
            catch (Exception)
            {

                return Conflict();
            }
        }

        [Route("EditCate")]
        [HttpPut]
        public async Task<IActionResult> EditCate(int cateid, CategoryDTO category)
        {
            try
            {
                var exsitCate = _context.Categories.FirstOrDefault(x => x.CategoryId == cateid);
                if (exsitCate == null)
                {
                    return NotFound("Category not Found ! Plz check again!");
                }

                exsitCate.CategoryName = category.CategoryName;
                _context.Categories.Update(exsitCate);
                var rowAffected = _context.SaveChanges();
                return Ok(exsitCate);
            }
            catch (Exception)
            {

                return Conflict();
            }
        }

    }
}
