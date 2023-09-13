using CommonLayer.Model;
using RepoLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepoLayer.Interface
{
    public interface INoteRepo
    {
        public NoteEntity CreateNote(NoteCreateModel model, long UserId);
        public NoteEntity UpdateNote(NoteCreateModel noteCreateModel, long UserId, long noteId);

    }
}
