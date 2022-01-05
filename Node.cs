using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace binary_Search_Tree
{
    public class Node <T> where T:IComparable
    {
        Node<T> RightNode;
        Node<T> LeftNode;
        public T Value;
        public Node<T>? Parent { get;}
        public Node(T value,Node<T>? parent = null)
        {
            Value = value;
            Parent = parent;
        }
        public void insert(T value)
        {
             if(value.CompareTo(Value)>0)
             {
                if(RightNode==null)
                {
                    RightNode = new Node<T>(value,this);
                }
                else
                {
                    RightNode.insert(value);
                }
             }
            else
            {
                if (LeftNode == null)
                {
                    LeftNode = new Node<T>(value,this);
                }
                else
                {
                    LeftNode.insert(value);
                }
            }

        }
        public void Print()
        {
            if(LeftNode!=null)
            {
                LeftNode.Print();
            }
            Console.WriteLine(Value);
            if(RightNode!=null)
            {
                RightNode.Print();
            }
        }
        public void Locate(T value)
        {
            //Delete function
            if (LeftNode == null && RightNode == null)
            {
                throw new Exception("The object doesn't exist in this context");
            }
            if (LeftNode != null)// checks if the Left Node is there
            {
                if (value.CompareTo(LeftNode.Value) == 0)
                {
                    if (LeftNode.LeftNode != null || LeftNode.RightNode != null) //checks if there is something to swimp up
                    {
                        LeftNode.Delete(); // calls the swimDown method for the node whice needs to be deleted
                    }
                    else
                    {
                        LeftNode = null;// deletes the node
                    }
                }
                else if (value.CompareTo(Value) < 0)
                {
                    LeftNode.Locate(value);// Calls the delete Method to continue recursively threw the Left Node
                }
            }
            if (RightNode != null)// checks if the Right Node is there
            {
                if (value.CompareTo(RightNode.Value) == 0)
                {
                    if (RightNode.LeftNode != null || RightNode.RightNode != null) //checks if there is a node to swim up
                    {
                        RightNode.Delete(); // calls the swimDown method for the node whice needs to be deleted
                    }
                    else
                    {
                        RightNode = null; // deletes the node
                    }
                }
                else if (value.CompareTo(Value) > 0) // climbs up the tree to the write
                {
                    RightNode.Locate(value); //Calls the Delete Method to continue recursively threw the Right Node
                }
            }
           
        }
        private void Delete()
        {
            /* SwimDown Method works recursively and is declared when found the node which needs to be delete
             * but the node is a parent to one or two other nodes
             */
            if(RightNode != null)
            {
                Value = RightNode.Value;
                if (RightNode.LeftNode != null || RightNode.RightNode != null)
                {
                    RightNode.Delete();
                }
                else
                {
                    RightNode = null;
                }
            }
            else
            {
                Value = LeftNode.Value;
                if (LeftNode.LeftNode != null || LeftNode.RightNode != null)
                {
                    LeftNode.Delete();
                }
                else
                {
                    LeftNode = null;
                }
            }
        }
        
    }
}
