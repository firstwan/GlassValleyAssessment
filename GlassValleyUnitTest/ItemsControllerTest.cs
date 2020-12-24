using Microsoft.EntityFrameworkCore;
using System;
using Xunit;
using GlassValley;
using GlassValley.Model;
using GlassValley.Controllers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace GlassValleyUnitTest
{
    public class ItemsControllerTest
    {
        protected ItemsContext _context { get; }

        public ItemsControllerTest()
        {
            var options = new DbContextOptionsBuilder<ItemsContext>()
                .UseInMemoryDatabase("Item")
                .Options;

            _context = new ItemsContext(options);
        }

        [Fact]
        public async Task Can_get_items()
        {
            // arrange
            var controller = new ItemsController(_context);

            // act
            var response = (await controller.GetItems()) as OkObjectResult;

            // assert
            Assert.NotNull(response);
            Assert.IsType<List<ItemModel>>(response.Value);
            Assert.Equal(StatusCodes.Status200OK, response.StatusCode);
        }

        [Fact]
        public async Task Can_add_item()
        {
            // arrange
            var controller = new ItemsController(_context);
            var itemCreateModel = new ItemCreateModel()
            {
                key = "new key",
                value = "something new"
            };

            // act
            var response = (await controller.AddItem(itemCreateModel)) as OkObjectResult;

            // assert
            Assert.NotNull(response);            
            Assert.Equal(StatusCodes.Status200OK, response.StatusCode);
        }
    }
}
