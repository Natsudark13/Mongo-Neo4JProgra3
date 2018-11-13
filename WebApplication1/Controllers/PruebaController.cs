using Neo4j.Driver.V1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class PruebaController : Controller
    {
        public /*List<string>*/ string PruebaControllerX()
        {
            //List<string> people = null;
            string people = "a";
            IDriver driver = GraphDatabase.Driver("bolt://localhost:7687", AuthTokens.Basic("neo4j", "12345"));
            using (ISession session = driver.Session())
            {
                //IStatementResult result = session.Run("MATCH(tom { name: \"Tom Hanks\"}) RETURN tom");//.Run("CREATE (n) RETURN n");

                // Original: MATCH(a: Person) RETURN a.name as name
                //neo: MATCH(tom { name: "+"Tom Hanks"+"}) RETURN tom
                //people = result.Select(record => record["name"].As<string>()).ToList();

                //IRecord record = result.First();

                IStatementResult result2 = session.Run("CREATE (Alejandro:Person {name:'Alejandro', born:1998})");

                //var node = record["tom"].As<INode>();
                //string name = node["name"].As<string>();

                //people = name;//record["tom"].As<string>();

            }
            driver.Dispose();
            return people;
        }


        public ActionResult Index()
        {
            ViewBag.CitasPorPaciente = PruebaControllerX();
            return View();
        }
    }
}
