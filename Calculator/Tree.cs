using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Tree
    {
        string value;
        Tree leftTree;
        Tree rightTree;
        public Tree(Tree leftTree, string value, Tree rightTree)
        {
            this.leftTree = leftTree;
            this.value = value;
            this.rightTree = rightTree;
        }
    }
}
