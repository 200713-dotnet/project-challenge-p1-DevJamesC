using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using PizzaBox.Client.Controllers;
using PizzaBox.Client.Models;
using PizzaBox.Domain.Models;
using PizzaBox.Storing;
using Xunit;

namespace PizzaBox.Testing
{
    public class OrderControllerTest
    {

        private static readonly SqliteConnection _connection = new SqliteConnection("Data Source=:memory:");
        private static readonly DbContextOptions<PizzaBoxDbContext> _options = new DbContextOptionsBuilder<PizzaBoxDbContext>().UseSqlite(_connection).Options;
        PizzaBoxDbContext dbo = new PizzaBoxDbContext(_options);
        
        [Fact]
        public async System.Threading.Tasks.Task HomeTestAsync()
        {
            await _connection.OpenAsync();
            await dbo.Database.EnsureCreatedAsync();

           //arrange
        var sut = new OrderController(dbo);

        //act
        IActionResult view = sut.Home(new UserViewModel());

        //assert

        Assert.NotNull(view);
        



        
        }
}
}