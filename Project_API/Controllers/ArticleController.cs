using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project_API.DTO;
using Project_API.Models;

namespace Project_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private readonly IMapper _mapper;
        private PRN_ProjectContext _context;

        public ArticleController(PRN_ProjectContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [Route("GetOrder")]
        [HttpGet]
        public IActionResult GetArticles()
        {
            List<Article> orders = _context.Articles.ToList();
            return Ok(_mapper.Map<List<ArticleDTO>>(orders));
        }
    }
}
