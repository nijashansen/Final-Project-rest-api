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
                ProcessName = "Dax Tester"
            }).Entity;

            var process2 = ctx.Processes.Add(new Process()
            {
                ProcessName = "CCB Tester"
            }).Entity;

            var process3 = ctx.Processes.Add(new Process()
            {
                ProcessName = "startslut2 Tester"
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
                ErrorDetail = "startslut2 failed",
                ErrorType = "System exception",
                Process = process3
            }).Entity;

            var error5 = ctx.Errors.Add(new Error()
            {
                ErrorDetail = "startslut2 failed",
                ErrorType = "System exception",
                Process = process3
            });

            var error6 = ctx.Errors.Add(new Error()
            {
                ErrorDetail = "startslut2 failed",
                ErrorType = "System exception",
                Process = process3
            });

            string password = "1234";
            byte[] passwordHashJoe, passwordSaltJoe, passwordHashAnn, passwordSaltAnn;
            authenticationHelper.CreatePasswordHash(password, out passwordHashJoe, out passwordSaltJoe);
            authenticationHelper.CreatePasswordHash(password, out passwordHashAnn, out passwordSaltAnn);

            var adminAnn = ctx.Users.Add(new User()
            {
                IsAdmin = true,
                PasswordHash = passwordHashAnn,
                PasswordSalt = passwordSaltAnn,
                Username = "AdminAnn",
            });

            var userJoe = ctx.Users.Add(new User()
            {
                IsAdmin = false,
                PasswordHash = passwordHashJoe,
                PasswordSalt = passwordSaltJoe,
                Username = "userJoe",
            });

            ctx.SaveChanges();
        }

    }
}
