using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;

namespace CyclePictures
{
    public class ImageLocationList
    {
        private int size;
        private int length;
        private string[] list;
		
        public int Length { get { return length; } }
        public const int START_SIZE = 10;
        /// <summary>
        /// Default Constructor: creates empty array and sets default size to 10
        /// </summary>
		public ImageLocationList()
        {
            size = START_SIZE;
            length = 0;
            list = new string[size];
        }
        /// <summary>
        /// Constructor: creates new string array that using the non null elements of the <paramref name="inputs"/>
        /// length = size of inputs - # of null elements
        /// </summary>
        /// <param name="inputs"></param>
        public ImageLocationList(string[] inputs)
        {
            length = 0;
            size = inputs.Length + 10;
            list = new string[size];
            for (int i = 0; i < inputs.Length; i++)
            {
                if (inputs[i] == null)
                { continue; }
                list[i] = inputs[i];
                length++;
            }
            
        }
        /// <summary>
        /// Retrieve and set instances in the array
        /// </summary>
        /// <param name="index"></param>
        /// <returns>Element in the array at <paramref name="index"/></returns>
		public string this[int index]
		{
            get 
            { 
                if (index >= length) 
                { throw new IndexOutOfRangeException("The index you entered is not within the valid range of numbers.  The array currently has " + this.Length + " elements in it."); }
                return list[index]; 
            }
            //set { list[index] = value; }
		}
        /// <summary>
        /// Add an additional element to the array
        /// Increment length by 1
        /// If length greater than size, then resize the array
        /// </summary>
        /// <param name="str"></param>
        public void add(string str)
        {
            length++;
            if (length > size)
            {
                size = (int)(size * 1.75);
                string[] tempArr = new string[size];
                for (int i = 0; i < list.Length; i++)
                { 
                    tempArr[i] = list[i];
                    list = null;
                    list = tempArr;
                }
            }
            list[length] = str;
        }
        public void delete(string str)
        {

        }
    }
}
