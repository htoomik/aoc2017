using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC.Code
{
    class Day07
    {
        public static string Solve(IEnumerable<string> indata)
        {
            var nodes = MakeTree(indata);
            var root = nodes.Single(n => n.IsRoot);
            return root.Name;
        }


        public static int Solve2(IEnumerable<string> indata)
        {
            var nodes = MakeTree(indata);
            var root = nodes.Single(n => n.IsRoot);
            root.CalculateWeight();
            var nodeNotInBalance = nodes
                .Single(n => !n.ChildrenInBalance &&
                            n.Children.All(c => c.ChildrenInBalance));
            var byWeight = nodeNotInBalance.Children.GroupBy(c => c.WeightWithChildren);
            var wrong = byWeight.Single(g => g.Count() == 1).Key;
            var right = byWeight.First(g => g.Count() != 1).Key;
            var diff = right - wrong;
            var correctWeight = nodeNotInBalance.Children.Single(c => c.WeightWithChildren == wrong).Weight + diff;
            return correctWeight;
        }


        private static List<Node> MakeTree(IEnumerable<string> indata)
        {
            var nodes = indata.Select(row => Parse(row)).ToList();
            foreach (var node in nodes)
            {
                foreach (var childName in node.ChildNames)
                {
                    var child = nodes.Single(n => n.Name == childName);
                    node.Children.Add(child);
                    child.IsRoot = false;
                }
            }
            if (nodes.Count(n => n.IsRoot) > 1)
                throw new Exception("More than one root found");
            return nodes;
        }


        private static Node Parse(string row)
        {
            var parts = row.Split(new[] { " -> " }, StringSplitOptions.None);
            var nameAndWeight = parts[0].Split('(');
            var name = nameAndWeight[0].Trim();
            var weight = int.Parse(nameAndWeight[1].Replace(")", "").Trim());
            var childNames = parts.Length > 1 ? parts[1].Split(',').Select(s => s.Trim()).ToList() : new List<string>();
            return new Node
            {
                Name = name,
                Weight = weight,
                ChildNames = childNames
            };
        }

        private class Node
        {
            public string Name;
            public int Weight;
            public List<string> ChildNames;
            public bool IsRoot = true;

            public List<Node> Children;
            public int WeightWithChildren;
            public bool ChildrenInBalance;


            public Node()
            {
                Children = new List<Node>();
            }


            public void CalculateWeight()
            {
                foreach (var c in Children)
                    c.CalculateWeight();

                var childWeights = Children.Select(c => c.WeightWithChildren);
                if (childWeights.Any())
                {
                    WeightWithChildren = Weight + childWeights.Sum();
                    ChildrenInBalance = childWeights.Min() == childWeights.Max();
                }
                else
                {
                    WeightWithChildren = Weight;
                    ChildrenInBalance = true;
                }
            }
        }
    }
}
