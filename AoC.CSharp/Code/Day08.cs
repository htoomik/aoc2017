using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC.Code
{
    public static class Day08
    {
        public static dynamic Solve(IEnumerable<string> input)
        {
            var instructions = input.Select(Parse);
            var registers = new Dictionary<string, int>();
            var max = 0;

            foreach (var i in instructions)
            {
                if (EvaluateCondition(i, registers))
                {
                    if (!registers.ContainsKey(i.Register))
                        registers.Add(i.Register, 0);
                    var currentValue = registers[i.Register];
                    var newValue = currentValue + i.Increment;
                    max = Math.Max(max, newValue);
                    registers[i.Register] = newValue;
                }
            }

            return new
            {
                FinalMax = registers.Values.Max(),
                RunningMax = max
            };
        }


        private static bool EvaluateCondition(Instruction i, Dictionary<string, int> registers)
        {
            var value1 =0 ;
            registers.TryGetValue(i.ConditionRegister, out value1);
            var value2 = i.ConditionTerm;
            switch (i.ConditionOperator)
            {
                case "<": return value1 < value2;
                case ">": return value1 > value2;
                case "==": return value1 == value2;
                case ">=": return value1 >= value2;
                case "<=": return value1 <= value2;
                case "!=": return value1 != value2;
                default: throw new Exception("Unexpected condition " + i.ConditionOperator);
            }
        }

        private static Instruction Parse(string s)
        {
            var parts = s.Split(' ');
            return new Instruction
            {
                Register = parts[0],
                Operation = parts[1],
                Term = int.Parse(parts[2]),
                ConditionRegister = parts[4],
                ConditionOperator = parts[5],
                ConditionTerm = int.Parse(parts[6])
            };
        }

        private class Instruction
        {
            public string Register;
            public string Operation;
            public int Term;
            public string ConditionRegister;
            public string ConditionOperator;
            public int ConditionTerm;

            public int Increment
            {
                get
                {
                    switch (Operation)
                    {
                        case "inc": return Term;
                        case "dec": return -Term;
                        default: throw new Exception("Unexpected operation " + Operation);
                    }
                }
            }
        }
    }
}
