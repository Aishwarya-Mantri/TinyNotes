using System;
using System.Collections.Generic;
using TinyNotes.Common;

namespace TinyNotes.DataLayer
{
    public interface IDbManager
    {
        void InsertUser(User data);
        User GetUser(string name, string password);
        void InsertNote(Notes data);
        void UpdateNote(Guid id, Notes data);
        void DeleteNote(Guid id);
        Notes GetNote(Guid userId, Guid notesId);
        List<Notes> GetAllNotes(Guid userId);
    }
}
