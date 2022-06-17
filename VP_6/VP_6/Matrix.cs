using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VP_6
{
    public class Matrix
    {
        private List<List<float>> _matrix = new List<List<float>>();

        public List<List<float>> ElementsLists {
            get 
            {
                return _matrix;
            }
            set 
            {
                _matrix = value;
            }
        }

        public float this[int row, int column]
        {

            get{
                try
                {
                    return _matrix[row][column];
                }
                catch (ArgumentOutOfRangeException) 
                {
                    throw new IndexOutOfRangeException("You can only access element inside matrix");
                }
            }

            set{
                try
                {
                    _matrix[row][column] = value;
                }
                catch (ArgumentOutOfRangeException)
                {
                    throw new IndexOutOfRangeException("You can only access element inside matrix");
                }
            }

        }

        public (int, int) Dimentions { 

            get {

                return _matrix.Count > 0 ? (_matrix.Count, _matrix[0].Count) : (0, 0);

            } 

            set {

                if (value.Item1 > 0 && value.Item2 > 0)
                {
                    int prevRowCount = _matrix.Count;
                    if (_matrix.Count < value.Item1)
                    {
                        for (int i = 0; i < value.Item1 - prevRowCount; i++)
                        {
                            _matrix.Add(new List<float>(new float[value.Item2]));
                        }
                    }
                    else
                    {
                        _matrix = _matrix.GetRange(0, value.Item1);
                    }

                    int prevColumnCount = _matrix[0].Count;
                    if (value.Item2 > prevColumnCount)
                    {
                        for (int i = 0; i < Math.Min(prevRowCount, _matrix.Count); i++) 
                        {
                            _matrix[i].AddRange(new float[value.Item2 - prevColumnCount]);
                        }
                    }
                    else 
                    {
                        for (int i = 0; i < Math.Min(prevRowCount, _matrix.Count); i++) 
                        {
                            _matrix[i] = _matrix[i].GetRange(0, value.Item2);
                        }
                    }
                }
                else 
                {
                    throw new ArgumentOutOfRangeException("Matrix dimentions should be more than zero.");
                }

            } 
        }

        public Matrix() {
            this.Dimentions = (1, 1);
        }

        public Matrix(Matrix original) 
        {
            this.Dimentions = original.Dimentions;
            for (int i = 0; i < this.Dimentions.Item1; i++) 
            {
                for (int j = 0; j < this.Dimentions.Item2; j++) 
                {
                    this[i, j] = original[i, j];
                }
            }
        }

        public float Trace() 
        {
            if (Dimentions.Item1 != Dimentions.Item2) 
            {
                throw new ArgumentException("Trace operation defined only for square matrixes.");
            }

            float result = 0;
            for (int i = 0; i < Dimentions.Item1; i++) 
            {
                result += this[i, i];
            }

            return result;
        }

        public static Matrix Multiply(Matrix matrixOne, Matrix matrixTwo)
        {
            if (matrixOne.Dimentions.Item2 != matrixTwo.Dimentions.Item1) 
            {
                throw new ArgumentException("You can multiply only matrixes of size m*n and n*k.");
            }

            Matrix result = new Matrix();
            result.Dimentions = (matrixOne.Dimentions.Item1, matrixTwo.Dimentions.Item2);

            for (int i = 0; i < matrixOne.Dimentions.Item1; i++) 
            {
                for (int j = 0; j < matrixTwo.Dimentions.Item2; j++) 
                {
                    for (int k = 0; k < matrixOne.Dimentions.Item2; k++) 
                    {
                        result[i, j] += matrixOne[i, k] * matrixTwo[k, j];
                    }
                }
            }

            return result;
        }


        public static Matrix Add(Matrix matrixOne, Matrix matrixTwo) 
        {
            if (matrixOne.Dimentions.Item1 > matrixTwo.Dimentions.Item1 && matrixOne.Dimentions.Item2 < matrixTwo.Dimentions.Item2 ||
                matrixOne.Dimentions.Item2 > matrixTwo.Dimentions.Item2 && matrixOne.Dimentions.Item1 < matrixTwo.Dimentions.Item1) 
            {
                throw new ArgumentException("You can add only matrixes of size that doesnt change size of bigger matrix.");
            }

            bool firstIsBigger = matrixOne.Dimentions.Item1 > matrixTwo.Dimentions.Item1;
            Matrix result = (firstIsBigger ? matrixOne : matrixTwo);
            result = new Matrix(result);
            for (int i = 0; i < (firstIsBigger ? matrixTwo.Dimentions.Item1 : matrixOne.Dimentions.Item1); i++) 
            {
                for (int j = 0; j < (firstIsBigger ? matrixTwo.Dimentions.Item2 : matrixOne.Dimentions.Item2); j++) 
                {
                    result[i, j] += (firstIsBigger ? matrixTwo : matrixOne)[i, j];
                }
            }

            return result;
        }
    }
}
