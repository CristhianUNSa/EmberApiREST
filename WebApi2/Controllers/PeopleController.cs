using Logic.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Http;
//agregar este using para el cors .. installar desde el nuget Microsoft.AspNet.WebApi.Cors
using System.Web.Http.Cors;
using Logic.Model;

namespace WebApi2.Controllers
{
    public class PeopleController : ApiController
    {
        // GET api/people
        [EnableCors(origins: "*", headers: "*", methods: "*")] //agregar esto para que funcione el cors ...cuidado porque esto habilita para que sea llamado desde todos lados
        public dynamic Get()
        {
            return PersonLogic.GetAllPerson(); //new string[] { "value1", "value2" };
        }

        // POST api/people
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public string Post([FromBody]Person person)
        {
           return PersonLogic.PersonAdd(person);
        }

        // POST api/people/otroname
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public string otroname([FromBody]Person person)
        {
            return "LLEGO a la API";//PersonLogic.PersonAdd(person);
        }


    }
}