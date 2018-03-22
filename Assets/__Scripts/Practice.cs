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

            -Integral Types ex: sbyte, byte, ushort, int, uint, long, ulong, and char

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

        class Rectangle
        {
            //Public members
            public double length;
            public double width;

            //Public Method
            public double GetArea()
            {
                return length * width;
            }

            public void Display()
            {
                Debug.Log($"Length = {length}");
                Debug.Log($"Width = {width}");
                Debug.Log($"Area = {GetArea()}"); // Gets the whole area
            }

        }

        class ExecuteRectangle
        {
            public void Start()
            {
                Rectangle r = new Rectangle();
                r.length = 4.3;
                r.width = 5.5;
                r.Display();
            }
        }

        /* PRIVATE ACCESS SPECIFIER
         -Private access specifier allows a class to hide its member variables and member
         functions from other functions and objects. Only functions of the same class can access
         its private members. Even an instance of a class cannot access its private members

        -Example Below...
         
         */

        class RectangleTwo
        {
            //member variables
            private double length;
            private double width;

            //This function will accept user input
            public void AcceptDetails()
            {
                Console.WriteLine("Enter Length: ");
                length = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Enter Width: ");
                width = Convert.ToDouble(Console.ReadLine());

            }

            public double GetArea()
            {
                return length * width;
            }

            //Display the input
            public void Display()
            {
                Console.WriteLine("Length: {0}", length);
                Console.WriteLine("Width: {0}", width);
                Console.WriteLine("Area: {0}", GetArea());
            }


        }

        class ExecuteRectangle2
        {
            static void Main(string[] args)
            {
                RectangleTwo r = new RectangleTwo();
                r.AcceptDetails();
                r.Display();
                Console.ReadLine();
            }
        }


        // PROTECTED Access Specifier
        /*
            - Protected access specifier allows a child class to access member variables and
            member functions of its base class. This way it helps implementing inheritance.

        */


        //INTERNAL Access Specifier
        /*
            -Internal access specifier allows a class to expose its member variables and member
            functions to other functions and objects in the current assembly. In other words, any member
            with internal access specifier can be accessed from any class or method defined within the
            application in which the member is defined
          
            -TIP! If a method isn't declared an access specifer, it is automatically 'private'

        */


        //Example:

        class Rectangle3
        {
            //member variables
            internal double length;
            internal double width;

            //return Area Method
            double GetArea()
            {
                return length * width;
            }

            //Display Function
            public void Display()
            {
                Console.WriteLine("Length:{0}", length);
                Console.WriteLine("width:{0}", width);
                Console.WriteLine("Area: {0}", GetArea());
            }

        }

        class ExecuteRectangle3
        {
            static void Main(string[] args)
            {
                Rectangle3 r = new Rectangle3();
                r.length = 4.5;
                r.width = 3.5;
                r.Display();
                Console.ReadLine();
            }
        }



        //PROTECTED INTERNAL access specifier
        /*
            -The protected internal access specifier allows a class to hide its member variables
            and member functions from other class objects and functions, except a child class within
            the same application. This is also used while implementing inheritance.
         
        */


        #endregion

        #region == Passing Parameters by Value  ==

        /*
            -This is the default mechanism for passing parameters to a method. In this mechanism, when
            a method is called, a new storage location is created for each value parameter.

            - The values of the actual parameters are copied into them. Hence, the changes made to the
            parameter inside the method have no effect on the argument. 

        Example Below:

        */

        class NumberMainipulator
        {
            public void swap(int x, int y)
            {
                int temp;

                temp = x; // Save the value of x
                x = y; // put y into x
                y = temp;
            }

            static void Main(string[] args)
            {
                NumberMainipulator n = new NumberMainipulator();

                //local variable definition
                int a = 100;
                int b = 200;

                Console.WriteLine("Before Swap, value of a:{0}", a);
                Console.WriteLine("Before Swap, value of b: {0}", b);


                //Call the swap function to swap the values
                n.swap(a, b);

                Console.WriteLine("After Swap, value of a:{0}", a);
                Console.WriteLine("After Swap, value of b: {0}", b);

                Console.ReadLine();
            }


            // When the code above is compiled, it will show that there is no change
            // in the value even though they changed inside the function!

        }


        #endregion

        #region == Passing Parameters by Reference ==

        /*
            - A reference parameter is a reference to a memory location of a variable.
            When you pass parameters by reference, unlike value parameters, a new storage
            location is not created for these parameters. The reference parameters represent the same
            memory location as the actual parameters that are supplied to the method.

            - You can declare the reference parameters using the 'ref' key
          word. 


        Example Below:
        
        */

        class NumberManipulator2
        {
            public void swap(ref int x, ref int y)
            {
                int temp;

                temp = x;
                x = y;
                y = temp;
            }

        }

        static void Main(string[] args)
        {
            NumberManipulator2 n = new NumberManipulator2();

            //local variable definition
            int a = 200;
            int b = 500;

            Console.WriteLine("Before the Swap for a {0}", a);
            Console.WriteLine("Before the Swap for b {0}", b);


            //Calling Swap function here
            n.swap(ref a, ref b);


            Console.WriteLine("After the Swap for a {0}", a);
            Console.WriteLine("After the Swap for b {0}", b);

            Console.ReadLine();

        }


        // It Shows that the values have changed inside the swap function and this
        // change reflects in the Main Function


        #endregion

        #region == Passing Parameters Output ==

        /*
           - A return statement can be used for returning only one value from a function.
           However, using output parameters, you can return two values from a function. Output
           parameters are similar to reference parameters, except that they transfer data 
           OUT of the method rather than into it.

           **! use the keyword 'out'  before the type and name

           Example below:
        */

        class NumberManipulator3
        {
            public void GetValue(out int x)
            {
                int temp = 5;
                x = temp;
            }
        }

        static void Main()
        {
            NumberManipulator3 n = new NumberManipulator3();

            // local variable declaration
            int a = 100;

            Console.WriteLine("Before Method call, the value of a is: {0}", a);

            //Calling a function to get the value
            n.GetValue(out a);
            Console.WriteLine("After Method call, the value of a is: {0}", a);
            Console.ReadLine();

        }

        /* 
            -The variable supplied for the output parameter need not to be assigned a value.
            Output parameters are particularly useful when you need to return values from a method
            through the parameters without assigning an initial value to the parameter.
    


        Here is another example:

        */
        class NumberManipulator4
        {
            public void GetValues(out int x, out int y)
            {
                Console.WriteLine("Enter the First value: ");
                x = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter the Second Value: ");
                y = Convert.ToInt32(Console.ReadLine());
            }
        }

        class manipulatinNumbers
        {
            static void Main()
            {
                NumberManipulator4 n = new NumberManipulator4();

                //local variable declaration
                int a, b;

                //Call the Get Values function
                n.GetValues(out a, out b);
                Console.WriteLine("After Method call, value of a:{0}", a);
                Console.WriteLine("After Method call, value of b:{0}", b);
                Console.ReadLine();


            }
        }


        #endregion

        #region == Nullables(UNFINISHED) ==

        /*
            - C# provides a special data types, the 'nullables' types to which you can
              assign normal range values as well as null values.

            - For example, you can store any value from -2,147,483,648 to 2,147,483,647
              or null in a Nullable<Int32> variable. Similarly, you can assign true, false
              or null in a Nullable<bool> variable. Syntax for declaring 'nullable' type is
              as follows

            <data_type>? <variable_name> = null;

        */

        // Example below will demonstrate use of nullable data types

        class NullablesAtShow
        {
            static void Main(string[] args)
            {
                int? num1 = null;
                int? num2 = 45;

                double? num3 = new double?();
                double? num4 = 3.14157;

                bool? boolval = new bool?();

                //display the values
                Console.WriteLine("Nullables at Show: {0},{1},{2},{3}", num1, num2, num3, num4);
                Console.WriteLine("A Nullable boolean value: {0}", boolval);
                Console.ReadLine();
            }
        }

        // The Null Coalescing operator (??)

        #endregion

        #region == Arrays ==

        /*
            - An array stores a fixed-size sequential collection of elements of the same
              type. An array is used to store a collection of data, but it is often more useful
              to think if an array as a collection of variables of the same type stored at contiguous
              memory locations.


            - Instead of declaring individual variables, such as number0, number1, ..., and
              number99, you declare one array variable such as numbers and use numbers[0], numbers[1],
              and.., numbers[99] to represent individual variables. A Specific element in an array is 
              accessed by an index.


            -All arrays consist of contigious memory locations. The lowest address corresponds to the
             first element and the highest address to the last element.

            Example..

             First Element                                    Last element
            | Numbers[0] | Numbers[1] | Numbers[2] | Numbers[3] | ..... | 

        */


        //** DECLARATION ** 

        //datatype[] arrayName;
        int[] intArray;

        // Initializing an Array with 5 elements(Size of the array) and using the 'new' keyword
        double[] doubleArray = new double[5];

        // Assigning Values to an Array
        //You can assign values to individual array elements, by using the index number
        int[] balance = new int[10];
        //balance[0] = 300;


        //Assign the values of the Array at time of declaration
        double[] Array = { 45.0, 52.1, 59.8 };

        //Create and initialize the Array
        int[] Array2 = new int[5] { 88, 67, 10, 25, 40 };

        //Omitting the Size of the Array
        int[] Array3 = new int[] { 89, 20, 10, 67, 89 };


        //Copying an array into another target array variable
        int[] marks = new int[] { 100, 6, 9, 10 };
        //int[]score = marks;


        //Accessing Array Elements
        /*
            - An element is accessed by indexing the array name. This is done by
              placing the index of the element within square brackets after the name of
              the array.

            Example: 
                    double salary = balance[9];
        */


        class MyArray
        {
            static void Main(string[] args)
            {
                int[] n = new int[10];
                int i, j;

                //Initialize elements of array
                for (i = 0; i < 10; i++)
                {
                    n[i] = i + 100;
                }

                //output each arrays element's value
                for (j = 0; j < 10; j++)
                {
                    Console.WriteLine("Element{0}={1}", j, n[i]);
                }
                Console.ReadKey();
            }
        }

        //When this is compiled, the result is.
        //Element[0] = 100;
        //Element[1] = 101;
        //Element[2] = 102;


        //Using the ForEach Loop
        class MyArray2
        {
            static void Main(string[] args)
            {
                int[] n = new int[10];

                //initialize elements of the array
                for (int i = 0; i < 10; i++)
                {
                    n[i] = i + 100;
                }

                //ForEach Loop
                foreach (int j in n)
                {
                    int i = j - 100;
                    Console.WriteLine("Element{0} = {1}", i, j);
                }


            }
        }


        #endregion

        #region == Multidimentsional Arrays ==
        /*
            - Multidimensional arrays are also called rectangular arrays(2d)

            - Syntax of 2D: string [,] names; <- 2D array of type string

            - Syntax of 3D: int [, , ] m;

            -The Simplest form of the multidimensional array is the 2-dimensional array.
             A 2D array is a list of 1D arrays.

            -A 2D array can be thought of as a table, which has x number of rows and y number
             of columns.

            - Thus, every element in the array is identified by an element name of 'a[i,j]', where
              'a' is the name of the array, and i and j are the subscripts that uniquely identify each
              element in array 'a'.

            Initializing Two-Demensional Arrays

            -Multidimensional arrays be initialized by specifying bracketed values for
             each row.

            Example:....

        */


        class RandomArray
        {
            //Init 2D array below...
            public int[,] a = new int[3, 4]{
                {0,5,5,200},
                {2,8,9,10},
                {45,67,90,2}

            };



            /* Accessing Two-Dimensional Array Elements

                - An elelment in a 2D array is accessed by using the subscripts. That is
                  row index and column index of the array..

                Example below...

                 int val = [2, 3];

                -The above statement takes the 4th element of the 3rd row of the array. You
                 can verify it in the above diagram.

            */

        }

        // This program will handle a 2D array

        class MyArray3
        {
            static void Main(string[] args)
            {
                //Declare an array with 5 rows and 2 columns
                int[,] a = new int[5, 2]{
                    {0,0},
                    {1,2},
                    {2,4},
                    {3,6},
                    {4,8}
                };

                int i, j;

                //output each array element
                //Rows
                for (i = 0; i < 5; i++)
                {
                    //Columns
                    for (j = 0; j < 2; j++)
                    {
                        Console.WriteLine("a{0},{1}, = {2}", i, j, a[i, j]);
                    }
                    Console.ReadKey();
                }

            }


            /* 
             - When the above code is compiled and executed, it produces the following result

              a[0,0]: 0
              a[0,1]: 1
              a[1,0]: 2
              and so on....
             
            */


        }


        #endregion

        #region == Jagged Arrays == 

        /* A jagged array is an array of arrays. You can declare a jagged array named 
           'scores' of type 'int' as - 
            int[][] scores;

        - Declaring an array, does not create the array in memory. To create the above array..


            int[][] scores = new int[5][];
            for(int i = 0; i < scores.Length; i ++){
            scores[i] = new int [4];
            }

        - Initialize a jagged array as-
            int[][] scores = new int[2][]{new int[]{92,93,94},new int[]{85,66,87,88}};

          Where, scores is an array of two arrays of integers-scores[0] is an array of 3
          integers and scores[1] is an array of 4 integers.
          

        -Example below...
    
        }
        */

        class MyArray4
        {
            static void Main(string[] args)
            {
                // A jagged array of 5 array of integers
                int[][] a = new int[][]{new int[]{0,0},new int[]{1,2},new int[]{2,4},
                    new int[]{3,6},new int[]{4,8}};
                int i, j;

                //output each array element's value
                for (i = 0; i < 5; i++)
                {
                    for (j = 0; j < 2; j++) { }
                    Console.WriteLine("a[{0}][{1}]=2", i, j, a[i][j]);
                }
                Console.ReadKey();
            }
        }

        /*
            -  a[0][0]:0
            -  a[0][1]:0
            -  a[1][0]:1
            -  a[1][1]:2
            -  a[2][0]: 1
            and so on....
        */

        #endregion

        #region == Passing Arrays as Function Arguments  ==

        /*You can pass an array as a function argument in C#. Example Below.. */
        class MyArray5
        {
            double GetAverage(int[] array, int size)
            {
                int i;
                double avg;
                int sum = 0;

                for (i = 0; i < size; i++)
                {
                    sum += array[i];
                }
                avg = (double)sum / size;
                return avg;
            }

            static void Main(string[] args)
            {
                MyArray5 app = new MyArray5(); // Create object, (instantiate it)

                /*an int array with 5 elements*/
                int[] balance = new int[] { 1000, 2, 3, 17, 50 };
                double avg;

                /* pass pointer to the array as an argument */
                avg = app.GetAverage(balance, 5);

                /* output the returned value */
                Console.WriteLine("Average value is: {0} ", avg);
                Console.ReadKey();
            }
        }

        /* When the above code is compiled and executed,it produces the following result.. */

        /* Average value is : 214.4*/

        #endregion

        #region == Param Arrays ==

        /*
         -At times, while declaring a method, you are not sure of the number of arguments
         passed as a parameter. C# param arrays(Parameter arrays) come into help at such times.

         -Here is an example below...   
        */


        class ParamArray
        {
            public int AddElements(params int[] arr)
            {
                int sum = 0;

                foreach (int i in arr)
                {
                    sum += i;
                }
                return sum;
            }

            //Main Method
            static void Main(string[] args)
            {
                ParamArray app = new ParamArray();

                int sum = app.AddElements(512, 780, 799, 90, 5);
                Console.WriteLine("The sum is: {0}", sum);
                Console.ReadKey();
            }

        }


        #endregion

        #region == The Array Class ==

        /*
            The following table below describes most of the commonly used properties
            of the Array class

            - IsFixedSize
              This gets a value indicating whether the Array has a fixed size

            -IsReadOnly
              Gets a value indicating whether the Array is read-only

            -Length
              Gets a 32-bit integer that represents the total number of elements in all 
              the dimensions of the array

            -LongLegth
              gets a 64-bit that represents the total number of elements in all the dimensions
              of the array

            -Rank
             Gets the rank(number of dimensions) of the Array


             *** Methods of the Array Class ***

            -Clear
             Sets a range of elements in the array to zero,to false, or to null, depending
             on the element type

            -Copy(Array, Array,int32
             Copies a range of elements from an Array starting at the first element and 
             pastes them into another Array starting at the first element. The length specified
             as a 32-bit integer.

            -CopyTo(Array,int32)
             copies all the elements of the current-one dimensional Array to the specified
             one-dimiensional Array starting at the specified destination Array index. The 
             index is specified as a 32-bit integer.
             
            -GetLength
             Gets a 32-bit integer that represents the number of elements in the specified dimension
             of the Array.

            -GetLongLength
             Gets a 64-bit integer that represents the number of elements in the specified dimension
             of the Array.

            -Get LowerBound
             Gets the lower bound of the specified dimension in the Array.

            -Get UpperBound
             Gets the upper bound of the specified dimension in the Array.

            -GetValue(Int32)
             Gets the value at the specified position in the one-dimensional Array. The Index is
             specified as a 32-bit integer.

            -IndexOf(Array, Object)
             Searches for the specified object and returns the index of the first occurence within
             the entire one-dimensional Array.

            -Reverse(Array)
             Reverses the sequence of the elemetns in the entire one-dimensional Array.

            -SetValue(Object,Int32)
             Sets a value to the element at the specified position in the one-dimensional Array.
             The index is specified as a 32-bit integer.

            -Sort(Array)
            Sorts the elements in an entire one-dimensional Array using the IComparable implementation
            of each element of the Array.

            -ToStringK
             Returns a string that represents the current object.(Inherited from Object.)

        */
        #endregion

        #region == C# Strings ==
        /*
            In C#, you can use strings as array of characters, However, more common practice is to use
            the 'string' keyword to declare a string variable. The string keyword is an alias for the
            'System.String' class.


        ** Creating a String Object **
        You can create a string object using one of these following methods

        - Assigning a string literal to a string variable
        - Using a String class Constructor
        - Using the string concatenation operator (+)
        - By retrieving a property or calling a method that returns a string
        - By Calling a formatting method to convert a value or an object
          to its representation


            Here is an example below....
            
        */


        class Program
        {

            static void Main()
            {

                //from string literal and string concatenation
                string fname, lname;
                fname = "Randall";
                lname = "Joshua";

                string fullname = fname + lname;
                Console.WriteLine("Full Name:{0}", fullname);

                //by using the string constructor {'H','e','l', 'l', 'o'};
                //string greetings = new string(letters);
                //Console.WriteLine("Greetings:{0}",greetings);

                //Methods returning string {"Hello", "From", "Tutorials", "Point};
                //string message = String.Join(" ", Hi);
                //Console.WriteLine("Message: {0}",message);

                //formatting method to convert a value
                DateTime waiting = new DateTime(2018, 03, 05, 19, 49, 10);
                string chat = String.Format("Message sent at {0:t} on {0:D", waiting);
                Console.WriteLine("Message: {0}", chat);

            }

        }

        #endregion

        #region == Structures ==
        /*
         - A structure is a value type data type. It helps you to make a single variable hold
         related data of a various data types. The 'Struct' keyword is used for creating a structure.

         Structures are used to represent a record. Suppose you watn to keep track of your books in
         a library. You might want to track the following attributes about each book
         - Title
         - Author
         - Subject
         - Book ID

         How do you define a structure?
         To define one, you use the struct statement. The struct statement defines a new data type, with
         more than one memeber for your program.

        For example...
        */


        struct Books
        {
            public string title;
            public string author;
            public string subject;
            public int book_id;
        };

        public class testStructure
        {
            public static void Main(string[] args)
            {
                Books book1; // Declare Book1 of type Book
                Books book2; // Declare Book2 of type Book

                //Book 1 specification
                book1.title = "C# Programming";
                book1.author = "Josh randall";
                book1.subject = "Programming";
                book1.book_id = 6789;

                //Book 1 specification
                book2.title = "C++ Programming";
                book2.author = "Josh randall";
                book2.subject = "Programming";
                book2.book_id = 6790;

                //Print Book1 Information
                Console.WriteLine("Book 1 title: {0}", book1.title);
                Console.WriteLine("Book Author: {0}", book1.author);
                Console.WriteLine("Book Subject: {0}", book1.subject);
                Console.WriteLine("Book ID: {0}", book1.book_id);

                //Print Book2 Information
                Console.WriteLine("Book 2 title: {0}", book2.title);
                Console.WriteLine("Book Author: {0}", book2.author);
                Console.WriteLine("Book Subject: {0}", book2.subject);
                Console.WriteLine("Book ID: {0}", book2.book_id);

                Console.ReadKey(); ;
            }
        }


        /*
            *** Features of C# Structures ***
             Structures in C# are quite different from that in traditional C or C++
             The C# structures have the following features..

            - Structures can have methods, fields, indexers, properties, operator
             methods, and events.

            - Structures can have defined constructors, but not destructors. However,
              you cannot define a default constructor for a structure. The default constructor
              is automatically defined and cannot be changed.

            - Unlike Classes, structures cannot inherit other structures or classes.

            - Structures cannot be used as a base for other structures or classes.

            - A Structure can implement one or more interfaces.

            - Structure members cannot be specified as abstract, virtual, or protected.

            - When you create a struct object using the 'New' operator, it gets created
              and the appropriate constructor is called. Unlike classes, structs can be instantiated
              without using the New operator.

            - If the New operator is not used, the fields remain unassigned and the object cannot
              be used until all the fields are init


            *** Class versus Structures ***
            - classes are reference types and structs are value types
            - structures do not support inheritance
            - structures cannot have default constructor

            Here is an example below...

        */

        struct NewBooks
        {
            private string title;
            private string author;
            private string subject;
            private int book_id;


            //Getting Values
            public void getValues(string t, string a, string s, int id)
            {
                title = t;
                author = a;
                subject = s;
                book_id = id;
            }


            //Display Method
            public void Display()
            {
                Console.WriteLine("Title of book: {0}", title);
                Console.WriteLine("Author of book: {0}", author);
                Console.WriteLine("Subject of book: {0}", subject);
                Console.WriteLine("ID of book: {0}", book_id);

            }
        };
        //Test Book Structure
        public static void MainFunction(string[] argu)
        {
            NewBooks Book1 = new NewBooks(); // declare Book1 of type NewBooks
            NewBooks Book2 = new NewBooks(); // declare Book1 of type NewBooks

            //Book1 specs
            Book1.getValues("The Power of strength", "Josh", "Well Being", 25);

            //Book2 specs
            Book2.getValues("The Power of Motivation", "Josh", "Well Being", 27);

            //Print Book1 Info
            Book1.Display();

            //Print Book2 Info
            Book2.Display();

            Console.ReadKey();

        }
    }


    #endregion

    #region == Enums ==
    /*
      An enumeration is a set named of integer constancs. An enumerated type is
      decalred using the 'enum' keyword.

     C# enumerations are value data type. In other words, enumeration contains its own
     values and cannot inherit or cannot pass inheritance.

     *** Declaring enum variable *** 

      enum <enum_name> {
        enumeration list
     }

    - The 'enum_space' specifies the enumeration type name.
    - The enumeration list is a comma-sperated list of identifiers.


     Each of the symbols in the enumeration list stand for an integer value, one
     greather than the symbol that percedes it. By default, the value of the first
     enumeration symbol is 0.

    Here is an example below...

    */

    namespace EnumApllication
    {
        class enumProgram
        {
            enum Days { Sun, Mon, tue, Wed, thu, Fri, Sat };

            static void Main(string[] args)
            {
                int WeekdayStart = (int)Days.Mon;
                int WeekdayEnd = (int)Days.Fri;


                Console.WriteLine("Monday:{0}", WeekdayStart);
                Console.WriteLine("Friday: {0}", WeekdayEnd);
                Console.ReadKey();

            }
        }
    }


    #endregion

    #region == Classes == 

    #endregion


    #region == Attributes == 




    #endregion


}