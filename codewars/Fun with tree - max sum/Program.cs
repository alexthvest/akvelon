namespace TreeMaxSum;

internal class Program
{
    private static void Main(string[] args)
    {
        var tree = new TreeNode(10, new TreeNode(3), new TreeNode(5, new TreeNode(11)));
        var sum = MaxSum(tree);

        Console.WriteLine(sum);
    }

    private static int MaxSum(TreeNode? root)
    {
        if (root is null)
        {
            return 0;
        }

        var left = MaxSum(root.Left);
        var right = MaxSum(root.Right);

        return Math.Max(left, right) + root.Value;
    }
}