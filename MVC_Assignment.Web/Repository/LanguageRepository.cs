using Microsoft.EntityFrameworkCore;
using MVC_Assignment_1.Data;
using MVC_Assignment_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Assignment_1.Repository
{

    public class LanguageRepository
    {
        private readonly BookStoreContext _context = null;

        public LanguageRepository(BookStoreContext context)
        {
            _context = context;
        }

        public async Task<List<LanguageModel>> GetLanguages()
        {
            return await _context.Language.Select(x => new LanguageModel()
            {
                Id=x.Id,
                Description=x.Description,
                Name=x.Name,

            }).ToListAsync();
        }

    }
}
