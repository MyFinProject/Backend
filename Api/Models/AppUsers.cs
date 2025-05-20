using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
namespace Api.Models
{
    public class AppUser : IdentityUser
    {
        public List<Budget> Budgets { get; set; } = new List<Budget>();
        public List<UserWallets> UserAccounts { get; set; } = new List<UserWallets>();

    }
}