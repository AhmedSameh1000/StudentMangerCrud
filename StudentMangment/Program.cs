using Microsoft.EntityFrameworkCore;
using StudentMangmentBLL.Interfaces;
using StudentMangmentBLL.repositories;
using StudentMangmentDAL.DbContxet;
using StudentMangmentDAL.models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
//builder.Services.AddControllersWithViews();
// Add services to the container.

//builder.Services.AddScoped<IStudetRepository, StudentRepository>();

//builder.Services.AddScoped<ISubjectRepository , SubjectRepository>();

//builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddControllersWithViews();
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<StudentDbContect>(options =>

                   options.UseSqlServer(connectionString));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();