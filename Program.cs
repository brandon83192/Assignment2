using System;
using System.Linq;
using System.Collections.Generic;
// Group reflection: We believe this assignment taught us more on how to better problem solve as some of the problems
// were very tricky. We feel like we had to brush up on our data strructures such as lists, arrays, and dictionaries.
// This assignment explains the value of using a dictionary object. The group spent around 50 hours total on working the
// assignment. We feel like the majority of time was researching/learning how to do certain things and trying to 
// figure out how to solve the solutions. Very few hours were spent actually writing the code as some of the solutions
// only took 20-30 lines of code to solve. This assignment also helped us learn time complexities, as solutions
// required us to be O(n). We had to think outside the box in order to derive the answers. We agree that the time spent
// on the solutions could have decreased if we had more practice with arrays and dictionaries.
// #9 solution is assumming characters can have the same value as another character and characters can be zero

namespace Assignment2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Question 1");
            int[] l1 = new int[] { 5, 6, 6, 9, 9, 12 };
            int target = 9;
            int[] r = TargetRange(l1, target);
            DisplayArray(r);
            Console.WriteLine();

            Console.WriteLine("Question 2");
            string s = "University of South Florida";
            string rs = StringReverse(s);
            Console.WriteLine(rs);

            Console.WriteLine("Question 3");
            int[] l2 = new int[] { 4,5,6,9 };
            int sum = MinimumSum(l2);
            Console.WriteLine(sum);

            Console.WriteLine("Question 4");
            string s2 = "Dell";
            string sortedString = FreqSort(s2);
            Console.WriteLine(sortedString);

            Console.WriteLine("Question 5-Part 1");
            int[] nums1 = { 3, 6, 6, 6};
            int[] nums2 = { 6, 3, 6, 7, 3};
            int[] intersect1 = Intersect1(nums1, nums2);
            Console.WriteLine("Part 1- Intersection of two arrays is: ");
            DisplayArray(intersect1);
            Console.WriteLine("\n");

            Console.WriteLine("Question 5-Part 2");
            int[] intersect2 = Intersect2(nums1, nums2);
            Console.WriteLine("Part 2- Intersection of two arrays is: ");
            DisplayArray(intersect2);
            Console.WriteLine("\n");

            Console.WriteLine("Question 6");
            char[] arr = new char[] { 'a', 'g', 'h', 'a' };
            int k = 3;
            Console.WriteLine(ContainsDuplicate(arr, k));

            Console.WriteLine("Question 7");
            int rodLength = 15;
            int priceProduct = GoldRod(rodLength);
            Console.WriteLine("Max gold profit:" + priceProduct);

            Console.WriteLine("Question 8");
            string[] userDict = new string[] { "rocky", "usf", "hello", "apple" };
            string keyword = "hllll";
            Console.WriteLine(DictSearch(userDict, keyword));

            Console.WriteLine("Question 9");
            SolvePuzzle();

        }
        public static void DisplayArray(int[] a)
        {
            foreach (int n in a)
            {
                Console.Write(n + " ");
            }
        }
        public static int[] TargetRange(int[] l1, int t)
        {
            try
            {
                int[] begin = new int[] { -1, -1 }; //Initilize int array
                for (int i = 0; i < l1.Length; i++)
                {
                    if (l1[i] != t) //if number is not equal to target value, continue through loop
                    {
                        continue;
                    }
                    if (begin[0] == -1) //if number is equal for first time, set the first variable to i
                    {
                        begin[0] = i;
                    }
                    begin[1] = i; //if number is equal for 2nd time and on, set the 2nd variable to it
                }
                return begin;

            }
            catch (Exception)
            {
                throw;
            }
        }
        public static string StringReverse(string s)
        {
            try
            {
                //Initialize variables
                string rk = "";
                string reverse_word = "";
                //Start looping through the text
                for (int ctr = s.Length - 1; ctr >= 0; ctr--) //reverse positions of the word
                {
                    if (s[ctr] == ' ')
                    {
                        reverse_word = rk + " " + reverse_word; 
                        rk = "";
                    }
                    else
                    {

                        rk += s[ctr];

                    }
                }
                reverse_word = rk + " " + reverse_word;
                Console.WriteLine(reverse_word); //return the reverse word
            }

            catch (Exception)
            {
                throw;
            }
            return null;
        }
        public static int MinimumSum(int[] l2)
        {
            try
            {
                if (l2.Length == 0) //check if there is no element present in the array and return 0
                {
                    return 0;
                }
                int sum = 0;
                for (int i = 0; i < l2.Length; i++) 
                {
                    if (i != 0 && l2[i] == l2[i - 1]) //dont run the below code the first time and compare the integer with the previous
                    {
                        l2[i] = l2[i] + 1; //increase the value of an element by 1
                    }
                    sum = sum + l2[i]; //Calculate the sum
                }
                return sum;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static string FreqSort(string s2)
        {
            try
            {
                Dictionary<char, int> charWithFrequency = new Dictionary<char, int> { };
                int count = 1;
                for (int i = 0; i < s2.Length; i++)
                {
                    if (charWithFrequency.ContainsKey(s2[i]))
                    {
                        charWithFrequency[s2[i]]++; //if dictionary already contains the char, increase its frequency by 1
                    }
                    else
                    {
                        charWithFrequency.Add(s2[i], count); //if new char, add char to dictionary and frequency as 1
                    }
                }
                //iterate through each item in dictionary by sorting it in descending order of the char frequency
                foreach (KeyValuePair<char, int> item in charWithFrequency.OrderByDescending(key => key.Value))
                {
                    //if frequency more than 1 then print the char for the number of its occurance
                    if (item.Value > 1)
                    {
                        for (int k = 0; k < item.Value; k++)
                        {
                            Console.Write(item.Key);
                        }
                    }
                    else
                    {
                        Console.Write(item.Key);
                    }
                }
            }
         catch (Exception)
            {
            throw;
            }
            return null;
        }
        public static int[] Intersect1(int[] nums1, int[] nums2)
        {
            try
            {
                //Initialize new arrays that are going to be used in this program
                int[] m = nums1;
                int[] n = nums2;
                List<int> intList = new List<int>();
                if (nums1.Length > nums2.Length) // switch arrays if array 1 is larger
                {
                    m = nums2;
                    n = nums1;
                }
                //Arrays must be sorted
                Array.Sort(m);
                Array.Sort(n);

                int j = 0;
                int x = 0;

                //loop through each word
                for (int i = 0; i<m.Length; i++) //use smaller array (m) to search bigger array (n)
                {
                    for(j=x; j<n.Length;j++) //track where j is and never go back to 0 because arrays are sorted
                    {
                        if (m[i]==n[j])
                        {
                            intList.Add(m[i]); //add to list if integers are equal
                            x = j + 1; //create new starting point got j loop for next i
                            break; //break the loop since we found matching integers
                        }

                    }
                }
                return intList.ToArray();//return the list as an array
            }
            catch
            {
                throw;
            }
        }
        public static int[] Intersect2(int[] nums1, int[] nums2)
        {
            try
            {
                //Initialize variables for this program
                int[] intArray = new int[] { };
                var intersectDict = new Dictionary<int, int>();
                var nDict = new Dictionary<int, int>();
                var mDict = new Dictionary<int, int>();
                int[] m = nums1;
                int[] n = nums2;
                List<int> intList = new List<int>();

                if (nums1.Length > nums2.Length) // switch arrays if array 1 is larger
                {
                    m = nums2;
                    n = nums1;
                }
                for (int i = 0; i < n.Length; i++) // adding the largest array to a dictionary
                {
                    if (nDict.ContainsKey(n[i]))
                    {
                        nDict[n[i]] = nDict[n[i]] + 1; //increase the value if the integer is in the dictionary
                    }
                    else
                    {
                        nDict.Add(n[i], 1); //else add the new integer to the dictionary
                    }
                }
                for (int i = 0; i < m.Length; i++) // if smaller array is in the dictionary, then return that value
                {
                    if (nDict.TryGetValue(m[i],out int value)) //if the value is in the dictionary, output new variable value
                    {
                        if (value > 0) //if value from the dictionary is greater than zero
                        {
                            intList.Add(m[i]); //add integer to the list
                            nDict[m[i]] = value - 1; //subtract the value to keep track of how many there is left
                        }
                    }
                    else
                    {
                        
                    }
                }
                return intList.ToArray(); //return the list as an array
            }
            catch
            {
                throw;
            }
        }
        public static bool ContainsDuplicate(char[] arr, int k)
        {
            try
            {
                //Initialize teh variables
                Dictionary<char, int> chardict = new Dictionary<char, int> { };
                int difference = 0;
                int newIndex = 0;

                //Loop through the character array
                for (int i = 0; i < arr.Length; i++)
                {
                    if (chardict.ContainsKey(arr[i])) //if the character is in the dictionary....
                    {

                        newIndex = chardict[arr[i]];
                        difference = Math.Abs(i - newIndex); //calculate the difference bewtween the current and new index
                        chardict[arr[i]] = i; //update dictionary value to current index
                    }
                    else
                    {
                        chardict.Add(arr[i], i); //add the character if not in the dictionary and set the value to current index
                    }
                }
                if (difference <= k) //if the absolute difference is less than k, return true
                {
                    return true;
                }
                else
                {
                    return false; // otherwise return false
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static int GoldRod(int rodLength)
        {
            try
            {
                
                int[] profit = new int[rodLength]; // declare the array to keep track of profits for each interation
                for (int i = 1; i<rodLength; i++) //Loop through combinations example 1 and 3, 2 and 2, 3 and 1
                {
                    profit[i-1] = i * GoldRod(rodLength - i); //calcutation of profit and recursion starts to calculate remainders
                }
                if (profit.Max() < rodLength)
                {
                    return rodLength; //since recursion keeps interating, the number shouldnt be lower than starting gold
                }
                else
                {
                    return (profit.Max()); // return max of the array
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static bool DictSearch(string[] userDict, string keyword)
        {
            try
            {

                foreach (var word in userDict)
                {
                    if (keyword.Length != word.Length) //if length of the keyword is not same the word in the dictionary,continue
                    {
                        continue;
                    }
                    if (keyword.Length == word.Length) //check if length of keyword is same the word in the dictionary
                    {
                        int count = 0;
                        for (int i = 0; i < word.Length; i++)
                        {
                            if (keyword[i] != word[i]) //calculate the count of characters in word that doesn't match with the letters in keyword
                            {
                                count++;
                            }
                            if (count > 1) //if there is mismatch of more than one character in word and keyword, break
                            {
                                break;
                            }
                        }
                        if (count == 1) //if there is just one character in word that doesn't match with the character in keyword, return true
                            return true;
                    }
                }
                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static void SolvePuzzle()
        {
            try
            {
                //collect all string inputs and convert them to char arrays
                Console.WriteLine("Enter first string");
                char[] firstword = Console.ReadLine().ToCharArray();
                Console.WriteLine("Enter second string");
                char[] secondword = Console.ReadLine().ToCharArray();
                Console.WriteLine("Enter output string");
                char[] outputword = Console.ReadLine().ToCharArray();

                // Combine all words
                char[] allwords = firstword.Concat(secondword).ToArray();
                allwords = allwords.Concat(outputword).ToArray();

                //identify unique characters in all strings
                char[] distinctchar = allwords.Distinct().ToArray();
                int solution = 0;

                //Loop through using brute force method depending on how many unique characters
                for (int i = Convert.ToInt32(Math.Pow(10,distinctchar.Length - 1)); i < Math.Pow(10,distinctchar.Length);i++)
                {
                    //assign values to the unique characters
                    string combo = String.Format("{0:D" + distinctchar.Length + "}", i);
                    char[] combochar = combo.ToCharArray();

                    //using the combochar to assign values to the first word
                    string firstwordvalue = "";
                    for (int j = 0;j < firstword.Length;j++)
                    {
                        string add = combochar[Array.IndexOf(distinctchar, firstword[j])].ToString();
                        firstwordvalue = firstwordvalue + add;
                    }

                    //using the combochar to assign values to the second word
                    string secondwordvalue = "";
                    for (int j = 0; j < secondword.Length; j++)
                    {
                        string add = combochar[Array.IndexOf(distinctchar, secondword[j])].ToString();
                        secondwordvalue = secondwordvalue + add;
                    }

                    //using the combochar to assign values to the output word
                    string outputwordvalue = "";
                    for (int j = 0; j < outputword.Length; j++)
                    {
                        string add = combochar[Array.IndexOf(distinctchar, outputword[j])].ToString();
                        outputwordvalue = outputwordvalue + add;
                    }
                    //Parse texts to numbers
                    int firstwordnum = int.Parse(firstwordvalue);
                    int secondwordnum = int.Parse(secondwordvalue);
                    int outputwordnum = int.Parse(outputwordvalue);

                    //Add first word to second word
                    int addednum = firstwordnum + secondwordnum;

                    //Test the assignments. if passes print the code values and the letters associated. 
                    if (addednum == outputwordnum)
                    {
                        solution++;
                        Console.WriteLine("Solution: " + solution);
                        Console.WriteLine(combochar);
                        Console.WriteLine(distinctchar);
                        Console.WriteLine("Added sum:" + addednum + " Output sum:" + outputwordnum);
                    }

                }
                
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
