using MongoDB.Bson.Serialization.Attributes;
using System;

namespace TinyNotes.Common
{
    public class Notes
    {
        [BsonId]
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }


    }
}
