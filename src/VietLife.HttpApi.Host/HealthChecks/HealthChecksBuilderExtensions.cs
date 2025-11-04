using System;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;

namespace VietLife.HealthChecks;

public static class HealthChecksBuilderExtensions
{
    public static void AddVietLifeHealthChecks(this IServiceCollection services)
    {
        var configuration = services.GetConfiguration();
        var appSelfUrl = configuration["App:SelfUrl"] ?? "http://localhost:8012";
        var healthCheckPath = configuration["App:HealthCheckUrl"] ?? "/health-status";

        // Nếu cấu hình có chứa http:// thì chỉ lấy phần path thôi
        if (healthCheckPath.StartsWith("http", StringComparison.OrdinalIgnoreCase))
        {
            var uri = new Uri(healthCheckPath);
            healthCheckPath = uri.AbsolutePath; // chỉ còn "/health-status"
        }

        var healthChecksBuilder = services.AddHealthChecks();
        healthChecksBuilder.AddCheck<VietLifeDatabaseCheck>(
            "VietLife DbContext Check",
            tags: new[] { "database" }
        );

        // Map endpoint cho health check
        services.Configure<AbpEndpointRouterOptions>(options =>
        {
            options.EndpointConfigureActions.Add(endpointContext =>
            {
                endpointContext.Endpoints.MapHealthChecks(healthCheckPath, new HealthCheckOptions
                {
                    Predicate = _ => true,
                    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse,
                    AllowCachingResponses = false
                });
            });
        });

        // HealthChecks UI
        var fullHealthCheckUrl = $"{appSelfUrl.TrimEnd('/')}{healthCheckPath}";
        var uiBuilder = services.AddHealthChecksUI(settings =>
        {
            settings.AddHealthCheckEndpoint("VietLife Health Status", fullHealthCheckUrl);
        });
        uiBuilder.AddInMemoryStorage();

        // Map UI endpoints
        services.Configure<AbpEndpointRouterOptions>(routerOptions =>
        {
            routerOptions.EndpointConfigureActions.Add(endpointContext =>
            {
                endpointContext.Endpoints.MapHealthChecksUI(options =>
                {
                    options.UIPath = "/health-ui";
                    options.ApiPath = "/health-ui-api";
                });
            });
        });
    }



    private static IServiceCollection ConfigureHealthCheckEndpoint(this IServiceCollection services, string path)
    {
        services.Configure<AbpEndpointRouterOptions>(options =>
        {
            options.EndpointConfigureActions.Add(endpointContext =>
            {
                endpointContext.Endpoints.MapHealthChecks(
                    new PathString(path.EnsureStartsWith('/')),
                    new HealthCheckOptions
                    {
                        Predicate = _ => true,
                        ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse,
                        AllowCachingResponses = false,
                    });
            });
        });

        return services;
    }

    private static IServiceCollection MapHealthChecksUiEndpoints(this IServiceCollection services, Action<global::HealthChecks.UI.Configuration.Options>? setupOption = null)
    {
        services.Configure<AbpEndpointRouterOptions>(routerOptions =>
        {
            routerOptions.EndpointConfigureActions.Add(endpointContext =>
            {
                endpointContext.Endpoints.MapHealthChecksUI(setupOption);
            });
        });

        return services;
    }
}
