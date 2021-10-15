using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Week4.NaimaElKhattabi.CORE.Interfaces;
using Week4.NaimaElKhattabi.CORE.Models;

namespace Week4.NaimaElKhattabi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMainBL mainBusinessLayer;

        public OrderController(IMainBL mainBusinessLayer)
        {
            this.mainBusinessLayer = mainBusinessLayer;
        }


        // GET: api/Order
        [HttpGet]
        public IActionResult GetOrders()
        {
            var orders = mainBusinessLayer.FetchOrders();
            return Ok(orders);
        }

        // GET api/Order/5
        [HttpGet("{id}")]
        public IActionResult GetOrderBy(int id)
        {
            if (id <= 0)
                return BadRequest("Id non valido");

            Order order = mainBusinessLayer.GetOrderById(id);

            if (order == null)
            {
                return NotFound("Order not found");
            }

            return Ok(order);
        }

        // POST api/order
        [HttpPost]
        public IActionResult PostOrder([FromBody] Order newOrder)
        {
            if (newOrder == null)
                return BadRequest("Dati ordine non validi");

            bool isAdded = mainBusinessLayer.CreateOrder(newOrder);

            if (!isAdded)
                return StatusCode(500, "Ordine could not be saved");

            return CreatedAtAction("PostOrder", newOrder);
        }

        // PUT api/Order/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Order order)
        {
            if (id <= 0 || order == null)
                return BadRequest("Ordine non valido"); 

            if (id != order.Id)
                return BadRequest("Gli id non combaciano");

            //update
            mainBusinessLayer.EditOrder(order);

            return Ok(order);
        }

        // DELETE api/order/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id <= 0)
                return BadRequest("Id non valido");

            Order order = mainBusinessLayer.GetOrderById(id);
            if (order == null)
                return BadRequest("Ordine non esistente");

            bool isAdded = mainBusinessLayer.DeleteOrder(order);

            if (!isAdded)
                return StatusCode(500, "Book could not be deleted");

            return Ok();
        }
    }
}
