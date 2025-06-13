using AmarLenden.DTOs;
using AmarLenden.Interfaces;
using AmarLenden.Model;
using AmarLenden.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AmarLenden.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VoucherController : ControllerBase
    {
        private readonly IVoucherRepository _repo;
        private readonly IMapper _mapper;

        public VoucherController(IVoucherRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VoucherDto>>> GetAll()
        {
            var vouchers = await _repo.GetAllWithLinesAsync();
            return Ok(_mapper.Map<IEnumerable<VoucherDto>>(vouchers));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<VoucherDto>> GetById(int id)
        {
            var voucher = await _repo.GetByIdWithLinesAsync(id);
            if (voucher == null) return NotFound();
            return Ok(_mapper.Map<VoucherDto>(voucher));
        }

        [HttpPost]
        public async Task<ActionResult> Create(VoucherVM model)
        {
            var voucher = _mapper.Map<Voucher>(model);
            await _repo.AddAsync(voucher);
            await _repo.SaveAsync();
            return CreatedAtAction(nameof(GetById), new { id = voucher.Id }, _mapper.Map<VoucherDto>(voucher));
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, VoucherVM model)
        {
            var existing = await _repo.GetByIdWithLinesAsync(id);
            if (existing == null) return NotFound();

            existing.Lines.Clear();
            foreach (var line in model.Lines)
            {
                existing.Lines.Add(new VoucherLine
                {
                    AccountName = line.AccountName,
                    Debit = line.Debit,
                    Credit = line.Credit
                });
            }
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
