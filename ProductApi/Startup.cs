using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using ProductApi.Models;

namespace ProductApi
{
    public class Startup
    {
        //dummy data
        private string[] descs = { "large tv", "22in monitor", "4k tv", "1080p tv", "144p tv" };
        private string[] models = { "A100", "IPS9000", "OLED117" };
        private string[] brands = { "GL", "SUSA", "ACE", "PAN", "TKL" };

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //database context is registered with dependency injection (DI) container
            //services that are registered with DI are available to the controllers
            //specifies an in memory database and is injected into the service container
            services.AddDbContext<ProductContext>(opt => opt.UseInMemoryDatabase("ProductList"));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetService<ProductContext>();
            PopulateDB(context, 20);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            //serving static files and enabling default file mapping
            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseHttpsRedirection();
            app.UseMvc();
        }

        //filling database with products
        private void PopulateDB(ProductContext context, int i)
        {
            for (int n = 0; i > n; n++)
            {
                AddProduct(context, i);
            }
            context.SaveChanges();
        }

        //adding individual product
        private void AddProduct(ProductContext context, int i)
        {
            Random rnd = new Random();
            context.ProductList.Add(new Product { Description = descs[rnd.Next(0, descs.Count())], Model = models[rnd.Next(0, models.Count())], Brand = brands[rnd.Next(0, brands.Count())] });
        }
    }
}
