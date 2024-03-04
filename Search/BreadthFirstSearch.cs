using foguete.Collections;

namespace foguete.Search;

public static partial class Search
{
    public static bool BreadthFirstSearch<T>(TreeNode<T> node, T goal)
    {
        var queue = new Queue<TreeNode<T>>();
        queue.Enqueue(node);

        while (queue.Count > 0)
        {
            var currNode = queue.Dequeue();

            if (EqualityComparer<T>.Default.Equals(currNode.Value, goal))
                return true;

            foreach (var child in currNode.Children)
                queue.Enqueue(child);
        }

        return false;
    }
}