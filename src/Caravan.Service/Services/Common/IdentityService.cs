using Caravan.Service.Interfaces.Common;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caravan.Service.Services.Common;

public class IdentityService : IIdentityService
{
    private readonly IHttpContextAccessor _accessor;

    public IdentityService(IHttpContextAccessor accessor)
    {
        this._accessor = accessor;
    }
    public long? Id
    {
        get
        {
            var result = _accessor.HttpContext!.User.FindFirst("Id");
            return result is not null ? long.Parse(result.Value) : null;
        }
    }

    public string FirstName
    {
        get
        {
            var result = _accessor.HttpContext!.User.FindFirst("FirstName");
            return result is null ? string.Empty : result.Value;
        }
    }

    public string LastName
    {
        get
        {
            var result = _accessor.HttpContext!.User.FindFirst("LastName");
            return result is null ? string.Empty : result.Value;
        }
    }

    public string Email
    {
        get
        {
            var result = _accessor.HttpContext!.User.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress");
            return result is null ? string.Empty : result.Value;
        }
    }
}
