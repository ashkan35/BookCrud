using System.Threading.Tasks;

namespace Application.Contracts.Services
{
    public interface ISmsService
    {
        Task<bool> SendVerificationCode(string phoneNumber,string code);
    }
}