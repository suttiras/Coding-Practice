using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
    class People:IComparable
    {
        public string name { get; set; }

        public People(string name)
        {
            this.name = name;
        }

        public int CompareTo(object obj)
        {
            People other = obj as People;
            return this.name.CompareTo(other.name);
        }

        public override string ToString()
        {
            return this.name;
        }
    }

    class BST
    {
        // Creating Binary Search Tree node class
        class Node<T>
        {
            public T data;
            public Node<T> left;
            public Node<T> right;
            public Node(T value)
            {
                this.data = value;
                left = null;
                right = null;
            }
        }
        class BinarySearchTree<T> where T : IComparable
        {
            //public Node<int> root;
            //public Node<string> root;
            //public Node<People> root;
            public Node<T> root;
            static int count;
            public BinarySearchTree()
            {
                root = null;
            }

            // Creates and returns a BST node
            //public Node<int> addNode(int data)
            //public Node<string> addNode(string data)
            //public Node<People> addNode(People data)
            public Node<T> addNode(T data)
            {
                //Node<int> temp = new Node<int>(data);
               // Node<string> temp = new Node<string>(data);
               // Node<People> temp = new Node<People>(data);
                Node<T> temp = new Node<T>(data);
                if (root == null)
                    root = temp;
                count++;
                return temp;
            }

            // Procedure inserts 'newNode' in BST at proper position
            //public void insert(Node<int> root, Node<int> newNode)
            //public void insert(Node<string> root, Node<string> newNode)
            //public void insert(Node<People> root, Node<People> newNode)
            public void insert(Node<T> root, Node<T> newNode)
            {                
                if (root == null)
                {
                    root = newNode;
                }
                //else if (root.left == null && newNode.data <= root.data)
                else if (root.left == null && (newNode.data.CompareTo(root.data) < 0 || newNode.data.CompareTo(root.data) == 0))
                {
                    root.left = newNode;
                }
                //else if (root.right == null && newNode.data >= root.data)
                else if (root.right == null && (newNode.data.CompareTo(root.data) > 0 || newNode.data.CompareTo(root.data) == 0))
                {
                    root.right = newNode;
                }
                else
                {
                    //if (root.data > newNode.data)
                    if (root.data.CompareTo(newNode.data) > 0)
                    {
                        insert(root.left, newNode);
                    }
                    //else if (root.data < newNode.data)
                    else
                    {
                        insert(root.right, newNode);
                    }
                }       
            }
            // Recursive Procedure travels BST tree in Inorder Fashion (left subtree -> root -> right Subtree)
            //public void inorder(Node<int> root)
            //public void inorder(Node<string> root)
            //public void inorder(Node<People> root)
            public void inorder(Node<T> root)
            {
                if (root != null)
                {
                    inorder(root.left);
                    Console.Write(root.data + " ");
                    inorder(root.right);
                }
            }

            public void inorder2(Node<T> root)
            {
                Stack<Node<T>> stack = new Stack<Node<T>>();
                Node<T> currentNode = root;
                //stack.Push(currentNode);
                bool done = false;
                while(!done)
                {
                    if(currentNode != null)
                    {
                        stack.Push(currentNode);
                        currentNode = currentNode.left;
                    }
                    else
                    {
                        if (stack.Count == 0)
                            done = true;
                        else
                        {
                            currentNode = stack.Pop();
                            Console.WriteLine(currentNode.data);
                            currentNode = currentNode.right;
                        }

                    }                    
                }

            }

            public void inorder3(Node<T> root)
            {
                Stack<Node<T>> stack = new Stack<Node<T>>();
                Node<T> currentNode = root;

                while (stack.Count != 0 || currentNode != null)
                {
                    if (currentNode != null)
                    {
                        stack.Push(currentNode);
                        currentNode = currentNode.left;
                    }
                    else
                    {
                        currentNode = stack.Pop();
                        Console.WriteLine(currentNode.data);
                        currentNode = currentNode.right;
                    }
                }
            }

            //public int getHeight(Node<int> node, int count)
            //public int getHeight(Node<People> node, int count)
            public int getHeight(Node<T> node, int count)
            {
                if (node == null)
                {
                    return count;
                }
                else
                {
                    if (node.left != null && node.right != null)
                    {
                        int left = getHeight(node.left, count + 1);
                        int right = getHeight(node.right, count + 1);
                        if (left > right)
                            return left;
                        else
                            return right;
                    }
                    else if (node.left != null && node.right == null)
                    {
                        return getHeight(node.left, count + 1);
                    }
                    else if (node.left == null && node.right != null)
                        return getHeight(node.right, count + 1);
                    else
                        return count;
                }
            }
            
            //public bool isBalanced(Node<int> root)
            //public bool isBalanced(Node<People> root)
            public bool isBalanced(Node<T> root)
            {
                int left = getHeight(root.left, 0);
                int right = getHeight(root.right, 0);
                return (left == right || (left + 1) == right || left == (right + 1));
                //if (left == right || (left + 1) == right || left == (right + 1))
                //    return true;
                //else
                //    return false;
            }

            //public bool isSymmetric(Node<int> root)
            //public bool isSymmetric(Node<People> root)
            public bool isSymmetric(Node<T> root)
            {
                return isSymmetricHelper(root.left, root.right);
            }

            //public bool isSymmetricHelper(Node<int> left, Node<int> right)
            //public bool isSymmetricHelper(Node<People> left, Node<People> right)
            public bool isSymmetricHelper(Node<T> left, Node<T> right)
            {

                if (left == null && right == null)
                    return true;
                else if (left != null && right != null)
                {
                    return (isSymmetricHelper(left.left, right.right) && isSymmetricHelper(left.right, right.left) && (left.data.CompareTo(right.data) == 0));
                }
                else
                {
                    return false;
                }
            }
        }
        static void Main(string[] args)
        {
            BinarySearchTree<People> bst = new BinarySearchTree<People>();
            // Inserting Nodes to Binary search Tree
            //bst.insert(bst.root, bst.addNode("21"));
            //bst.insert(bst.root, bst.addNode("19"));
            //bst.insert(bst.root, bst.addNode(7));
            //bst.insert(bst.root, bst.addNode(19));
            //bst.insert(bst.root, bst.addNode(16));
            //bst.insert(bst.root, bst.addNode(13));
            //bst.insert(bst.root, bst.addNode(8));
            //bst.insert(bst.root, bst.addNode("22"));
            bst.insert(bst.root, bst.addNode(new People("Sandra")));
            bst.insert(bst.root, bst.addNode(new People("Bob")));
            bst.insert(bst.root, bst.addNode(new People("Steve")));
            bst.insert(bst.root, bst.addNode(new People("Tom")));
            bst.insert(bst.root, bst.addNode(new People("Carl")));
            // Traversing BST in Inorder fashion
            bst.inorder3(bst.root);
            int temp = bst.getHeight(bst.root, 0);
            bool isBalanced1 = bst.isBalanced(bst.root);
            bool isSymmetricv = bst.isSymmetric(bst.root);
            Console.ReadKey();
        }
    }
}
