using System;
using System.Collections.Generic;
using TinyNotes.Common;

namespace TinyNotes.DataLayer
{
    public class InMemoryManager : IDbManager
    {
        public List<User> UserRecords;
        public List<Notes> NoteRecords;
        static InMemoryManager _instance = null;
        public InMemoryManager()
        {
            UserRecords = new List<User>();
            NoteRecords = new List<Notes>();
        }
        public static InMemoryManager GetInstance()
        {
            if(_instance == null)
            {
                _instance = new InMemoryManager();
            }
            return _instance;    
        }
        public void DeleteNote(Guid id)
        {
            var note = NoteRecords.Find(x => x.Id == id);
            NoteRecords.Remove(note);
        }

        public List<Notes> GetAllNotes(Guid userId)
        {
            return NoteRecords.FindAll(x => x.UserId == userId);
        }

        public Notes GetNote(Guid userId, Guid notesId)
        {
            var note = NoteRecords.Find(x => x.Id == notesId);
            if (note.UserId == userId)
                return note;
            throw new Exception("Note not Found");
        }

        public User GetUser(string name, string password)
        {
            return UserRecords.Find(x => (x.Name == name && x.Password == password));
        }

        public void InsertNote(Notes data)
        {
            NoteRecords.Add(data);
        }

        public void InsertUser(User data)
        {
            UserRecords.Add(data);
        }

        public void UpdateNote(Guid id, Notes newNote)
        {
            var oldNote = NoteRecords.Find(x => x.Id == id);
            oldNote.Content = newNote.Content;
            oldNote.Title = newNote.Title;
            oldNote.UpdatedDate = DateTime.Now;
        }
    }
}
