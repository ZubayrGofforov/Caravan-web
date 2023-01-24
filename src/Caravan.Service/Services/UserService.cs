using AutoMapper;
using Caravan.DataAccess.DbContexts;
using Caravan.DataAccess.Interfaces.Common;
using Caravan.Domain.Entities;
using Caravan.Domain.Enums;
using Caravan.Service.Common.Exceptions;
using Caravan.Service.Common.Helpers;
using Caravan.Service.Common.Utils;
using Caravan.Service.Dtos.Users;
using Caravan.Service.Interfaces;
using Caravan.Service.Interfaces.Common;
using Caravan.Service.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Caravan.Service.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;
        private readonly IPaginatorService _paginatorService;
        private readonly IImageService imageService;
        private readonly AppDbContext appDbContext;
        public UserService(IMapper imapper, AppDbContext appDbContext, IPaginatorService paginatorService, IUnitOfWork unitOfWork, IImageService imageService)
        {
            this.mapper = imapper;
            this.unitOfWork = unitOfWork;
            this.imageService = imageService;
            this._paginatorService = paginatorService;
            this.appDbContext = appDbContext;
        }
       

        public async Task<bool> DeleteAsync(long id)
        {
            var temp = await unitOfWork.Users.FindByIdAsync(id);
            if(temp is not null)
            {
                unitOfWork.Users.Delete(id);
                var res = await unitOfWork.SaveChangesAsync();
                return res > 0;
            }
            else throw new StatusCodeException(System.Net.HttpStatusCode.NotFound, "User not found");
        }

        public async Task<IEnumerable<UserViewModel>> GetAllAysnc(PaginationParams @params)
        {
            var query = unitOfWork.Users.GetAll().OrderBy(x => x.Id)
                .ToList().ConvertAll(x => mapper.Map<UserViewModel>(x));
            var data = await _paginatorService.ToPagedAsync(query, @params.PageNumber, @params.PageSize);
            return data;

        }

        public async Task<UserViewModel> GetAsync(long id)
        {
            var temp = await unitOfWork.Users.FindByIdAsync(id);
            if (temp is not null)
                 return mapper.Map<UserViewModel>(temp);
            else throw new StatusCodeException(System.Net.HttpStatusCode.NotFound, "User not found");

        }

        public async Task<UserViewModel> GetEmailAsync(string email)
        {
            var user = await unitOfWork.Users.GetByEmailAsync(email.Trim());
            if (user is null)
                throw new StatusCodeException(HttpStatusCode.NotFound, "User not found");
            var userView = mapper.Map<UserViewModel>(user);
            return userView;
        }

        public async Task<bool> UpdateAsync(long id, UserUpdateDto entity)
        {
            if (id == HttpContextHelper.UserId || HttpContextHelper.UserRole != "User") 
            {
                var temp = await appDbContext.Users.FindAsync(id);
                unitOfWork.Users.TrackingDeteched(temp);
                if (entity is not null)
                {
                    var res = mapper.Map<User>(entity);
                    res.Id = HttpContextHelper.UserId;
                    res.PasswordHash = temp!.PasswordHash;
                    res.Salt = temp.Salt;
                    res.Email = temp.Email;
                    res.FirstName = string.IsNullOrWhiteSpace(entity.FirstName) ? temp.FirstName : entity.FirstName;
                    res.LastName = string.IsNullOrWhiteSpace(entity.LastName) ? temp.LastName : entity.LastName;
                    res.Address = string.IsNullOrWhiteSpace(entity.Address) ? temp.Address : entity.Address;
                    res.PhoneNumber = string.IsNullOrWhiteSpace(entity.PhoneNumber) ? temp.PhoneNumber : entity.PhoneNumber;
                    res.CreatedAt = temp.CreatedAt;
                    res.UpdatedAt = TimeHelper.GetCurrentServerTime();
                    appDbContext.Users.Update(res);
                    var result = await appDbContext.SaveChangesAsync();
                    return result > 0;
                }
                else throw new StatusCodeException(System.Net.HttpStatusCode.NotFound, "User not found");
            }
            else throw new StatusCodeException(System.Net.HttpStatusCode.BadRequest, "Not allowed");
        }
    }
}
