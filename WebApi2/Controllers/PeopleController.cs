using Logic.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace WebApi2.Controllers
{
    public class PeopleController : ApiController
    {
        // GET api/people
        public dynamic Get()
        {
            return PersonLogic.GetAllPerson(); //new string[] { "value1", "value2" };
        }
    }
}