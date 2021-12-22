namespace TreeMaxSum;

internal class TreeNode
{
    public TreeNode(int value, TreeNode? left = null, TreeNode? right = null)
    {
        Value = value;
        Left = left;
        Right = right;
    }

    public int Value { get; }
    public TreeNode? Left { get; }
    public TreeNode? Right { get; }
}