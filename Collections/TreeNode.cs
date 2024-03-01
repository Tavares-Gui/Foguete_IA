namespace foguete.Collections;

public class TreeNode<T> : INode<T>
{
    public T Value { get; set; }
    public TreeNode<T> Parent { get; set; }
    public List<TreeNode<T>> Children { get; set; }

    public TreeNode(
        T value, 
        TreeNode<T>? parent = null, List<TreeNode<T>>? children = null
    )
    {
        Value = value;
        Parent = parent;
        Children = children ?? new List<TreeNode<T>>();
    }

    public TreeNode<T> AddChild(TreeNode<T> child)
    {
        child.Parent = this;
        Children.Add(child);

        return this;
    }

    public TreeNode<T> RemoveChild(TreeNode<T> child)
    {
        child.Parent = null;
        Children.Remove(child);

        return this;
    }
}