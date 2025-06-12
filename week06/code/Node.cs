public class Node
{
    public int Data { get; set; }
    public Node? Right { get; private set; }
    public Node? Left { get; private set; }

    public Node(int data)
    {
        this.Data = data;
    }

    public void Insert(int value)
    {
        // TODO Start Problem 1

        if (value == Data)
        {
            return;
        }
        if (value < Data)
        {
            // Insert to the left
            if (Left is null)
                Left = new Node(value);
            else if (Left.Data == value)
                return;
            else
                Left.Insert(value);
        }
        else
        {
            // Insert to the right
            if (Right is null)
                Right = new Node(value);
            else if (Right.Data == value)
                return;
            else
                Right.Insert(value);
        }
    }

    public bool Contains(int value)
    {
        // TODO Start Problem 2
        if (value == Data)
        {
            return true;
        }
        else if (value < Data)
        {
            // Check left
            if (Left is null)
                return false;
            else if (Left.Data == value)
                return true;
            else
                return Left.Contains(value);
        }
        else
        {
            // Check right
            if (Right is null)
                return false;
            else if (Right.Data == value)
                return true;
            else
                return Right.Contains(value);
        }
        
    }

    public int GetHeight()
    {
        // TODO Start Problem 4
        int rightHeight = 0;
        int leftHeight = 0;

        if (Left is null && Right is null)
            return 1;
        else if (Left is null)
            return Right.GetHeight() + 1;
        else if (Right is null)
            return Left.GetHeight() + 1;
        else
            leftHeight = Left.GetHeight();
            rightHeight = Right.GetHeight();

        if (leftHeight > rightHeight)
            return leftHeight + 1;
        else
            return rightHeight + 1;

    }
}