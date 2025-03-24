using Logic.Model;

namespace Logic
{
    public interface IUserService
    {
        Task<LogInResponse> LogInAsync();
    }
}
