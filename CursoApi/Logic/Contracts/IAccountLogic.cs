using CursoApi.Dtos.Account;
using CursoApi.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CursoApi.Logic.Contracts
{
    public interface IAccountLogic
    {
        LogicResponse Register(RegisterDto registerDto);
        Task<LogicResponse> Login(LoginDto loginDto);
    }
}
