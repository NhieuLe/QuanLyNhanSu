using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NhanSuAPI.Data;
using NhanSuAPI.Models.ResponseModels;
using NhanSuAPI.Services;

namespace NhanSuAPI.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhanCongController : ControllerBase
    {
        private readonly IPhanCongService _PhanCongService;
        private readonly IMapper _mapper;

        public PhanCongController(IPhanCongService PhanCongService, IMapper mapper)
        {
            _PhanCongService = PhanCongService;
            _mapper = mapper;
        }

        [HttpGet("PhanCongs")]
        public async Task<IActionResult> GetPhanCongs()
        {
            var result = await _PhanCongService.GetAllPhanCongsAsync();
            return Ok(_mapper.Map<List<PhanCongResponse>>(result));
        }

        [HttpPost("PhanCong")]
        public async Task<IActionResult> CreatePhanCong(PhanCongResponse model)
        {
            var result = await _PhanCongService.CreatePhanCongAsync(_mapper.Map<PhanCong>(model));

            return Ok(_mapper.Map<PhanCongResponse>(result));
        }

        [HttpPut("edit/{nhansuId}&{duanId}")]
        public async Task<IActionResult> UpdatePhanCong(string nhansuId, string duanId, PhanCongResponse model)
        {
            var temp = _mapper.Map<PhanCong>(model);
            temp.MaNhanSu = nhansuId;
            temp.MaCongViec = duanId;
            var result = await _PhanCongService.UpdatePhanCongAsync(temp);
            return Ok(_mapper.Map<PhanCongResponse>(result));
        }
        [HttpDelete("delete/{nhansuId}&{duanId}")]
        public async Task<IActionResult> DeletePhanCong(string nhansuId, string duanId)
        {
            var result = await _PhanCongService.DeletePhanCongAsync(nhansuId, duanId);
            var returnRes = _mapper.Map<PhanCongResponse>(result);

            return Ok(returnRes);
        }
    }
}
