using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NhanSuAPI.Data;
using NhanSuAPI.Models.ResponseModels;
using NhanSuAPI.Services;

namespace NhanSuAPI.Controller
{
    public class NhanSuController : ControllerBase
    {
        private readonly INhanSuService _NhanSuService;
        private readonly IMapper _mapper;

        public NhanSuController(INhanSuService NhanSuService, IMapper mapper)
        {
            _NhanSuService = NhanSuService;
            _mapper = mapper;
        }

        [HttpGet("NhanSus")]
        public async Task<IActionResult> GetNhanSus()
        {
            var result = await _NhanSuService.GetAllNhanSusAsync();
            return Ok(_mapper.Map<List<NhanSu>>(result));
        }

        [HttpPost("NhanSu")]
        public async Task<IActionResult> CreateNhanSu(NhanSuResponse model)
        {
            var result = await _NhanSuService.CreateNhanSuAsync(_mapper.Map<NhanSu>(model));

            return Ok(_mapper.Map<NhanSuResponse>(result));
        }

        [HttpPut("edit/{keyId}")]
        public async Task<IActionResult> UpdateNhanSu(string keyId, NhanSuResponse model)
        {
            var temp = _mapper.Map<NhanSu>(model);
            temp.Id = keyId;
            var result = await _NhanSuService.UpdateNhanSuAsync(temp);
            return Ok(_mapper.Map<NhanSuResponse>(result));
        }
        [HttpDelete("delete/{keyId}")]
        public async Task<IActionResult> DeleteNhanSu(string keyId)
        {
            var result = await _NhanSuService.DeleteNhanSuAsync(keyId);
            var returnRes = _mapper.Map<NhanSuResponse>(result);

            return Ok(returnRes);
        }
    }
}
