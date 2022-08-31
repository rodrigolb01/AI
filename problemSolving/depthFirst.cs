/******************************************************************************

Welcome to GDB Online.
GDB online is an online compiler and debugger tool for C, C++, Python, Java, PHP, Ruby, Perl,
C#, OCaml, VB, Swift, Pascal, Fortran, Haskell, Objective-C, Assembly, HTML, CSS, JS, SQLite, Prolog.
Code, Compile, Run and Debug online from anywhere in world.

*******************************************************************************/
using System;

struct Node {
    public int value;
    public Node[] branches;

    public Node(int _value, Node[] _branches)
    {
        this.value = _value;
        this.branches = _branches;
    }
    
    public void PrintTree(Node root) 
    {
        Console.WriteLine(root.value);
        for(int i=0; i<root.branches.Length; i++)
        {
            PrintTree(root.branches[i]);
        }
    }
    
    public void DeptFirstSearch(Node root, int target)
    {
        //Console.WriteLine("current value is {0}", root.value);
        if(root.value == target)
            Console.WriteLine("Target found with value {0}", root.value);
        else
        {
            for(int i=0; i<root.branches.Length; i++)
            {
                DeptFirstSearch(root.branches[i], target);
            }
        }
    }
};
    
class HelloWorld {
  static void Main() {
    Console.WriteLine("Hello World");
    
    Node[] emptyArr = {};
    Node n8 = new Node(8, emptyArr);
    Node n9 = new Node(9, emptyArr);
    Node[] n4Branches = {n8, n9};
    
    Node n10 = new Node(10, emptyArr);
    Node n11 = new Node(11, emptyArr);
    Node[] n5Branches = {n10, n11};
    
    Node n12 = new Node(12, emptyArr);
    Node n13 = new Node(13, emptyArr);
    Node[] n6Branches = {n12, n13};
    
    Node n14 = new Node(14, emptyArr);
    Node n15 = new Node(15, emptyArr);
    Node[] n7Branches = {n14, n15};
    
    Node n4 = new Node(4, n4Branches);
    Node n5 = new Node(5, n5Branches);
    Node[] n2Branches = {n4, n5};
    
    Node n6 = new Node(6, n6Branches);
    Node n7 = new Node(7, n7Branches);
    Node[] n3Branches = {n6, n7};
    
    
    Node n3 = new Node(3, n3Branches);
    Node n2 = new Node(2, n2Branches);
    Node[] newArr = {n2, n3};
    Node n1 = new Node(1, newArr);
    
    n1.PrintTree(n1);
    n1.DeptFirstSearch(n1, 7);
  }
}