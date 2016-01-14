namespace QuoteQuiz.RestServices.Tests.Mocks
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Data.Repositories;

    public class GenericRepositoryMock<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
        private readonly List<TEntity> entities = new List<TEntity>();

        private readonly Func<TEntity, object> keySelector;

        public bool ChangesSaved { get; set; }

        public GenericRepositoryMock(Func<TEntity, object> keySelector = null)
        {
            if (keySelector != null)
            {
                this.keySelector = keySelector;
            }
            else
            {
                this.keySelector = (u => ((dynamic) u).Id);
            }
        }

        public IQueryable<TEntity> All()
        {
            return this.entities.AsQueryable();
        }

        public TEntity Find(object id)
        {
            return this.entities.FirstOrDefault(entity => id.Equals(this.keySelector(entity)));
        }

        public void Add(TEntity entity)
        {
            this.entities.Add(entity);
        }

        public void Update(TEntity entity)
        {
            var existingEntity = this.Find(this.keySelector(entity));
            var existingEntityIndex = this.entities.IndexOf(existingEntity);
            this.entities[existingEntityIndex] = entity;
        }

        public void Delete(TEntity entity)
        {
            var existingEntity = this.Find(this.keySelector(entity));
            var existingEntityIndex = this.entities.IndexOf(existingEntity);
            this.entities.RemoveAt(existingEntityIndex);
        }

        public TEntity Delete(object id)
        {
            var entity = this.Find(id);
            this.Delete(entity);
            return entity;
        }

        public void SaveChanges()
        {
            this.ChangesSaved = true;
        }
    }
}