using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_D
{
    internal class Program
    {
        public class DataItem
        {
            public int data;
            public int key;
        }

        public class HashTable
        {
            private const int SIZE = 10;
            private DataItem[] hashArray;

            public HashTable()
            {
                hashArray = new DataItem[SIZE];
            }

            public int HashCode(int key)
            {
                return key % SIZE;
            }

            public DataItem Search(int key)
            {
                // Get the hash
                int hashIndex = HashCode(key);

                while (hashArray[hashIndex] != null)
                {
                    if (hashArray[hashIndex].key == key)
                        return hashArray[hashIndex];

                    // Go to next cell
                    ++hashIndex;

                    hashIndex %= SIZE;
                }

                return null;
            }
            public void PrintAllValues()
            {
                for (int index = 0; index < SIZE; index++)
                {
                    if (hashArray[index] != null)
                    {
                        Console.WriteLine(index+"--------   "+hashArray[index].data);
                    }
                    else
                    {
                        Console.WriteLine("Empty");
                    }
                }
            }
            public void Insert(int data)
            {
                int key = data % SIZE; // Calculate the key using data mod 10
                DataItem item = new DataItem { data = data, key = key };

                // Move in array until empty or deleted cell
                while (hashArray[key] != null && hashArray[key].key != -1)
                {
                    // Go to next cell
                    ++key;

                    key %= SIZE;
                }

                hashArray[key] = item;
            }


            public DataItem Delete(DataItem item)
            {
                int key = item.key;

                // Get the hash
                int hashIndex = HashCode(key);

                // Move in array until empty
                while (hashArray[hashIndex] != null)
                {
                    if (hashArray[hashIndex].key == key)
                    {
                        DataItem temp = hashArray[hashIndex];

                        // Assign a dummy item at the deleted position
                        hashArray[hashIndex].data =-1 ;
                        hashArray[hashIndex].key = -1;
                        return temp;
                    }

                    // Go to next cell
                    ++hashIndex;

                    // Wrap around the table
                    hashIndex %= SIZE;
                }

                return null;
            }
        }
        private static void Main(string[] args)
        {
            HashTable hashObj= new HashTable();
            hashObj.Insert(20);
            hashObj.Insert(20);
            hashObj.Insert(30);
            hashObj.Insert(85);
            Console.WriteLine("Searched Index "+hashObj.Search(0).data);
            hashObj.Delete(new DataItem { data =20,key = 0 });
            hashObj.PrintAllValues();
            Console.ReadLine();
        }

    }

    
}
