using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NhanSuAPI.Data;
using NhanSuAPI.Models.ResponseModels;
using NhanSuAPI.Services;

namespace NhanSuAPI.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CongViecController : ControllerBase
    {
        private readonly ICongViecService _CongViecService;
        private readonly IMapper _mapper;

        public CongViecController(ICongViecService CongViecService, IMapper mapper)
        {
            _CongViecService = CongViecService;
            _mapper = mapper;
        }

        [HttpGet("CongViecs")]
        public async Task<IActionResult> GetCongViecs()
        {
            var result = await _CongViecService.GetAllCongViecsAsync();
            return Ok(_mapper.Map<List<CongViecResponse>>(result));
        }

        [HttpPost("CongViec")]
        public async Task<IActionResult> CreateCongViec(CongViecResponse model)
        {
            var result = await _CongViecService.CreateCongViecAsync(_mapper.Map<CongViec>(model));

            return Ok(_mapper.Map<CongViecResponse>(result));
        }

        [HttpPut("edit/{keyId}")]
        public async Task<IActionResult> UpdateCongViec(string keyId, CongViecResponse model)
        {
            var temp = _mapper.Map<CongViec>(model);
            temp.Id = keyId;
            var result = await _CongViecService.UpdateCongViecAsync(temp);
            return Ok(_mapper.Map<CongViecResponse>(result));
        }
        [HttpDelete("delete/{keyId}")]
        public async Task<IActionResult> DeleteCongViec(string keyId)
        {
            var result = await _CongViecService.DeleteCongViecAsync(keyId);
            var returnRes = _mapper.Map<CongViecResponse>(result);

            return Ok(returnRes);
        }
    }
}
