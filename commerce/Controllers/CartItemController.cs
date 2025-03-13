using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using commerce.Models;
using commerce.Services;

namespace commerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartItemController : ControllerBase
    {
        private readonly ICartItemService _cartItemService;

        public CartItemController(ICartItemService cartItemService)
        {
            _cartItemService = cartItemService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CartItem>> GetCartItem(int id)
        {
            try
            {
                var cartItem = await _cartItemService.GetCartItemByIdAsync(id);
                if (cartItem == null)
                {
                    return NotFound();
                }
                return Ok(cartItem);
            }
            catch (Exception )
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("cart/{cartId}")]
        public async Task<ActionResult<IEnumerable<CartItem>>> GetCartItemsByCartId(int cartId)
        {
            try
            {
                var items = await _cartItemService.GetCartItemsByCartIdAsync(cartId);
                return Ok(items);
            }
            catch (Exception )
            {
                return StatusCode(500, "Internal server error");
            }
        }
        //total price 
        [HttpGet("cart/{cartId}/total")]
        public async Task<ActionResult<decimal>> GetTotalPriceByCartId(int cartId)
        {
            try
            {
                var totalPrice = await _cartItemService.GetTotalPriceByCartIdAsync(cartId);
                return Ok(new { TotalPrice = totalPrice });
            }
            catch (Exception )
            {
                // Log the exception
                return StatusCode(500, "Internal server error");
            }
        }
        //update data
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCartItem(int id, CartItem cartItem)
        {
            if (id != cartItem.CartItemId)
            {
                return BadRequest("CartItem ID mismatch.");
            }

            try
            {
                await _cartItemService.UpdateCartItemAsync(cartItem);
                return NoContent();
            }
            catch (Exception )
            {
                return StatusCode(500, "Internal server error");
            }
        }


        //inserting data
        //[HttpPost]
        //public async Task<IActionResult> AddCartItem(CartItem cartItem)
        //{
        //    try
        //    {
        //        await _cartItemService.AddCartItemAsync(cartItem);
        //        return CreatedAtAction(nameof(GetCartItem), new { id = cartItem.CartItemId }, cartItem);
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, "Internal server error");
        //    }
        //}
        [HttpPost]
        public async Task<IActionResult> AddCartItem(CartItemDto cartItemDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var cartItem = new CartItem
                {
                    CartId = cartItemDto.CartId,
                    ProductId = cartItemDto.ProductId,
                    Quantity = cartItemDto.Quantity
                };

                await _cartItemService.AddCartItemAsync(cartItem);
                return CreatedAtAction(nameof(GetCartItem), new { id = cartItem.CartItemId }, cartItem);
            }
            catch (Exception )
            {
                // Log the exception
                return StatusCode(500, "Internal server error");
            }
        }

        //delete data
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCartItem(int id)
        {
            try
            {
                await _cartItemService.DeleteCartItemAsync(id);
                return NoContent();
            }
            catch (Exception )
            {
                return StatusCode(500, "Internal server error");
            }
        }

    }
}