using System.Collections;

namespace Cppia.Std;

public class CppiaArray
{
    // Required for cppia
    public CppiaArray(){}

    public static void Push(IList list, object value) => list.Add(value);

    public static IList Concat(IList list, IList a)
        => list.OfType<object>().Union(a.OfType<object>()).ToList();

    public static bool Contains(IList list, object value) => list.Contains(value);

    public static IList Copy(IList list)
    {
        return new List<object>(list.Cast<object>());
    }

    public static string Join(IList list, string seperator)
        => string.Join(seperator, list.OfType<object>());

    
    public static IList Filter(IList list, Func<object, bool> lymbda) => list.OfType<object>().Where(x => lymbda(x)).ToList();

    public static int IndexOf(IList list, object x, int? fromIndex) 
        => list.IndexOf(x);

    public static void Insert(IList list, int pos, object x) => list.Insert(pos, x);
    public static object? Pop(IList list)
    {
        if(list.Count > 0)
            return list[list.Count - 1];
        return null;
    }

    public static void Remove(IList list, int pos) => list.RemoveAt(pos);



}
