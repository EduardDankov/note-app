using Microsoft.EntityFrameworkCore;

using NoteApp.Api;
using NoteApp.Api.Interfaces;
using NoteApp.Api.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<Database>(optionsAction => optionsAction.UseInMemoryDatabase("NoteApp"));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddScoped<INoteService, NoteService>();
builder.Services.AddControllers().AddControllersAsServices();

var app = builder.Build();
app.UseHttpsRedirection();
app.UseRouting();

app.MapControllers();

app.Run();
