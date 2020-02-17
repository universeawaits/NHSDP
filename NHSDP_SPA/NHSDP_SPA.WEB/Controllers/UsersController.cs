using AutoMapper;
using Microsoft.AspNetCore.Mvc;

using NHSDP_SPA.Core.Model;
using NHSDP_SPA.Logic;
using NHSDP_SPA.Logic.Interface;
using NHSDP_SPA.WEB.ViewModel;
using System.Threading.Tasks;

namespace NHSDP_SPA.WEB.Controllers
{
    [Route("[controller]")]
    [ApiController] 
    public class UsersController : CRUDControllerBase<User, UserVM>
    {
        public UsersController(IMapper mapper, ICRUDServiceBase<User> userService)
        {
            this.mapper = mapper;
            this.entityService = userService;
        }
        [Route("my")]
        [HttpPost]
        public override async Task<ErrorVM> Create([FromBody] UserVM entity)
        {
            Error error = await entityService.CreateAsync(mapper.Map<User>(entity));

            return error == null ? null : mapper.Map<ErrorVM>(error);
        }
    }
}
