using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Reborn.IdentityServer4.AuditLogging.EntityFramework.DbContexts;
using Reborn.IdentityServer4.AuditLogging.EntityFramework.DbContexts.Default;
using Reborn.IdentityServer4.AuditLogging.EntityFramework.Entities;
using Reborn.IdentityServer4.AuditLogging.EntityFramework.Repositories;
using Reborn.IdentityServer4.AuditLogging.EntityFramework.Services;
using Reborn.IdentityServer4.AuditLogging.Extensions;

namespace Reborn.IdentityServer4.AuditLogging.EntityFramework.Extensions
{
    public static class AuditLoggingEntityFrameworkExtensions
    {
        /// <summary>
        /// Add default DbContext and Repository
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="dbContextOptions"></param>
        /// <returns></returns>
        public static IAuditLoggingBuilder AddDefaultStore(this IAuditLoggingBuilder builder, Action<DbContextOptionsBuilder> dbContextOptions)
        {
            builder.AddStore<DefaultAuditLoggingDbContext, AuditLog, AuditLoggingRepository<DefaultAuditLoggingDbContext, AuditLog>>(dbContextOptions);

            return builder;
        }

        /// <summary>
        /// Add store with DbContext and Repository
        /// </summary>
        /// <typeparam name="TDbContext"></typeparam>
        /// <typeparam name="TAuditLoggingRepository"></typeparam>
        /// <typeparam name="TAuditLog"></typeparam>
        /// <param name="builder"></param>
        /// <param name="dbContextOptions"></param>
        /// <returns></returns>
        public static IAuditLoggingBuilder AddStore<TDbContext, TAuditLog, TAuditLoggingRepository>(this IAuditLoggingBuilder builder, Action<DbContextOptionsBuilder> dbContextOptions)
            where TDbContext : DbContext, IAuditLoggingDbContext<TAuditLog> where TAuditLoggingRepository : class, IAuditLoggingRepository<TAuditLog> where TAuditLog : AuditLog
        {
            builder.Services.AddDbContext<TDbContext>(dbContextOptions);
            builder.Services.AddTransient<IAuditLoggingRepository<TAuditLog>, TAuditLoggingRepository>();

            return builder;
        }

        /// <summary>
        /// Add default database audit sink
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static IAuditLoggingBuilder AddDefaultAuditSink(this IAuditLoggingBuilder builder)
        {
            builder.AddAuditSinks<DatabaseAuditEventLoggerSink<AuditLog>>();

            return builder;
        }
    }
}