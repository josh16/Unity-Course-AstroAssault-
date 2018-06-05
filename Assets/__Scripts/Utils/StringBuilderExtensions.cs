using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text; // StringBuilder class

namespace LearnProgrammingAcademy.Utils
{
   
   public static class StringBuilderExtensions
    {
        // == Constants ==
        public const string Tab = "\t";


        // == Public Methods ==
        public static StringBuilder AppendTab(this StringBuilder sb, int tabCount = 1)
        {
            for (int i = 0; i < tabCount; i++)
            {
                sb.Append(Tab);
            }

            return sb;
        }
       

    }
}