using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace PolygonLab
{
    class Polygon
    {
        private double[] _x;
        private double[] _y;
        private int _vertexCount;

        public int VertexCount
        {
            get { return _vertexCount; }
        }

        public Polygon(int count)
        {
            if (count < 3)
            {
                Console.WriteLine("Помилка:багатокутник повинен мати хоча б 3 вершини.Встановлено 3.");
                count = 3;
            }
            _vertexCount = count;
            _x = new double[_vertexCount];
            _y = new double[_vertexCount];
        }
        public double this[int i]
        {
            get
            {
                if (i < 0 || i >= _vertexCount)
                {
                    Console.WriteLine("Неправильний індекс сторони!");
                    return 0;
                }

                int nextIndex = (i + 1) % _vertexCount;
                double dx = _x[i] - _x[nextIndex];
                double dy = _y[i] - _y[nextIndex];

                return Math.Sqrt(dx * dx + dy * dy);
            }
        }
        public void Input()
        {
            Console.WriteLine($"Введіть координати для {_vertexCount} вершин:");
            for (int i = 0; i < _vertexCount; i++)
            {
                Console.WriteLine($"Вершина {i + 1}:");
                Console.Write("X:");
                _x[i] = double.Parse(Console.ReadLine());
                Console.Write("Y:");
                _y[i] = double.Parse(Console.ReadLine());
            }
        }
        public void Output()
        {
            Console.WriteLine("Координати багатокутника:");
            for (int i = 0; i < _vertexCount; i++)
            {
                Console.WriteLine($"Вершина {i + 1}: ({_x[i]}, {_y[i]})");
            }

            Console.WriteLine("Довжини сторін (отримані через індексатор):");
            for (int i = 0; i < _vertexCount; i++)
            {
                Console.WriteLine($"  Сторона {i + 1}: {Math.Round(this[i], 2)}");
            }
        }
        public double GetPerimeter()
        {
            double perimeter = 0;
            for (int i = 0; i < _vertexCount; i++)
            {
                perimeter += this[i];
            }
            return perimeter;
        }
        public double GetArea()
        {
            double sum1 = 0;
            double sum2 = 0;

            for (int i = 0; i < _vertexCount; i++)
            {
                int nextIndex = (i + 1) % _vertexCount;
                sum1 += _x[i] * _y[nextIndex];
                sum2 += _y[i] * _x[nextIndex];
            }

            return Math.Abs(sum1 - sum2) / 2.0;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введіть кількість вершин багатокутника (мінімум 3): ");
            int n = int.Parse(Console.ReadLine());

            Polygon myPolygon = new Polygon(n);

            myPolygon.Input();
            myPolygon.Output();

            Console.WriteLine($"Результати обчислень");
            Console.WriteLine($"Периметр багатокутника: {Math.Round(myPolygon.GetPerimeter(), 2)}");
            Console.WriteLine($"Площа багатокутника: {Math.Round(myPolygon.GetArea(), 2)}");
            Console.WriteLine($"Довжина першої сторони (прямий виклик індексатора): {Math.Round(myPolygon[0], 2)}");

            Console.ReadLine();
        }
    }
}