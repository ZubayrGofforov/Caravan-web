using AutoMapper;
using Caravan.DataAccess.Interfaces.Common;
using Caravan.Service.Common.Exceptions;
using Caravan.Service.Common.Utils;
using Caravan.Service.Dtos.Admins;
using Caravan.Service.Interfaces;
using Caravan.Service.Interfaces.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Caravan.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Caravan.DataAccess.Repositories.Common;
using Caravan.Service.Common.Helpers;

namespace Caravan.Service.Services
{
    public class AdminService : IAdminService
    {
        private readonly IUnitOfWork _repository;
        private readonly IMapper _mapper;
        private readonly IImageService _imageService;
        private readonly IPaginatorService _paginatorService;

        public AdminService(IUnitOfWork unitOfWork, IMapper mapper, IImageService imageService, IPaginatorService paginatorService)
        {
            _repository = unitOfWork;
            _mapper = mapper;
            _imageService = imageService;
            _paginatorService = paginatorService;
        }
        public async Task<bool> DeleteAsync(long id)
        {
            var admin = _repository.Administrators.FirstOrDefaultAsync(x => x.Id == id);
            if (admin is null)
            {
                throw new StatusCodeException(HttpStatusCode.NotFound, "Admin not found"); 
            }
            _repository.Administrators.Delete(id);
            var res = await _repository.SaveChangesAsync();
            return res > 0;
        }

        public async Task<IEnumerable<AdminViewModel>> GetAllAsync(PaginationParams @params)
        {
            var query = _repository.Administrators.GetAll().OrderBy(x => x.CreatedAt).ToList()
                .ConvertAll(x => _mapper.Map<AdminViewModel>(x));
            var data = await _paginatorService.ToPagedAsync(query, @params.PageNumber, @params.PageSize);
            return data;
        }

        public async Task<AdminViewModel> GetByIdAsync(long id)
        {
            var admin = await _repository.Administrators.FindByIdAsync(id);
            if (admin is null)
                throw new StatusCodeException(HttpStatusCode.NotFound, "Admin is not found");

            var res = _mapper.Map<AdminViewModel>(admin);
            return res;
        }

        public async Task<bool> UpdateAsync(long id, AdminCreateDto dto)
        {
            var admin = await _repository.Administrators.FindByIdAsync(id);
            if (admin is null)
                throw new StatusCodeException(HttpStatusCode.NotFound, "Admin is not found");
            _repository.Administrators.TrackingDeteched(admin);
            admin.FirstName= dto.FirstName;
            admin.LastName = dto.LastName;
            admin.ImagePath = dto.ImagePath;
            admin.PhoneNumber = dto.PhoneNumber;
            admin.PassportNumber = dto.PassportNumber;
            admin.PassportSeria= dto.PassportSeria;
            admin.UpdatedAt = TimeHelper.GetCurrentServerTime();
            _repository.Administrators.Update(id,admin);
            var result = await _repository.SaveChangesAsync();
            return result > 0;
        }
    }
}
