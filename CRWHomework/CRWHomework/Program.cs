using CRWHomework.DataAccess;
using CRWHomework.Formatters;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace CRWHomework
{
    public class Program
    {
        public static void Main(string[] args)
        {
             var serviceProvider = new ServiceCollection()
            .AddSingleton<IDataAccess, FileSystem>()
            .AddSingleton<IDataAccess, Cloud>()
            .AddSingleton<IFormat, XmlFormat>()
            .AddSingleton<IFormat, JsonFormat>()
            .BuildServiceProvider();

            var dataAccess = serviceProvider.GetServices<IDataAccess>();
            var formatters = serviceProvider.GetServices<IFormat>();
                       
            ProcessData process = new ProcessData(dataAccess, formatters);
            try
            {
                process.Logic();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}