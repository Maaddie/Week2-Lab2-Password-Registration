using System;
using System.Collections.Generic;

namespace Week2_Lab2_Password_Registration
{
    class Program
    {
        static void Main(string[] args)
        {
            //1. Create Lists:
            // - One List for username
            // - One list for password

            List<string> username = new List<string>();
            List<string> password = new List<string>();

            //3. Via the console, ask the user to create a username that follows the below criteria:
            // - Must have letters and numbers
            // - Must have at least 5 letters
            // - Must be a length of 7 character minimum
            // - Must be no longer then 12 characters 
            // - Extended: Have a list of forbidden words that are not allowed in the username

            bool keepGoing = true;
             
            while (keepGoing) 
            {
                Console.WriteLine("Please create a username that meets the following criteria: ");
                Console.WriteLine(" - Must have letters and numbers");
                Console.WriteLine(" - Must have at least 5 letters");
                Console.WriteLine(" - Must have min of 7 characters");
                Console.WriteLine(" - Must have a max of 12 characters");

                string usernameInput = Console.ReadLine();
                if(!(UsernameCriteria(usernameInput,username)))
                {
                    continue;
                }

                //5. Ask the user to create a password that must meet the following criteria:
                // - Must have at least one lowercase letter
                // - Must have at least one uppcase letter
                // - Must have at least one number
                // - Must be min 7 characters (inclusive)
                // - Must be max 12 characters (inclusive)
                // - Must have any of the following special characters: ! @ # $ % ^ & *

                Console.WriteLine("Now, please create a password that meets the following criteria: ");
                Console.WriteLine(" - Must have at least one lowercase letter");
                Console.WriteLine(" - Must have at least one uppercase letter");
                Console.WriteLine(" - Must have at least one number");
                Console.WriteLine(" - Must be min 7 characters");
                Console.WriteLine(" - Must be a max of 12 characters");
                Console.WriteLine(" - Must have any of the following symbols: ! @ # $ % ^ & * ");

                string passwordInput = Console.ReadLine();

                //2. When a username and password combo is valid, add them to the list
                //4. If the username doesn't already exist in the user  list, Add them into the list and add their password collection at the same index
                //6. If any of the rules are violated, print an error message that shows the first rule does not get met

                //this also checks the password criteria that calls all the written methods 
                if (PasswordCriteria(passwordInput))
                {
                    username.Add(usernameInput);
                    password.Add(passwordInput);
                }
                else
                {
                    //What the continue does, it basically tells the program to start the loop again. continue is a build in feature. (method)

                    continue;
                }

                
                keepGoing = Continue();
            }
            for(int i = 0; i < username.Count; i++)
            {
                Console.WriteLine("Username: " + username[i]);
                Console.WriteLine("Password: " + password[i]);
            }
        }

        //THIS method calls all of the username Criteria. Test methods.
        public static bool UsernameCriteria(string username, List <string> usernameList) //only passwing the usernameList to check for uniqness
        {
            //Calling all methods and testing all of the criteria
            // inside username uniqueness passing 2 args
            if(LettersAndNumbers(username) && MinLetters(username) && TestLength(username) && OffensiveWords(username) && UsernameUniqueness(username, usernameList))
            {
                return true;
            }
            return false;
        }

        //THIS method calls for all of the password Criteria.
        public static bool PasswordCriteria(string password)
        {
            if(LowerCase(password) && UpperCase(password) && NumberTest(password) && TestLength(password) && Symbols(password))
            {
                return true;
            }
            return false;
        }
        
        //THIS method checks for username uniqueness but does NOT ADD IT to the LIST.
        //THIS returns TRUE if the username IS unique
        public static bool UsernameUniqueness(string username, List<string> usernameList) //this method passes the username that was inputted by the user and compares the username to the username List
                                                                                          //returns true or false
        {
            foreach(string user in usernameList) //for each user that exists in the username list
            {
                if(username == user) 
                {
                    //7. When a username or password does not meet the validation rules, print ALL rules that they fail to meet.
                    Console.WriteLine("Username is not unique. Try again.");
                    return false; //if the username that was inputted by the user exists on the list, then it will return a false boolean
                }
            }
            return true; //if the username inputted by the user does not exist on the list, it has to be true so it will return a true boolean.
        }

        //THIS method checks if there are offensive words in the username inputted by the user
        public static bool OffensiveWords(string username)
        { 
            List<string> forbiddenWords = new List<string>() { "hell", "devil", "hate", "shit" };

            foreach (string forbiddenWord in forbiddenWords)
            {
                if (username == forbiddenWord)
                {
                    Console.WriteLine("The chosen username includes offensive language. Please use a different username.");
                    return false;
                }
            }
            return true; //if inputted username does not include any offensive words, return true.
        }

        //THIS method checks if the username has letters and numbers
        public static bool LettersAndNumbers(string username)
        {
            bool hasNumbers = false; //declaring boolean datatype that have false values because we have to prove they are true
            bool hasLetters = false; //declaring boolean datatype that have false values because we have to prove they are true

            foreach (char character in username) // Going through each character inputted by the user in username and checking if it is a letter or a number.
            {
                //conditional checking if the username has letters and numbers
                if (Char.IsLetter(character) == true) //using chat.isletter is a built in method which checks character inputted by the user and if it is a letter it equals true.
                {
                    hasLetters = true; //if boolean value is met, return true
                }
                else if (Char.IsDigit(character) == true) //char.isdigit is also a built in method which checks character inputted by the user and if it is a digit it equals true.
                {
                    hasNumbers = true; //if boolean value is met, return true
                }
            }
            if (hasNumbers == true && hasLetters == true) //here checking if username characters have letters and numbers
            {
                return true; //if the username has numbers & letters
            }
            else
            {
                Console.WriteLine("Username does not contain letters and numbers. Please try again.");
                return false; // if the username does not have letters and numbers.
            }
        }

        //THIS method checks for the length of the username
        public static bool TestLength(string username)
        {
            //condition for the username length
            if (username.Length >= 7 && username.Length <= 12)
            {
                return true;
            }
            Console.WriteLine("Username or password does not meet the length criteria. Please try again.");
            Console.WriteLine("The Username and Password must contain a minimum of 7 characters and a maximum of 12 characters.");
            return false;
        }

        //THIS method checks for the minimum amount of letters ( Username must have at least 5 letters)
        public static bool MinLetters(string username)
        {
            int letterCount = 0; //this is a placeholder to hold our count
            foreach(char letter in username) //loop checking each letter inside of username
            {
                if (char.IsLetter(letter)) // char.isletter is a built in method that passes the letters in username

                {
                    letterCount++; //incrementing our counter by 1 for each letter it finds
                }
            }

            if(letterCount >= 5) //checking how much the count is. if it is greater than or equal to 5, then it will return a true value, if not, then it will return false.
            {
                return true;
            }
            else
            {
                Console.WriteLine("The username does not contain the required number of letters. Please try again.");
                return false;
            }
        }
        //THIS method checks for at least 1 lower case letter in the password
        public static bool LowerCase(string password)
        {
            foreach(char letter in password) //for each letter in password 
            {
                if (char.IsLower(letter)) 
                {
                    return true; //if character in password is lowercase return true
                }
            }
            Console.WriteLine("Password must contain at least 1 lower case letter. Please try again.");
            return false; // if not, return false
        }

        //THIS method checks for at least 1 uppser case letter inside the password
        public static bool UpperCase(string password)
        {
            foreach (char letter in password) //for each letter in password 
            {
                if (char.IsUpper(letter))
                {
                    return true; //if character in password is lowercase return true
                }
            }
            Console.WriteLine("Password must contain at least one uppercase letter. Please try again.");
            return false; // if not, return false
        }

        //THIS method checks for at least one number in the pasword 
        public static bool NumberTest(string password)
        {
            foreach (char number in password) //for each character number in password 
            {
                if (char.IsDigit(number)) //as soon as this is true, that is at least 1 number
                {
                    return true; //if character if number, return true
                }
            }
            Console.WriteLine("Password must contain at least one number. Please try again.");
            return false; // if not, return false
        }

        //THIS method checks for the special characters ! @ # $ % ^ & * 
        public static bool Symbols(string password)
        {
            string specialCharacters = "!@#$%^&*";
            foreach(char symbol in password)
            {
                if (password.Contains(symbol))
                {
                    return true;
                }
            }
            Console.WriteLine("Password must have at least one of the following symbols  ! @ # $ % ^ & * . Please try again.");
            return false;
        }

        public static string GetInput(string prompt)
        {
            Console.WriteLine(prompt);
            string output = Console.ReadLine().ToLower();

            return output;
        }


        public static bool Continue()
        {
            string answer = GetInput("Would you like to create another username and password? y/n ");

            if (answer == "y")
            {
                return true;
            }
            else if (answer == "n")
            {
                Console.WriteLine("Goodbye");
                return false;
                //This code is unreachable since the return statements kicks us out of the method
                //Console.WriteLine("Goodbye");
            }
            else
            {
                Console.WriteLine("I am sorry, I didn't understand");
                Console.WriteLine("Let's try again.");

                //This is recursion, calling a method inside itself
                return Continue();
            }
        }

    }
}
