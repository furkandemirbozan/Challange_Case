using Hangfire;
using Microsoft.EntityFrameworkCore;
using Shipping.API.Extensions;
using Shipping.Application.Jobs;
using Shipping.Persistence.Context;



var builder = WebApplication.CreateBuilder(args);


builder.Services.AddApiServices(builder.Configuration);
//Seed Data



var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHangfireDashboard("/hf");//hangfire
RecurringJob.AddOrUpdate<IJobService>("GenerateCarrierReports", x => x.GenerateCarrierReports(), Cron.Hourly);


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
