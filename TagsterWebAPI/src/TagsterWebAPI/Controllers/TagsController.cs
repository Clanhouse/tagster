using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Tagster.DataAccess.DBContexts;

namespace TagsterWebAPI.Controllers
{
    [ApiController]
    [Route("{controller}")]
    public class TagsController : ControllerBase
    {
        private readonly ITagsterDbContext _tagsterDb;

        public TagsController(ITagsterDbContext tagsterDb) 
            => _tagsterDb = tagsterDb;

        [HttpGet]
        public string StartMessage() 
            => "Welcome!";

        [Route("tags/{name}")]
        public Array TagsOnProfile(string name)
        {
            var tagsList = _tagsterDb
                .Profiles
                .Where(profile => profile.Name.Equals(name))
                .Include(profile => profile.ProfileTags)
                .Select(profile => profile.ProfileTags)
                .ToArray();

            return tagsList;
        }
    }
}