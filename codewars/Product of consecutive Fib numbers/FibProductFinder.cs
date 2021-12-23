namespace FibProduct;

internal static class FibProductFinder
{
    public static ulong[] Find(ulong value)
    {
        ulong previousNumber = 0;
        ulong currentNumber = 1;

        while (true)
        {
            var product = previousNumber * currentNumber;

            if (product >= value)
            {
                var isProduct = (ulong)(product == value ? 1 : 0);
                return new ulong[] { previousNumber, currentNumber, isProduct };
            }

            var temp = currentNumber;
            currentNumber += previousNumber;
            previousNumber = temp;
        }
    }
}
