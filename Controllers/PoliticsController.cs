using Aplication.Client.API.DTO;
using Aplication.Client.API.Models;
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
    public class PoliticsController : ControllerBase
    {
        private readonly IPolitics _politics;
        private readonly ICustomerPolitics _customerPolitics;

        public PoliticsController(IPolitics politics, ICustomerPolitics customerPolitics)
        {
            _politics = politics;
            _customerPolitics = customerPolitics;   
        }

        /// <summary>
        /// Obtener politicas 
        /// </summary>
        /// <param name=""></param>
        /// <returns>Un objeto con las propiedades idPolitics, description y terminos y condiciones</returns>
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [AllowAnonymous]
        public async Task<IActionResult> GetPoliticsGymnasium()
        {
            try
            {
                PoliticsDTO politics = await _politics.GetPoliticsGymnasium();
                if (politics != null)
                {
                    return Ok(politics);
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// Guardar politicas aceptadas
        /// </summary>
        /// <returns></returns>
        /// <response code="200">El recurso se creó</response>
        /// <response code="400">Faltó algún dato en el request body.</response>
        /// <response code="500">Ha ocurrido un error durante la creación.</response>
        [HttpPost("accepted")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [AllowAnonymous]
        public async Task<IActionResult> SavePoliticsAccepted([FromBody] CustomerPoliticsSave customerPoliticsSave)
        {
            try
            {
                if (customerPoliticsSave != null)
                {
                    int result = await _customerPolitics.CustomerPoliticsSave(customerPoliticsSave);
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
