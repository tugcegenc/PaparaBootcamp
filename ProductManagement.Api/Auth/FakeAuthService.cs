using ProductManagement.Api.Models;

namespace ProductManagement.Api.Auth;

public class FakeAuthService
{
    private static List<User> _users = new List<User>
    {
        new User { Id = 1, Username = "admin", Password = "admin123" },
        new User { Id = 2, Username = "user", Password = "user123" }
    };

    public static User? Authenticate(string username, string password)
    {
        return _users.FirstOrDefault(u => u.Username == username && u.Password == password);
    }
}