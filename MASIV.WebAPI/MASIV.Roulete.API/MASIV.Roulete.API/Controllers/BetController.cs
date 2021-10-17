using MASIV.Core.Common.Dto;
using MASIV.Core.Common.Entities;
using MASIV.Core.Common.Interfaces;
using MASIV.Core.Common.Utils;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
namespace MASIV.Roulete.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BetController : ControllerBase
    {
        private readonly IBetRepository betRepository;
        public BetController(IBetRepository repository)
        {
            betRepository = repository;
        }
        [HttpPost]
        public async Task<ActionResult<Bet>> Post([FromBody] Bet newBet)
        {
            try
            {
                bool success = false;
                Request.Headers.TryGetValue("userId", out Microsoft.Extensions.Primitives.StringValues userId);
                if (string.IsNullOrEmpty(userId))
                    return BadRequest(Utils.CreateMessageError(message: "No se encontró {userId} válido en la cabecera."));

                newBet.Id = Guid.NewGuid();
                newBet.IdUsuario = userId;
                await Task.Run(() =>
                {
                    success = betRepository.CreateBet(bet: newBet);
                });
                if (!success)
                    return BadRequest();

                return Ok(newBet);
            }
            catch (Exception ex)
            { return BadRequest(ex.Message); }
        }
        [HttpPost("Close/{rouletteId:Guid}")]
        public async Task<ActionResult<Bet>> CloseBets(Guid rouletteId)
        {
            try
            {
                ResultBet result = null;
                await Task.Run(() =>
                {
                    result = betRepository.CloseBet(rouletteID: rouletteId);
                });

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}