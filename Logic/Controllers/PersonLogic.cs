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
            Answer oanswer1 = new Answer();
            oanswer1.id = 1;
            oanswer1.text = "Licenciado en Sistemas";
            Answer oanswer2 = new Answer();
            oanswer2.id = 2;
            oanswer2.text = "Analista en Sistemas";
            Answer oanswer3 = new Answer();
            oanswer3.id = 3;
            oanswer3.text = "Ingeniero en Informatica";
            Answer oanswer4 = new Answer();
            oanswer4.id = 4;
            oanswer4.text = "Analista Programador";
            Answer oanswer5 = new Answer();
            oanswer5.id = 5;
            oanswer5.text = "Otro";

            Answer a1 = new Answer();
            a1.id = 6;
            a1.text = "Simecom";
            Answer a2 = new Answer();
            a2.id = 7;
            a2.text = "Tel Net";
            Answer a3 = new Answer();
            a3.id = 8;
            a3.text = "YAPP";


            Question q1 = new Question();
            q1.id = 1;
            q1.text = "Cual es tu Nombre";
            q1.type="input";
            q1.answers = new List<Answer>();

            Question q2 = new Question();
            q2.id = 2;
            q2.text = "Cual es tu Apellido";
            q2.type = "input";
            q2.answers = new List<Answer>();
            Question q3 = new Question();
            q3.id = 3;
            q3.text = "Cual es tu direccion";
            q3.type = "input";
            q3.answers = new List<Answer>();

             var personal = new List<Answer> { oanswer1, oanswer2, oanswer3, oanswer4, oanswer5 };

            Question q4 = new Question();
            q4.id = 4;
            q4.text = "Cual es tu profesion";
            q4.type = "checkbox";
            q4.answers = personal;

            var laboral = new List<Answer> { a1, a2, a3, oanswer5 };

            Question q5 = new Question();
            q5.id = 5;
            q5.text = "En que empresa trabajas";
            q5.type = "checkbox";
            q5.answers = laboral;


            var questions = new List<Question>{q1,q2,q3,q4,q5};
            var questionsresponse = questions.Select(x => new {
                                                                x.id,
                                                                x.text,
                                                                fieldId = x.answers.Any() ? x.answers.Select(xx => x.type.Trim() + '_' + x.id + '_' + xx.id) : new List<string>() { x.type.Trim() + "_" + x.id.ToString() },
                                                                x.type,
                                                                answers = x.answers.Select(y => new {
                                                                                                      id = x.type.Trim() + '_' +x.id+'_'+ y.id,
                                                                                                      y.text 
                                                                                                    })
                                                                 });


           // var emberfields = questionsresponse.Select(z => new { id = z.answers.Any() ? z.answers.Select(xx => xx.id) : new List<string>() { z.type.Trim()+"_"+z.id.ToString()} });

            return new { questions = questionsresponse };


            //using (var db = new EmberContext())
            //{
            //    //var widgets = db.Database.SqlQuery<Widget>("usp_SmartInsight_Widget_GetAll").ToList();

            //   // return new { people = widgets };                
            //}
        } 

        public static string PersonAdd(Person person){

            Answer oanswer1 = new Answer();
            oanswer1.id = 1;
            oanswer1.text = "Licenciado en Sistemas";
            Answer oanswer2 = new Answer();
            oanswer2.id = 2;
            oanswer2.text = "Analista en Sistemas";
            Answer oanswer3 = new Answer();
            oanswer3.id = 3;
            oanswer3.text = "Ingeniero en Informatica";
            Answer oanswer4 = new Answer();
            oanswer4.id = 4;
            oanswer4.text = "Analista Programador";
            Answer oanswer5 = new Answer();
            oanswer5.id = 5;
            oanswer5.text = "Otro";

            return "ok";
        }

    }
}
