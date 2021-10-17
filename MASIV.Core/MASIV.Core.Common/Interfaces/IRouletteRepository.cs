using MASIV.Core.Common.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MASIV.Core.Common.Interfaces
{
    public interface IRouletteRepository
    {
        List<Roulette>GetAll(); 
        Roulette GetById(Guid rouletteId);
        bool CreateRoulette(Roulette roulette);
        bool OpenRoulette(Roulette roulette);
        bool CloseRoulette(Guid rouletteId);
    }
}