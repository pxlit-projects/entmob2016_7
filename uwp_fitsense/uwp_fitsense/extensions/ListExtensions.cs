using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uwp_fitsense.extensions
{
    public static class ListExtensions
    {
        public static ObservableCollection<T> ToObservableCollection<T>(this IEnumerable<T> coll)
        {
            if (coll == null)
                return null;
            var collection = new ObservableCollection<T>();
            foreach (var element in coll)
                collection.Add(element);
            return collection;
        }
    }
}