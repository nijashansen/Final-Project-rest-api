using FinalProject.Core.Entity;
using System;
using FinalProject.Core.DomainService;
using FinalProject.Infrastructure.Static.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;
using FinalProject.Core.ApplicationService;
using FinalProject.Core.ApplicationService.Services;

namespace consoleapp
{
    class Program
    { 
        static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddScoped<IErrorRepository, ErrorRepository>();
            serviceCollection.AddScoped<IErrorService, ErrorService>();
            serviceCollection.AddScoped<IPrinter, Printer>();

            var serviceProvider = serviceCollection.BuildServiceProvider();
            var printer = serviceProvider.GetRequiredService<IPrinter>();

            printer.start();

            Console.ReadLine();
        }
    }
}
