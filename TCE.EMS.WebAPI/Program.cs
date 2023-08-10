using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authorization;
using log4net;
using System.Reflection;
using Newtonsoft.Json.Serialization;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//For MVC Authentication
builder.Services.AddAuthentication(options =>
{
    options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
})
.AddCookie(options =>
{
    options.LoginPath = new PathString("/Login");
    options.ExpireTimeSpan = TimeSpan.FromMinutes(double.Parse(builder.Configuration["SessionTimeout"]));
    
});

// // Authorization settings.  
// builder.Services.AddAuthorization(options =>
// {
    
//     options.FallbackPolicy = new AuthorizationPolicyBuilder()
//         .RequireAuthenticatedUser()
//         .Build();
// });

//Enable Session Timeout
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(double.Parse(builder.Configuration["SessionTimeout"]));
});



// Add services to the container.
builder.Services.AddRazorPages();
var mContolllers = builder.Services.AddControllers();

//To avoid Json property auto formatting
mContolllers.AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
mContolllers.AddNewtonsoftJson(x => x.UseMemberCasing());

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpContextAccessor();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


//app.UseHttpsRedirection();

app.UseAuthentication();
app.UseSession();
app.UseAuthorization();


app.MapControllers();
// Shows UseCors with CorsPolicyBuilder.
app.UseCors(builder =>
{
    builder.WithOrigins()
        .AllowAnyMethod()
        .AllowAnyHeader();
});



app.Run();
