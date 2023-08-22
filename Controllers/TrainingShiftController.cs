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
    public class TrainingShiftController : ControllerBase
    {
        private readonly ITrainingShift _trainingShift;

        public TrainingShiftController(ITrainingShift trainingShift)
        {
           _trainingShift = trainingShift;
        }

        /// <summary>
        /// Obtener catálogo de turnos
        /// </summary>
        /// <param name=""></param>
        /// <returns>Arreglo de objetos con las propiedades Id y Description</returns>
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [AllowAnonymous]
        public async Task<IActionResult> GetTrainingShifts()
        {
            try
            {
                List<TrainingShift> trainingShifts = await _trainingShift.GetTrainingShifts();
                if (trainingShifts != null)
                {
                    return Ok(trainingShifts);
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
