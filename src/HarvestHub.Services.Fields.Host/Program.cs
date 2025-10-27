using HarvestHub.Services.Fields.Api;
using HarvestHub.Shared.Exceptions;
using HarvestHub.Shared;
using HarvestHub.Services.Fields.Shared.Events.Fields;
using HarvestHub.Shared.Messaging;
using HarvestHub.Services.Users.Shared.Events;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHarvestHubMessaging(builder.Configuration, "fields", bus =>
{
    bus.AddConsumer<EventHandlerConsumer<FieldAreaChanged>>();
    bus.AddConsumer<EventHandlerConsumer<FieldCreated>>();
    bus.AddConsumer<EventHandlerConsumer<FieldDeleted>>();
    bus.AddConsumer<EventHandlerConsumer<UserCreated>>();
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddFieldsModule(builder.Configuration);
builder.Services.AddShared(builder.Configuration);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAny", builder =>
    {
        builder
        .AllowAnyHeader()
        .AllowAnyMethod()
        .AllowAnyOrigin();
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ErrorHandlerMiddleware>();
app.UseCors("AllowAny");

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
