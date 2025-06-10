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
    public class BudgetController : ControllerBase
    {
        private readonly IBudgetRepository _repo;
        private readonly IMapper _mapper;

        public BudgetController(IBudgetRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BudgetDto>>> GetAll()
        {
            var budgets = await _repo.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<BudgetDto>>(budgets));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BudgetDto>> GetById(int id)
        {
            var budget = await _repo.GetByIdAsync(id);
            if (budget == null) return NotFound();
            return Ok(_mapper.Map<BudgetDto>(budget));
        }

        [HttpPost]
        public async Task<ActionResult> Create(BudgetVM model)
        {
            var budget = _mapper.Map<Budget>(model);
            await _repo.AddAsync(budget);
            await _repo.SaveAsync();
            return CreatedAtAction(nameof(GetById), new { id = budget.Id }, _mapper.Map<BudgetDto>(budget));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, BudgetVM model)
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
