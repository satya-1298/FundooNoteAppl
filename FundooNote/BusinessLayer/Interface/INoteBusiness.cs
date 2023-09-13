using CommonLayer.Model;
using RepoLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interface
{
    public interface INoteBusiness
    {
        public NoteEntity CreateNote(NoteCreateModel model, long UserId);
        public NoteEntity UpdateNote(NoteCreateModel noteCreateModel, long UserId, long noteId);
    }
}
