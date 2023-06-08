using BirdPlatForm.BirdPlatform;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BirdPlatForm.Controllers
{
    [Authorize(Roles = "AD")]
    [Route("[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly BirdPlatFormContext _context;

        public AdminController(BirdPlatFormContext ct) {
            _context = ct;
        }
        [HttpGet]
        public async Task<IActionResult> Getall()
        {
            var result = _context.TbUsers.ToList();
            return Ok(result);
        }
    }
}
