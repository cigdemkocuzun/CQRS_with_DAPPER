﻿using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Albelli.Application.DTOs;
using Albelli.Application.Orders.Queries;
using Albelli.Application.CQRS.Orders.Command;

namespace Albelli.API.Orders
{
    [Route("api/customers")]
    [ApiController]
    public class CustomerOrdersController : Controller
    {
        private readonly IMediator _mediator;

        public CustomerOrdersController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        /// <summary>
        /// Get customer orders.
        /// </summary>
        /// <param name="customerId">Customer ID.</param>
        /// <returns>List of customer orders.</returns>
        [Route("{customerId}/orders")]
        [HttpGet]
        [ProducesResponseType(typeof(List<OrderDto>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetCustomerOrders(Guid customerId)
        {
            var orders = await _mediator.Send(new GetCustomerOrdersQuery(customerId));

            return Ok(orders);
        }


        /// <summary>
        /// Add customer order.
        /// </summary>
        /// <param name="customerId">Customer ID.</param>
        /// <param name="request">Products list.</param>
        [Route("{customerId}/orders")]
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<IActionResult> AddCustomerOrder(
            [FromRoute]Guid customerId, 
            [FromBody]CustomerOrderRequest request)
        {
        var customerOrder = await _mediator.Send(new PlaceCustomerOrderCommand(customerId, request.Products, request.Currency));

           return Created(string.Empty, customerOrder);
        }

        /// <summary>
        /// Change customer order.
        /// </summary>
        /// <param name="customerId">Customer ID.</param>
        /// <param name="orderId">Order ID.</param>
        /// <param name="request">List of products.</param>
        [Route("{customerId}/orders/{orderId}")]
        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> ChangeCustomerOrder(
            [FromRoute]Guid customerId, 
            [FromRoute]Guid orderId,
            [FromBody]CustomerOrderRequest request)
        {
            await _mediator.Send(new ChangeCustomerOrderCommand(customerId, orderId, request.Products, request.Currency));

            return Ok();
        }

        /// <summary>
        /// Remove customer order.
        /// </summary>
        /// <param name="customerId">Customer ID.</param>
        /// <param name="orderId">Order ID.</param>
        [Route("{customerId}/orders/{orderId}")]
        [HttpDelete]
        [ProducesResponseType(typeof(List<OrderDto>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> RemoveCustomerOrder(
            [FromRoute]Guid customerId,
            [FromRoute]Guid orderId)
        {
            await _mediator.Send(new RemoveCustomerOrderCommand(customerId, orderId));

            return Ok();
        }
    }
}
