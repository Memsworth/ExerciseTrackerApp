using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ExerciseTracker.DataAccess;
using ExerciseTracker.Domain.Abstractions.Services;
using ExerciseTracker.Domain.Models;
using ExerciseTracker.WebApi.DTO;

namespace ExerciseTracker.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExerciseController : ControllerBase
    {
        private readonly IExerciseService _exerciseService;

        public ExerciseController(IExerciseService exerciseService)
        {
            _exerciseService = exerciseService;
        }
        
        // GET: api/Exercise
        [HttpGet]
        public async Task<ActionResult<List<ExerciseItemDisplayDTO>>> GetExerciseItems()
        {
            var items = await _exerciseService.GetAllExerciseAsync();
            return items.Select(x => x.ToDto()).ToList();
        }

        
        // GET: api/Exercise/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ExerciseItemDisplayDTO>> GetExerciseItem(int id)
        {
            var item = await _exerciseService.GetExerciseByIdAsync(id);
            return item.ToDto();
        }
        
        
        //THIS FEELS WRONG. Check in with sensei
        // PUT: api/Exercise/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutExerciseItem(int id, ExerciseItemUpdateDto exerciseItemUpdateDto)
        {
            // I see the link from MS who am I to go against them lol
            var item = await _exerciseService.GetExerciseByIdAsync(id);
            item.UpdateItem(exerciseItemUpdateDto);
            await _exerciseService.UpdateExerciseAsync(item);
            return NoContent();
        }

        // POST: api/Exercise
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ExerciseItemPostDTO>> PostExerciseItem(ExerciseItemPostDTO exerciseItemDto)
        {
            var employeeItem = exerciseItemDto.ToDbo();
            await _exerciseService.AddExerciseAsync(employeeItem);
            return CreatedAtAction("PostExerciseItem", new { id = employeeItem.Id }, employeeItem);
        }

        // DELETE: api/Exercise/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExerciseItem(int id)
        {
            await _exerciseService.DeleteExerciseAsync(await _exerciseService.GetExerciseByIdAsync(id));
            return NoContent();
        }
    }
}
