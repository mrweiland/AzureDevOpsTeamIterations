using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace TfsIterations
{
    class Program
    {
        internal static IConfiguration Configuration { get; set; }


        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            Configuration = builder.Build();
            TfsVariables.Teams = Configuration.GetSection("teams").GetChildren().ToList();
            TfsVariables.Collection = Configuration["collection"];
            TfsVariables.BaseUrl = Configuration["baseUrl"];
            TfsVariables.TeamDefaultBacklogIteration = Configuration["teamDefaultBacklogIteration"];
            TfsVariables.Project = Configuration["project"];
            TfsVariables.PersonalAccessToken = Configuration["personalAccessToken"];
            TfsVariables.IterationToAddToTeams = Configuration.GetSection("iterationToAddToTeams").GetChildren().ToList();

            //RunAsync().GetAwaiter().GetResult();
            RunIterationAddToTeams().GetAwaiter().GetResult();
            Console.WriteLine("Done");
            Console.ReadLine();
        }

        //static async Task RunAsync()
        //{
            
        //    //var x = await TfsApi.GetProjects();

        //}
        static async Task RunIterationAddToTeams()
        {           
            await AddIterationToTeams.CreateIteration(Configuration);

        }
    }


    public class TfsVariables
    {
        public static string Collection { get; set; }
        public static List<IConfigurationSection> Teams { get; set; }
        public static string BaseUrl { get; internal set; }
        public static string Project { get; internal set; }
        public static string PersonalAccessToken { get; set; }
        public static List<IConfigurationSection> IterationToAddToTeams { get; set; }

        public static string TeamDefaultBacklogIteration { get; set; }

    }
}
