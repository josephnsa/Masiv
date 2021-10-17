using MASIV.Core.Common.Dto;
using MASIV.Core.Common.Entities;
using MASIV.Core.Common.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace Masivian.Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RouletteController : ControllerBase
    {
        private readonly IRouletteApplication rouletteApplication;
        public RouletteController(IRouletteApplication rouletteApplication)
        {
            this.rouletteApplication = rouletteApplication;
        }
        [HttpGet]
        public async Task<ResponseDto<List<Roulette>>> Get()
        {
            return await rouletteApplication.Get();
        }
        [HttpPost]
        public async Task<BaseResponseDto> Post()
        {
            return await rouletteApplication.Post();
        }
        [HttpPost("Open/{rouletteId:Guid}")]
        public async Task<ResponseDto<Roulette>> Open(Guid rouletteId)
        {
            return await rouletteApplication.Open(rouletteId);
        }
    }
}