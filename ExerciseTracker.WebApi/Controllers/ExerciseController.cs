using Microsoft.AspNetCore.Mvc;
using ExerciseTracker.Domain.Abstractions.Services;
using ExerciseTracker.Domain.DTO;
using ExerciseTracker.Service;

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
        public async Task<ActionResult<List<ExerciseItemDisplayDto>>> GetExerciseItems()
        {
            var items = await _exerciseService.GetAllExerciseAsync();
            return items.Select(x => x.ToDto()).ToList();
        }

        
        // GET: api/Exercise/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ExerciseItemDisplayDto>> GetExerciseItem(int id)
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
            await _exerciseService.UpdateExerciseAsync(await _exerciseService.GetExerciseByIdAsync(id),
                exerciseItemUpdateDto);
            return NoContent();
        }

        // POST: api/Exercise
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ExerciseItemPostDto>> PostExerciseItem(ExerciseItemPostDto exerciseItemDto)
        {
            await _exerciseService.AddExerciseAsync(exerciseItemDto);
            return CreatedAtAction("PostExerciseItem", exerciseItemDto);
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
