using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Milky.Entity.Concrete;
using MilkyProject.Business.Abstract;
using MilkyProject.Business.Concrete;
using MilkyProject.Data.Abstract;
using MilkyProject.Data.Concrete.EfCore;

var builder = WebApplication.CreateBuilder(args);

    builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<Context>().AddDefaultTokenProviders();

    builder.Services.AddControllersWithViews()
        .AddJsonOptions(options => options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

// Add services to the container.

    // ---------------------------------------------------------------------------------------------------
    builder.Services.AddDbContext<Context>();

    builder.Services.AddScoped<ISliderService,SliderManager>();
    builder.Services.AddScoped<ISliderDal,SliderDal>();

    builder.Services.AddScoped<IAboutService,AboutManager>();
    builder.Services.AddScoped<IAboutDal,AboutDal>();

    builder.Services.AddScoped<IAddressService,AddressManager>();
    builder.Services.AddScoped<IAddressDal,AddressDal>();

    builder.Services.AddScoped<IBannerService,BannerManager>();
    builder.Services.AddScoped<IBannerDal,BannerDal>();

    builder.Services.AddScoped<ISiteSocialMediaService,SiteSocialMediaManager>();
    builder.Services.AddScoped<ISiteSocialMediaDal,SiteSocialMediaDal>();

    builder.Services.AddScoped<IProductService,ProductManager>();
    builder.Services.AddScoped<IProductDal,ProductDal>();

    builder.Services.AddScoped<ITestimonialService,TestimonialManager>();
    builder.Services.AddScoped<ITestimonialDal,TestimonialDal>();

    builder.Services.AddScoped<IServiceService,ServiceManager>();
    builder.Services.AddScoped<IServiceDal,ServiceDal>();

    builder.Services.AddScoped<ITeamService,TeamManager>();
    builder.Services.AddScoped<ITeamDal,TeamDal>();

    builder.Services.AddScoped<ISocialMediaService,SocialMediaManager>();
    builder.Services.AddScoped<ISocialMediaDal,SocialMediaDal>();

    builder.Services.AddScoped<IMessageService,MessageManager>();
    builder.Services.AddScoped<IMessageDal,MessageDal>();

    builder.Services.AddScoped<ISubscribeService,SubscribeManager>();
    builder.Services.AddScoped<ISubscribeDal,SubscribeDal>();

    // AutoMapper ---------------------------------------
    builder.Services.AddAutoMapper(typeof(Program));


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
