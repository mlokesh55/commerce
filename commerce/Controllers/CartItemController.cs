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

        [HttpPost]
        public async Task<IActionResult> AddCartItem(CartItem cartItem)
        {
            try
            {
                await _cartItemService.AddCartItemAsync(cartItem);
                return CreatedAtAction(nameof(GetCartItem), new { id = cartItem.CartItemId }, cartItem);
            }
            catch (Exception ex)
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
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
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
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

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
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCartItem(int id)
        {
            try
            {
                await _cartItemService.DeleteCartItemAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }
    }
}