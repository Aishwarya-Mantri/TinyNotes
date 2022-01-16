using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TinyNotes.Common;
using TinyNotes.Domain;

namespace TinyNotes.Controllers
{
    [Route("api/v1.0/{userid}/note")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        [HttpGet("{id}")]
        public Notes GetNote(Guid userid, Guid id)
        {
            if(UserSession.GetUserSession(userid) == true)
            {
                var noteService = new NoteService();
                return noteService.GetNote(userid, id);
            }
            throw new Exception("Please Login first");
        }

        [Route("all")]
        [HttpGet]
        public List<Notes> GetAllNotesOfUser(Guid userid)
        {
            if (UserSession.GetUserSession(userid) == true)
            {
                var noteService = new NoteService();
                return noteService.GetAllNotesOfUser(userid);
            }
            throw new Exception("Please Login first");
        }

        [Route("create")]
        [HttpPost]
        public string CreateNote([FromBody] NotesRequest request, Guid userid)
        {
            if (UserSession.GetUserSession(userid) == true)
            {
                var noteService = new NoteService();
                noteService.InsertNote(request, userid);
                return "Note Created";
            }
            throw new Exception("Please Login first");
        }

        [Route("update/{id}")]
        [HttpPost]
        public string UpdateNote(Guid id, [FromBody] NotesRequest request, Guid userid)
        {
            if (UserSession.GetUserSession(userid) == true)
            {
                var noteService = new NoteService();
                noteService.UpdateNote(id, request);
                return "Note Updated";
            }
            throw new Exception("Please Login first");
        }

        [Route("delete/{id}")]
        [HttpDelete]
        public string Delete(Guid id, Guid userid)
        {
            if (UserSession.GetUserSession(userid) == true)
            {
                var noteService = new NoteService();
                noteService.DeleteNote(id);
                return "Note deleted successfully.";
            }
            throw new Exception("Please Login first");

        }
    }
}
