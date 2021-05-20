using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;
using Tagster.Database;

namespace TagsterWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TagsterController : ControllerBase
    {

        private readonly IServiceProvider _mServiceProvider;
        private readonly ILogger<TagsterController> _logger;

        public TagsterController(ILogger<TagsterController> logger, IServiceProvider serviceProvider)
        {
            _mServiceProvider = serviceProvider;
            _logger = logger;
        }

        [HttpGet]
        public string StartMessage()
        {
            var mess = "Welcome!";
            return mess;
        }

        [Route("tags/{name}")]

        public Array TagsOnProfile(string name)
        {
            var database = _mServiceProvider.GetService(typeof(TagsterDbContext)) as TagsterDbContext;

            var tagsList = database
                .Profiles
                .Where(a => a.Name == name)
                .Include(a => a.ProfileTags)
                .Select(a => new { a.ProfileTags})
                .ToArray();

            return tagsList;

        }
       
    }
}
