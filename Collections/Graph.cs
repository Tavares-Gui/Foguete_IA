using System.Diagnostics.Contracts;

namespace foguete.Collections;

public class Graph : GraphNode<T>
{
    public Graph(Task value, List<GraphNode<T>> neighbours = null!)
        : base (value, neighbours);
}