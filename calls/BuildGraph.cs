using foguete.Collections;
using foguete.Search;

public static class BuildGraph
{
    Graph<string> BuildingGraph()
    {
        var nodeBaltimore = new GraphNode<string>("Baltimore");
        var nodeBoston = new GraphNode<string>("Boston");
        var nodeBuffalo = new GraphNode<string>("Buffalo");
        var nodeChicago = new GraphNode<string>("Chicago");
        var nodeCleveland = new GraphNode<string>("Cleveland");
        var nodeColumbus = new GraphNode<string>("Columbus");
        var nodeDetroit = new GraphNode<string>("Detroit");
        var nodeIndianapolis = new GraphNode<string>("Indianapolis");
        var nodeNewYork = new GraphNode<string>("New York");
        var nodePhiladelphia = new GraphNode<string>("Philadelphia");
        var nodePittsburgh = new GraphNode<string>("Pittsburgh");
        var nodePortland = new GraphNode<string>("Portland");
        var nodeProvidence = new GraphNode<string>("Providence");
        var nodeSyracuse = new GraphNode<string>("Syracuse");

        nodeBaltimore.AddNode(nodePhiladelphia)
                     .AddNode(nodePittsburgh);

        nodeBoston.AddNode(nodeNewYork)
                  .AddNode(nodePortland)
                  .AddNode(nodeProvidence)
                  .AddNode(nodeSyracuse);

        nodeBuffalo.AddNode(nodeCleveland)
                   .AddNode(nodeDetroit)
                   .AddNode(nodePittsburgh)
                   .AddNode(nodeSyracuse);

        nodeChicago.AddNode(nodeCleveland)
                   .AddNode(nodeDetroit)
                   .AddNode(nodeIndianapolis);

        nodeCleveland.AddNode(nodeBuffalo)
                     .AddNode(nodeChicago)
                     .AddNode(nodeColumbus)
                     .AddNode(nodeDetroit)
                     .AddNode(nodePittsburgh);

        nodeColumbus.AddNode(nodeCleveland)
                    .AddNode(nodeIndianapolis)
                    .AddNode(nodePittsburgh);

        nodeDetroit.AddNode(nodeBuffalo)
                   .AddNode(nodeChicago)
                   .AddNode(nodeCleveland);

        nodeIndianapolis.AddNode(nodeChicago)
                        .AddNode(nodeColumbus);

        nodeNewYork.AddNode(nodeBoston)
                   .AddNode(nodePhiladelphia)
                   .AddNode(nodeProvidence)
                   .AddNode(nodeSyracuse);

        nodePhiladelphia.AddNode(nodeBaltimore)
                        .AddNode(nodeNewYork)
                        .AddNode(nodeSyracuse);

        nodePittsburgh.AddNode(nodeBaltimore)
                      .AddNode(nodeBuffalo)
                      .AddNode(nodeCleveland)
                      .AddNode(nodeColumbus)
                      .AddNode(nodePhiladelphia);

        nodePortland.AddNode(nodeBoston);

        nodeProvidence.AddNode(nodeBoston)
                      .AddNode(nodeNewYork);

        nodeSyracuse.AddNode(nodeBoston)
                    .AddNode(nodeBuffalo)
                    .AddNode(nodeNewYork)
                    .AddNode(nodePhiladelphia);

        var buildGraph = new Graph<string>(new List<GraphNode<string>>
    {
        nodeBaltimore,
        nodeBoston,
        nodeBuffalo,
        nodeChicago,
        nodeCleveland,
        nodeColumbus,
        nodeDetroit,
        nodeIndianapolis,
        nodeNewYork,
        nodePhiladelphia,
        nodePittsburgh,
        nodePortland,
        nodeProvidence,
        nodeSyracuse,
    });

        return buildGraph;
    }
}
