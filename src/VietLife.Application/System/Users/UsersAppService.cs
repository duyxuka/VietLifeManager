using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Account;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Identity;
using VietLife.NhanViens;

namespace VietLife.System.Users
{
    [Authorize(IdentityPermissions.Users.Default, Policy = "AdminOnly")]
    public class UsersAppService : CrudAppService<NhanVien, UserDto, Guid, PagedResultRequestDto,
                        CreateUserDto, UpdateUserDto>, IUsersAppService
    {
        private readonly NhanVienManager _nhanVienManager;

        public UsersAppService(IRepository<NhanVien, Guid> repository,
            NhanVienManager nhanVienManager) : base(repository)
        {
            _nhanVienManager = nhanVienManager;

            GetPolicyName = IdentityPermissions.Users.Default;
            GetListPolicyName = IdentityPermissions.Users.Default;
            CreatePolicyName = IdentityPermissions.Users.Create;
            UpdatePolicyName = IdentityPermissions.Users.Update;
            DeletePolicyName = IdentityPermissions.Users.Delete;
        }

        [Authorize(IdentityPermissions.Users.Delete)]
        public async Task DeleteMultipleAsync(IEnumerable<Guid> ids)
        {
            await Repository.DeleteManyAsync(ids);
            await UnitOfWorkManager.Current.SaveChangesAsync();
        }

        [Authorize(IdentityPermissions.Users.Default)]
        public async Task<List<UserInListDto>> GetListAllAsync(string filterKeyword)
        {
            var query = await Repository.GetQueryableAsync();
            if (!string.IsNullOrEmpty(filterKeyword))
            {
                query = query.Where(o => o.Name.ToLower().Contains(filterKeyword)
              || o.Email.ToLower().Contains(filterKeyword)
              || o.PhoneNumber.ToLower().Contains(filterKeyword));
            }

            var data = await AsyncExecuter.ToListAsync(query);
            return ObjectMapper.Map<List<NhanVien>, List<UserInListDto>>(data);
        }

        [Authorize(IdentityPermissions.Users.Default)]
        public async Task<PagedResultDto<UserInListDto>> GetListWithFilterAsync(BaseListFilterDto input)
        {
            var query = await Repository.GetQueryableAsync();

            if (!input.Keyword.IsNullOrWhiteSpace())
            {
                input.Keyword = input.Keyword.ToLower();
                query = query.Where(o => o.Name.ToLower().Contains(input.Keyword)
                || o.Email.ToLower().Contains(input.Keyword)
                || o.PhoneNumber.ToLower().Contains(input.Keyword));
            }
            query = query.OrderByDescending(x => x.CreationTime);

            var totalCount = await AsyncExecuter.CountAsync(query);

            query = query.Skip(input.SkipCount).Take(input.MaxResultCount);
            var data = await AsyncExecuter.ToListAsync(query);
            var users = ObjectMapper.Map<List<NhanVien>, List<UserInListDto>>(data);
            return new PagedResultDto<UserInListDto>(totalCount, users);
        }

        [Authorize(IdentityPermissions.Users.Create)]
        public async override Task<UserDto> CreateAsync(CreateUserDto input)
        {
            var query = await Repository.GetQueryableAsync();
            var isUserNameExisted = query.Any(x => x.UserName == input.UserName);
            if (isUserNameExisted)
            {
                throw new UserFriendlyException("Tài khoản đã tồn tại");
            }

            var isUserEmailExisted = query.Any(x => x.Email == input.Email);
            if (isUserEmailExisted)
            {
                throw new UserFriendlyException("Email đã tồn tại");
            }
            var userId = Guid.NewGuid();

            var user = new NhanVien(userId, input.UserName, input.Email)
            {
                Name = input.Name,
                Surname = input.Surname,
                MaNv = input.MaNv,
                HoTen = input.HoTen,
                NgaySinh = DateTime.SpecifyKind((DateTime)input.NgaySinh, DateTimeKind.Utc).ToLocalTime(),
                GioiTinh = input.GioiTinh,
                SoCmnd = input.SoCmnd,
                NgayCapCmnd = DateTime.SpecifyKind((DateTime)input.NgayCapCmnd, DateTimeKind.Utc).ToLocalTime(),
                NoiCapCmnd = input.NoiCapCmnd,
                DiaChi = input.DiaChi,
                PhongBanId = input.PhongBanId,
                ChucVuId = input.ChucVuId,
                NgayVaoLam = DateTime.SpecifyKind((DateTime)input.NgayVaoLam, DateTimeKind.Utc).ToLocalTime(),
                TrangThai = input.TrangThai
            };

            user.SetPhoneNumber(input.PhoneNumber, true);

            var result = await _nhanVienManager.CreateAsync(user, input.Password);
            if (result.Succeeded)
            {
                return ObjectMapper.Map<IdentityUser, UserDto>(user);
            }
            else
            {
                List<Microsoft.AspNetCore.Identity.IdentityError> errorList = result.Errors.ToList();
                string errors = "";

                foreach (var error in errorList)
                {
                    errors = errors + error.Description.ToString();
                }
                throw new UserFriendlyException(errors);
            }
        }

        [Authorize(IdentityPermissions.Users.Update)]
        public async override Task<UserDto> UpdateAsync(Guid id, UpdateUserDto input)
        {
            var user = await _nhanVienManager.FindByIdAsync(id.ToString()) as NhanVien;
            if (user == null)
            {
                throw new EntityNotFoundException(typeof(NhanVien), id);
            }
            user.Name = input.Name;
            user.SetPhoneNumber(input.PhoneNumber, true);
            user.Surname = input.Surname;

            user.HoTen = input.HoTen;
            user.NgaySinh = DateTime.SpecifyKind((DateTime)input.NgaySinh, DateTimeKind.Utc).ToLocalTime();
            user.GioiTinh = input.GioiTinh;
            user.SoCmnd = input.SoCmnd;
            user.NgayCapCmnd = DateTime.SpecifyKind((DateTime)input.NgayCapCmnd, DateTimeKind.Utc).ToLocalTime(); 
            user.NoiCapCmnd = input.NoiCapCmnd;
            user.DiaChi = input.DiaChi;
            user.PhongBanId = input.PhongBanId;
            user.ChucVuId = input.ChucVuId;
            user.NgayVaoLam = DateTime.SpecifyKind((DateTime)input.NgayVaoLam, DateTimeKind.Utc).ToLocalTime();
            user.TrangThai = input.TrangThai;

            var result = await _nhanVienManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                return ObjectMapper.Map<NhanVien, UserDto>(user);
            }
            else
            {
                List<Microsoft.AspNetCore.Identity.IdentityError> errorList = result.Errors.ToList();
                string errors = "";

                foreach (var error in errorList)
                {
                    errors = errors + error.Description.ToString();
                }
                throw new UserFriendlyException(errors);
            }
        }

        [Authorize(IdentityPermissions.Users.Default)]
        public async override Task<UserDto> GetAsync(Guid id)
        {
            var user = await _nhanVienManager.FindByIdAsync(id.ToString());
            if (user == null)
            {
                throw new EntityNotFoundException(typeof(IdentityUser), id);
            }
            var userDto = ObjectMapper.Map<IdentityUser, UserDto>(user);

            //Get roles from users
            var roles = await _nhanVienManager.GetRolesAsync(user);
            userDto.Roles = roles;
            return userDto;
        }

        [Authorize(IdentityPermissions.Users.Update)]
        public async Task AssignRolesAsync(Guid userId, string[] roleNames)
        {
            var user = await _nhanVienManager.FindByIdAsync(userId.ToString());
            if (user == null)
            {
                throw new EntityNotFoundException(typeof(IdentityUser), userId);
            }
            var currentRoles = await _nhanVienManager.GetRolesAsync(user);
            var removedResult = await _nhanVienManager.RemoveFromRolesAsync(user, currentRoles);
            var addedResult = await _nhanVienManager.AddToRolesAsync(user, roleNames);
            if (!addedResult.Succeeded || !removedResult.Succeeded)
            {
                List<Microsoft.AspNetCore.Identity.IdentityError> addedErrorList = addedResult.Errors.ToList();
                List<Microsoft.AspNetCore.Identity.IdentityError> removedErrorList = removedResult.Errors.ToList();
                var errorList = new List<Microsoft.AspNetCore.Identity.IdentityError>();
                errorList.AddRange(addedErrorList);
                errorList.AddRange(removedErrorList);
                string errors = "";

                foreach (var error in errorList)
                {
                    errors = errors + error.Description.ToString();
                }
                throw new UserFriendlyException(errors);
            }
        }

        [Authorize(IdentityPermissions.Users.Update)]
        public async Task SetPasswordAsync(Guid userId, SetPasswordDto input)
        {
            var user = await _nhanVienManager.FindByIdAsync(userId.ToString());
            if (user == null)
            {
                throw new EntityNotFoundException(typeof(IdentityUser), userId);
            }
            var token = await _nhanVienManager.GeneratePasswordResetTokenAsync(user);
            var result = await _nhanVienManager.ResetPasswordAsync(user, token, input.NewPassword);
            if (!result.Succeeded)
            {
                List<Microsoft.AspNetCore.Identity.IdentityError> errorList = result.Errors.ToList();
                string errors = "";

                foreach (var error in errorList)
                {
                    errors = errors + error.Description.ToString();
                }
                throw new UserFriendlyException(errors);
            }
        }
    }
}
