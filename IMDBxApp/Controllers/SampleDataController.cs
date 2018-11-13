using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IMDBxApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace IMDBxApp.Controllers
{
    [Route("api/[controller]")]
    public class SampleDataController : Controller
    {
        private DataAccessLayer _dataService ;

        public SampleDataController(DataAccessLayer dataService)
        {
            _dataService = dataService;
        }

        [HttpGet("[action]")]
        public IEnumerable<Movie_Master> GetAllMovieList()
        {
            return _dataService.GetMovieList();
        }


    }


}