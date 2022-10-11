using CleanArquitecture.Domain.Entities;
using CleanArquitecture.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClearArquitecture.Api.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class ProductController : ControllerBase
    {

        private readonly IProductRepository _productRepository;


        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }



        /// <summary>
        /// This Method return the list of products
        /// </summary>
        /// <returns> All </returns>
        /// <response code = "200">This code show you get alls products</response>
        /// <response code = "400">This code show you not found</response>
        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<Product>>> GetAllAsync()
        {

            await _productRepository.GetAll();

            return Ok();
        }



        /// <summary>
        /// This Method return the product By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns> Id </returns>
        /// <response code = "200">This code show you product by Id</response>
        /// <response code = "204">This code show you product not found</response>
        /// <response code = "500">This code show error in the request or fail in the codification</response>
        [HttpGet("GetById/{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Product>> GetByIdAsync(int id)
        {

            var productById = await _productRepository.GetById(id);

            return Ok(productById);
        }



        /// <summary>
        /// This Method add a new product
        /// </summary>
        /// <param name="product"></param>
        /// <returns> Product </returns>
        /// <response code = "201">This code show you added a product</response>
        /// <response code = "400">This code show you bad request </response>
        /// <response code = "404">This code show you not found </response>        
        /// <response code = "500">This code show error in the request or fail in the codification</response>
        [HttpPost("Add")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> PostAsync(Product product)
        {
            await _productRepository.Insert(product);
            await _productRepository.SaveAsync();

            return Ok(product);
        }



        /// <summary>
        /// This Method update a product
        /// </summary>
        /// <param name="product"></param>
        /// <returns> Product </returns>
        /// <response code = "201">This code show you updated product</response>
        /// <response code = "400">This code show you bad request </response>
        /// <response code = "500">This code show error in the request or fail in the codification</response>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> UpdateAsync(Product product) 
        {
            await _productRepository.Update(product);
            await _productRepository.Save();

            return Ok();
        }



        /// <summary>
        /// This Method delete a product
        /// </summary>
        /// <param name="id"></param>
        /// <returns> Id </returns>
        /// <response code = "201">This code show you deleted product</response>
        /// <response code = "500">This code show error in the request or fail in the codification</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var productFound = _productRepository.GetById(id);

            await _productRepository.Delete(productFound);
            await _productRepository.Save();

            return Ok();
        }
    }
}
