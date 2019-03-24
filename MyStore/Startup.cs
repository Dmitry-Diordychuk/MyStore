using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using MyStore.Models;

namespace MyStore
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IProductRepository, FakeProductRepository>(); //Таким образом мы сообщаем что когда компоненту вроде контролера понадобится реализация интерфейса она должна получить фейковый объект
            services.AddMvc(); //Расширяющий метод. Настраевает разделяемые объекты, применяемые в приложение MVC
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        // Используется для настройки средств, которые получают и обрабатывают HTTP запросы.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env) 
        {
            //Расширяющие методы. Которые настраивают средство обработки HTTP запросов.
            //Этот метод отображает детили исключения, которое произошло в приложение.
            app.UseDeveloperExceptionPage();
            //добавляет простое сообщение в HTTP-ответ, которые инче бы не имели тела. Например 404
            app.UseStatusCodePages();
            //Включает поддержку для обслуживания статического содержимого из папки wwwroot
            app.UseStaticFiles();
            //Включает инфраструктуру ASP.NET Core MVC
            app.UseMvc(routes =>
            {

            });
        }
    }
}
