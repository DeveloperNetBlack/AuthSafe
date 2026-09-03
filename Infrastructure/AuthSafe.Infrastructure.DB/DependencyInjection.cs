using AuthSafe.DomainService.IRepositories.IAuthRepositories;
using AuthSafe.DomainService.IRepositories.IConstantRepositories;
using AuthSafe.DomainService.IRepositories.IPageCompanyRepositories;
using AuthSafe.DomainService.IRepositories.IRolePermissionRepositories;
using AuthSafe.DomainService.IRepositories.IRoleRepositories;
using AuthSafe.DomainService.IRepositories.ITokenRepositories;
using AuthSafe.DomainService.Transactions;
using AuthSafe.Infrastructure.DB.AppDBContext;
using AuthSafe.Infrastructure.DB.Repositories.AuthRepositories;
using AuthSafe.Infrastructure.DB.Repositories.ConstantRepositories;
using AuthSafe.Infrastructure.DB.Repositories.PageCompanyRepositories;
using AuthSafe.Infrastructure.DB.Repositories.RolePermissionRepositories;
using AuthSafe.Infrastructure.DB.Repositories.RoleRepositories;
using AuthSafe.Infrastructure.DB.Repositories.TokenRepositories;
using AuthSafe.Infrastructure.DB.Transactions;
using Knotus.NET10.DB.SQLServer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AuthSafe.Infrastructure.DB
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddAuthSafeInfrastructureDB(this IServiceCollection services, IConfiguration configuration, string sectionConnectionName)
        {
            services.Configure<AppDbContext>(configuration.GetSection(sectionConnectionName));
            services.AddScoped<ITransactionAccessor, TransactionAccessor>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            // Registro (una sola vez, en tu extensión de DI de Infrastructure)
            services.AddScoped(typeof(Connection<>));

            services.AddDependencyInjectionRepository();
            return services;
        }

        private static IServiceCollection AddDependencyInjectionRepository(this IServiceCollection services)
        {
            services.AddScoped<IAuthLoginRepository, AuthLoginRepository>();
            services.AddScoped<IAuthGetRepository, AuthGetRepository>();

            services.AddScoped<ITokenCreateRepository, TokenCreateRepository>();
            services.AddScoped<ITokenGetExpirationRepository, TokenGetExpirationRepository>();
            services.AddScoped<ITokenUpdateRevocationRepository, TokenUpdateRevocationRepository>();

            //services.AddScoped<ICategoryChangeStateRepository, CategoryChangeStateRepository>();
            //services.AddScoped<ICategoryCreateRepository, CategoryCreateRepository>();
            //services.AddScoped<ICategoryGetRepository, CategoryGetRepository>();
            //services.AddScoped<ICategoryUpdateRepository, CategoryUpdateRepository>();
            //services.AddScoped<ICategoryValidateRepository, CategoryValidateRepository>();

            services.AddScoped<IRolePermissionListRepository, RolePermissionListRepository>();
            services.AddScoped<IRolePermissionCreateRepository, RolePermissionCreateRepository>();
            services.AddScoped<IRolePermissionDeleteRepository, RolePermissionDeleteRepository>();

            services.AddScoped<IRolePaginationRepository, RolePaginationRepository>();
            services.AddScoped<IRoleChangeStateRepository, RoleChangeStateRepository>();
            services.AddScoped<IRoleCreateRepository, RoleCreateRepository>();
            services.AddScoped<IRoleUpdateRepository, RoleUpdateRepository>();
            services.AddScoped<IRoleVerifyCodeAndNameRepository, RoleVerifyCodeAndNameRepository>();
            services.AddScoped<IRoleGetRepository, RoleGetRepository>();

            services.AddScoped<IPageCompanyListRepository, PageCompanyListRepository>();
            services.AddScoped<IPageCompanyCreateNotExistsRepository, PageCompanyCreateNotExistsRepository>();
            services.AddScoped<IPageCompanyCreateRepository, PageCompanyCreateRepository>();
            services.AddScoped<IPageCompanyDeleteRepository, PageCompanyDeleteRepository>();

            //services.AddScoped<IUbigeoListSearchRepository, UbigeoListSearchRepository>();
            //services.AddScoped<IUbigeoListByUbigeoClassRepository, UbigeoListByUbigeoClassRepository>();
            //services.AddScoped<IUbigeoListByClassAndCodeAndLenCodeRepository, UbigeoListByClassAndCodeAndLenCodeRepository>();

            services.AddScoped<IConstantListRepository, ConstantListRepository>();

            return services;
        }
    }
}
