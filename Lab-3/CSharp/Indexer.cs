using System;


namespace lab3
{
    class Indexer
    {
        private int n;
        private char[,] Matrix;
        private int intNumb;
        private string column;
        public Indexer()
        {
            n = 5;
            Matrix = new char[n, n];
        }


        public void FillMatrix()
        {
            Random random = new Random();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    int num = random.Next(30, 80);
                    Matrix[i, j] = (char)(num);
                    if (Matrix[i, j] >= 48 && Matrix[i, j] <= 57)
                    {
                        intNumb++;
                    }
                }
            }
        }

        public void PrintMatrix()
        {
            Console.WriteLine();

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(Matrix[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }



        public int IntNumb => intNumb;
        public string this[int index]
        {
            get
            {
                column = "";
                for (int i = 0; i < n; i++)
                {
                    column += Matrix[i, index];
                }
                return column;
            }
        }
    }
}

     