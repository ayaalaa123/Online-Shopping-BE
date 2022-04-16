using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Online_Shopping_Domain.DTO;
using Online_Shopping_Domain.Entities;
using Online_Shopping_Infrastructure.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Online_Shopping_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;
        private IMapper _mapper;
        public UsersController(
            IUserService userService,
              IMapper mapper
            )
        {
            _userService = userService;
            _mapper = mapper;


        }

        [HttpPost]
        public IActionResult Register([FromBody] AddUserDTO userDTO)
        {
           try
            {
              var user=  _mapper.Map<User>(userDTO);
                _userService.Create(user);

                return Ok();
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }

        }
    }
}
