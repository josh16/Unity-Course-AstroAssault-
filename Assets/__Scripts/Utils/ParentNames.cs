using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//This class will contain "Parent Names"
// like Global constants and etc
//This will help prevent with duplication of code

namespace LearnProgrammingAcademy.AstroAssault.Utils
{

    //This class can be static because we will never instantiate this class
    public static class ParentNames{

        //It's Better to have a const name instead of hard coding a string

        // == CONSTANTS ==
        public const string ENEMIES_PARENT_NAME = "Enemies";
        public const string SPAWN_METHOD_NAME = "Spawn";
        public const string BULLETS_PARENT_NAME = "Bullets";


    }
}