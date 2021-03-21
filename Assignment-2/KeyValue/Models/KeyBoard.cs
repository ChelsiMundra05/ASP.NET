using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KeyValue.Models
{
    public class KeyBoard : IKeyBoard
    {
        private readonly KeyContext db;

        public KeyBoard(KeyContext db)
        {
            this.db = db;
        }

        public Key Add(Key newMessage)
        {
            try
            {
                db.Add(newMessage);
                db.SaveChanges();
                return newMessage;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Key GetById(int key)
        {
            return db.Keys.Find(key);
        }

        public IEnumerable<Key> GetMessage()
        {
            try
            {
                var query = from m in db.Keys
                            orderby m.key
                            select m;
                return query;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Key Update(Key updatedMessage)
        {
            var entity = db.Keys.Attach(updatedMessage);   //tracks changes for the Message object that's already in there
            entity.State = EntityState.Modified;
            return updatedMessage;
        }
    }
}
