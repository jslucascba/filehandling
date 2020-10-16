using System;
using System.IO;

namespace files
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = new string[50];
            string[] breed = new string[50];
            int [] weight = new int[50];

            int count = GetAllDogs(names, breed, weight);

            PrintAllDogs(names, breed, weight, count);

            //weight[2] = 65;

            SortDogs(names, breed, weight, count);

            Console.WriteLine("\n\nAfter the sort");

            PrintAllDogs(names, breed, weight, count);

            Console.WriteLine("\n\nControl Break Report");

            TotalWeightByBreed(breed, weight, count);

            //SaveAllDogs(names, breed, weight, count);

        }


        public static int GetAllDogs(string[] names, string[] breed, int[] weight)
        {
            //open
            StreamReader inFile = new StreamReader("input.txt");

            //process
            int count = 0;
            string dataRow = inFile.ReadLine();   //priming read

            while(dataRow != null)
            {
                string[] temp = dataRow.Split('#');
                names[count] = temp[0];
                breed[count] = temp[1];
                weight[count] = int.Parse(temp[2]);
                count++;

                //update read
                dataRow = inFile.ReadLine();
            }
            //close
            inFile.Close();

            return count;
        }

        public static void PrintAllDogs(string[] names, string[] breed, int[] weight, int count)
        {

            for(int i = 0; i<count; i++)
            {
                Console.WriteLine($"{names[i]} is a {breed[i]} and weighs {weight[i]}");
            }
        }

        public static void SaveAllDogs(string[] names, string[] breed, int[] weight, int count)
        {
            //open
            StreamWriter outFile = new StreamWriter("input.txt");

            //process
            for(int i = 0; i<count; i++)
            {
                outFile.WriteLine($"{names[i]}#{breed[i]}#{weight[i]}");
            }
            //close
            outFile.Close();
        }

        public static void SortDogs(string[] names, string[] breed, int[] weight, int count){
            for(int i=0; i< count-1; i++){
                int minIndex = i;
                for(int j=i+1; j< count; j++){
                    if (breed[j].CompareTo(breed[minIndex]) < 0){
                        minIndex = j;
                    }
                }
                if(minIndex != i){
                    Swap(names, minIndex, i);
                    Swap(breed, minIndex, i);
                    Swap(weight, minIndex, i);
                }
            }
        }

        public static void Swap(string[] myArray, int x, int y){
            string temp = myArray[x];
            myArray[x] = myArray[y];
            myArray[y] = temp;
        }

        public static void Swap(int[] myArray, int x, int y){
            int temp = myArray[x];
            myArray[x] = myArray[y];
            myArray[y] = temp;
        }

        public static void TotalWeightByBreed(string[] breed, int[] weight, int count){
            int total = weight[0];
            string currBreed = breed[0];

            for(int i = 1; i<count; i++){
                if(breed[i]==currBreed){
                    total+= weight[i];
                } else {
                    ProcessBreak(breed[i], weight[i], ref currBreed, ref total);
                }
            }
            ProcessBreak("na", 0, ref currBreed, ref total);
        }

        public static void ProcessBreak(string newBreed, int newWeight, ref string currBreed, ref int total){
            Console.WriteLine($"Total weight for {currBreed} is {total}");
            currBreed = newBreed;
            total = newWeight;
        }
    }
}
