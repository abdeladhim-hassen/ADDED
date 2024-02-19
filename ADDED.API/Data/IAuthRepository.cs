using System.Threading.Tasks;
using ADDED.API.Dtos;
using ADDED.API.Models;

namespace ADDED.API.Data
{
    public interface IAuthRepository
    {       
        Task<Chef> Register(Chef chef, string password);
        Task<Chef> Login(string MailTel, string password);
        Task<bool> ChefExists(MailTel  mailTel);
    }
}