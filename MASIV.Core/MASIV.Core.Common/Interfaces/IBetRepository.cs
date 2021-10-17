using MASIV.Core.Common.Dto;
using MASIV.Core.Common.Entities;
using System;
namespace MASIV.Core.Common.Interfaces
{
    public interface IBetRepository
    {
        bool CreateBet(Bet bet);
        ResultBet CloseBet(Guid rouletteID);
    }
}