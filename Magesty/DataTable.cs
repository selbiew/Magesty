using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magesty
{
    public class DataTable
    {
        int rows = 0, cols = 0;
        public string[] indexList { get; set; }
        public int[,] valueTable { get; set; }
        public int valueRows;
        public int[,] returnTable { get; set; }

       public DataTable(string pathOne, string pathTwo, int valueRows)
        {
            String input = System.IO.File.ReadAllText(pathOne);
            this.valueRows = valueRows;
            int i = 0, j = 0;
            string firstLine;

            foreach (var row in input.Split('\n'))
            {
                if (rows == 0) { firstLine = row; }
                rows++;
            }
            cols = rows-1;

            indexList = new string[cols];
            returnTable = new int[rows-1, cols];

            foreach (var row in input.Split('\n'))
            {
                j = 0;
                if (i == 0)
                {
                    foreach (var name in row.Split('|'))
                    {
                        indexList[j] = name;
                        j++;
                    }
                }

                else
                {
                    foreach (var col in row.Split(null))
                    {
                        if(col != "")
                        {
                            if (col == "-") { returnTable[i - 1, j] = -1; }
                            else { returnTable[i - 1, j] = int.Parse(col); }
                            j++;
                        }
                    }
                }
                i++;
            }

            if(pathTwo != null)
            {
                i = 0;
                valueTable = new int[valueRows, cols];
                input = System.IO.File.ReadAllText(pathTwo);
                foreach(var line in input.Split('\n'))
                {
                    j = 0;
                    foreach(var value in line.Split('|'))
                    {
                        valueTable[i, j] = int.Parse(value);
                        j++;
                    }
                    i++;
                }

            }
        }

        public void printValues()
        {
            for(int i = 0; i < cols; i++)
            {
                Console.WriteLine("Index {0}: {1}", i, indexList[i]);
            }
            for(int i = 0; i < rows-1; i++)
            {
                for(int j = 0; j < cols; j++)
                {
                    Console.Write("{0} ", returnTable[i, j]);
                }
                Console.WriteLine("");
            }
            if(valueTable != null)
            {
                for(int i = 0; i < valueRows; i++)
                {
                    for(int j = 0; j < cols; j++)
                    {
                        Console.Write("Power: {0}", valueTable[i, j]);
                    }
                    Console.WriteLine("");
                }
            }
        }
      }
   }

