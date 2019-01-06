#pragma warning disable CS1701 // Assuming assembly reference matches identity
using MongoDB.Driver;
using Chatter.Server.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using MongoDB.Bson;

namespace Chatter.Server.Services
{
    public sealed class MongoDbService
    {
        private readonly IMongoCollection<UserModel> _usersCollection;

        public MongoDbService(string dbUrl, string dbName, string collectionName)
        {
            var client = new MongoClient(dbUrl);
            var db = client.GetDatabase(dbName);
            _usersCollection = db.GetCollection<UserModel>(collectionName);
        }

        public async Task InserUserAsync(UserModel user) => await _usersCollection.InsertOneAsync(user);

        public async Task<List<UserModel>> GetAllUsers()
        {
            var users = new List<UserModel>();
            await (await _usersCollection.FindAsync(new BsonDocument())).ForEachAsync(u => users.Add(u));
            return users;
        }
    }
}

#pragma warning restore CS1701 // Assuming assembly reference matches identity