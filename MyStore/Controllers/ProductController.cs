using Microsoft.AspNetCore.Mvc;
using MyStore.Models;

namespace MyStore.Controllers
{
    public class ProductController : Controller 
    {
        private IProductRepository repository; //Когда будет необходимо создать экземлпяр класс ProductController для обработки HTTP запроса, MVC проинспектирует конструктор
        //и выяснит, что он требует объекта, который реализует интерфейс IProductRepository. Чтобы определить какой класс реализации должен использоваться MVC обращается к
        public ProductController(IProductRepository repo)//конфигурацие в StartUp, которая сообщает что нужно каждый раз создавать FakeRepository
        {//FakeRepository используется для вызова этого конструктора, для создания объекта контролера который будет обрабатывать запрос.
            repository = repo;
        }
        public ViewResult List() => View(repository.Products); //View() - везуализирует стандартное предатавление для метода действия
    }
}
