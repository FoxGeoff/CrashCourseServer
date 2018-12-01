using CrashCourseServer.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CrashCoreServer
{
    public class DataSeeder
    {
        private EntryDbContext _context;
        private IHostingEnvironment _hosting;

        public DataSeeder(EntryDbContext context, IHostingEnvironment hosting)
        {
            _context = context;
            _hosting = hosting;
        }

        public static void InitializeData(IServiceProvider services)
        {
            using (var serviceScope = services.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var env = serviceScope.ServiceProvider.GetService<IHostingEnvironment>();
                if (!env.IsDevelopment()) { return; }

                var seederManager = serviceScope.ServiceProvider.GetRequiredService<DataSeeder>();
                seederManager.Seed();
            }
        }

        public void Seed()
        {
            if (!_context.Entries.Any())
            {
                var filepath = Path.Combine(_hosting.ContentRootPath, "Resources/Entries.json");
                var json = File.ReadAllText(filepath);

                /* Mapping to Dtos TBD
                var dtoProductImages = JsonConvert.DeserializeObject<IEnumerable<Dtos.product_image>>(json);
                var productImages = ConvertToProductImages(dtoProductImages);
                */

                var entries = JsonConvert.DeserializeObject<IEnumerable<Entry>>(json);
                _context.Entries.AddRange(entries);
                _context.SaveChanges();
            }
        }
    }
}