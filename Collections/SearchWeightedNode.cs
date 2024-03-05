using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace foguete.Collections;

public class SearchWeightedNode<T> : SearchNode<T, WeightedNode<T>>
{
    public SearchWeightedNode(WeightedNode<T> node) : base(node) { }

    public override List<SearchNode<T, WeightedNode<T>>> Neighbours()
    {
        var neighbours = new List<SearchNode<T, WeightedNode<T>>>(Node.Neighbours.Count);
        neighbours.AddRange(Node.Neighbours.Select(neighbour => new SearchWeightedNode<T>(neighbour.Node)));
        
        return neighbours;
    }
}
