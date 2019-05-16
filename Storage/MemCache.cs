using System;
using System.Collections.Generic;
using System.Linq;
using to.Models;

namespace to.Storage
{
    public class MemCache : IStorage<Lab1Mod>
    {
        private object _sync = new object();
        private List<Lab1Mod> _memCache = new List<Lab1Mod>();
        public Lab1Mod this[Guid id] 
        { 
            get
            {
                lock (_sync)
                {
                    if (!Has(id)) throw new IncorrectLabDataException($"No Lab1Mod with id {id}");

                    return _memCache.Single(x => x.Id == id);
                }
            }
            set
            {
                if (id == Guid.Empty) throw new IncorrectLabDataException("Cannot request Lab1Mod with an empty id");

                lock (_sync)
                {
                    if (Has(id))
                    {
                        RemoveAt(id);
                    }

                    value.Id = id;
                    _memCache.Add(value);
                }
            }
        }

        public System.Collections.Generic.List<Lab1Mod> All => _memCache.Select(x => x).ToList();

        public void Add(Lab1Mod value)
        {
            if (value.Id != Guid.Empty) throw new IncorrectLabDataException($"Cannot add value with predefined id {value.Id}");

            value.Id = Guid.NewGuid();
            this[value.Id] = value;
        }

        public bool Has(Guid id)
        {
            return _memCache.Any(x => x.Id == id);
        }

        public void RemoveAt(Guid id)
        {
            lock (_sync)
            {
                _memCache.RemoveAll(x => x.Id == id);
            }
        }
    }
} 