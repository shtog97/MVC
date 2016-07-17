using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
namespace WebApllication4.Models
{
    public class AvtoDbInitializer : DropCreateDatabaseAlways<AvtoContext>
    {
        protected override void Seed(AvtoContext db)
        {
            db.Avtos.Add(new Avto { Name = "Toyota Prius 2015", opisanie = "Продолжается внедрением  гибридного привода Hybrid Synergy Drive нового поколения. Благодаря двум электродвигателям и режиму «Электромобиль», в котором автомобиль движется исключительно на электротяге, вы получите настоящее удовольствие от мощной разгонной динамики, чёткого управления, лучших в классе показателей потребления топлива и аэродинамических характеристик.", Id=5, price=125600, dataVipuska=2015 });
            db.Avtos.Add(new Avto { Name = "Tesla Model S", opisanie = "Вы хотите почувствовать мощь будущего, мощь новой Tesla Model S. Запас хода около 400 км. Больше никаких заправок только электричество. От 0 до 100 км/ч всего за 4.4 секунды. Превосходство будущего уже у нас.", dataVipuska=2015, price=65000, Id=1 });
           

            base.Seed(db);
        }
    }
}