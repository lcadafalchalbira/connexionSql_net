using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using AdventureData.DAL;

namespace AdventureData
{
    class Program
    {
        private static IConfiguration _iconfiguration;
        static void Main(string[] args)
        {
            GetAppSettingsFile();
            ShowAdventureDepartments();
            Console.WriteLine("Press any key to stop.");
            Console.ReadKey();
        }

        static void GetAppSettingsFile()
        {
            var builder = new ConfigurationBuilder()
                                 .SetBasePath(Directory.GetCurrentDirectory())
                                 .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            _iconfiguration = builder.Build();
        }        
        static void ShowAdventureDepartments()
        {
            var deptDAL = new DepartmentDAL(_iconfiguration);
            var lstDepartment = deptDAL.GetAllDepartments();
            lstDepartment.ForEach(item =>
            {
                Console.WriteLine($"Id: {item.Id}" +
                    $" FirstName: {item.FirstName}" +
                    $" LastName: {item.LastName}" +
                    $" Username: {item.Username}" +
                    $" Date: {DateTime.Now}");
            });            
        }
    }
}
