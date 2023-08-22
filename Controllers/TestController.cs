using Aplication.Client.API.DTO;
using Aplication.Client.API.Models;
using Aplication.Client.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using System.Net;

namespace Aplication.Client.API.Controllers
{
    [EnableCors("Client")]
    [Route("[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly ICustomerAnswerTest _customerAnswerTest;
        private readonly IAnswerTestHealth _answerTestHealth;

        public TestController(ICustomerAnswerTest customerAnswerTest, IAnswerTestHealth AnswerTestHealth)
        {
            _customerAnswerTest = customerAnswerTest;
            _answerTestHealth = AnswerTestHealth;

        }

        /// <summary>
        /// Guardar las respuestas del cliente del test de salud
        /// </summary>
        /// <returns>Id del test</returns>
        /// <response code="200">El recurso o los recursos se crearon</response>
        /// <response code="400">Faltó algún dato en el request body.</response>
        /// <response code="500">Ha ocurrido un error durante la creación.</response>
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [AllowAnonymous]
        public async Task<IActionResult> SaveAnswerTest([FromBody] CustomerAnswerTestRegister CustomerAnswerTestRegister)
        {
            try
            {
                if (CustomerAnswerTestRegister != null && CustomerAnswerTestRegister.TestId > 0 && CustomerAnswerTestRegister.CustomerId > 0
                      && CustomerAnswerTestRegister.QuestionsAnswereds != null)
                {
                    int customerAnswerTestId = await _customerAnswerTest.CostumerAnswerTest(CustomerAnswerTestRegister);
                    if (customerAnswerTestId > 0)
                    {
                        return Ok();
                    }
                }
                return BadRequest();

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }


        /// <summary>
        /// Obtener las Respuestas del Test
        /// </summary>
        /// <param name=""></param>
        /// <returns>Lista de las respuestas del Test de salud</returns>
        [HttpGet("Answer")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [AllowAnonymous]
        public async Task<IActionResult> GetAnswerTestHealth()
        {
            try
            {
                TestDTO question = await _answerTestHealth.GetAnswerTestHealth();
                if (question != null)
                {
                    return Ok(question);
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
