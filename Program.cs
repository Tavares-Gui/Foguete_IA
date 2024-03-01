using foguete.Search;
using foguete.Collections;

// Launch.LaunchRocket();



// var list = new List<float> { 1.6f, 2.4f, 3.6f, 5.7f, 7.8f, 8.1f, 9.3f };

// var sol = Search.BinarySearch(list, 1.6f);

// Console.WriteLine(sol);


 
var node = new TreeNode<int>(6);
var node2 = new TreeNode<int>(21, children: new List<TreeNode<int>> { node });
