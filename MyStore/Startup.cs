using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using MyStore.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;

namespace MyStore
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }
        //Конструктор получает данные из appsettings.json, которые представленны по средствам объекта который реализует интерфейс IConfiguration.
        public Startup(IConfiguration configuration) => Configuration = configuration;
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //AddDbContext расширенный метод настраивает сервисы предоставляемые EFC для класса ApplicationDbContext.cs. Аргументом является лямбда выражение которая принимает
            //объект опции которое конфигурирует базу данных для нашего класса Контекста. В нашем случае  используется метод UseSqlServer и строка подключения получиная из Configuration свойства
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration["Data:MyStoreProducts:ConnectionString"]));
            //Замешаем фейк настоящим репозиторием. Все компоненты которые используют IProductRepository (которые являются Product контроллерами) будут получить объект EFProductRepository
            //при создание. Что даст им доступ к базе данных. То есть фейковые данные будут невидимо замещатся настоящими данными из ДБ без нужды изменять ProductController
            services.AddTransient<IProductRepository, EFProductRepository>();
            //services.AddTransient<IProductRepository, FakeProductRepository>(); //Таким образом мы сообщаем что когда компоненту вроде контролера понадобится реализация интерфейса она должна получить фейковый объект

            services.AddMemoryCache();
            services.AddSession();
            services.AddMvc(); //Расширяющий метод. Настраевает разделяемые объекты, применяемые в приложение MVC
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        // Используется для настройки средств, которые получают и обрабатывают HTTP запросы.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env) //Этот метод применяется для настроики конвеера запросов. ?состоит из классов (Промежуточное ПО)?
        {
            //Расширяющие методы. Которые настраивают средство обработки HTTP запросов.
            //Этот метод отображает детили исключения, которое произошло в приложение.
            app.UseDeveloperExceptionPage();
            //добавляет простое сообщение в HTTP-ответ, которые инче бы не имели тела. Например 404
            app.UseStatusCodePages();
            //Включает поддержку для обслуживания статического содержимого из папки wwwroot
            app.UseStaticFiles();
            app.UseSession();
            //Включает инфраструктуру ASP.NET Core MVC
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "pagination",
                    template: "/Page{productPage}",
                    defaults: new {Controller="Product", action="list"}
                    );
                routes.MapRoute( //MVC - это промежуточное ПО. Этот метод настраивает. Один из параметров это схема для сопаставления URL.
                    name: "default",
                    template: "{controller=Product}/{action=List}/{id?}");//Где после равно стандартное значение
            });
            SeedData.EnsurePopulated(app);
        }
    }
}
