using Grud.Cars.Application.Data.Entities;
using Grud.Cars.Application.Interfaces;
using Grud.Cars.Application.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddSingleton<ICarService, CarService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.MapGet("/api/cars", (ICarService service) =>
{
    return Results.Ok(service.GetAll());
});

app.MapGet("/api/car/{id:int}", (int id, ICarService service) =>
{
    var car = service.GetById(id);
    return car;
});

app.MapMethods("/api/remove", new[] { "POST" }, (Car car, ICarService service) =>
{
    service.Remove(car);
    return Results.Ok();
});
app.MapMethods("/api/save", new[] { "POST"}, (Car car, ICarService service) =>
{
    service.Save(car);
    return Results.Ok();
});


app.Run();
