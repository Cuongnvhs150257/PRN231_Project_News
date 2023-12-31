﻿using AutoMapper;
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

        [Route("GetArticles")]
        [HttpGet]
        public IActionResult GetArticles()
        {
            List<Article> articles = _context.Articles.Include(x => x.User).Include(x => x.Categories).OrderByDescending(x => x.EditDate).ToList();
            return Ok(_mapper.Map<List<Article>>(articles));
        }

        [Route("GetArticle/{id}")]
        [HttpGet]
        public IActionResult GetArticleById(int id)
        {
            try
            {
                var articles = _context.Articles.Include(x => x.User).Include(x => x.Categories).FirstOrDefault(x => x.ArticleId == id);

                var dto = new ArticleDTO();

                dto.ArticleId = articles.ArticleId;
                dto.UserId = articles.User.UserId;
                dto.Title = articles.Title;
                dto.CreateDate = articles.CreateDate;
                dto.EditDate = articles.EditDate;
                dto.Content = articles.Content;
                dto.Summary = articles.Summary;
                dto.Img = articles.Img;

                foreach (var item in articles.Categories)
                {
                    dto.Categories = new List<CategoryDTO> {

                    new CategoryDTO {CategoryId = item.CategoryId, CategoryName = item.CategoryName, }
                };
                }
                return Ok(dto);
            }
            catch (Exception ex)
            {

                return Conflict(ex);
            }
        }

        [Route("GetArticleByTitle/{title}")]
        [HttpGet]
        public IActionResult GetArticleByTitle(string title)
        {
            try
            {
                List<Article> articles = _context.Articles.Include(x => x.User).Include(x => x.Categories).Where(x => x.Title.Contains(title)).ToList();

                return Ok(_mapper.Map<List<Article>>(articles));
            }
            catch (Exception ex)
            {

                return Conflict(ex);
            }
        }

        [HttpPost("CreateNews")]
        public IActionResult CreateNews(ArticleDTO article, int userId)
        {
            try
            {
                if (article == null || userId == null)
                {
                    return BadRequest();
                }

                var newArticle = new Article();
                newArticle.UserId = article.UserId;
                newArticle.Title = article.Title;
                newArticle.CreateDate = article.CreateDate;
                newArticle.EditDate = article.EditDate;
                newArticle.View = article.View;
                newArticle.UserId = userId;
                newArticle.Content = article.Content;
                newArticle.Summary = article.Summary;
                newArticle.Img = article.Img;

                var cates = article.Categories.Select(c => c.CategoryId).ToList();

                var listcates = _context.Categories.Where(x => cates.Contains(x.CategoryId)).ToList();

                foreach (var item in listcates)
                {
                    //var cate = _context.Categories.FirstOrDefault(x => x.CategoryId == item.CategoryId);

                    newArticle.Categories.Add(item);
                    item.Articles.Add(newArticle);
                }
                _context.Articles.Add(newArticle);
                var rowAffect = _context.SaveChanges();

                if (rowAffect == 0)
                {
                    return BadRequest();
                }

                return Ok(newArticle);
            }
            catch (Exception)
            {

                return Conflict();
            }
        }

        [HttpPut("EditNews")]
        public IActionResult EditNews(int articleId, ArticleDTO article, int userId)
        {
            try
            {
                if (articleId == null || article == null || userId == null)
                {
                    return BadRequest();
                }

                var existArticle = _context.Articles.Include(x => x.User).Include(x => x.Categories).FirstOrDefault(x => x.ArticleId == articleId);
                if(existArticle == null)
                {
                    return NotFound("Not found article! Flz check again!");
                }

                existArticle.Title = article.Title;
                existArticle.Content = article.Content;
                existArticle.CreateDate = article.CreateDate;
                existArticle.EditDate = DateTime.Now;
                existArticle.View = article.View;
                existArticle.Summary = article.Summary;
                existArticle.UserId = userId;
                existArticle.Img = article.Img;

                foreach (var cate in existArticle.Categories.ToList())
                {
                    existArticle.Categories.Remove(cate);
                }

                var cates = article.Categories.Select(c => c.CategoryId).ToList();

                var listcates = _context.Categories.Where(x => cates.Contains(x.CategoryId)).ToList();


                foreach (var item in listcates)
                {
                    //var cate = _context.Categories.FirstOrDefault(x => x.CategoryId == item.CategoryId);

                    existArticle.Categories.Add(item);
                    item.Articles.Add(existArticle);
                }
                _context.Articles.Update(existArticle);
                var rowAffect = _context.SaveChanges();

                if (rowAffect == 0)
                {
                    return BadRequest();
                }

                return Ok(existArticle);
            }
            catch (Exception)
            {

                return Conflict();
            }
        }

        [HttpDelete("DeleteArticle/{id}")]
        public async Task<IActionResult> DeleteArticle(int id)
        {
            try
            {
                var exsitNew = _context.Articles.Include(x => x.Categories).FirstOrDefault(x => x.ArticleId == id);
                if(exsitNew == null)
                {
                    return NotFound("Does not have article! Plz check again!");
                }

                foreach (var cate in exsitNew.Categories.ToList())
                {
                    exsitNew.Categories.Remove(cate);
                }

                _context.Articles.Remove(exsitNew);
                var rowAffected = _context.SaveChanges();
                return Ok(rowAffected);
            }
            catch (Exception)
            {

                return Conflict();
            }
        }

        [Route("GetArticleByCate/{cateId}")]
        [HttpGet]
        public IActionResult GetArticleByCateId(int cateId)
        {

            var listArticlesByCate = new List<Article>();

            var articles = _context.Articles.Include(x => x.User).Include(x => x.Categories).ToList();
            foreach (var article in articles)
            {
                foreach (var cate in article.Categories)
                {
                    if (cate.CategoryId == cateId)
                    {
                        listArticlesByCate.Add(article);
                    }
                }
            }

            return Ok(listArticlesByCate);
        }

    }

}
