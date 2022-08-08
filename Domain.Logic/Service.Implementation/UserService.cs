using AutoMapper;
using DataAccess.Entities.Entities;
using DataAccess.SQLServer;
using Domain.Logic.MappingDTO;
using Domain.Logic.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Logic.Service.Implementation
{
    public class UserService : IService<UserDTO>
    {
        private readonly ITestAppKeptDbContext _testAppKeptDbContext;

        private readonly IMapper _mapper;
        public UserService(ITestAppKeptDbContext testAppKeptDbContext, IMapper mapper)
        {
            _testAppKeptDbContext = testAppKeptDbContext;
            _mapper = mapper;
        }

        public void CreateAsync(string Name, CancellationToken cancellationToken, string userName = "undefined")
        {
            var newUserDTO = new UserDTO 
            { 
                UserName = userName, 
                Company = new CompanyDTO  { CompanyName = Name }
            };

            var newUser = _mapper.Map<User>(newUserDTO);

            var company = _testAppKeptDbContext.Companies.AsNoTracking().FirstOrDefault(c => c.CompanyName.Equals(Name));

            if (company != null)
            {
                newUser.Company = company;

                _testAppKeptDbContext.Entry(company).State = EntityState.Unchanged;

                _testAppKeptDbContext.Users.AddAsync(newUser);

                _testAppKeptDbContext.SaveChangesAsync(cancellationToken);
            }
            else
            {
                _testAppKeptDbContext.Users.AddAsync(newUser);

                _testAppKeptDbContext.SaveChangesAsync(cancellationToken);
            }
        }

        public async Task<IEnumerable<UserDTO>> GetAllAsync()
        {
            var users = await _testAppKeptDbContext.Users.Include(u => u.Company).ToListAsync();

            var usersDto = _mapper.Map<IEnumerable<UserDTO>>(users);

            return usersDto;
        }

        public async Task<UserDTO> GetByNameAsync(string Name)
        {
            var user = await _testAppKeptDbContext.Users.Include(c => c.Company).FirstOrDefaultAsync(c => c.UserName.Equals(Name));

            //if (user == null)
            //{
            //    UserDTO userDtoNull = new UserDTO();
            //    return userDtoNull;
            //}

            var userDto = _mapper.Map<UserDTO>(user);

            return userDto;
        }

        public void UpdateAsync(string userName, string newUserName, CancellationToken cancellationToken)
        {
            var user = _testAppKeptDbContext.Users.Include(c => c.Company).AsNoTracking().FirstOrDefault(c => c.UserName.Equals(userName));

            if (user == null)
            {
                
            }

            var userDto = _mapper.Map<UserDTO>(user);

            userDto.UserName = newUserName;

            user = _mapper.Map<User>(userDto);


            _testAppKeptDbContext.Entry(user).State = EntityState.Modified;

            _testAppKeptDbContext.SaveChangesAsync(cancellationToken);
        }

    }
}
