﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;

namespace SharedKernel.Caching;

public static class RedisCacheExtensions
{
    public static IServiceCollection AddRedisCaching(this IServiceCollection services,
        IConfiguration configuration)
    {
        var redisCacheSettings = configuration.GetSection(RedisCacheSettings.SectionName).Get<RedisCacheSettings>();
        if (redisCacheSettings is null)
        {
            throw new ArgumentNullException(nameof(redisCacheSettings));
        }
        
        PollyExtensions.CreateDefaultPolicy(cfg =>
        {
            cfg.Or<RedisServerException>()
                .Or<RedisConnectionException>();
        });

        return services;
    }
}