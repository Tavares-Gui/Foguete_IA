using foguete.Collections;

namespace foguete.Search;

public static partial class Search
{
    public static bool DepthFirstSearch<T>(TreeNode<T> node, T goal)
    {
        if (EqualityComparer<T>.Default.Equals(node.Value, goal))
            return true;

        foreach (var currNode in node.Children)
        {
            if (DepthFirstSearch(currNode, goal))
                return true;
        }

        return false;
    }
}