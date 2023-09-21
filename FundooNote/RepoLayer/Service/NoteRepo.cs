using CommonLayer.Model;
using RepoLayer.Context;
using RepoLayer.Entity;
using RepoLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RepoLayer.Service
{
    public class NoteRepo:INoteRepo
    {
        private readonly FundooContext _fundooContext;
    
        public NoteRepo(FundooContext fundooContext)
        {
            this._fundooContext = fundooContext;
            
        }
        public NoteEntity CreateNote(NoteCreateModel model, long UserId)
        {
            NoteEntity notes = new NoteEntity();
            notes.UserId = UserId;
            notes.Title = model.Title;
            notes.Description = model.Description;
            notes.Reminder = DateTime.Now;
            notes.BackGround = model.BackGround;
            notes.Image = model.Image;
            notes.IsArchive = model.IsArchive;
            notes.IsPin = model.IsPin;
            notes.IsTrash = model.IsTrash;
            _fundooContext.Note.Add(notes);
            _fundooContext.SaveChanges();
            if (notes != null)
            {
                return notes;
            }
            return null;
        }
        public NoteEntity UpdateNote(NoteCreateModel noteCreateModel, long UserId,long noteId)
        {
            try
            {
                var result = _fundooContext.Note.FirstOrDefault(x => x.NoteID == noteId);
                if (result != null)
                {
                    result.Title = noteCreateModel.Title;
                    result.Description = noteCreateModel.Description;
                    result.Reminder = noteCreateModel.Reminder;
                    result.BackGround = noteCreateModel.BackGround;
                    result.Image = noteCreateModel.Image;
                    result.IsArchive = noteCreateModel.IsArchive;
                    result.IsPin = noteCreateModel.IsPin;
                    result.IsTrash = noteCreateModel.IsTrash;
                    result.UserId = UserId;
                    _fundooContext.SaveChanges();
                    return result;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public NoteEntity CopyNote(long UserId,long noteId)
        {
            try
            {
                var result = _fundooContext.Note.FirstOrDefault(x => x.NoteID == noteId && x.UserId == UserId);
                if (result != null)
                {
                    NoteEntity note = new NoteEntity();
                    note.UserId = UserId;
                    note.Title = result.Title;
                    note.Description = result.Description;
                    note.Reminder = result.Reminder;
                    note.BackGround = result.BackGround;
                    note.Image = result.Image;
                    note.IsArchive = result.IsArchive;
              
                    note.IsPin = result.IsPin;
                    note.IsTrash = result.IsTrash;
                  
                    _fundooContext.Note.Add(note);
                    _fundooContext.SaveChanges();
                    return result;
                }
                else
                {
                    return null;
                }
            }
            catch 
            {
                return null;
            }

        }
        public bool IsArchieve(long noteId,long userId)
        {
            try
            {
                var result = _fundooContext.Note.FirstOrDefault(x => x.UserId == userId && x.NoteID == noteId);
                if (result != null)
                {
                    result.IsArchive = !result.IsArchive;
                    _fundooContext.SaveChanges();
                    return true;
                }
                return false;
            }
            catch
            {
                throw;
            }
        }
        public bool IsPin(long noteId, long userId)
        {
            try
            {
                var result = _fundooContext.Note.FirstOrDefault(x => x.UserId == userId && x.NoteID == noteId);
                if (result != null)
                {
                    result.IsPin = !result.IsPin;
                    _fundooContext.SaveChanges();
                    return true;
                }
                return false;
            }
            catch
            {
                throw;
            }

        }
        public bool IsTrash(long noteId, long userId)

        {
            try
            {
                var result = _fundooContext.Note.FirstOrDefault(x => x.UserId == userId && x.NoteID == noteId);
                if (result != null)
                {
                    result.IsTrash = !result.IsTrash;
                    _fundooContext.SaveChanges();
                    return true;
                }
                return false;
            }
            catch
            {
                throw;
            }

        }
    }
}
