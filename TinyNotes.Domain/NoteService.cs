using System;
using System.Collections.Generic;
using TinyNotes.Common;
using TinyNotes.DataLayer;

namespace TinyNotes.Domain
{
    public class NoteService
    {
        public string InsertNote(NotesRequest request, Guid userId)
        {
            var notes = new Notes {
                Id = Guid.NewGuid(),
                UserId = userId,
                Title = request.Title,
                Content = request.Content,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now
            };
            
            var dbManager = DbFactory.GetInstance("mongo");
            dbManager.InsertNote(notes);
            return "Note inserted successfully.";
        }
        public string UpdateNote(Guid id, NotesRequest request)
        {
            var notes = new Notes
            {
                Title = request.Title,
                Content = request.Content,
                Id = id
            };
            var dbManager = DbFactory.GetInstance("mongo");
            dbManager.UpdateNote(id, notes);
            return "Note updated successfully.";
        }
        public string DeleteNote(Guid id)
        {
            var dbManager = DbFactory.GetInstance("mongo");
            dbManager.DeleteNote(id);
            return "Note deleted successfully.";
        }
        public Notes GetNote(Guid userId, Guid noteId)
        {
            var dbManager = DbFactory.GetInstance("mongo");
            return dbManager.GetNote(userId,noteId);
        }
        public List<Notes> GetAllNotesOfUser(Guid userId)
        {
            var dbManager = DbFactory.GetInstance("mongo");
            return dbManager.GetAllNotes(userId);
        }
    }
}
