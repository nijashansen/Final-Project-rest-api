using FinalProject.Core.Entity;
using FinalProjectAPI.Data;
using FinalProjectAPI.Helpers;

namespace FinalProject.Infrastructure.Data
{
    public class DBSeeder: IDBSeeder
    {
        private IAuthenticationHelper authenticationHelper;

        public DBSeeder(IAuthenticationHelper authHelper)
        {
            authenticationHelper = authHelper;
        }

        public void SeedDB(ErrorContext ctx)
        {
            ctx.Database.EnsureDeleted();
            ctx.Database.EnsureCreated();

            var process1 = ctx.Processes.Add(new Process()
            {
                ProcessName = "Startslut2"
            }).Entity;

            var process2 = ctx.Processes.Add(new Process()
            {
                ProcessName = "CCB live objekt"
            }).Entity;

            var process3 = ctx.Processes.Add(new Process()
            {
                ProcessName = "Lukkeordre for sortseere"
            }).Entity;

            var error1 = ctx.Errors.Add(new Error()
            {
                ErrorDetail = "dax failed",
                ErrorType = "System exception",
                Process = process1
            }).Entity;

            var error2 = ctx.Errors.Add(new Error()
            {
                ErrorDetail = "ccb failed",
                ErrorType = "System exception",
                Process = process2
            }).Entity;

            var error3 = ctx.Errors.Add(new Error()
            {
                ErrorDetail = "ccb failed",
                ErrorType = "System exception",
                Process = process2
            }).Entity;

            var error4 = ctx.Errors.Add(new Error()
            {
                ErrorDetail = "information not valid",
                ErrorType = "Buissnes exception",
                Process = process3
            }).Entity;

            var error5 = ctx.Errors.Add(new Error()
            {
                ErrorDetail = "process failed",
                ErrorType = "System exception",
                Process = process3
            });

            var error6 = ctx.Errors.Add(new Error()
            {
                ErrorDetail = "CCB failed",
                ErrorType = "System exception",
                Process = process3
            });

            string password = "1234";
            byte[] passwordHashUser, passwordSaltUser, passwordHashAdmin, passwordSaltAdmin;
            authenticationHelper.CreatePasswordHash(password, out passwordHashUser, out passwordSaltUser);
            authenticationHelper.CreatePasswordHash(password, out passwordHashAdmin, out passwordSaltAdmin);

            var adminAnn = ctx.Users.Add(new User()
            {
                IsAdmin = true,
                PasswordHash = passwordHashAdmin,
                PasswordSalt = passwordSaltAdmin,
                Username = "Admin",
            });

            var userJoe = ctx.Users.Add(new User()
            {
                IsAdmin = false,
                PasswordHash = passwordHashUser,
                PasswordSalt = passwordSaltUser,
                Username = "User",
            });

            ctx.SaveChanges();
        }

    }
}
