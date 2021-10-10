using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trax.Services;
using Trax.Services.Repository.IRepository;

namespace Trax
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("Trax")));
            services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<AppDbContext>();
            services.AddScoped<ISocial, Trax.Services.Repository.Social>();
            services.AddScoped<ISetting, Trax.Services.Repository.Setting>();
            services.AddScoped<ISubscribe, Trax.Services.Repository.Subscribe>();
            services.AddScoped<ICounters, Trax.Services.Repository.Counters>();
            services.AddScoped<IProcessType, Trax.Services.Repository.ProcessType>();
            services.AddScoped<IProcess, Trax.Services.Repository.Process>();
            services.AddScoped<IPartner, Trax.Services.Repository.Partner>();
            services.AddScoped<IExpert, Trax.Services.Repository.Expert>();
            services.AddScoped<ITeamMember, Trax.Services.Repository.TeamMember>();
            services.AddScoped<ITestimonial, Trax.Services.Repository.Testimonial>();
            services.AddScoped<ISetting, Trax.Services.Repository.Setting>();
            services.AddScoped<IContact, Trax.Services.Repository.Contact>();
            services.AddScoped<IPage, Trax.Services.Repository.Page>();
            services.AddScoped<IPageDetail, Trax.Services.Repository.PageDetail>();
            services.AddScoped<IPosition, Trax.Services.Repository.Position>();
            services.AddScoped<ITeamMember, Trax.Services.Repository.TeamMember>();
            services.AddScoped<ISocialToTeamMember, Trax.Services.Repository.SocialToTeamMember>();
            services.AddScoped<IGallery, Trax.Services.Repository.Gallery>();
            services.AddScoped<IGalleryCategory, Trax.Services.Repository.GalleryCategory>();
            services.AddScoped<IService, Trax.Services.Repository.Service>();
            services.AddScoped<IServiceCategory, Trax.Services.Repository.ServiceCategory>();
            services.AddScoped<IServiceImage, Trax.Services.Repository.ServiceImage>();
            services.AddScoped<IAccordion, Trax.Services.Repository.Accordion>();
            services.AddScoped<IServiceCategory, Trax.Services.Repository.ServiceCategory>();
            services.AddScoped<IMessage, Trax.Services.Repository.Message>();
            services.AddScoped<IConsultation, Trax.Services.Repository.Consultation>();
            services.AddScoped<IHomeOne, Trax.Services.Repository.HomeOne>();
            services.AddScoped<IAbout, Trax.Services.Repository.About>();
            services.AddScoped<ISkill, Trax.Services.Repository.Skill>();
            services.AddScoped<ISlider, Trax.Services.Repository.Slider>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapAreaControllerRoute(
                    name: "areas",
                    areaName: "admin",
                    pattern: "Admin/{controller=Account}/{action=Login}/{id?}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
