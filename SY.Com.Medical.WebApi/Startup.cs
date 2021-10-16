using DocumentFormat.OpenXml.EMMA;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.PlatformAbstractions;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Converters;
using Swashbuckle.AspNetCore.Swagger;
using SY.Com.Medical.WebApi.Filter;
using SY.Com.Medical.WebApi.Format;
using SY.Com.Medical.WebApi.JWT;
using System.IO;

namespace SY.Com.Medical.WebApi
{
    /// <summary>
    /// ����
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// ���캯��
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// ����������
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// ע�����
        /// </summary>
        /// <param name="services"></param>
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //����JWT,Bearer JWT
            services.AddAuthentication("Bearer")
            .AddJwtBearer(options => options.TokenValidationParameters = JWTTokenValidationParameters.getParameters());

            services.AddControllers(options => options.Filters.Add(new CustomerFilter()));
            services.AddMvc(opt =>
            {
                opt.Filters.Add<ExceptionFilter>();
            }).AddJsonOptions(option =>
            {
                //ԭ�����,Ĭ�ϻ������ĸСд
                //option.JsonSerializerOptions.PropertyNamingPolicy = null;
                option.JsonSerializerOptions.Converters.Add(new DateConverter());
                option.JsonSerializerOptions.Converters.Add(new DateTimeNullableConverter());
            });
            //���ÿ�����
            services.AddCors(options =>
            {
                options.AddPolicy("any", builder =>
                {
                    builder.AllowAnyOrigin() //�����κ���Դ����������
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials();//ָ������cookie
                });
            });
            
            //����Swagger
            services.AddSwaggerGen(c =>
            {
                //����swagger��֤����
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Description = "���¿�����������ͷ����Ҫ���Jwt��ȨToken��Bearer Token",
                    Name = "Authorization",//jwtĬ�ϵĲ�������
                    In = ParameterLocation.Header,//jwtĬ�ϴ��authorization��Ϣ��λ��(����ͷ��)
                    Type = SecuritySchemeType.ApiKey,
                    BearerFormat = "JWT",
                    Scheme = "Bearer"
                });
                //���ȫ�ְ�ȫ����
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme{
                            Reference = new OpenApiReference {
                                        Type = ReferenceType.SecurityScheme,
                                        Id = "Bearer"}
                        },new string[] { }
                    }
                });
                //��ʾ�Զ����Heard Token
                c.OperationFilter<AuthTokenHeaderParameter>();
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "�ӿ��ĵ�",
                    Description = "RESTful API for TwBusManagement"
                });
                c.OperationFilter<AddTenantIdHeaderParameter>();
                var basePath = PlatformServices.Default.Application.ApplicationBasePath;
                var xmlPath = Path.Combine(basePath, "SY.Com.Medical.WebApi.xml");//Api
                var xmlPath2 = Path.Combine(basePath, "SY.Com.Medical.Model.xml");//Model
                var xmlPath3 = Path.Combine(basePath, "SY.Com.Medical.Enum.xml");//Enum
                c.IncludeXmlComments(xmlPath);
                c.IncludeXmlComments(xmlPath2);
                c.IncludeXmlComments(xmlPath3);
                //
            });

            //����ö�ٷ���
            services.AddMvc().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.Converters.Add(new System.Text.Json.Serialization.JsonStringEnumConverter());
            });
        }

        /// <summary>
        /// ע������
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles(); //��̬�ļ�����
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "TwBusManagement API V1");
                //c.ShowExtensions();
            });
            app.UseRouting();
            app.UseAuthentication();//JWT��֤  
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
