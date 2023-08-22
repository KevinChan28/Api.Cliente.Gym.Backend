using Aplication.Client.API.DTO;
using Aplication.Client.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Aplication.Client.API.Controllers
{
    [EnableCors("Client")]
    [Route("[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProducts _products;

        public ProductsController(IProducts products)
        {
            _products = products;
        }


        /// <summary>
        /// Obtener catálogo de productos
        /// </summary>
        /// <param name=""></param>
        /// <returns>Arreglo de objetos con las propiedades Id y ProductName</returns>
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [AllowAnonymous]
        public async Task<IActionResult> GetCatalogProducts()
        {
            try
            {
                List<CatalogProducts> products = await _products.GetCatalogProducts();
                if (products != null)
                {
                    return Ok(products);
                }

                return NoContent();
            } 
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// Registrar entrada por producto
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        [HttpPost("sale")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [AllowAnonymous]
        public async Task<IActionResult> RegisterIncomeProduct([FromBody] ProductSale sellProduct)
        {
            try
            {
                if (sellProduct != null)
                {
                    int result = await _products.ProductSale(sellProduct);
                    if (result > 0)
                    {
                        return Ok();
                    }
                }

                return BadRequest();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
