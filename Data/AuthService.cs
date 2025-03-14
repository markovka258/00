using Microsoft.EntityFrameworkCore;


namespace WorkCalendar.Data
{
    public class AuthService
    {
        private readonly AppDbContext _context;

        public AuthService(AppDbContext context)
        {
            _context = context;
        }

        public bool Login(string username, string password)
        {
            var user = _context.Users.FirstOrDefault(u => u.Username == username);
            if (user != null && VerifyPassword(password, user.PasswordHash))
            {
                return true;
            }
            return false;
        }

        private bool VerifyPassword(string password, string passwordHash)
        {
            // Реализуйте проверку пароля (например, с использованием BCrypt)
            return BCrypt.Net.BCrypt.Verify(password, passwordHash);
        }
    }
}
