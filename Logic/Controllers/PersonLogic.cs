using Logic.DBConnection;
using Logic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Controllers
{
    public abstract class PersonLogic
    {
        public static dynamic GetAllPerson()
        {
            using (var db = new EmberContext())
            {
                var widgets = db.Database.SqlQuery<Widget>("usp_SmartInsight_Widget_GetAll").ToList();

                return new { widgets = widgets };
            }
        } 

    }
}
