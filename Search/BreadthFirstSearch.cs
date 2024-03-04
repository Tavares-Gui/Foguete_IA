using System.Reflection.Metadata;
using foguete.Collections;

namespace foguete.Search;

public static partial class Search
{
    public static bool BreadthFirstSearch<T>(TreeNode<T> node, T goal)
    {
        var list = new List<TreeNode<T>>() { node };

        while (list.Count > 0)
        {
            if (EqualityComparer<T>.Default.Equals(list[0].Value, goal))
                return true;

            foreach (var child in list[0].Children)
                list.Add(child);

            list.Remove(list[0]);
        }

        return false;
    }
}