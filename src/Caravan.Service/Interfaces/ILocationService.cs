using Caravan.Service.Dtos.Locations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caravan.Service.Interfaces
{
    public interface ILocationService
    {
        public Task<(bool IsSuccessful, long Id)> CreateAsync(LocationCreateDto createDto);
        public Task<bool> UpdateAsync(long id, LocationCreateDto updateDto);
    }
}
