using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using TinyNotes.Common;

namespace TinyNotes.DataLayer
{
    public class MongoDbManager : IDbManager
    {
        static MongoDbManager _instance = null;
        IMongoDatabase _mongoDatabase = null;
        IMongoCollection<User> user = null;
        IMongoCollection<Notes> notes = null;
        public MongoDbManager()
        {
            var client = new MongoClient("mongodb+srv://AishMantri:********@cluster0.1ib5b.mongodb.net/tiny_notes?retryWrites=true&w=majority");
            _mongoDatabase = client.GetDatabase("tiny_notes");
            user = _mongoDatabase.GetCollection<User>("user");
            notes = _mongoDatabase.GetCollection<Notes>("notes");
        }
        public static MongoDbManager GetInstance()
        {
            if(_instance == null)
            {
                _instance = new MongoDbManager();
            }
            return _instance;
        }
        public void DeleteNote(Guid id)
        {
            notes.DeleteOne(x => x.Id == id);
        }

        public List<Notes> GetAllNotes(Guid userId)
        {
            return notes.Find(x => x.UserId == userId).ToList();
        }

        public Notes GetNote(Guid userId, Guid notesId)
        {
            return notes.Find(x => x.UserId == userId && x.Id == notesId).FirstOrDefault() ?? throw new Exception("Notes not found");
        }

        public User GetUser(string name, string password)
        {
            var userData = user.Find(x => x.Name == name && x.Password == password).FirstOrDefault();
            return userData;
        }

        public void InsertNote(Notes data)
        {
            notes.InsertOne(data);
        }

        public void InsertUser(User data)
        {
            user.InsertOne(data);
        }

        public void UpdateNote(Guid id, Notes data)
        {
            var builder = Builders<Notes>.Update.Set(x => x.Title, data.Title)
                                                .Set(x => x.Content, data.Content)
                                                .Set(x => x.UpdatedDate, DateTime.Now);
            notes.UpdateOne(x => x.Id == id, builder);
        }
    }
}
