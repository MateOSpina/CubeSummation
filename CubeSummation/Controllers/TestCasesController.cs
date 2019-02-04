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
    public class TestCasesController : ApiController
    {
        //// GET: api/TestCases
        //public IQueryable<TestCase> GetTestCases()
        //{
        //    return db.TestCases;
        //}

        //// GET: api/TestCases/5
        //[ResponseType(typeof(TestCase))]
        //public IHttpActionResult GetTestCase(int id)
        //{
        //    TestCase testCase = db.TestCases.Find(id);
        //    if (testCase == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(testCase);
        //}

        // POST: api/TestCases

        [HttpPost]
        [ResponseType(typeof(TestCase))]        
        public IHttpActionResult PostTestCase(TestCase testCase)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var testCaseBl = new TestCaseBL();
            testCaseBl.CreateTestCase(testCase);

            return CreatedAtRoute("DefaultApi", new { id = testCase.Id }, testCase);
        }
    }
}