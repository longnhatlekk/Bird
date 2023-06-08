using BirdPlatForm.BirdPlatform;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BirdPlatForm.Controllers
{
    [Authorize(Roles = "AD")]
    [Route("[controller]")]
    [ApiController]
    public class AdMinController : ControllerBase
    {
        private readonly BirdPlatFormContext _context;

        public AdMinController(BirdPlatFormContext bird)
        {
            _context = bird;
        }
        [HttpGet]
        public IEnumerable<TbUser> Get()
        {
            return _context.TbUsers.ToList();
        }
    }
}
