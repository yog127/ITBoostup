using ITBoostUp.BusinessLayer.IRepository;
using ITBoostUp.DataAccessLayer.Repository;
using ITBoostUp.Presentation.Filters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews(option =>
{
    option.Filters.Add(new ExceptionFilter());
    //option.Filters.Add(new ActionFilter());
    //option.Filters.Add(new AuthorizationFilter());
    //option.Filters.Add(new ResultFilter());

});
builder.Services.AddScoped<ActionFilter>();
builder.Services.AddScoped<ExceptionFilter>();
builder.Services.AddScoped<AuthorizationFilter>();
builder.Services.AddScoped<ResultFilter>();

builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();
builder.Services.AddScoped<ICountryRepository, CountryRepository>();
builder.Services.AddScoped<IStateRepository, StateRepository>();

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
