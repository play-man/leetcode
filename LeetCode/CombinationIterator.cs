using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    internal class CombinationIterator
    {
        /*Design the CombinationIterator class:

        CombinationIterator(string characters, int combinationLength) Initializes the object with a string characters of sorted distinct lowercase English letters and a number combinationLength as arguments.
        next() Returns the next combination of length combinationLength in lexicographical order.
        hasNext() Returns true if and only if there exists a next combination.
        
        Constraints:

        1 <= combinationLength <= characters.length <= 15
        All the characters of characters are unique.
        At most 10^4 calls will be made to next and hasNext.
        It's guaranteed that all calls of the function next are valid. 
         */
        private readonly string characters;
        private readonly int combinationLength;
        private int lastReturnedStart = -1;
        // Stores indexes of next string
        Stack<int> combinationStack = new Stack<int>();
        public CombinationIterator(string characters, int combinationLength)
        {
            this.characters = characters;
            this.combinationLength = combinationLength;
        }

        public string Next()
        {
            int countRemoved = 0;
            if (combinationStack.Count >= 1)
            {
                while (combinationStack.Peek() == characters.Length - 1 - countRemoved)
                {
                    combinationStack.Pop();
                    countRemoved++;
                }
                if (combinationStack.Count == 1)
                {
                    lastReturnedStart++;
                }
                combinationStack.Push(combinationStack.Pop() + 1);

                for (int i = 0; i < countRemoved; i++)
                {
                    combinationStack.Push(combinationStack.Peek() + 1);
                }
            }
            // At the first execution of Next
            else if (combinationStack.Count == 0)
            {
                lastReturnedStart = 0;
                for (int i = 0; i < combinationLength; i++)
                    combinationStack.Push(i);
                //Enumerable.Range(0, combinationLength).ToList().ForEach(i => combinationStack.Push(characters[i]));
            }
            return new string(combinationStack.Select(i => characters[i]).ToArray().Reverse().ToArray());
        }

        public bool HasNext()
        {
            //Console.WriteLine();
            return (lastReturnedStart != characters.Length - combinationLength);
        }
    }
}
