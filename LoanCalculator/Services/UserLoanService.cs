using LoanCalculator.Data;
using LoanCalculator.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoanCalculator.Services
{
    public interface IUserLoanService
    {
        Task<UserLoans> Add(UserLoans loan);
        Task<UserLoans> Delete(int id);
        Task<UserLoans> Get(int id);
        Task<List<UserLoans>> GetByUser(ApplicationUser user);
        Task<UserLoans> Update(UserLoans loan);
    }
    public class UserLoanService : IUserLoanService
    {
        private readonly ApplicationDbContext _context;
        public UserLoanService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<UserLoans>> GetByUser(ApplicationUser user)
        {
            return await _context.UserLoans.Where(x => x.User == user).ToListAsync();
        }

        public async Task<UserLoans> Get(int id)
        {
            UserLoans loan = await _context.UserLoans.FindAsync(id);
            return loan;
        }

        public async Task<UserLoans> Add(UserLoans loan)
        {
            _context.UserLoans.Add(loan);
            await _context.SaveChangesAsync();
            return loan;
        }

        public async Task<UserLoans> Update(UserLoans loan)
        {
            _context.Update(loan);
            await _context.SaveChangesAsync();
            return loan;
        }

        public async Task<UserLoans> Delete(int id)
        {
            UserLoans loan = await _context.UserLoans.FindAsync(id);
            _context.UserLoans.Remove(loan);
            await _context.SaveChangesAsync();
            return loan;
        }
    }
}
