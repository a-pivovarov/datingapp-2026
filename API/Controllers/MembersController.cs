using API.Entities;
using API.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize]
    public class MembersController(IMemberRepository memberRepository) : BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<Member>>> GetMembersAsync()
        {
            return Ok(await memberRepository.GetMembersAsync());
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<Member>> GetMemberAsync(string id)
        {
            var member = await memberRepository.GetMemberByIdAsync(id);

            if (member == null) return NotFound();

            return Ok(member);
        }

        [HttpGet("{id}/photos")]
        public async Task<ActionResult<IReadOnlyList<Photo>>> GetPhotosForMemberAsync(string id)
        {
            return Ok(await memberRepository.GetPhotosForMemberAsync(id));
        }
    }
}