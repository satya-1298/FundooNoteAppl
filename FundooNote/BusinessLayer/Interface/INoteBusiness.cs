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
        public NoteEntity CopyNote( long UserId, long noteId);
        public bool IsArchieve(long noteId, long userId);
        public bool IsPin(long noteId, long userId);
        public bool IsTrash(long noteId, long userId);
    }
}
