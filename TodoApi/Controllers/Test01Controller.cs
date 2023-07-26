using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using TodoApi.Model;
using TodoApi.Validation;

namespace TodoApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class Test01Controller : ControllerBase
    {
        /// <summary>
        /// Manual Validation validator mee geven.
        /// </summary>
        /// <param name="validator1"></param>
        public Test01Controller(IValidator<PersonFluentMuliError> validator1)
        {
            _validator1 = validator1;
        }

        private readonly IValidator<PersonFluentMuliError> _validator1;

        [HttpGet("Test01")]
        public PersonFluentMuliError Get()
        {
            PersonFluentMuliError Aperson = new()
            {
                AchterNaam = "Maurice",
                VoorNaam = "Schmitz",
                Leeftijd = 40
            };
            // return NotFound(); // Kan niet
            return Aperson;
        }

        /// <summary>
        /// Meeste info
        /// </summary>
        /// <returns></returns>
        [HttpGet("Test02")]
        public IActionResult Get2()
        {
            PersonFluentMuliError Aperson = new()
            {
                AchterNaam = "Maurice",
                VoorNaam = "Schmitz",
                Leeftijd = 40
            };
            //var result = Ok(Aperson);
            var result = NotFound(Aperson);
            return result;
        }

        [HttpGet("Test03")]
        public IResult Get3()
        {
            PersonFluentMuliError aPerson = new()
            {
                AchterNaam = "Maurice",
                VoorNaam = "Schmitz",
                Leeftijd = 40
            };
            //var result = Results.Ok<PersonFluentMuliError>(Aperson);
            var result = Results.NotFound(aPerson);
            return result;
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

        [HttpPut("updateFluentMan")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IResult> UpdateFluentMan(Model.PersonFluentMuliError aPerson)
        {
            // Manual Validation
            ValidationResult result = await _validator1.ValidateAsync(aPerson);
            if (!result.IsValid)
            {
                // Copy the validation results into ModelState.
                // ASP.NET uses the ModelState collection to populate 
                // error messages in the View.
                return Results.ValidationProblem(result.ToDictionary());
            }
            else
            {
                Console.WriteLine(aPerson.ToString());
                await Task.Delay(1000);
                Console.WriteLine(aPerson.ToString());
            }


            return Results.NoContent();

        }

        [HttpPut("updateFluentMan2")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateFluentMan2(Model.PersonFluentMuliError aPerson)
        {
            // Manual Validation, in de body alleen de foutmeldingen. De Status geeft een 400. (dit is ok)
            ValidationResult result = await _validator1.ValidateAsync(aPerson);
            if (!result.IsValid)
            {
                return BadRequest(result.ToDictionary());
            }

            Console.WriteLine(aPerson.ToString());
            await Task.Delay(1000);
            Console.WriteLine(aPerson.ToString());

            return NoContent();
        }
    }
}
