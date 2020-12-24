using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GlassValley.Model;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;
using GlassValley.Attributes;

namespace GlassValley.Controllers
{
    /// <summary>
    /// Item routing controller
    /// </summary>
    [Route("[controller]")]
    public class ItemsController : Controller
    {
        private readonly ItemsContext _itemContext;

        public ItemsController(ItemsContext itemContext)
        {
            _itemContext = itemContext;
        }

        /// <summary>
        /// List all the item
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetItems()
        {
            var itemList = await _itemContext.Items.ToListAsync();
            return Ok(itemList);
        }


        /// <summary>
        /// Add new item
        /// </summary>
        /// <param name="itemCreateRequest"></param>
        /// <returns></returns>
        [HttpPost]
        [ModelStateFilter]
        public async Task<IActionResult> AddItem([FromBody] ItemCreateModel itemCreateRequest)
        {
            var newItem = new ItemModel()
            {
                key = itemCreateRequest.key,
                value = itemCreateRequest.value
            };

            _itemContext.Items.Add(newItem);
            await _itemContext.SaveChangesAsync();

            // Successfully added item message
            return Ok("New item added.");
        }


        /// <summary>
        /// Edit existing item
        /// </summary>
        /// <param name="Key"></param>
        /// <param name="itemEditRequest"></param>
        /// <returns></returns>
        [HttpPatch("{Key}")]
        [ModelStateFilter]
        public async Task<IActionResult> EditItem(string Key, [FromBody] ItemEditModel itemEditRequest)
        {
            var item = await _itemContext.Items.Where(x => x.key == Key).FirstOrDefaultAsync();

            if(item != null)
            {
                item.value = itemEditRequest.value;
                _itemContext.Update(item);
                await _itemContext.SaveChangesAsync();


                // Successfully added item message
                return Ok("Successfully edited item.");
            }
            else
            {
                return BadRequest("Unable to found item.");
            }         
        }


        /// <summary>
        /// Delete item
        /// </summary>
        /// <param name="Key"></param>
        /// <returns></returns>
        [HttpDelete("{Key}")]
        [ModelStateFilter]
        public async Task<IActionResult> DeleteItem(string Key)
        {
            var item = await _itemContext.Items.Where(x => x.key == Key).FirstOrDefaultAsync();

            if (item != null)
            {
                _itemContext.Items.Remove(item);
                await _itemContext.SaveChangesAsync();


                // Successfully added item message
                return Ok("Successfully deleted item.");
            }
            else
            {
                return BadRequest("Unable to found item.");
            }
        }

        /// <summary>
        /// For Testing exception
        /// </summary>
        /// <returns></returns>
        [HttpGet("TestException")]
        public Task TestException()
        {
            throw new Exception("Testing Exception.");
        }
    }
}
