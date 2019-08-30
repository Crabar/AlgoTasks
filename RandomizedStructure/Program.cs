using System;
using System.Collections.Generic;
using System.Linq;

namespace RandomizedStructure
{
    class Program
    {
        static void Main(string[] args)
        {
            // Init an empty collection.
            RandomizedCollection collection = new RandomizedCollection();

// Inserts 1 to the collection. Returns true as the collection did not contain 1.
            var val = collection.Insert(1);

// Inserts another 1 to the collection. Returns false as the collection contained 1. Collection now contains [1,1].
            var val2 = collection.Insert(1);

// Inserts 2 to the collection, returns true. Collection now contains [1,1,2].
            var val3 = collection.Insert(2);

// getRandom should return 1 with the probability 2/3, and returns 2 with the probability 1/3.
            var val4 = collection.GetRandom();

// Removes 1 from the collection, returns true. Collection now contains [1,2].
            var val5 = collection.Remove(1);

// getRandom should return 1 and 2 both equally likely.
            var val6 = collection.GetRandom();
        }
    }

    public class RandomizedCollection
    {
        private readonly Dictionary<int, HashSet<int>> _innerDict;
        private readonly List<int> _innerList;

        private readonly Random _random;
        /** Initialize your data structure here. */

        public RandomizedCollection()
        {
            _innerDict = new Dictionary<int, HashSet<int>>();
            _innerList = new List<int>();
            _random = new Random();
        }

        /** Inserts a value to the collection. Returns true if the collection did not already contain the specified element. */
        public bool Insert(int val)
        {
            var isValExist = _innerDict.ContainsKey(val);

            if (!isValExist)
            {
                _innerDict.Add(val, new HashSet<int>());
            }

            _innerDict[val].Add(_innerList.Count);
            _innerList.Add(val);
            return !isValExist;
        }

        /** Removes a value from the collection. Returns true if the collection contained the specified element. */
        public bool Remove(int val)
        {
            if (!_innerDict.ContainsKey(val))
            {
                return false;
            }

            var value = _innerDict[val];
            var index = value.First();
            value.Remove(index);

            if (_innerList.Count == 1)
            {
                _innerList.RemoveAt(0);
            }
            else
            {
                var last = _innerList[_innerList.Count - 1];
                _innerDict[last].Add(index);
                _innerDict[last].Remove(_innerList.Count - 1);
                _innerList[index] = last;
                _innerList.RemoveAt(_innerList.Count - 1);
            }
            
            if (value.Count == 0)
            {
                _innerDict.Remove(val);
            }

            return true;
        }

        /** Get a random element from the collection. */
        public int GetRandom()
        {
            var randomIndex = _random.Next(_innerList.Count);
            return _innerList[randomIndex];
        }
    }
}