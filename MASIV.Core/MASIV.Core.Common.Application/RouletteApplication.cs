using MASIV.Core.Common.Dto;
using MASIV.Core.Common.Entities;
using MASIV.Core.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MASIV.Core.Common.Application
{
    public class RouletteApplication : IRouletteApplication
    {
        private readonly IRouletteRepository rouletteRepository;
        public RouletteApplication(IRouletteRepository rouletteRepository)
        {
            this.rouletteRepository = rouletteRepository;
        }
        public async Task<ResponseDto<List<Roulette>>> Get()
        {
            ResponseDto<List<Roulette>> result = new ResponseDto<List<Roulette>>();
            try
            {
                await Task.Run(() =>
                {
                    result.Data = rouletteRepository.GetAll();
                });

                if (result.Data.Count() == 0)
                {
                    result.Message = "No hay datos registrado en ruleta";
                    result.IsSuccessful = false;
                }
                else
                {
                    result.Message = "Lista lodos los registros de la ruleta";
                    result.IsSuccessful = true;
                }
            }
            catch (Exception e)
            {
                result.Status = e.HResult;
                result.Message = e.Message;
            }
            return result;
        }
        public async Task<BaseResponseDto> Post()
        {
            BaseResponseDto result = new BaseResponseDto();
            try
            {
                bool succes = false;
                Roulette roulette = new Roulette { Id = Guid.NewGuid(), CreatedDate = DateTime.UtcNow };
                await Task.Run(() =>
                {
                    succes = rouletteRepository.CreateRoulette(roulette: roulette);
                });
                if (!succes)
                {
                    result.Message = "Error al registrar";
                }
                else
                {
                    result.Result = long.Parse(roulette.Id.ToString());
                    result.Message = $"Registrado Rouleta Existosamente con el Id:{long.Parse(roulette.Id.ToString())}";
                }

                result.IsSuccessful = succes;
            }
            catch (Exception e)
            {
                result.Status = e.HResult;
                result.Message = e.Message;
            }
            return result;
        }
        public async Task<ResponseDto<Roulette>> Open(Guid rouletteId)
        {
            ResponseDto<Roulette> result = new ResponseDto<Roulette>();
            try
            {
                bool open = false;
                var currentRoulette = rouletteRepository.GetById(rouletteId: rouletteId);
                currentRoulette.Status = "Abierta";
                await Task.Run(() =>
                {
                    open = !rouletteRepository.OpenRoulette(roulette: currentRoulette);
                });
                if (open)
                {
                    result.Data = currentRoulette;
                    result.Message = "Se aperturo la ruleta exitosamente";
                }
                else 
                {
                    result.Message = "No se pudo aperturar la ruleta";
                }
                result.IsSuccessful = open;
            }
            catch (Exception e)
            {
                result.Status = e.HResult;
                result.Message = e.Message;
            }
            return result;
        }

    }
}
