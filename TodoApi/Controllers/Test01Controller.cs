using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;
using TodoApi.Model;

namespace TodoApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class Test01Controller : ControllerBase
    {

        [HttpGet(Name = "Test01")]
        public string Get()
        {
            return "Hello World";
        }

        [HttpPut("update")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update(Model.Person aPerson)
        {
            Console.WriteLine(aPerson.ToString());
            await Task.Delay(1000);
            Console.WriteLine(aPerson.ToString());
            Console.WriteLine(aPerson.ToString());
            return NoContent();

        }

        [HttpPut("updateFluent")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateFluent(Model.PersonFluent aPerson)
        {

            Console.WriteLine(aPerson.ToString());
            await Task.Delay(1000);
            Console.WriteLine(aPerson.ToString());

            return NoContent();

        }

    }
}
