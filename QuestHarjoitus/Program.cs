using QuestHarjoitus;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<QuestDb>(opt => opt.UseInMemoryDatabase("Questlist"));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

var app = builder.Build(); app.MapGet("/quest", async (QuestDb db) => await db.Quests.ToListAsync());

app.MapGet("/quest/{id}", async (int id, QuestDb db) => await db.Quests.FindAsync(id) is Quest quest 
    ? Results.Ok(quest) 
    : Results.NotFound());

app.MapPost("/quest", async (Quest quest, QuestDb db) => 
{ 
    db.Quests.Add(quest); await db.SaveChangesAsync();
    return Results.Created($"/quest/{quest.Id}", quest);
});
app.Run();



