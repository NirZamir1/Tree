using System;

namespace binary_Search_Tree
{
    class Program
    {
        static void Main(string[] args)
        {
            Node<int> tree = new Node<int>(10);
            tree.insert(11);
            tree.insert(9);
            tree.insert(8);
            tree.insert(12);
            tree.insert(13);
            tree.Locate(8);
            tree.Print();
            /*foreach(var item in tree)
            {
                Console.WriteLine(item.Value);
            }
            */
        }
    }
}
