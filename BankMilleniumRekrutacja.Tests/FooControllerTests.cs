namespace BankMilleniumRekrutacja.Tests
{
    using AutoMapper;
    using BankMilleniumRekrutacja.Controllers;
    using System;
    using Xunit;

    public class FooControllerTests
    {
        private readonly IMapper mapper;

        public FooControllerTests()
        {

        }

        [Fact]
        public void GetFound()
        {
            // Arrange
            var controller = new FooController();
        }
    }
}
