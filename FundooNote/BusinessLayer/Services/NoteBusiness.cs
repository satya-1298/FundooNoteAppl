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
        public NoteEntity UpdateNote(NoteCreateModel noteCreateModel, long UserId, long noteId)
        {
            try
            {
                return noteRepo.UpdateNote(noteCreateModel, UserId, noteId);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public NoteEntity CopyNote( long UserId, long noteId)
        {
            try
            {
                return noteRepo.CopyNote( UserId, noteId);

            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public bool IsArchieve(long noteId, long userId)
        {
            try
            {
                return noteRepo.IsArchieve(noteId, userId);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
