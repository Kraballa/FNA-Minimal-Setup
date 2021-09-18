using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Namespace.Util
{
    /// <summary>
    /// A type of list that is safe to modify while iterating.
    /// </summary>
    /// <typeparam name="T">Generic Type</typeparam>
    public class SafeList<T> : IEnumerable<T>, IEnumerable
    {
        private List<T> entities;
        private List<T> toAdd;
        private List<T> toAwake;
        private List<T> toRemove;

        private HashSet<T> current;
        private HashSet<T> adding;
        private HashSet<T> removing;

        internal SafeList()
        {
            entities = new List<T>();
            toAdd = new List<T>();
            toAwake = new List<T>();
            toRemove = new List<T>();

            current = new HashSet<T>();
            adding = new HashSet<T>();
            removing = new HashSet<T>();
        }

        public void UpdateLists()
        {
            if (toAdd.Count > 0)
            {
                for (int i = 0; i < toAdd.Count; i++)
                {
                    var entity = toAdd[i];
                    if (!current.Contains(entity))
                    {
                        current.Add(entity);
                        entities.Add(entity);
                    }
                }
            }

            if (toRemove.Count > 0)
            {
                for (int i = 0; i < toRemove.Count; i++)
                {
                    var entity = toRemove[i];
                    if (entities.Contains(entity))
                    {
                        current.Remove(entity);
                        entities.Remove(entity);
                    }
                }

                toRemove.Clear();
                removing.Clear();
            }

            if (toAdd.Count > 0)
            {
                toAwake.AddRange(toAdd);
                toAdd.Clear();
                adding.Clear();
                toAwake.Clear();
            }
        }

        public void Add(T entity)
        {
            if (!adding.Contains(entity) && !current.Contains(entity))
            {
                adding.Add(entity);
                toAdd.Add(entity);
            }
        }

        public void Remove(T entity)
        {
            if (!removing.Contains(entity) && current.Contains(entity))
            {
                removing.Add(entity);
                toRemove.Add(entity);
            }
        }

        public void Add(IEnumerable<T> entities)
        {
            foreach (var entity in entities)
                Add(entity);
        }

        public void Remove(IEnumerable<T> entities)
        {
            foreach (var entity in entities)
                Remove(entity);
        }

        public void Add(params T[] entities)
        {
            for (int i = 0; i < entities.Length; i++)
                Add(entities[i]);
        }

        public void Remove(params T[] entities)
        {
            for (int i = 0; i < entities.Length; i++)
                Remove(entities[i]);
        }

        public int Count
        {
            get
            {
                return entities.Count;
            }
        }

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= entities.Count)
                    throw new IndexOutOfRangeException();
                else
                    return entities[index];
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return entities.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public T[] ToArray()
        {
            return entities.ToArray<T>();
        }
    }
}
