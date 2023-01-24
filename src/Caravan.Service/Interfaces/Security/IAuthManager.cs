using Caravan.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caravan.Service.Interfaces.Security
{
    public interface IAuthManager
    {
        public string GenerateToken(User user);
    }
}
