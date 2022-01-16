using MongoDB.Bson.Serialization.Attributes;
using System;

namespace TinyNotes.Common
{
    public class User
    {
        [BsonId]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
    }
}
