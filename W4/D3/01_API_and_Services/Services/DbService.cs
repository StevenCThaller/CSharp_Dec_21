using _01_API_and_Services.Models;
using System.Linq;

namespace _01_API_and_Services.Services
{
    public interface IDbService
    {
        int UserFavoriteThing(int userId, int thingId);
        int AddThingToDb(string url);
        StarWarsThing GetThingByUrl(string url);
    }

    public class DbService : IDbService
    {
        private MyContext _context { get; }
        public DbService(MyContext context)
        {
            _context = context;
        }

        // Create a method that will take a UserId and an object,
        // and link them in the database
        public int UserFavoriteThing(int userId, int thingId)
        {
            Favorite toAdd = new Favorite
            {
                UserId = userId,
                StarWarsThingId = thingId
            };

            if(_context.Favorites.Any(f => f.UserId == userId && f.StarWarsThingId == thingId))
            {
                return -1;
            }

            _context.Add(toAdd);
            _context.SaveChanges();
            return toAdd.FavoriteId;
        }

        public int AddThingToDb(string url)
        {
            StarWarsThing toAdd = new StarWarsThing
            {
                Url = url
            };

            if(_context.StarWarsThings.Any(t => t.Url == url))
            {
                return -1;
            }

            _context.Add(toAdd);
            _context.SaveChanges();
            return toAdd.StarWarsThingId;
        }

        public StarWarsThing GetThingByUrl(string url)
        {
            return _context.StarWarsThings.FirstOrDefault(t => t.Url == url);
        }
    }
}