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
    public class OrderController : ControllerBase
    {

        private readonly ILogger<OrderController> _logger;
        private readonly IOrdertbBusiness _ordertbBusiness;

        public OrderController(ILogger<OrderController> logger, IOrdertbBusiness ordertbBusiness)
        {
            _logger = logger;
            _ordertbBusiness = ordertbBusiness;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json", Type = typeof(IEnumerable<Orderstb>))]
        [Route("get-allOrders")]
        public async Task<ActionResult<IEnumerable<Orderstb>>> GetAll()
        {
            try
            {
                var resp = await _ordertbBusiness.GetAllOrders();

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
        [Produces("application/json", Type = typeof(Orderstb))]
        [Route("getOrder-byId")]
        public async Task<ActionResult<Orderstb>> GetOrderById(int id)
        {
            try
            {
                var resp = await _ordertbBusiness.GetOrderById(id);

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
        [Route("insert-Order")]
        public async Task<ActionResult> InsertAmazonCountry([FromBody] Orderstb orderstb)
        {
            try
            {
                await _ordertbBusiness.InsertOrder(orderstb);
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
        [Route("update-Order")]
        public async Task<ActionResult> UpdateEmployee([FromBody] Orderstb orderstb)
        {
            try
            {
                await _ordertbBusiness.UpdateOrder(orderstb);
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
        [Route("delete-OrderById")]
        public async Task<ActionResult> DeleteAmazonCountry(int id)
        {
            try
            {
                await _ordertbBusiness.DeleteOrderById(id);
                return Ok();
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
        [Produces("application/json", Type = typeof(IEnumerable<Orderstb>))]
        [Route("get-all-orders-by-CreatedTime")]
        public async Task<ActionResult<List<Orderstb>>> GetAllOrdersByCreatedDate(DateTime d)
        {
            try
            { 

                var resp = await _ordertbBusiness.GetAllOrdersByCreatedDate(d);

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
        [Produces("application/json", Type = typeof(IEnumerable<Orderstb>))]
        [Route("get-all-usernames")]
        public async Task<ActionResult<double>> GetAllUserNames()
        {
            try
            {

                var resp = await _ordertbBusiness.GetAllUserNames();

                return Ok(resp);


            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

    }
}



