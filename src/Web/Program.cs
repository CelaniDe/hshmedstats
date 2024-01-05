using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using hshmedstats.Persistence;
using hshmedstats.Application;
using hshmedstats.Application.Mappers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using hshmedstats.Application.Models;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using hshmedstats.Web.Helpers;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
builder.InitLogger(builder.Environment.IsDevelopment());
builder.Host.UseSerilog();

builder.Services.AddAutoMapper(typeof(PatientProfile), typeof(hshmedstats.Application.DependancyInjection));
builder.Services.AddHttpContextAccessor();

builder.Services.AddCore();
builder.Services.AddPersistence(builder.Configuration);


builder.Services.AddControllersWithViews(options =>
{
    options.MaxModelBindingCollectionSize = int.MaxValue;
}).AddRazorRuntimeCompilation();



var appSettingsSection = builder.Configuration.GetSection("AppSettings");
builder.Services.Configure<AppSettings>(appSettingsSection);
var appSettings = appSettingsSection.Get<AppSettings>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
   .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, opt =>
   {
       var key = Encoding.ASCII.GetBytes(appSettings.Secret);
       if (builder.Environment.IsDevelopment())
       {
           opt.RequireHttpsMetadata = false;
       }
       opt.SaveToken = true;
       opt.TokenValidationParameters = new TokenValidationParameters
       {
           ValidateIssuerSigningKey = true,
           IssuerSigningKey = new SymmetricSecurityKey(key),
           ValidateIssuer = false,
           ValidateAudience = false,
       };
   });

builder.Services.AddSession();

var app = builder.Build();
await app.SeedDatabase();

// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Error/Index");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSession();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=User}/{action=Login}/{id?}");
});