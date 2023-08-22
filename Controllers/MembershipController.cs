using System.Net;
using Aplication.Client.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Aplication.Client.API.DTO;
using Aplication.Client.API.Models;

namespace Aplication.Client.API.Controllers
{
    [EnableCors("Client")]
    [Route("[controller]")]
    [ApiController]
    public class MembershipController : ControllerBase
    {

        private readonly ISuscription _suscription;

        public MembershipController(ISuscription suscription)
        {
            _suscription = suscription;
        }

        /// <summary>
        /// Obtención de Membresias a Vencer
        /// </summary>
        /// <param name=""></param>
        /// <returns>Obtención de Membresias a Vencer</returns>
        [HttpGet("Expire")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [AllowAnonymous]
        public async Task<IActionResult> SuscriptionToExpire(DateTime dateExpire, int numberPage, int numberRecords, bool isAsc)
        {
            try
            {
                SuscriptionExpire suscriptionExpire = await _suscription.GetSuscriptionToExpire(dateExpire, numberPage, numberRecords, isAsc);
                if (suscriptionExpire != null)
                {
                    return Ok(suscriptionExpire);
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// Obtención de Membresias mediante el nombre de un usuario
        /// </summary>
        /// <param name=""></param>
        /// <returns>Obtención de Membresias mediante el nombre de un usuario</returns>
        [HttpGet("Expire/NameUser")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [AllowAnonymous]
        public async Task<IActionResult> GetSuscriptionToNameUser(String nameUser, int numberPage, int numberRecords, bool isAsc)
        {
            try
            {
                SuscriptionExpire suscriptionExpireToNameUser = await _suscription.GetSuscriptionToUser(nameUser,numberPage,numberRecords,isAsc);
                if (suscriptionExpireToNameUser != null)
                {
                    return Ok(suscriptionExpireToNameUser);
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
