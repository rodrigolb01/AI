/******************************************************************************

Welcome to GDB Online.
GDB online is an online compiler and debugger tool for C, C++, Python, Java, PHP, Ruby, Perl,
C#, OCaml, VB, Swift, Pascal, Fortran, Haskell, Objective-C, Assembly, HTML, CSS, JS, SQLite, Prolog.
Code, Compile, Run and Debug online from anywhere in world.

*******************************************************************************/
using System;
using System.Collections.Generic;

class HelloWorld
{
    struct Move
    {
        public char start;

        public int cost;

        public char target;

        public bool explored;

        public Move(char _start, int _cost, char _target, bool _explored)
        {
            this.start = _start;
            this.cost = _cost;
            this.target = _target;
            this.explored = _explored;
        }
    }

    static Move findLowest(List<Move> input)
    {
        Move lowest = input[0];
        for (int i = 0; i < input.Count; i++)
        {
            Console.WriteLine (i);
            foreach (Move v in input)
            {
                if (v.cost < lowest.cost) lowest = v;
            }
        }
        return lowest;
    }

    static List<Move>
    greedyAlgorithm(char start, List<Move> inputs, char target)
    {
        char current = start;
        List<Move> path = new List<Move>();
        if (current == target)
        {
            return path;
        }
        else
        {
            while (current != target)
            {
                List<Move> possibilites = new List<Move>();
                foreach (Move m in inputs)
                {
                    Console
                        .WriteLine("Iteration for Move {0}-{1}-{2}-explored {3}",
                        m.start,
                        m.cost,
                        m.target,
                        m.explored);
                    if ((m.start == current) && m.explored == false)
                    {
                        possibilites.Add (m);
                    }
                }
                if (possibilites.Count > 0)
                {
                    Move pick = findLowest(possibilites);
                    current = pick.target;
                    Console
                        .WriteLine("{0} - {1} - {2}",
                        pick.start,
                        pick.cost,
                        pick.target);

                    // mark pick as explored;
                    //if reverse path exists mark as explored
                    for (int i = 0; i < inputs.Count; i++)
                    {
                        if (
                            (
                            (inputs[i].start == pick.start) &&
                            (inputs[i].target == pick.target) ||
                            (
                            (inputs[i].start == pick.target) &&
                            (inputs[i].target == pick.start)
                            )
                            )
                        )
                        {
                            inputs[i] =
                                new Move(inputs[i].start,
                                    inputs[i].cost,
                                    inputs[i].target,
                                    true);
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Nao foi possivel achar o caminho");
                    return path;
                }
            }
            return path;
        }
    }

    static void Main()
    {
        Move AB = new Move('A', 10, 'B', false);
        Move BA = new Move('B', 10, 'A', false);

        Move AD = new Move('A', 12, 'D', false);
        Move DA = new Move('D', 12, 'A', false);

        Move BC = new Move('B', 9, 'C', false);
        Move CB = new Move('C', 9, 'B', false);

        Move CD = new Move('C', 15, 'D', false);
        Move DC = new Move('D', 15, 'C', false);

        Move DE = new Move('D', 16, 'E', false);
        Move ED = new Move('E', 16, 'D', false);

        List<Move> input = new List<Move>();
        input.Add (AB);
        input.Add (BA);

        input.Add (AD);
        input.Add (DA);

        input.Add (BC);
        input.Add (CB);

        input.Add (CD);
        input.Add (DC);

        input.Add (DE);
        input.Add (ED);

        greedyAlgorithm('A', input, 'E');
    }
}
