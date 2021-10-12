using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<IResponseRepository, ResponseRepository>();
var app = builder.Build();

app.MapGet("/responses", ([FromServices] IResponseRepository repo) =>
	repo.GetAll()
);

app.MapGet("/responses/{id}", GetResponseById);

app.MapPost("/responses", ([FromServices] IResponseRepository repo, Response response) =>
{
	repo.Create(response);
	return Results.Created($"/responses/{response.Id}", response);
});

app.MapPut("/responses/{id}", ([FromServices] IResponseRepository repo, Response response) =>
{
	repo.Update(response);
	return Results.Ok(response);
});

app.MapDelete("/responses/{id}", ([FromServices] IResponseRepository repo, Guid id) =>
{
	repo.Delete(id);
	return Results.Ok();
});

IResult GetResponseById(IResponseRepository repo, Guid id)
{
	var response = repo.GetById(id);
	return response is not null ? Results.Ok(response) : Results.NotFound();
}


app.Run();
