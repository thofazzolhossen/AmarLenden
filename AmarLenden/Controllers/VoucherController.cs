using AmarLenden.DTOs;
using AmarLenden.Interfaces;
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
            var vouchers = await _repo.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<VoucherDto>>(vouchers));
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<VoucherDto>> GetById(int id)
        {
            var voucher = await _repo.GetByIdAsync(id);
            if (voucher == null) return NotFound();
            return Ok(_mapper.Map<VoucherDto>(voucher));
        }
    }
}
