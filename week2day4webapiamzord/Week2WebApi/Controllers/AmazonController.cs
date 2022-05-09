using BusinessLayer21;
using DomainLayer21;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Week2WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AmazonController : ControllerBase
    {

        private readonly ILogger<AmazonController> _logger;
        private readonly IOrdertbBusiness _ordertbBusiness;

        public AmazonController(ILogger<AmazonController> logger, IOrdertbBusiness ordertbBusiness)
        {
            _logger = logger;
            _ordertbBusiness = ordertbBusiness;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json", Type = typeof(IEnumerable<Amazontb>))]   
        [Route("get-allAmazonCountries")]
        public async Task<ActionResult<IEnumerable<Amazontb>>> GetAll()
        {
            try
            {
                var resp = await _ordertbBusiness.GetAllAmazonCountries();

                if (resp == null || resp.Count == 0)
                {
                    return StatusCode(404, "No Data available.");
                }
                return Ok(resp);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json", Type = typeof(Amazontb))]
        [Route("getAmazonCountry-byId")]
        public async Task<ActionResult<Amazontb>> GetAmazonCountryById(int id)
        {
            try
            {
                var resp = await _ordertbBusiness.GetAmazonCountryById(id);

                if (resp == null)
                {
                    return StatusCode(404, "No Data available.");
                }
                return Ok(resp);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Route("insert-AmazonCountry")]
        public async Task<ActionResult> InsertAmazonCountry([FromBody] Amazontb amazontb)
        {
            try
            {
                await _ordertbBusiness.InsertAmazonCountry(amazontb);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Route("update-AmazonCountry")]
        public async Task<ActionResult> UpdateAmazonCountry([FromBody] Amazontb amazontb)
        {
            try
            {
                await _ordertbBusiness.UpdateAmazonCountry(amazontb);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Route("delete-AmazonCountryById")]
        public async Task<ActionResult> DeleteAmazonCountry(int id)
        {
            try
            {
                await _ordertbBusiness.DeleteAmazonCountryById(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


    }
}



