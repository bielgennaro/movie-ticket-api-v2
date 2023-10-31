using Microsoft.AspNetCore.Mvc;

using MovieTicket.Application.DTOs;
using MovieTicket.Application.Interfaces;

namespace MovieTicket.WebApi.Controller
{
    [Route( "api/[controller]" )]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController( IUserService userService )
        {
            this._userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDto>>> Get()
        {
            try
            {
                List<UserDto> users = ( await this._userService.GetUsersAsync() ).ToList();

                return this.Ok( users );
            }
            catch( Exception ex )
            {
                return this.BadRequest( ex.Message );
            }
        }

        [HttpGet( "{id}" )]
        public async Task<ActionResult<UserDto>> ListById( int id)
        {
            try
            {
                var user = await this._userService.GetUserByIdAsync( id );

                return this.Ok( user );
            }catch( Exception ex )
            {
                return this.BadRequest( ex.Message );
            }
        }
    }
}
