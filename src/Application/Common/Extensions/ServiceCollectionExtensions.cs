﻿using Microsoft.Extensions.DependencyInjection;

namespace GraduationProject.Application.Common.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        return services;
    }
}
