using Aplication.Client.API.DTO;
using Aplication.Client.API.Models;
using Aplication.Client.API.Repository;
using Aplication.Client.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.Json.Serialization;

namespace Aplication.Client.API.Controllers
{
    [EnableCors("Client")]
    [Route("[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly ICustomer _customer;
        private readonly IManagerImage _managerImage;
        private readonly ITutor _tutor;
        private readonly IKinship _kinship;
        private readonly IAddress _address;

        public ClientController(ICustomer customer, IManagerImage managerImage, ITutor tutor, IKinship kinship, IAddress address)
        {
            _customer = customer;
            _managerImage = managerImage;
            _tutor = tutor;
            _kinship = kinship;
            _address = address;
        }


        /// <summary>
        /// Registro de un nuevo cliente
        /// </summary>
        /// <returns>Id del cliente</returns>
        /// <response code="200">El recurso se creó y ademas retornará el Id del cliente</response>
        /// <response code="400">Faltó algún dato en el request body.</response>
        /// <response code="500">Ha ocurrido un error durante la creación.</response>
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [AllowAnonymous]
        public async Task<IActionResult> RegisterNewGymClient([FromBody] CustomerRegister CustomerData)
        {
            try
            {
                if (CustomerData != null && CustomerData.IdentificationImage != null && CustomerData.LastName != null && CustomerData.Name != null)
                {
                    int customerId = await _customer.CustumerRegister(CustomerData);
                    if (customerId > 0)
                    {
                        return Ok(new { CustomerId = customerId });
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
        /// Obtener cliente por su ID
        /// </summary>
        /// <param name=""></param>
        /// <returns>Toda la informacion del cliente</returns>
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [AllowAnonymous]
        public async Task<IActionResult> GetCustomer(int customerId)
        {
            try
            {
                Customer customer = await _customer.GetCustomerById(customerId);

                if (customer != null)
                {
                    return Ok(customer);
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }


        /// <summary>
        /// Guardar imagen del cliente en el server
        /// </summary>
        /// <returns>Path Image</returns>
        /// <response code="200">El recurso se creó y ademas retornará el PathImage</response>
        /// <response code="500">Ha ocurrido un error durante la creación.</response>
        [HttpPost("image")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [AllowAnonymous]
        public async Task<IActionResult> SaveImage([FromBody] IdentificationImageData identificationImageData)
        {
            try
            {
                PathImageInformation pathImage = await _managerImage.SaveImage(identificationImageData);

                if (pathImage != null)
                {
                    return Ok(pathImage);
                }

                throw new IOException(pathImage.PathImage);
            }
            catch (IOException ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// Obtiene imagen del cliente en base 64
        /// </summary>
        /// <returns>Base 64 Image String</returns>
        /// <response code="200"> Retorna el base 64 de la imagen del cliente</response>
        /// <response code="500">Ha ocurrido un error a la hora de obtener la imagen.</response>
        [HttpPost("image/base64")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [AllowAnonymous]
        public async Task<IActionResult> GetImageBase64([FromBody] PathImageInformation pathImageInformation)
        {
            try
            {
                string imageBase64String = await _managerImage.GetImageToBase64(pathImageInformation.PathImage);

                if (imageBase64String != null)
                {
                    return Ok(new { ImageBase64String = imageBase64String });
                }

                throw new IOException(imageBase64String);
            }
            catch (IOException ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }


        /// <summary>
        /// Registro del tutor de el cliente
        /// </summary>
        /// <returns>Id del tutor</returns>
        /// <response code="200">El recurso se creó y ademas retornará el Id del tutor</response>
        /// <response code="400">Faltó algún dato en el request body.</response>
        /// <response code="500">Ha ocurrido un error durante la creación.</response>
        [HttpPost("tutor")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [AllowAnonymous]
        public async Task<IActionResult> RegisterNewGymTutor([FromBody] TutorRegister TutorData)
        {
            try
            {
                if (TutorData != null && TutorData.KinshipId > 0 && TutorData.Name != null && TutorData.LastName != null)
                {
                    int tutorId = await _tutor.TutorRegister(TutorData);
                    if (tutorId > 0)
                    {
                        return Ok(new { TutorId = tutorId });
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
        /// Obtener catálogo de los tipos de Relación Cliente-Tutor
        /// </summary>
        /// <param name=""></param>
        /// <returns>Arreglo de objetos con las propiedades Id y ProductName</returns>
        [HttpGet("tutor/kinship/catalog")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [AllowAnonymous]
        public async Task<IActionResult> GetKinshipsData()
        {
            try
            {
                List<Kinship> kinshipData = await _kinship.GetKinshipCatalog();
                if (kinshipData != null)
                {
                    return Ok(kinshipData);
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// Obtener direccion por el idAddres del cliente
        /// </summary>
        /// <param name=""></param>
        /// <returns>La direccion del cliente</returns>
        [HttpGet("address")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [AllowAnonymous]
        public async Task<IActionResult> GetAddress(int idAddress)
        {
            try
            {
                Address address = await _address.GetAddressByAddressId(idAddress);

                if (address != null)
                {
                    return Ok(address);
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// Actualizar datos del cliente
        /// </summary>
        /// <returns>Id del cliente actualizado</returns>
        /// <response code="200">El recurso se creó y ademas retornará el Id del cliente actualizado</response>
        /// <response code="400">Faltó algún dato en el request body.</response>
        /// <response code="500">Ha ocurrido un error durante la creación.</response>
        [HttpPost("update")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [AllowAnonymous]
        public async Task<IActionResult> UpdateDataCustomer([FromBody] CustomerUpdate customerUpdate)
        {
            try
            {
                if (customerUpdate != null && customerUpdate.Id > 0)
                {
                    int customerId = await _customer.UpdateDataOfCustomer(customerUpdate);
                    if (customerId > 0)
                    {
                        return Ok(new { CustomerId = customerId });
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
        /// Actualizar datos de la direccion
        /// </summary>
        /// <returns>Id del cliente actualizado</returns>
        /// <response code="200">El recurso se creó y ademas retornará el Id del cliente actualizado</response>
        /// <response code="400">Faltó algún dato en el request body.</response>
        /// <response code="500">Ha ocurrido un error durante la creación.</response>
        [HttpPost("updateAddress")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [AllowAnonymous]
        public async Task<IActionResult> UpdateDataAddress([FromBody] Address addressUpdate)
        {
            try
            {
                if (addressUpdate != null && addressUpdate.Id > 0)
                {
                    int addressId = await _address.UpdateAddress(addressUpdate);
                    if (addressId > 0)
                    {
                        return Ok(new { AddressId = addressId });
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
        /// Verifica si el email que se intenta registrar existe previamente
        /// </summary>
        /// <param name=""></param>
        /// <returns>Objeto con campo EmailExist</returns>
        [HttpGet("email/{email}/verify/exist")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [AllowAnonymous]
        public async Task<IActionResult> GetIfEmailExist(string email)
        {
            try
            {
                if (email != null)
                {
                    bool emailExist = await _customer.EmailExist(email);
                    return Ok(new ExistEmail { EmailExist = emailExist });
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
    

