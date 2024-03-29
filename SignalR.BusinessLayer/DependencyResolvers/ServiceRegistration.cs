﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SignalR.BusinessLayer.Abstract;
using SignalR.BusinessLayer.Concrete;
using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BusinessLayer.DependencyResolvers
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddBusinessServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddScoped<IAboutService, AboutManager>()
                    .AddScoped<IAboutDal, EfAboutDal>();

            services.AddScoped<IBookingService, BookingManager>()
                    .AddScoped<IBookingDal, EfBookingDal>();

            services.AddScoped<ICategoryService, CategoryManager>()
                    .AddScoped<ICategoryDal, EfCategoryDal>();

            services.AddScoped<IContactService, ContactManager>()
                    .AddScoped<IContactDal, EfContactDal>();

            services.AddScoped<IDiscountService, DiscountManager>()
                    .AddScoped<IDiscountDal, EfDiscountDal>();

            services.AddScoped<IFeatureService, FeatureManager>()
                   .AddScoped<IFeatureDal, EfFeatureDal>();

            services.AddScoped<IProductService, ProductManager>()
                    .AddScoped<IProductDal, EfProductDal>();

            services.AddScoped<ISocialMediaService, SocialMediaManager>()
                    .AddScoped<ISocialMediaDal, EfSocialMediaDal>();

            services.AddScoped<ITestimonialService, TestimonialManager>()
                    .AddScoped<ITestimonialDal, EfTestimonialDal>();

            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddDbContext<SignalRContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            return services;
        }
    }
}
