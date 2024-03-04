using System.Text;

namespace foguete.Collections;

public class GraphNode<T> : INode<T>
{
    public T Value { get; set; }
    public List<GraphNode<T>> Neighbours { get; set; }
    public int Connecton
        => Neighbours.Count

    public GraphNode(T value, List<GraphNode<T>> neighbours = null!)
    {
        Value = value;
        Neighbours = neighbours ?? new List<GraphNode<T>>();

        foreach (var neighbours in Neighbours)
            neighbours.Neighbours.Add(this);
    }

    public GraphNode<T> AddNeighbours(GraphNode<T> node)
    {
        Neighbours.Add(node);
        node.Neighbours.Add(this);

        return this;
    }

    public GraphNode<T> RemoveNeighbours(GraphNode<T> node)
    {
        Neighbours.Remove(node);
        node.Neighbours.Remove(this);

        return this;
    }

}