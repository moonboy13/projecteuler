namespace DataStructures
{
    public class BTree
    {
        private Node? root;
        private int id = -1;

        public void Insert(Node toInsert)
        {
            if(toInsert.id < 0)
            {
                toInsert.id = ++id;
            }

            if(root == null)
            {
                root = toInsert;
                return;
            }


        }
    }

    public class Node
    {
        public Node? left { get; set; }
        public Node? right { get; set; }
        public Node? parent { get; set; }
        public int id { get; set; }
    }

}