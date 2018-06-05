using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LearnProgrammingAcademy.Utils{

    //Imagine the 'T' is the PlayerPrefsController..
    public abstract class Singleton<T> : MonoBehaviour where T : Component{

        // == Constants == 
        private const string NameSuffix = " - Singleton";

        // == Fields ==
        private static T instance;

        // == Properties ==
        //'T' is our type component
        public static T Instance{
            get {
                if(!instance){
                    instance = Find(); // <- Call the Find method
                }
                return instance;
            }
        }

        // == Messages ==
        protected virtual void Awake(){
            if(!instance){
                instance = Find();
            } else{
                //Destroy game object if its duplicated
                Debug.Log($"Duplicated {typeof(T)} destroying...");
                Destroy(gameObject);
            }
        }

        // == Private methods ==
        private static T Find(){
            var singletonComponent = FindObjectOfType<T>();

            //If not found, create it
            if (!singletonComponent)
            {
                //Create new object
                GameObject singletonGameObject = new GameObject();
                // add component to game object
                singletonComponent = singletonGameObject.AddComponent<T>();
                //dont destroy after loading a new scene
                DontDestroyOnLoad(singletonGameObject);
            }
            singletonComponent.gameObject.name = typeof(T).Name + NameSuffix;
            return singletonComponent;
        }

    }
}