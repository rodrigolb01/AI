/******************************************************************************

Welcome to GDB Online.
GDB online is an online compiler and debugger tool for C, C++, Python, Java, PHP, Ruby, Perl,
C#, OCaml, VB, Swift, Pascal, Fortran, Haskell, Objective-C, Assembly, HTML, CSS, JS, SQLite, Prolog.
Code, Compile, Run and Debug online from anywhere in world.

*******************************************************************************/
using System;
using System.Collections.Generic;

class HelloWorld {
    
  struct Move {
      public string start;
      public int cost;
      public string target;

      public Move(string _start, int _cost, string _target)
      {
          this.start = _start;
          this.cost = _cost;
          this.target = _target;
      }
  }
    
  static Move findLowest(List<Move> input)
  {
      Move lowest = input[0];
      for(int i=0; i<input.Count; i++)
      {
          foreach(Move v in input)
          {
              if(v.cost < lowest.cost)
                  lowest = v;
          }
      }
      return lowest;
  }
  
  static List<Move> greedyAlgorithm(string start, List<Move> inputs, string target)
  {
      string current = start;
      List<Move> path = new List<Move>();
      if(String.Equals(current,target) == true)
      {
          return null;
      }
      else
      {
          while(String.Equals(current,target) == false)
          {
              List<Move> possibilites = new List<Move>();
              foreach(Move m in inputs)
              {
                  if(String.Equals(m.start,current) == true)
                  {
                      possibilites.Add(m);
                  }
              }
              Move pick = findLowest(possibilites);
              current = pick.target;
              Console.WriteLine("{0} - {1} - {2}", pick.start, pick.cost, pick.target);
          }
          return path;
      }
  }
  
  static void Main() {
      Move SibilFaragas = new Move("A",99,"B");
      Move FaragasBucharest = new Move("B",211,"E");
      Move SibilRimmicu = new Move("A",80,"C");
      Move RimmicuPiltesti = new Move("C",97,"D");
      Move PiltestiBucharest = new Move("D", 101, "E");
      
      List<Move> input = new List<Move>();
      input.Add(SibilFaragas);
      input.Add(FaragasBucharest);
      input.Add(SibilRimmicu);
      input.Add(RimmicuPiltesti);
      input.Add(PiltestiBucharest);
      
      List<Move> output = new List<Move>();
      output = greedyAlgorithm("A",input,"E");
     
  }
}