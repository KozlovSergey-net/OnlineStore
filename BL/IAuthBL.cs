using Microsoft.AspNetCore.Identity.Data;
using OnlineStore.DAL.Models;
using System.ComponentModel.DataAnnotations;

namespace OnlineStore.BL
{
    public interface IAuthBL 
    {
        Task<int> CreateUser(UserModel user);
        Task<int> GetUser(string Email, string Password);
        Task<ValidationResult> ValidEmail(string Email);


    }
}
