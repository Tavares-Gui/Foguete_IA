using foguete.Search;
using foguete.Collections;

// Launch.LaunchRocket();



// var list = new List<float> { 1.6f, 2.4f, 3.6f, 5.7f, 7.8f, 8.1f, 9.3f };

// var sol = Search.BinarySearch(list, 1.6f);

// Console.WriteLine(sol);


    // Tree 1 (root: 50)
var node = new TreeNode<int>(6);
node = new TreeNode<int>(21, children: new List<TreeNode<int>> { node });
var node2 = new TreeNode<int>(45);
node = new TreeNode<int>(12, children: new List<TreeNode<int>> { node, node2 });
node = new TreeNode<int>(50, children: new List<TreeNode<int>> { node });

var tree1 = new Tree<int>(node);

    // Tree 1 (root: 50)
var root = new TreeNode<int>(1);
    .AddChild(new TreeNode<int>(70))
    .AddChild(new TreeNode<int>(61));

var tree2 = new Tree<int>(root);

    // Tree 3 (root: 50)
root = new TreeNode<int>(150)
    .AddChild(new TreeNode<int>(30)
        .AddChild(new TreeNode<int>(96))
        .AddChild(new TreeNode<int>(9))
    )
    .AddChild(new TreeNode<int>(5))
    .AddChild(new TreeNode<int>(11));

var tree3 = new     
