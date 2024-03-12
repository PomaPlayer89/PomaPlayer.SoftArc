using Microsoft.EntityFrameworkCore;
using PomaPlayer.SoftArc.Components.Extensions;
using PomaPlayer.SoftArc.Logic.Extensions;
using PomaPlayer.SoftArc.Storage.Database;
using PomaPlayer.SoftArc.Storage.MS_SQL.Extensions;
using PomaPlayer.SoftArc.Storage.MS_SQL.InitDatabase;
using PomaPlayer.SoftArc.Web.Extensions;

// todo: необходимо добавить логирование в проект

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"), o =>
    {
        // todo: ќзнакомтесь с пон€тием декартова взрыва, AsSplitQuery
        o.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);
    }));

// Add services to the container.
builder.Services
    .AddControllersWithViews()
    .AddDataAnnotationsLocalization()
    .AddTagComponents()
    .AddNewtonsoftJson();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMappers();
builder.Services.AddLogicServices();
builder.Services.AddStorageServices();
builder.Services.AddFeaturesServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
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

app.UseSwagger();
app.UseSwaggerUI();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

var databaseInit = app.Services.GetRequiredService<DatabaseInit>();
databaseInit.InternalSeed();

app.Run();
