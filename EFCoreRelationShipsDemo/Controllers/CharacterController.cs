
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCoreRelationShipsDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharacterController : ControllerBase
    {
        private readonly DataContext _context;

        public CharacterController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Character>>> Get(int userId)
        {
            var characters=await _context.Characters
                .Where(c=>c.UserId == userId)
                .ToListAsync();
            return characters;
        }

        [HttpPost]
        public async Task<ActionResult<List<Character>>> Create(CreateCharacterDto request)
        {
            var user = await _context.Users.FindAsync(request.UserId);
            if (user == null)
            {
                return NotFound();
            }
            var newCharacter = new Character
            {
                Name = request.Name,
                RpgClass = request.RpgClass,
                User = user
            };
            _ = _context.Characters.Add(newCharacter);
            await _context.SaveChangesAsync();
            return await Get(newCharacter.UserId);
           
        }


    }
}
