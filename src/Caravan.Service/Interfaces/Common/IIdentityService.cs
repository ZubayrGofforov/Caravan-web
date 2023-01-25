using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caravan.Service.Interfaces.Common;

public interface IIdentityService
{
    public long? Id { get;}
    public string FirstName { get;}
    public string LastName { get;}
    public string Email { get;}

}
