using System;
using System.Collections.Generic;

namespace Populating_Next_Right_Pointers_in_Each_Node
{
  class Program
  {
    static void Main(string[] args)
    {
      Node root = new Node(1);

      root.left = new Node(2);
      root.left.left = new Node(4);
      root.left.right = new Node(5);

      root.right = new Node(3);
      root.right.left = new Node(6);
      root.right.right = new Node(7);

      Solution s = new Solution();
      s.Connect(root);
    }
  }

  public class Node
  {
    public int val;
    public Node left;
    public Node right;
    public Node next;

    public Node() { }

    public Node(int _val)
    {
      val = _val;
    }

    public Node(int _val, Node _left, Node _right, Node _next)
    {
      val = _val;
      left = _left;
      right = _right;
      next = _next;
    }
  }

  public class Solution
  {
    // Simple solution Using Level Order
    // at each level we track the prev node and link prev.next = cur
    public Node Connect(Node root)
    {
      if (root == null) return root;
      Queue<Node> q = new Queue<Node>();
      root.next = null;
      if (root.left != null)
        q.Enqueue(root.left);
      if (root.right != null)
        q.Enqueue(root.right);

      while (q.Count > 0)
      {
        int size = q.Count;
        Node prev = null;
        while (size-- > 0)
        {
          var node = q.Dequeue();
          if (node != null)
          {
            if (prev == null) prev = node;
            else
            {
              prev.next = node;
              prev = node;
            }
            //node.next = null;
            if (node.left != null)
              q.Enqueue(node.left);
            if (node.right != null)
              q.Enqueue(node.right);
          }
        }
      }

      return root;
    }
  }
}
