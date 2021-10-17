using MASIV.Core.Common.Dto;
using MASIV.Core.Common.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MASIV.Core.Common.Interfaces
{
    public interface IRouletteApplication
    {
        Task<ResponseDto<List<Roulette>>> Get();
        Task<BaseResponseDto> Post();
        Task<ResponseDto<Roulette>> Open(Guid rouletteId);
    }
}
