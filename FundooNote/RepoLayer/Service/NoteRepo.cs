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
    }
}
