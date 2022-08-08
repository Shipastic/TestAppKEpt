using DataAccess.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.SQLServer
{
    public class DbInitialize
    {
        public static void Initial(ITestAppKeptDbContext testAppKeptDbContext)
        {
            if (!testAppKeptDbContext.Companies.Any())
            {
                testAppKeptDbContext.Companies.AddRange(_comp.Select(c => c.Value));
            }

            if (!testAppKeptDbContext.Users .Any())
            {
                testAppKeptDbContext.Users.AddRange(_user.Select(c => c.Value));
            }
        }

        private static Dictionary<string, Company> _comp;
        public static Dictionary<string, Company> Companies
        {
            get
            {
                if (_comp == null)
                {
                    var list = new Company[]
                        {
                        new Company 
                        { 
                            Id = 1, 
                            CompanyName = "KEPT" 
                        },
                        new Company 
                        { 
                            Id = 2, 
                            CompanyName = "EPAM" 
                        },
                        new Company 
                        { 
                            Id = 3, 
                            CompanyName = "AURIGA" 
                        },
                        new Company 
                        { 
                            Id = 4, 
                            CompanyName = "DSPACE" 
                        },
                        };

                    _comp = new Dictionary<string, Company>();

                    foreach (Company comp in list)
                    {
                        _comp.Add(comp.CompanyName, comp);
                    }
                }
                return _comp;
            }
        }

        private static Dictionary<string, User> _user;
        public static Dictionary<string, User> Users
        {
            get
            {
                if (_user == null)
                {
                    var list = new User[]
                        {
                            new User
                            {
                                Id = 1,
                                UserName = "Alex",
                                CompanyId = 1,
                                Company = Companies["KEPT"]
                            },
                            new User
                            {
                                Id = 2,
                                UserName = "Denis",
                                CompanyId = 1,
                                Company = Companies["KEPT"]
                            },
                            new User
                            {
                                Id = 3,
                                UserName = "Petr",
                                CompanyId = 2,
                                Company = Companies["EPAM"]
                            },
                            new User
                            {
                                Id = 4,
                                UserName = "Max",
                                CompanyId = 3,
                                Company = Companies["AURIGA"]
                            },
                            new User
                            {
                                Id = 5,
                                UserName = "Dmitriy",
                                CompanyId = 2,
                                Company = Companies["EPAM"]
                            },
                            new User
                            {
                                Id = 6,
                                UserName = "Maria",
                                CompanyId = 4,
                                Company = Companies["DSPACE"]
                            },
                            new User
                            {
                                Id = 7,
                                UserName = "Anna",
                                CompanyId = 4,
                                Company = Companies["DSPACE"]
                            },
                            new User
                            {
                                Id = 8,
                                UserName = "Yulia",
                                CompanyId = 3,
                                Company = Companies["AURIGA"]},
                        };
                    _user = new Dictionary<string, User>();

                    foreach (User user in list)
                    {
                        _user.Add(user.UserName, user);
                    }
                }
                return _user;
            }
        }
    }
}
