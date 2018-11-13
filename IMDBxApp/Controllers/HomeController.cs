using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IMDBxApp.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IMDBxApp.Controllers
{
    [Route("api/[controller]")]
    public class HomeController : Controller
    {
        private DataAccessLayer _dataService;

        public HomeController(DataAccessLayer dataService)
        {
            _dataService = dataService;
        }

        [HttpGet("[action]")]
        public IEnumerable<Movie_Master> GetAllMovieList()
        {
            return _dataService.GetMovieList();
        }

        [HttpGet("[action]")]
        public IEnumerable<ActorMaster> GetAllActorList()
        {
            return _dataService.GetAllActorList();
        }

        [HttpGet("[action]")]
        public IEnumerable<ProducerMaster> GetAllProducerList()
        {
            return _dataService.GetAllProducerList();
        }

        [HttpPost("[action]")]
        public long SaveNewActor([FromBody]ActorMaster data)
        {
            return _dataService.saveActor(data);
        }

        [HttpPost("[action]")]
        public long SaveNewProducer([FromBody]ProducerMaster data)
        {
            return _dataService.saveProducer(data);
        }

        [HttpPost("[action]")]
        public bool SaveNewMovie([FromBody]Movie_Master data)
        {
            _dataService.saveMovie(data);
            return true;
        }

        [HttpPost("[action]")]
        public bool UpdateMovie([FromBody]Movie_Master data)
        {
            _dataService.updateMovie(data);
            return true;
        }

        







        /* // GET: api/<controller>
         [HttpGet]
         public IEnumerable<string> Get()
         {
             return new string[] { "value1", "value2" };
         }

         // GET api/<controller>/5
         [HttpGet("{id}")]
         public string Get(int id)
         {
             return "value";
         }

         // POST api/<controller>
         [HttpPost]
         public void Post([FromBody]string value)
         {
         }

         // PUT api/<controller>/5
         [HttpPut("{id}")]
         public void Put(int id, [FromBody]string value)
         {
         }

         // DELETE api/<controller>/5
         [HttpDelete("{id}")]
         public void Delete(int id)
         {
         }*/
    }
}
