﻿using CatalogService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogService.Domain.Repositories
{
    public interface ICourseRepository : IRepository<Course>
    {
        Task<List<Course>> GetAllByUserIdAsync(string userId);
    }
}
