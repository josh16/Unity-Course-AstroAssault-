using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace LearnProgrammingAcademy.Utils{

    public static class ListUtils { // This class will not extend from MonoBehaviour

        public static Stack<T>CreateShuffledStack<T>(IList<T> values) where T : Object { // T will extend from Object
            
            //Copy list
            var list = new List<T> (values);
            var Stack = new Stack<T>();

            //While loop for removing item at randomIndex and then pushing it to the top of the stack
            // After pushing it to the top, we return the stack
            while (list.Count > 0)
            {
                //Get next item at random index
                var randomIndex = Random.Range(0, list.Count);
                var randomItem = list[randomIndex];

                //Remove item from list and push it to the top of the stack
                list.RemoveAt(randomIndex); //Remove from list
                Stack.Push(randomItem); // We push at the top of the stack
            }

            return Stack;

        }

    }
}
