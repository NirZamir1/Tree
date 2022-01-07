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
        public Node<T> Locate(T value)
        {
           if(value.CompareTo(Value)==0)
            {
                return this;
            }
            else if(value.CompareTo(Value)<0)
            {
                if(LeftNode!=null)
                {
                    return LeftNode.Locate(value);
                }
                else
                {
                   throw new Exception("The value is not exsisting in the currrent context");
                }
            }
           else
            {
                if(RightNode!=null)
                {
                    return RightNode.Locate(value);
                }
                else
                {
                   throw new Exception("The value is not exsisting in the currrent context");
                }
            }
       
        }
     
        public void Delete(T value)
        {
          Locate(value).SwimUp();
        }
        private void SwimUp()
        {
            if(LeftNode != null)
            {
                Value = LeftNode.Value;
                LeftNode.SwimUp();
            }
            else if(RightNode != null)
            {
                Value = RightNode.Value;
                RightNode.SwimUp();
            }
            else
            {
               if(Parent.LeftNode!=null)
                {
                    if(this.Equals(Parent.LeftNode))
                    {
                        Parent.LeftNode = null;
                    }
                }
               else
                {
                    if(this.Equals(Parent.RightNode))
                    {
                        Parent.RightNode = null;
                    }
                }
            }
        }
    
        
    }
}
