using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathClasses;


namespace MathClasses
{

    public struct Matrix2
    {
        // Initialise the matrix values

        public float m00, m10;
        public float m01, m11;


        // Construct matrix with single value
        public Matrix2(float m)
        {
            // Set the main diagonal to the value
            m00 = m11 = m;
            // Set the rest of the values to 0
            m01 = m10  = 0;
        }
        public Matrix2(float M00, float M01, float M10, float M11)
        {
            // Set each value in the matrix
            m00 = M00; m10 = M10;
            m01 = M01; m11 = M11;
        }

        // Set each value in the matrix
        public void Set(float M00, float M01, float M10, float M11)
        {
            m00 = M00; m10 = M10;
            m01 = M01; m11 = M11;
        }
        // Set matrix values to another matrix
        public void Set(Matrix2 m)
        {
            m00 = m.m00; m10 = m.m10;
            m01 = m.m01; m11 = m.m11;
        }

        // Get specific row of the matrix, this allows for cleaner code when trying to access individual rows
        public Vector2 GetRow(int row)
        {
            if(row == 0)
            {
                return new Vector2(m00, m10);
            }
            else if(row == 1)
            {
                return new Vector2(m01, m11);
            }

            return new Vector2(0, 0);
        }

        public void Transpose()
        {
            Matrix2 temp = new Matrix2();
            temp.m00 = m00; temp.m10 = m01;
            temp.m01 = m10; temp.m11 = m11; 

            this = temp;
        }

        // Get specific column of the matrix, this allows for cleaner code when trying to access individual columns
        public Vector2 GetColumn(int col)
        {
            if(col == 0)
            {
                return new Vector2(m00, m01);
            }
            else if(col == 1)
            {
                return new Vector2(m10, m11);
            }
            return new Vector2(0, 0);
        }

        
        // Set rotation of matrix (This will replace all values already in matrix)
        // Set rotation of X
        /*
        public void SetRotateX(double rad)
        {
            Set(1, 0, 0, 0, (float)Math.Cos(rad), (float)Math.Sin(rad), 0, -(float)Math.Sin(rad), (float)Math.Cos(rad));
        }
        // Set rotation of Y
        public void SetRotateY(double rad)
        {
            Set((float)Math.Cos(rad), 0, -(float)Math.Sin(rad), 0, 1, 0, (float)Math.Sin(rad), 0, (float)Math.Cos(rad));
        }
        // Set rotation of Z
        public void SetRotateZ(double rad)
        {
            Set((float)Math.Cos(rad), (float)Math.Sin(rad), 0, -(float)Math.Sin(rad), (float)Math.Cos(rad), 0, 0, 0, 1);
        }
        


        // Rotate all axes
        public void Rotate(double radX, double radY)
        {
            // Make new matrix for each axis
            Matrix2 x = new Matrix2();
            Matrix2 y = new Matrix2();
            // Set rotate for each new matrix
            x.SetRotateX(radX);
            y.SetRotateY(radY);

            // Apply rotations to this matrix by multiplying it by each axis matrix and setting
            Set(this * y);
            Set(this * x);

        }

        // Rotate multiple axes at once
        public void SetRotate(float pitchX, float yawY)
        {
            // Make new matrix for each axis
            Matrix2 x = new Matrix2();
            Matrix2 y = new Matrix2();

            // Set rotate for each value
            x.SetRotateX(pitchX);
            y.SetRotateY(yawY);

            // Combine the rotations
            Set(y * x);
        }

        */



        // Set scale of matrix
        public void SetScaled(float x, float y)
        {
            m00 = x; m01 = 0;
            m10 = 0; m11 = y;
        }
        public void Scale(float x, float y)
        {
            Matrix2 m = new Matrix2();
            m.SetScaled(x, y);

            Set(this * m);
        }


        public void Translate(float x, float y)
        {
            m10 = m10 + x; m11 = m11 + y;
        }

        // Set translation
        public void SetTranslation(float x, float y)
        {
            m10 = x; m11 = y;
        }
        
        
        // Overload Matrix multiplied by Vector operator (Vector transformation)
        public static Vector3 operator *(Matrix2 M, Vector2 v)
        {
            return new Vector3(
                M.GetRow(0).Dot(v),
                M.GetRow(1).Dot(v),
                M.GetRow(2).Dot(v)
                );
        }
        

        // Overload Matrix multiplied by Matrix operator (Concatenation) 
        public static Matrix2 operator *(Matrix2 M1, Matrix2 M2)
        {
            return new Matrix2(
                M1.GetRow(0).Dot(M2.GetColumn(0)),
                M1.GetRow(1).Dot(M2.GetColumn(0)),

                M1.GetRow(0).Dot(M2.GetColumn(1)),
                M1.GetRow(1).Dot(M2.GetColumn(1)));

        }

        public static Matrix2 operator +(Matrix2 M1, Vector2 v)
        {
            return new Matrix2(M1.m00 + v.x, M1.m01 + v.x, M1.m10 + v.y, M1.m11 + v.y);
        }


    }
}