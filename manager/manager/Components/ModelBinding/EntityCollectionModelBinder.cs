﻿using System;
using System.Collections.ObjectModel;
using System.Web.Mvc;
using DomainModel.Entities;
using DomainModel.Repositories;

namespace manager.Components.ModelBinding
{
    public interface IEntityCollectionModelBinder<T> : IModelBinder { }

    public class EntityCollectionModelBinder<T> : IEntityCollectionModelBinder<T> where T : Entity
    {
        private readonly IQuerableRepository<T> _repository;

        public EntityCollectionModelBinder()
        {
            _repository = DependencyResolver.Current.GetService<IQuerableRepository<T>>();
        }

        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var result = new Collection<T>();

            int enumerator = 0;
            ValueProviderResult id = bindingContext.ValueProvider.GetValue(bindingContext.ModelName + "[" + enumerator + "]");

            for (; id != null; enumerator++, id = bindingContext.ValueProvider.GetValue(bindingContext.ModelName + "[" + enumerator + "]"))
            {
                Guid entityId;
                if (!Guid.TryParse(id.AttemptedValue, out entityId))
                {
                    continue;
                }

                var entity = _repository.Get(entityId);
                if (entity == null)
                {
                    continue;
                }

                result.Add(entity);
            }

            return result;
        }
    }
}