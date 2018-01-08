using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// <copyright file="RouteValueDictionary.cs" company="FIS" department="R&D">
// Copyright (c) 2017 All Rights Reserved
// </copyright>
// <author>LinhNT76</author>
// <date></date>
// <summary>RouteValueDictionary</summary>
namespace PatientPortal.Provider.Models
{
    //PERFORMANCE PASSING PARAMS FOR URL DATA
    //OLD: Url.Action("Some Action", "Controller", new {a = paramA, b = paramB, c = paramC})
    //NEW: Url.Action("Some Action", "Controller", new RouteValueDictionary({"a", paramA}, {"b", paramB}, {"c", paramC}))
    public class RouteValueDictionary : IDictionary<string, object>
    {
        private Dictionary<string, object> _dictionary;

        public RouteValueDictionary()
        {
            _dictionary = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);
        }

        public RouteValueDictionary(object values)
        {
            _dictionary = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);

            AddValues(values);
        }

        public RouteValueDictionary(IDictionary<string, object> dictionary)
        {
            _dictionary = new Dictionary<string, object>(dictionary, StringComparer.OrdinalIgnoreCase);
        }

        private void AddValues(object values)
        {
            if (values != null)
            {
                foreach (PropertyDescriptor descriptor in TypeDescriptor.GetProperties(values))
                {
                    object obj = descriptor.GetValue(values);
                    this.Add(descriptor.Name, obj);
                }
            }
        }

        public object this[string key]
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public int Count
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public bool IsReadOnly
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public ICollection<string> Keys
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public ICollection<object> Values
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public void Add(KeyValuePair<string, object> item)
        {
            throw new NotImplementedException();
        }

        public void Add(string key, object value)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(KeyValuePair<string, object> item)
        {
            throw new NotImplementedException();
        }

        public bool ContainsKey(string key)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(KeyValuePair<string, object>[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<KeyValuePair<string, object>> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public bool Remove(KeyValuePair<string, object> item)
        {
            throw new NotImplementedException();
        }

        public bool Remove(string key)
        {
            throw new NotImplementedException();
        }

        public bool TryGetValue(string key, out object value)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
