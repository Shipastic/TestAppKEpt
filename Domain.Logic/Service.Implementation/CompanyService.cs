using AutoMapper;
using DataAccess.Entities.Entities;
using DataAccess.SQLServer;
using Domain.Logic.MappingDTO;
using Domain.Logic.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Logic.Service.Implementation
{
    public class CompanyService : IService<CompanyDTO>
    {
        private readonly ITestAppKeptDbContext _testAppKeptDbContext;

        private readonly IMapper _mapper;

        public CompanyService(ITestAppKeptDbContext testAppKeptDbContext, IMapper mapper)
        {
            _testAppKeptDbContext = testAppKeptDbContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CompanyDTO>> GetAllAsync()
        {
            var companies = await _testAppKeptDbContext.Companies.Include(c => c.Users).ToListAsync();

            var companiesDto =  _mapper.Map<IEnumerable<CompanyDTO>>(companies);

            return companiesDto;
        }

        public async Task<CompanyDTO> GetByNameAsync(string name)
        {

            var company = await _testAppKeptDbContext.Companies.Include(c => c.Users).FirstOrDefaultAsync(c => c.CompanyName.Equals(name));// FindAsync(id);

            if (company == null)
            {
                throw new EntityNotFoundException();
            }

            var companyDto = _mapper.Map<CompanyDTO>(company);
         
            return companyDto;
        }

        public   void UpdateAsync(string CompanyName, string newCompanyName, CancellationToken cancellationToken)
        {
            var company =  _testAppKeptDbContext.Companies.Include(c => c.Users).AsNoTracking().FirstOrDefault(c => c.CompanyName.Equals(CompanyName));

            if (company == null)
            {
                throw new EntityNotFoundException();
            }

            var updateCompanyDto = _mapper.Map<UpdateCompanyDTO>(company);

            updateCompanyDto.CompanyName = newCompanyName;

            company = _mapper.Map<Company>(updateCompanyDto);


            _testAppKeptDbContext.Entry(company).State = EntityState.Modified;

            _testAppKeptDbContext.SaveChangesAsync(cancellationToken);

        }

        public  void CreateAsync(string companyName, CancellationToken cancellationToken, string userName = "undefined")
        {
            var newCompanyDTO = new CompanyDTO { CompanyName = companyName };

            var newCompany = _mapper.Map<Company>(newCompanyDTO);

            _testAppKeptDbContext.Companies.AddAsync(newCompany);

             _testAppKeptDbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
