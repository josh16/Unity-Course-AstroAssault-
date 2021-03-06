﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//This class will contain "Parent Names"
// like Global constants and etc
//This will help prevent with duplication of code

namespace LearnProgrammingAcademy.AstroAssault.Utils
{

    //This class can be static because we will never instantiate this class
    public static class ParentUtils{

        //It's Better to have a const name instead of hard coding a string

        // == CONSTANTS ==
        private const string EnemiesParentName = "Enemies";
        private const string BulletsParentName = "Bullets";
        private const string ExplosionsParentName = "Explosions";


        // == public Methods ==
        public static GameObject FindEnemiesParent(){
            return FindParent(EnemiesParentName);
        }

        public static GameObject FindBulletsParent(){
            return FindParent(BulletsParentName);
        }

        public static GameObject FindExplosionsParent(){
            return FindParent(ExplosionsParentName);
        }


        // == private methods == 
        private static GameObject FindParent(string parentName){
            var nameOfParent = GameObject.Find(parentName); //looks for object with name

            //Check to see if parent is null and if so, object will be created
            if (!nameOfParent)
            {
                Debug.Log($"{parentName}Parent not found, creating a new one!");
                nameOfParent = new GameObject(parentName);
            }
            return nameOfParent;
        }


    }
}