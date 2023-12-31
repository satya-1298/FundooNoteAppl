﻿using BusinessLayer.Interface;
using CommonLayer.Model;
using RepoLayer.Entity;
using RepoLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Services
{
    public class NoteBusiness : INoteBusiness
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
        public NoteEntity CopyNote(long UserId, long noteId)
        {
            try
            {
                return noteRepo.CopyNote(UserId, noteId);

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
        public bool IsPin(long noteId, long userId)
        {
            try
            {
                return noteRepo.IsPin(noteId, userId);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public bool IsTrash(long noteId, long userId)
        {
            try
            {
                return noteRepo.IsTrash(noteId, userId);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public List<NoteEntity> SearchQuery(long userId, string word)
        {
            try
            {
                return noteRepo.SearchQuery(userId, word);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
