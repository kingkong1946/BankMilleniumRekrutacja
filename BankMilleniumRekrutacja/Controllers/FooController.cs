namespace BankMilleniumRekrutacja.Controllers
{
    using AutoMapper;
    using BankMilleniumRekrutacja.Models;
    using BankMilleniumRekrutacja.Module.Foo.Application;
    using BankMilleniumRekrutacja.ViewModels;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Net;
    using System.Threading.Tasks;

    [Route("api/[controller]")]
    [ApiController]
    public class FooController : ControllerBase
    {
        private readonly FooService fooService;
        private readonly IMapper mapper;

        public FooController(FooService fooService, IMapper mapper)
        {
            this.fooService = fooService;
            this.mapper = mapper;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(FooDto), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<FooResource>> GetAsync(int id)
        {
            try
            {
                var foo = await this.fooService.GetAsync(id);
                return this.mapper.Map<FooResource>(foo);
            }
            catch (InvalidOperationException)
            {
                return this.NotFound("Foo is not found");
            }
        }

        [HttpPost()]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.Conflict)]
        public async Task<ActionResult> PostAsync(FooRequest request)
        {
            try
            {
                var foo = this.mapper.Map<FooDto>(request);

                await this.fooService.AddAsync(foo);

                return this.Ok();
            }
            catch (InvalidOperationException)
            {
                return this.Conflict("Foo is exist");
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
        public async Task<ActionResult> PutAsync(int id, FooRequest request)
        {
            try
            {
                var foo = this.mapper.Map<FooDto>(request);
                foo.Id = id;

                await this.fooService.UpdateAsync(foo);

                return this.NoContent();
            }
            catch (InvalidOperationException)
            {
                return this.NotFound("Foo is not exist");
            }
        }



        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            try
            {
                await this.fooService.DeleteAsync(id);

                return this.NoContent();
            }
            catch (InvalidOperationException)
            {
                return this.NotFound("Foo is not exist");
            }
        }
    }
}
