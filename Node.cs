using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace binary_Search_Tree
{
    public class Node<T> :IEnumerable<T>  where T : IComparable 
    {
        Node<T> RightNode;
        Node<T> LeftNode;
        public T Value;
        public Node<T>? Parent { get;}
        public Node(T value, Node<T>? parent = null)
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
        public Node<T> toBottom()
        {
            if(LeftNode != null)
            {
               return LeftNode.toBottom();
            }
            else
            {
                return this;
            }
        }
        public Node<T> NextInOrder()
        {
            if(RightNode != null)
            {
                return RightNode;
            }
            else if (Parent != null)
            {
                if(Value.CompareTo(Parent.Value)>0)
                {
                    if(Parent.Parent != null)
                    {
                        return Parent.Parent;
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return Parent;
                }
            }
            else
            {
                return null;
            }
        }
        public IEnumerator<T> GetEnumerator()
        {
            Enumartor<T> enumartor = new Enumartor<T>(this);
            return enumartor;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
    public class Enumartor<T> : IEnumerator<T> where T  : IComparable
    {
        public object Current => tree;
        Node<T> nextTree;
        T IEnumerator<T>.Current => tree.Value;

        private Node<T> tree;
        public Enumartor(Node<T> tree_)
        {
            tree = tree_.toBottom();
            nextTree = tree;
        }

        public bool MoveNext()
        {
            tree = nextTree;
            if (nextTree != null)
            {
                nextTree = nextTree.NextInOrder();
            }
            if (tree != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
        }
    }

}
