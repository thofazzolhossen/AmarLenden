using AmarLenden.DTOs;
using AmarLenden.Model;
using AmarLenden.ViewModels;
using AmarLendenAPI.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AmarLendenAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepository _repo;
        private readonly IMapper _mapper;

        public AccountController(IAccountRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AccountDto>>> GetAll()
        {
            var allAccounts = await _repo.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<AccountDto>>(allAccounts));
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<AccountDto>> GetById(int id)
        {
            var account = await _repo.GetByIdAsync(id);
            if (account == null) return NotFound();
            return Ok(_mapper.Map<AccountDto>(account));
        }
        [HttpPost]
        public async Task<ActionResult> Create(AccountVM model)
        {
            var accountis = _mapper.Map<Account>(model);
            await _repo.AddAsync(accountis);
            await _repo.SaveAsync();
            return CreatedAtAction(nameof(GetById), new { id = accountis.Id }, _mapper.Map<AccountDto>(accountis));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, AccountVM model)
        {
            var existing = await _repo.GetByIdAsync(id);
            if (existing == null) return NotFound();

            _mapper.Map(model, existing);
            _repo.Update(existing);
            await _repo.SaveAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existing = await _repo.GetByIdAsync(id);
            if (existing == null) return NotFound();

            _repo.Delete(existing);
            await _repo.SaveAsync();
            return NoContent();
        }


    }
}
