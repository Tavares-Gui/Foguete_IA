using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace foguete.Collections;

public class Edge<T>
{
    public WeightedNode<T> Node { get; set; }
    public float Weight { get; set; }

    public Edge(WeightedNode<T> node, float weight)
    {
        Node = node;
        Weight = weight;
    }
}
