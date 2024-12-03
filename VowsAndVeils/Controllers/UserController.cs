using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using VowsAndVeils.Interfaces;

namespace VowsAndVeils.Controllers
{
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

    }
}
