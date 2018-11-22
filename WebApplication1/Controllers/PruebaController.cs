using Neo4j.Driver.V1;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class PruebaController : Controller
    {

        private IDriver driver;

        public PruebaController()
        {
            driver = GraphDatabase.Driver("bolt://localhost:7687", AuthTokens.Basic("neo4j", "1234"));
        }

        public ActionResult historial()
        {
            using (ISession session = driver.Session())
            {
                var ReservationModels = new List<ReservationModel>();

                session.ReadTransaction(tx =>
                {
                    var result = tx.Run("MATCH(n: Reservation) -[:Reservation_Customer]->(m: Customer) where m.Name = \"Homer Simpson\" return n");
                    foreach (var record in result)
                    {
                        var nodeProps = JsonConvert.SerializeObject(record[0].As<INode>().Properties);

                        ReservationModels.Add(JsonConvert.DeserializeObject<ReservationModel>(nodeProps));

                    }
                });
                return View(ReservationModels);
            }
        }


        public /*List<string>*/ string PruebaControllerX()
        {
            //List<string> people = null;
            string people = "a";
            
            using (ISession session = driver.Session())
            {
                IStatementResult result = session.Run("MATCH(tom { name: \"Tom Hanks\"}) RETURN tom");//.Run("CREATE (n) RETURN n");

                //Original: MATCH(a: Person) RETURN a.name as name
                //neo: MATCH(tom { name: "+"Tom Hanks"+"}) RETURN tom

                //people = result.Select(record => record["name"].As<string>()).ToList();

                IRecord record = result.First();

                var node = record["tom"].As<INode>();
                string name = node["name"].As<string>();

                people = name;//record["tom"].As<string>();

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
