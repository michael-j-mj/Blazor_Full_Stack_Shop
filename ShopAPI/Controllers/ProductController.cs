﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopAPI.Extension;
using ShopAPI.Repositories.Contracts;
using ShopDTOModels.Dtos;

namespace ShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepositories _repo;
        public ProductController(IProductRepositories repo)
        {
            _repo = repo;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetItems()
        {
            try
            {
                var products = await _repo.GetItems(); 
                var ProductCategories = await _repo.GetCategories();
                if(products == null || ProductCategories == null)
                {
                    return NotFound();
                }
                else
                {
                    var productDtos = products.ConvertToDto(ProductCategories);
                    return Ok(productDtos);
                }
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error getting data"); 
            } 
         }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<ProductDto>> GetItem(int id)
        {
            try
            {
                var products = await _repo.GetItem(id);
            
                if (products == null )
                {
                    return BadRequest();
                }
                else
                {
                    var productCategory = await this._repo.GetCategory(products.CategoryId);
                    var productDtos = products.ConvertToDto(productCategory);
                    return Ok(productDtos);
                }
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error getting data");
            }
        }
    }
}
