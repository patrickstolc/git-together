using Microsoft.AspNetCore.Mvc;
using Domain;

namespace ProfileService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProfileController : ControllerBase
    {
        private readonly List<Profile> _profiles;

        public ProfileController()
        {
            _profiles = new List<Profile>();
            PopulateProfiles();
        }

        [HttpGet]
        public ActionResult<List<Profile>> GetProfiles([FromQuery] string techStack, [FromQuery] int age)
        {
            var techStackEnum = Enum.Parse<Stack>(techStack, true);
            var minYears = age - 5;
            var maxYears = age + 5;

            var filteredProfiles = _profiles
                .Where(p => p.TechStack.Contains(techStackEnum))
                .Where(p => p.Age >= minYears && p.Age <= maxYears)
                .ToList();

            return Ok(filteredProfiles);
        }

        private void PopulateProfiles()
        {
            var profiles = new List<Profile>
            {
                new Profile
                {
                    Id = 1,
                    Name = "Yo Momma",
                    TechStack = new List<Stack> { Stack.PHPisMyLife },
                    RemoteWork = true,
                    Age = 69,
                    Location = "Amsterdam",
                    LikeCount = 420
                },
                new Profile
                {
                    Id = 2,
                    Name = "Yo Daddy",
                    TechStack = new List<Stack> { Stack.Dotnet },
                    RemoteWork = false,
                    Age = 42,
                    Location = "Rotterdam",
                    LikeCount = 69
                },
                new Profile
                {
                    Id = 3,
                    Name = "Yo Sister",
                    TechStack = new List<Stack> { Stack.Java },
                    RemoteWork = true,
                    Age = 21,
                    Location = "Utrecht",
                    LikeCount = 666
                },
                new Profile
                {
                    Id = 4,
                    Name = "Yo Brother",
                    TechStack = new List<Stack> { Stack.Python },
                    RemoteWork = false,
                    Age = 30,
                    Location = "Den Haag",
                    LikeCount = 1337
                },
                new Profile
                {
                    Id = 5,
                    Name = "Yo Dog",
                    TechStack = new List<Stack> { Stack.Ruby },
                    RemoteWork = true,
                    Age = 5,
                    Location = "Groningen",
                    LikeCount = 1
                },
                new Profile
                {
                    Id = 6,
                    Name = "Yo Cat",
                    TechStack = new List<Stack> { Stack.Node },
                    RemoteWork = false,
                    Age = 3,
                    Location = "Maastricht",
                    LikeCount = 0
                },
                new Profile
                {
                    Id = 7,
                    Name = "Yo Fish",
                    TechStack = new List<Stack> { Stack.React },
                    RemoteWork = true,
                    Age = 1,
                    Location = "Eindhoven",
                    LikeCount = 0
                },
                new Profile
                {
                    Id = 8,
                    Name = "Yo Bird",
                    TechStack = new List<Stack> { Stack.Angular },
                    RemoteWork = false,
                    Age = 2,
                    Location = "Tilburg",
                    LikeCount = 0
                },
                new Profile
                {
                    Id = 9,
                    Name = "Yo Hamster",
                    TechStack = new List<Stack> { Stack.Vue },
                    RemoteWork = true,
                    Age = 1,
                    Location = "Breda",
                    LikeCount = 0
                },
                new Profile
                {
                    Id = 10,
                    Name = "Yo Lizard",
                    TechStack = new List<Stack> { Stack.IOnlyDoHTMLAndCSS },
                    RemoteWork = false,
                    Age = 1,
                    Location = "Arnhem",
                    LikeCount = 0
                }
            };

            _profiles.AddRange(profiles);
        }
    }
}
