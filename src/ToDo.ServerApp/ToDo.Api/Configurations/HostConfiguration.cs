﻿namespace ToDo.Api.Configurations;

public static partial class HostConfiguration
{
    public static ValueTask<WebApplicationBuilder> ConfigureAsync(this WebApplicationBuilder builder)
    {
        builder.AddMappers().AddValidators().AddBusinessLogicInfrastructure().AddCors().AddExposers().AddDevTools();

        return new(builder);
    }

    public static async ValueTask<WebApplication> ConfigureAsync(this WebApplication app)
    {
        await app.MigrateDatabaseSchemaAsync();
        
        app.UseCors();
        app.UseExposers().UseDevTools();

        return app;
    }
}