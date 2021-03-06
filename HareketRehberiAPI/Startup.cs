using AutoMapper;
using HareketRehberi.BL.AnswerBL;
using HareketRehberi.BL.EvaluationBL;
using HareketRehberi.BL.FileBL;
using HareketRehberi.BL.LessonBL;
using HareketRehberi.BL.LessonEvaluationMatchBL;
using HareketRehberi.BL.LessonPdfFileRelationBL;
using HareketRehberi.BL.LessonSoundFileRelationBL;
using HareketRehberi.BL.LessonUserMatchBL;
using HareketRehberi.BL.Logger;
using HareketRehberi.BL.QuestionBL;
using HareketRehberi.BL.SystemUserBL;
using HareketRehberi.BL.UserLessonProgressLogBL;
using HareketRehberi.BL.UserLessonsEvaluationsQuestionsAnswersBL;
using HareketRehberi.Data;
using HareketRehberi.Data.Repos.AnswerRepos;
using HareketRehberi.Data.Repos.EvaluationRepos;
using HareketRehberi.Data.Repos.LessonEvaluationMatchRepos;
using HareketRehberi.Data.Repos.LessonPdfFileRelationRepos;
using HareketRehberi.Data.Repos.LessonRepos;
using HareketRehberi.Data.Repos.LessonSoundFileRelationRepos;
using HareketRehberi.Data.Repos.LessonUserMatchRepos;
using HareketRehberi.Data.Repos.QuestionRepos;
using HareketRehberi.Data.Repos.SystemUserRepos;
using HareketRehberi.Data.Repos.UserLessonProgressLogRepos;
using HareketRehberi.Data.Repos.UserLessonsEvaluationsQuestionsAnswersRepos;
using HareketRehberi.Domain;
using HareketRehberi.Domain.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HareketRehberiAPI
{
    public class Startup
    {
        public Microsoft.AspNetCore.Hosting.IHostingEnvironment _hostingEnvironment { get; set; }

        public Startup(IConfiguration configuration,
            Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment)
        {
            Configuration = configuration;
            _hostingEnvironment = hostingEnvironment;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(o =>
            {
                o.AddPolicy("EnableCORS", builder =>
                {
                    builder.AllowAnyOrigin()//WithOrigins(Configuration.GetValue<string>("MyAppConfig:ClientSiteRoot"))
                    .AllowAnyHeader()
                    .SetIsOriginAllowed(origin => true) // allow any origin
                    .AllowAnyMethod();
                });
            });
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "HareketRehberiAPI", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please insert JWT with Bearer into field",
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                   { 
                     new OpenApiSecurityScheme 
                     { 
                       Reference = new OpenApiReference 
                       { 
                         Type = ReferenceType.SecurityScheme,
                         Id = "Bearer" 
                       } 
                     },
                     new string[] { } 
                   } 
                });
            });

            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MapperProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddDbContext<DataContext>(option => {
                option.UseMySQL(Configuration.GetConnectionString("DefaultConnection"), q => q.MigrationsAssembly("HareketRehberiAPI"));
            });

            services.AddOptions();
            services.Configure<MyAppConfig>(Configuration.GetSection("MyAppConfig"));

            services.AddAuthentication(o => {
                o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                o.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(o => {
                o.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,

                    ValidIssuer = Configuration.GetValue<string>("MyAppConfig:BaseSiteRoot"),
                    ValidAudience = Configuration.GetValue<string>("MyAppConfig:BaseSiteRoot"),
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration.GetValue<string>("MyAppConfig:Secret")))
                };
            });

            services.AddTransient<ISystemUserRepo, SystemUserRepo>();
            services.AddTransient<ISystemUserBL, SystemUserBL>();
            services.AddTransient<ILessonRepo, LessonRepo>();
            services.AddTransient<ILessonBL, LessonBL>();
            services.AddTransient<ILessonPdfFileRelationRepo, LessonPdfFileRelationRepo>();
            services.AddTransient<ILessonPdfFileRelationBL, LessonPdfFileRelationBL>();
            services.AddTransient<ILessonSoundFileRelationRepo, LessonSoundFileRelationRepo>();
            services.AddTransient<ILessonSoundFileRelationBL, LessonSoundFileRelationBL>();
            services.AddTransient<FileBL>();
            services.AddTransient<IEvaluationRepo, EvaluationRepo>();
            services.AddTransient<IEvaluationBL, EvaluationBL>();
            services.AddTransient<IQuestionRepo, QuestionRepo>();
            services.AddTransient<IQuestionBL, QuestionBL>();
            services.AddTransient<IAnswerRepo, AnswerRepo>();
            services.AddTransient<IAnswerBL, AnswerBL>();
            services.AddTransient<ILessonEvaluationMatchRepo, LessonEvaluationMatchRepo>();
            services.AddTransient<ILessonEvaluationMatchBL, LessonEvaluationMatchBL>();
            services.AddTransient<ILessonUserMatchRepo, LessonUserMatchRepo>();
            services.AddTransient<ILessonUserMatchBL, LessonUserMatchBL>();
            services.AddTransient<IUserLessonProgressLogRepo, UserLessonProgressLogRepo>();
            services.AddTransient<IUserLessonProgressLogBL, UserLessonProgressLogBL>();
            services.AddTransient<IUserLessonsEvaluationsQuestionsAnswersRepo, UserLessonsEvaluationsQuestionsAnswersRepo>();
            services.AddTransient<IUserLessonsEvaluationsQuestionsAnswersBL, UserLessonsEvaluationsQuestionsAnswersBL>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddProvider(new LoggerProvider(_hostingEnvironment));

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "HareketRehberiAPI v1"));
            }
            
            app.UseHttpsRedirection();

            app.UseCors("EnableCORS");
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
