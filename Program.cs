using System;

using BD9.Models;

using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;   // ������������ ���� ������ ApplicationContext
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);//��� DateTime
var builder = WebApplication.CreateBuilder(args);

// �������� ������ ����������� �� ����� ������������

// ��������� �������� ApplicationContext � �������� ������� � ����������
builder.Services.AddDbContext<ApplicationContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("Postgres"));
});
builder.Services.AddRazorPages();

var app = builder.Build();
app.UseStaticFiles();
app.UseRouting();
app.MapRazorPages();
using (var scope = app.Services.CreateScope())
{
    var serviceProvider = scope.ServiceProvider;


    var db = serviceProvider.GetRequiredService<ApplicationContext>();
    await db.Database.EnsureDeletedAsync();
    await db.Database.EnsureCreatedAsync();
    await ApplicationContextSeed.InitializeDb(db);

}
app.Run();