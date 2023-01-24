using Caravan.Service.Common.Helpers;
using Caravan.Service.Common.Utils;
using Caravan.Service.Dtos.Users;
using Caravan.Service.Interfaces;
using Caravan.Service.Interfaces.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Caravan.Api.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService service;
        private readonly IAccountService accountService;
        private readonly IPaginatorService _paginatorService;
        private readonly int _pageSize = 20;
        public UserController(IUserService service, IPaginatorService paginatorService, IAccountService accountservice)
        {
            this.service = service;
            this.accountService = accountservice;
            this._paginatorService = paginatorService;
        }

        [HttpGet("email"), AllowAnonymous]
        public async Task<IActionResult> GetEmailAsync(string email)
            => Ok(await service.GetEmailAsync(email));


        [HttpGet,Authorize(Roles ="Admin")]
        public async Task<IActionResult> GetAllAsync(int page)
            => Ok(await service.GetAllAysnc(new PaginationParams(page, _pageSize)));


        [HttpGet ("{id}"), Authorize(Roles = "Admin, User")]
        public async Task<IActionResult> GetAsync(long id)
            => Ok(await service.GetAsync(id));
        
        
        [HttpDelete("{id}"), Authorize(Roles = "User, Admin")]
        public async Task<IActionResult> DeleteAsync(long id)
            => Ok(await service.DeleteAsync(id));
        
        
        [HttpPut, Authorize(Roles ="User, Admin")]
        public async Task<IActionResult> UpdateAsync(long id,[FromBody] UserUpdateDto dto)
            => Ok(await service.UpdateAsync( id,dto));
    }
}
