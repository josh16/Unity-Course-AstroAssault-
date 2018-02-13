using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;



namespace GettingBetterAtProgramming
{

    public class Practice : MonoBehaviour
    {
        #region == Type Conversion ==
        //Type conversion is converting one type of data to another

        /*
            Implicit type conversion: 
            -These conversions are performed by C#
            in a type-safe manner. For example, are conversions from smaller to
            larger integral types and conversions from derived classes to base classes.

            -Integral Types ex: sbyte, byte,ushort,int,uint,long,ulong,and char

            Explicit type conversion
            -These conversions are done explicitly by users using the pre-defined functions.
            Explicit conversions require a cast operator.
        */

        //Example:
        private void ExplicitConversion()
        {
            double d = 56.74;
            int i;

            //We are going to cast double to int
            i = (int)d;
            Debug.Log(i);
        }

        // C# provides built-in-type conversions methods
        private void stringConversion()
        {
            int i = 75;
            float f = 53.405f;
            double d = 2345.4321;
            bool b = true;

            //All these Various types gets converted to string
            Debug.Log(i.ToString());
            Debug.Log(f.ToString());
            Debug.Log(d.ToString());
            Debug.Log(b.ToString());

        }

        #endregion


        #region == Encapsulation ==

        //Encapsulation

        /*
            - 'Encapsulation' is defined as the process of enclosing one or more items within
            a physical or logical package'. Encapsulation, in object oriented programming methodology,
            prevents access to implementation details.

            -Abstraction and encapsulation are related features in OOP. Abstraction allows making relevant
            information visible and encapsulation enables a programmer to 'implement' the desired level of abstraction.

            -Encapsulations is implemented by using "access specifiers"

            -Example:
                -Public
                -Private
                -Protected
                -Internal
                -Protected Internal
            */

            /*Public Access Specifier

            -Public access specifier allows a class to expose its member variables and
            member functions to other functions and objects. Any member can be accessed from out the class

            Example below..
            */

        class Rectangle{
            //Public members
            public double length;
            public double width;

            //Public Method
            public double GetArea(){
                return length * width;
            }
        
            public void Display()
            {
                Debug.Log($"Length = {length}");
                Debug.Log($"Width = {width}");
                Debug.Log($"Area = {GetArea()}"); // Gets the whole area
            }
        
        }

        class ExecuteRectangle{
            public void Start()
            {
                Rectangle r = new Rectangle();
                r.length = 4.3;
                r.width = 5.5;
                r.Display();
            }
        }

        /* Private Access Specifier
         -Private access specifier allows a class to hide its member variables and member
         functions from other functions and objects. Only functions of the same class can access
         its private members. Even an instance of a class cannot access its private members

        -Example Below...
         
         */

        class RectangleTwo{
            //member variables
            private double length;
            private double width;

            //this function will accept user input
            public void AcceptDetails(){
                Console.WriteLine("Enter Length: ");
                length = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Enter Width: ");
                width = Convert.ToDouble(Console.ReadLine());

               }
        
            public double GetArea()
            {
                return length * width;
            }
       
          
        
        }


        #endregion


    }
}
