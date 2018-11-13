using Neo4j.Driver.V1;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1
{
    public class Neo4JC
    {
        public Neo4JC()
        {
            IDriver driver = GraphDatabase.Driver("bolt://localhost:7687", AuthTokens.Basic("neo4j", "12345"));
            using (ISession session = driver.Session())
            {
                IStatementResult result = session.Run("CREATE (n) RETURN n");
            }
            driver.Dispose();
        }

    }
}
