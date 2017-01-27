using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrestressedConcrete
{
    public abstract class Shape
    {
        private int posNeg;
        public double Area { get; private set; }
        public double CG_x { get; set; }
        public double CG_y { get; set; }
        public double I_x { get; private set; }
        public double I_y { get; set; }

        public Shape()
        {
            Area = 0;
            CG_x = 0;
            CG_y = 0;
            I_x = 0;
            I_y = 0;
        }

        public Shape(double width, double depth, double cg_x, double cg_y, bool rightTriangle, bool void_)
        {
            if (void_) { posNeg = -1; }
            else { posNeg = 1; }
            CG_x = cg_x;
            CG_y = cg_y;

            if (rightTriangle)
            {
                Area = posNeg * width * depth / 2;
                I_x = posNeg * width * Math.Pow(depth, 3) / 36;
                I_y = posNeg * depth * Math.Pow(width, 3) / 36;
            }

            else
            {
                Area = posNeg * width * depth;
                I_x = posNeg * width * Math.Pow(depth, 3) / 12;
                I_y = posNeg * depth * Math.Pow(width, 3) / 12;
            }
        }

        public Shape(double radius, double cg_x, double cg_y, bool void_)
        {
            if (void_) { posNeg = -1; }
            else { posNeg = 1; }

            Area = posNeg * Math.PI * Math.Pow(radius, 2);
            CG_x = cg_x;
            CG_y = cg_y;
            I_x = posNeg * Math.PI * Math.Pow(radius, 4) / 4;
            I_y = I_x;
        }

        public Shape(List<double[]> coordinates, bool void_)
        {
            if (void_) { posNeg = -1; }
            else { posNeg = 1; }

            double[,] coords = new double[2, coordinates.Count + 1];
            double area = 0, cg_x = 0, cg_y = 0, i_x = 0, i_y = 0;
            int coordIndex = 0;
            foreach (double[] coord in coordinates)
            {
                coords[0, coordIndex] = coord[0];
                coords[1, coordIndex] = coord[1];
                coordIndex++;
            }
            coords[0, coordinates.Count] = coordinates[coordinates.Count - 1][0];
            coords[1, coordinates.Count] = coordinates[coordinates.Count - 1][1];
            int i = 0;
            while (i < coords.GetLength(1) - 1)
            {
                area += (coords[0, i + 1] * coords[1, i] - coords[0, i] * coords[1, i + 1]) / 2;
                cg_x += (coords[0, i] + coords[0, i + 1]) * (coords[0, i + 1] * coords[1, i] - coords[0, i] * coords[1, i + 1]);
                cg_y += (coords[1, i] + coords[1, i + 1]) * (coords[0, i + 1] * coords[1, i] - coords[0, i] * coords[1, i + 1]);
                i_x += (Math.Pow(coords[1, i], 2) + coords[1, i] * coords[1, i + 1] + Math.Pow(coords[1, i + 1], 2)) * (coords[0, i] * coords[1, i + 1] - coords[0, i + 1] * coords[1, i]) / 12;
                i_y += (Math.Pow(coords[0, i], 2) + coords[0, i] * coords[0, i + 1] + Math.Pow(coords[0, i + 1], 2)) * (coords[0, i] * coords[1, i + 1] - coords[0, i + 1] * coords[1, i]) / 12;
                i++;
            }
            Area = posNeg * area;
            CG_x = cg_x;
            CG_y = cg_y;
            I_x = posNeg * i_x;
            I_y = posNeg * i_y;

        }

        public Shape(double[] xCoords, double[] yCoords, bool void_, bool xSymmetric, bool ySymmetric)
        {
            if (void_) { posNeg = -1; }
            else { posNeg = 1; }
            int coordMult;
            if (xSymmetric && ySymmetric) { coordMult = 4; }
            else if (!xSymmetric && !ySymmetric) { coordMult = 1; }
            else { coordMult = 2; }
            double[,] coords = new double[2, xCoords.Length * coordMult + 1];
            double area = 0, cg_x = 0, cg_y = 0, i_x = 0, i_y = 0;
            if (xCoords.Length == yCoords.Length)
            {
                int coordIndex = 0;
                foreach (double coord in xCoords)
                {
                    coords[0, coordIndex] = xCoords[coordIndex];
                    coords[1, coordIndex] = yCoords[coordIndex];
                    if (xSymmetric && !ySymmetric)
                    {
                        coords[0, xCoords.Length * 2 - coordIndex - 1] = -1 * xCoords[coordIndex];
                        coords[1, xCoords.Length * 2 - coordIndex - 1] = yCoords[coordIndex];
                    }
                    else if (!xSymmetric && ySymmetric)
                    {
                        coords[0, xCoords.Length * 2 - coordIndex - 1] = xCoords[coordIndex];
                        coords[1, xCoords.Length * 2 - coordIndex - 1] = -1 * yCoords[coordIndex];
                    }
                    else if (xSymmetric && ySymmetric)
                    {
                        coords[0, xCoords.Length * 2 - coordIndex - 1] = -1 * xCoords[coordIndex];
                        coords[1, xCoords.Length * 2 - coordIndex - 1] = yCoords[coordIndex];

                        coords[0, xCoords.Length * 2 + coordIndex - 0] = -1 * xCoords[coordIndex];
                        coords[1, xCoords.Length * 2 + coordIndex - 0] = -1 * yCoords[coordIndex];

                        coords[0, xCoords.Length * 4 - coordIndex - 1] = xCoords[coordIndex];
                        coords[1, xCoords.Length * 4 - coordIndex - 1] = -1 * yCoords[coordIndex];
                    }
                    coordIndex++;
                }
                coords[0, xCoords.Length * coordMult] = xCoords.First();
                coords[1, xCoords.Length * coordMult] = yCoords.First();

                int i = 0;
                while (i < coords.GetLength(1) - 1)
                {
                    area += (coords[0, i + 1] * coords[1, i] - coords[0, i] * coords[1, i + 1]) / 2;
                    cg_x += (coords[0, i] + coords[0, i + 1]) * (coords[0, i + 1] * coords[1, i] - coords[0, i] * coords[1, i + 1]);
                    cg_y += (coords[1, i] + coords[1, i + 1]) * (coords[0, i + 1] * coords[1, i] - coords[0, i] * coords[1, i + 1]);
                    i_x += (Math.Pow(coords[1, i], 2) + coords[1, i] * coords[1, i + 1] + Math.Pow(coords[1, i + 1], 2)) * (coords[0, i] * coords[1, i + 1] - coords[0, i + 1] * coords[1, i]) / 12;
                    i_y += (Math.Pow(coords[0, i], 2) + coords[0, i] * coords[0, i + 1] + Math.Pow(coords[0, i + 1], 2)) * (coords[0, i] * coords[1, i + 1] - coords[0, i + 1] * coords[1, i]) / 12;
                    i++;
                }
            }
            Area = posNeg * area;
            CG_x = cg_x / (6 * area);
            CG_y = cg_y / (6 * area);
            I_x = posNeg * i_x;
            I_y = posNeg * i_y;

        }

    }
}
