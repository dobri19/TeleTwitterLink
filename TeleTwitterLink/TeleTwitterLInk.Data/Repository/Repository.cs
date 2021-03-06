﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Linq;
using TeleTwitterLink.Data.Models.Abstract;

namespace TeleTwitterLInk.Data.Repository
{
    public class Repository<T> : IRepository<T>
        where T : class, IDeletable
    {
        private readonly TeleTwitterLinkDbContext context;

        public Repository(TeleTwitterLinkDbContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("DbContext cant be null");
            }

            this.context = context;
        }

        public IQueryable<T> All
        {
            get
            {
                return this.context.Set<T>().Where(x => !x.IsDeleted);
            }
        }

        public IQueryable<T> AllAndDeleted
        {
            get
            {
                return this.context.Set<T>();
            }
        }

        public void Add(T entity)
        {
            EntityEntry entry = this.context.Entry(entity);

            if (entry.State != EntityState.Detached)
            {
                entry.State = EntityState.Added;
            }
            else
            {
                this.context.Set<T>().Add(entity);
            }
        }

        public void Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("Entity cant be null");
            }

            entity.IsDeleted = true;
            entity.DeletedOn = DateTime.Now;

            var entry = this.context.Entry(entity);
            entry.State = EntityState.Modified;
        }

        public void Update(T entity)
        {
            EntityEntry entry = this.context.Entry(entity);

            if (entry.State == EntityState.Detached)
            {
                this.context.Set<T>().Attach(entity);
            }

            entry.State = EntityState.Modified;
        }
    }
}