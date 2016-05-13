using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Program
    {
        public static Tree AnalyzeString(string str)
        {
                string left = GetAll(str, 1);
                string right = GetAll(str, 2);
                if (left == "" || right == "")
                    return new Tree(new Tree(), str, new Tree());
                if (left[0] == '(')
                    left = left.Substring(1, left.Length - 1);
                if (left[left.Length - 1] == ')')
                    left = left.Substring(0, left.Length - 1);
                if (right[0] == '(')
                    right = right.Substring(1, right.Length - 1);
                if (right[right.Length - 1] == ')')
                    right = right.Substring(0, right.Length - 1);
                return new Tree(AnalyzeString(left), GetChar(str, true), AnalyzeString(right));           
        }
        public static double Calculate(Tree tree)
        {
            try
            {
                if (Convert.ToDouble(tree.value) != null)
                {
                    return Convert.ToDouble(tree.value);
                }
            }
            catch (FormatException)
            {
                switch (tree.value)
                {
                    case "+":
                        return Calculate(tree.leftTree) + Calculate(tree.rightTree);
                        break;
                    case "-":
                        return Calculate(tree.leftTree) - Calculate(tree.rightTree);
                        break;
                    case "/":
                        return Calculate(tree.leftTree) / Calculate(tree.rightTree);
                        break;
                    case "*":
                        return Calculate(tree.leftTree) * Calculate(tree.rightTree);
                        break;
                }
            }
            return 0;
        }
        public static Tree SetTree(Tree leftTree, string str, Tree rightTree)
        {
            if(GetChar(str) != -1) 
            return new Tree(leftTree, GetChar(str, true), rightTree);
            return new Tree(leftTree, str, rightTree);
        }
        public static string GetAll(string str, int num)
        {
            int i = GetChar(str);
            if (i != -1)
            {
                string left = str.Substring(0, i);
                string right = str.Substring(i + 1, str.Length - i - 1);
                if (num == 1)
                    return left;
                return right;
            }
            return "";
        }
        public static int Find(string str, char ch)
        {
            int stat = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == '(')
                    stat++;
                else if (str[i] == ')')
                    stat--;
                else if (str[i] == ')' && stat > 0)
                    stat--;
                else if (str[i] == ')' && stat <= 0)
                    return i - 1;
                else if (stat == 0 && (str[i] == ch))
                    return i;
            }
            return -1;
        }
        public static int GetChar(string str)
        {
            
            int stat = 0;
            if(Find(str, '+') > -1)
            return Find(str, '+');
            else if (Find(str, '-') > -1)
                return Find(str, '-');
            else if (Find(str, '*') > -1)
                return Find(str, '*');
            else if (Find(str, '/') > -1)
                return Find(str, '/');
            return -1;
        }
        public static string GetChar(string str, bool type)
        {
            return str.Substring(GetChar(str), 1);
        }
        static void Main(string[] args)
        {
            string str = Console.ReadLine();
            Console.WriteLine(Calculate(AnalyzeString(str)));
            Console.ReadLine();
        }
    }
}
