using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using EntitiesLayer;
using BusinessLogicLayer;
using System.Web.Http.Cors;

namespace CubeSummation.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class MatrizsController : ApiController
    {
        //private Context db = new Context();

        //// GET: api/Matrizs
        //public IQueryable<Matriz> GetMatriz()
        //{
        //    return db.Matriz;
        //}

        //// GET: api/Matrizs/5
        //[ResponseType(typeof(Matriz))]
        //public IHttpActionResult GetMatriz(int id)
        //{
        //    Matriz matriz = db.Matriz.Find(id);
        //    if (matriz == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(matriz);
        //}
        

        // POST: api/Matrizs
        [ResponseType(typeof(Matriz))]
        public IHttpActionResult PostMatriz(Models.MatrizModel matriz)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var matrizBl = new MatrizBL();
            matrizBl.CreateMatriz(matriz.Matriz, matriz.NumberOfRows);

            return CreatedAtRoute("DefaultApi", new { id = matriz.Matriz.Id }, matriz.Matriz);
        }

        [HttpPost]
        [Route("api/ExecuteQuery")]
        public IHttpActionResult ExecuteQuery(Models.QueryModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var matrizBl = new MatrizBL();
            var summation = matrizBl.ExecuteQuery(model.QueryType, model.NumberOfRow, model.NumberOfEndRow, model.Value);
            return Ok(summation);
        }

        [HttpGet]
        [Route("api/GetQueriesType")]
        public IHttpActionResult GetQueriesType()
        {
            var enumerationsBl = new EnumerationsBL();
            return Ok(enumerationsBl.GetQueriesTypes());
        }
    }
}