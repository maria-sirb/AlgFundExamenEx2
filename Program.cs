using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgFundExamenEx2
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] v = new int[n];
            string[] data1 = Console.ReadLine().Split(' ');
            for(int i = 0; i < n; i++)
            {
                v[i] = int.Parse(data1[i]);
            }
            int m = int.Parse(Console.ReadLine());
            int[] u = new int[m];
            string[] data2 = Console.ReadLine().Split(' ');
            for (int i = 0; i < m; i++)
            {
                u[i] = int.Parse(data2[i]);
            }
            int[]  powV = Pow(v);
            int[] powU = Pow(u);
            Console.WriteLine(ComparePow(powV, powU));
            Console.ReadKey();

        }
        private static int ComparePow(int[] v, int[] u)
        {
            int minLength = Math.Min(v.Length, u.Length);
            for(int i = 0; i < minLength; i++)
            {
                if (v[i] > u[i])
                    return -1;
                if (v[i] < u[i])
                    return 1;
            }
            if (v.Length > u.Length)
                return -1;
            if (v.Length < u.Length)
                return 1;
  
            return 0;
        }
        private static int[] Pow(int[] v)
        {
            int[] freq = new int[201]; //monitorizeaza aparitiile pentru ficere nr din v
                                       //(nr din v sunt intre -100 si 100 => 201 valori)

            int notZeroCount = 0;    //numara cate valori apar cel putin o data    
            for(int i = 0; i < v.Length; i++)
            {
                if (freq[v[i] + 100] == 0) //daca este prima data cand gasim numarul crestem contorul        
                    notZeroCount++;        
                freq[v[i] + 100]++; // ex: freq[0] monitorizeaza aparitiile lui -100
                                    // freq[1] -> -99
                                    //freq[2] -> -98
                                    //...
                                    //freq[199] -> 99
                                    //freq[200] -> 100
                
               
            }
            int[] pow = new int[notZeroCount];
            int pos = 0;
            //adaug in vectorul putere frecventele mai mari decat 0
            for (int i = 0; i < freq.Length; i++)
            {
                if (freq[i] > 0)
                {
                    pow[pos] = freq[i];
                    pos++;
                }

            }
            BubbleSort(pow);
            for(int i = 0; i < pow.Length; i++)
            {
                Console.Write(pow[i] + " ");
            }
            Console.WriteLine();
            return pow;


        }
        private static void BubbleSort(int[] v)
        {
            bool sorted;
            do
            {
                sorted = true;
                for(int i = 0; i < v.Length - 1; i++)
                {
                    if(v[i] < v[i + 1])
                    {
                        int aux = v[i];
                        v[i] = v[i + 1];
                        v[i + 1] = aux;
                        sorted = false;
                    }
                }


            } while (!sorted);
        }
    }
}
