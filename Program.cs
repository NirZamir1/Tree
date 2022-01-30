using System;

namespace binary_Search_Tree
{
    class Program
    {
        static void Main(string[] args)
        {
            /*tasks-
             * combine the locate method and the swimup method to create the delete method (State-Finished)
             * Implement enumartor into the binnary tree (State-unfinshed)
             */
            Node<int> tree = new Node<int>(10);
            tree.insert(9);
            tree.insert(11);
            tree.insert(8);
            foreach(var item in tree)
            {
                Console.WriteLine(item);
            }
            
        }
    }
}
