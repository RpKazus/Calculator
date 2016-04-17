using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Program
    {
        private double AnalyzeString(string str)
        {
            
        }
        private Tree SetTree(Tree leftTree, string str, Tree rightTree)
        {
            return new Tree(leftTree, if(GetChar(str) != null) ? str.Substring(GetChar(str),GetChar(str) : str), rightTree);
        }
        private int GetChar(string str)
        {
            int stat = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == '(')
                    stat++;
                else if (str[i] == ')')
                    stat--;
                else if (str[i] == '+' || str[i] == '-' || str[i] == '/' || str[i] == '*')
                    return i;
            }
            return null;
        }
        int marker1;
        int marker2;
        static void Main(string[] args)
        {

        }
    }
}
