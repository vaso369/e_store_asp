using Estore.Application;
using Estore.Application.Commands;
using Estore.Application.Queries;
using Estore.Implementation.Commands;
using Estore.Implementation.Queries;
using Estore.Implementation.Validators;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estore.Api.Core
{
    public static class ContainerExtensions
    {
        public static void AddUsesCases(this IServiceCollection services)
        {
            services.AddTransient<ICreateRoleCommand, EFCreateRoleCommand>();
            services.AddTransient<ICreateUserCommand, EFCreateUserCommand>();
            services.AddTransient<ICreateCategoryCommand, EFCreateCategoryCommand>();
            services.AddTransient<ICreateProductCommand, EFCreateProductCommand>();        
            services.AddTransient<ICreateNewPictureCommand, EFCreateNewPictureCommand>();
            services.AddTransient<ICreateOrderCommand, EFCreateOrderCommand>();
            services.AddTransient<IUpdateProductCommand, EFUpdateProductCommand>();
            services.AddTransient<IUpdateCategoryCommand, EFUpdateCategoryCommand>();
            services.AddTransient<IUpdateUserCommand, EFUpdateUserCommand>();
            services.AddTransient<IUpdateRoleCommand, EFUpdateRoleCommand>();
            services.AddTransient<IUpdateOrderStatusCommand, EFUpdateOrderStatusCommand>();
            services.AddTransient<IDeleteOneProductPicturesCommand, EFDeleteOneProductPicturesCommand>();
            services.AddTransient<IDeleteProductCommand, EFDeleteProductCommand>();
            services.AddTransient<IDeleteUserCommand, EFDeleteUserCommand>();
            services.AddTransient<IDeleteRoleCommand, EFDeleteRoleCommand>();
            services.AddTransient<IDeleteCategoryCommand, EFDeleteCategoryCommand>();
            services.AddTransient<IGetRolesQuery, EFGetRolesQuery>();
            services.AddTransient<IGetProductsQuery, EFGetProductsQuery>();
            services.AddTransient<IGetOneProductQuery, EFGetOneProductQuery>();
            services.AddTransient<IGetOneUserQuery, EFGetOneUserQuery>();
            services.AddTransient<IGetUsersQuery, EFGetUsersQuery>();
            services.AddTransient<IGetOneProductPicturesQuery, EFGetOneProductPictures>();
            services.AddTransient<IGetOneOrderQuery, EFGetOneOrderQuery>();
            services.AddTransient<IGetOrdersQuery, EFGetOrdersQuery>();
            services.AddTransient<IGetCategoriesQuery, EFGetCategoriesQuery>();
            services.AddTransient<IGetLogsQuery, EFGetoLogsQuery>();
            services.AddTransient<CreateRoleValidator>();
            services.AddTransient<CreateUserValidator>();
            services.AddTransient<CreateCategoryValidator>();
            services.AddTransient<CreateProductValidator>();
            services.AddTransient<CreateOrderValidator>();
            services.AddTransient<UpdateProductValidator>();
            services.AddTransient<UpdateUserValidator>();
            services.AddTransient<UpdateCategoryValidator>();
            services.AddTransient<UpdateRoleValidator>();
            
        }
        public static void AddApplicationActor(this IServiceCollection services)
        {
            services.AddTransient<IApplicationActor>(x =>
            {
                var accessor = x.GetService<IHttpContextAccessor>();

                var user = accessor.HttpContext.User;

                if (user.FindFirst("ActorData") == null)
                {
                    return new AnonymusActor();
                }

                var actorString = user.FindFirst("ActorData").Value;

                var actor = JsonConvert.DeserializeObject<JwtActor>(actorString);

                return actor;

            });
        }
        public static void AddJwt(this IServiceCollection services)
        {
            services.AddTransient<JwtManager>();

            services.AddAuthentication(options =>
            {
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(cfg =>
            {
                cfg.RequireHttpsMetadata = false;
                cfg.SaveToken = true;
                cfg.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = "asp_api",
                    ValidateIssuer = true,
                    ValidAudience = "Any",
                    ValidateAudience = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ThisIsMyVerySecretKey")),
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                };
            });

        }
    }
}
