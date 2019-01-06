#pragma warning disable CS1701 // Assuming assembly reference matches identity
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace Chatter.Server.Models
{
    public sealed class UserModel
    {
        [BsonId]
        public ObjectId Id { get; set; }
        [BsonRequired]
        public string Login { get; set; }
        [BsonRequired]
        public string PasswordHash { get; set; }
    }
}
#pragma warning restore CS1701 // Assuming assembly reference matches identity