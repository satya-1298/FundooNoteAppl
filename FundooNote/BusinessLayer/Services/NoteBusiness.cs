using BusinessLayer.Interface;
using CommonLayer.Model;
using RepoLayer.Entity;
using RepoLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Services
{
    public class NoteBusiness:INoteBusiness
    {
        private readonly INoteRepo noteRepo;
        public NoteBusiness(INoteRepo noteRepo)
        {
            this.noteRepo = noteRepo;
        }
        public NoteEntity CreateNote(NoteCreateModel model, long UserId)
        {
            try
            {
                return noteRepo.CreateNote(model, UserId);

            }

            catch (Exception ex)
            {
                throw;
            }

        }
    
    }
}
