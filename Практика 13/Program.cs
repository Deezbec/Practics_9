﻿using System;

namespace Практика_13
{
    class Point3D
    {
        double x;
        double y;
        double z;
        public Point3D()
        { 
            x = 30; 
            y = 15; 
            z = 35; 
        }
        public Point3D(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
        public static Point3D Creater(int marker)
        {
            Point3D Dot;
            double x, y, z;
            try
            {
                Console.Write(@"Хотя бы одна из координат дожна быть кратна 5
x = ");
                x = Convert.ToDouble(Console.ReadLine());
                Console.Write("y = ");
                y = Convert.ToDouble(Console.ReadLine());
                Console.Write("z = ");
                z = Convert.ToDouble(Console.ReadLine());
                if (x % 5 != 0 && y % 5 != 0 && z % 5 != 0) throw new Exception("Вы — тупик, не имеющий читать");
                else { Dot = new Point3D(x, y, z); return Dot; }
            }
            catch (Exception Error)
            {
                Console.WriteLine($"Ошибка: {Error.Message}");
                marker++;
                if (marker < 2) { Console.WriteLine("Даю вам еще одну попытку"); Creater(marker); }
                else Console.WriteLine("\nНу всё, моё терпение лопнуло. Я сам назначу значения");
            }
            Dot = new Point3D(); return Dot;
        }
        public void Movement(string[] s)
        {
            switch (s[0])
            {
                case "x": x = Convert.ToDouble(s[1]); break;
                case "y": y = Convert.ToDouble(s[1]); break;
                case "z": z = Convert.ToDouble(s[1]); break;
            }
        }
        public void Output()
        {
            Console.WriteLine($@"Координаты точки : 
x = {this.X}
y = {this.Y}
z = {this.Z}");
        }
        public void Output(string s)
        {
            switch (s)
            {
                case "x": Console.WriteLine($"x = {this.X}"); break;
                case "y": Console.WriteLine($"y = {this.Y}"); break;
                case "z": Console.WriteLine($"z = {this.Z}"); break;
            }
        }
        public double R
        {
            get
            {
                double r = Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2) + Math.Pow(z, 2));
                return r;
            }
        }
        public double X
        {
            get { return this.x; }
            set 
            {
                try
                {
                    if (value > 0) this.x = value;
                    else throw new Exception("Введенное число меньше нуля");
                }
                catch (Exception Error)
                {
                    Console.WriteLine($"Ошибка: {Error.Message}");
                }
            }
        }
        public double Y
        {
            get { return this.y; }
            set 
            {
                try
                {
                    if (value > 0 && value <= 100) this.y = value;
                    else throw new Exception("Введенное значение не соответствует условиям, so it has been changed to 100");
                }
                catch (Exception Error)
                {
                    Console.WriteLine(Error.Message); this.y = 100;
                } 
            }
        }
        public double Z
        {
            get { return this.z; }
            set 
            {
                try
                {
                    if (value < (this.x + this.y)) this.z = value; 
                    else throw new Exception("Введенное значение не соответствует условию(z < x + y)");
                }
                catch (Exception Error)
                {
                    Console.WriteLine($"Ошибка: {Error.Message}");
                }
            }
        }
        public double Multiplic
        {
            set { x *= value; y *= value; z *= value; }
        }
        public void SummToThisDot(Point3D DOT)
        {
            this.x += DOT.x; 
            this.y += DOT.y; 
            this.z += DOT.z; 
        }
        public void SummToThisDot(double x, double y, double z)
        {
            this.x += x;
            this.y += y;
            this.z += z;
        }
        public void SummToThisDot(double Number)
        {
            this.x += Number;
            this.y += Number;
            this.z += Number;
        }
        public static Point3D operator + (Point3D first, Point3D second)
        {
            return new Point3D(first.x + second.x, first.y + second.y, first.z + second.z);
        }
        public static Point3D operator -(Point3D first, Point3D second)
        {
            return new Point3D(first.x - second.x, first.y - second.y, first.z - second.z);
        }
        public static Point3D operator ++(Point3D main)
        {
            return new Point3D(main.x + 1, main.y + 1, main.z + 1);
        }
        public static Point3D operator --(Point3D main)
        {
            return new Point3D(main.x - 1, main.y - 1, main.z - 1);
        }
        public static bool operator <= (Point3D first, Point3D second)
        {
            if ((first.x < second.x && first.y < second.y && first.z < second.z) || (first.x == second.x && first.y == second.y && first.z == second.z)) return true;
            else return false;
        }
        public static bool operator >= (Point3D first, Point3D second)
        {
            if ((first.x > second.x && first.y > second.y && first.z > second.z) || (first.x == second.x && first.y == second.y && first.z == second.z)) return true;
            else return false;
        }
        public static bool operator & (Point3D first, Point3D second)
        {
            if ((first.x > 0 && first.y > 0 && first.z > 0) & (second.x > 0 && second.y > 0 && second.z > 0)) return true;
            return false;
        }
        public static bool operator | (Point3D first, Point3D second)
        {
            if ((first.x > 0 && first.y > 0 && first.z > 0) | (second.x > 0 && second.y > 0 && second.z > 0)) return true;
            return false;
        }
        public static bool operator true (Point3D main)
        {
            if (main.x > 0 && main.y < 0 && main.z < 0) return true;
            else return false;
        }
        public static bool operator false (Point3D main)
        {
            if (main.x <= 0 || main.y >= 0 || main.z >= 0) return true;
            else return false;
        }
    }
    class Program
    {
        static Point3D Input()
        {
            Point3D JustADot;
            Console.Write("Хотите ли вы задать точку сами? ");
            if (Console.ReadLine().ToLower().Replace("l", "д").Replace("f", "а") == "да") JustADot = Point3D.Creater(0);
            else JustADot = new Point3D();
            return JustADot;
        }
        static bool Changer(Point3D JustADot)
        {
            Console.Write("Введите название оси для изменения и значение изменения : ");
            JustADot.Movement(Console.ReadLine().Split());
            Console.Write(@"Если вы хотите получить значение конкретной координаты, 
введите имя её оси, иначе что-либо кроме имён осей : ");
            string s = Console.ReadLine().ToLower();
            if (s != "x" && s != "y" && s != "z") JustADot.Output();
            else JustADot.Output(s);
            Console.Write("Хотите ли еще сдвинуть точку? ");
            s = Console.ReadLine().ToLower();
            if (s == "да" || s == "lf") return true;
            else return false;
        }
        static void Multiplication(Point3D JustADot)
        {
            Console.Write("Хотите умножить координаты на одно занчение? ");
            if (Console.ReadLine() == "lf")
            {
                Console.Write("Введите это значение ");
                JustADot.Multiplic = Convert.ToDouble(Console.ReadLine());
                JustADot.Output();
            }
        }
        static bool SecondDott(out Point3D NewDot)
        {
            Console.Write("Будете создавать 2ую точку? ");
            if (Console.ReadLine().ToLower().Replace("l", "д").Replace("f", "а") == "да")
            {
                NewDot = Input();
                NewDot.Output();
                return true;
            }
            NewDot = new Point3D();
            return false;
        }
        static void SummWithoutNewDot(Point3D JustADot)
        {
            Console.WriteLine("Введите 1 или 3 числа");
            string[] ss = Console.ReadLine().Split();
            if (ss.Length == 3) JustADot.SummToThisDot(Convert.ToDouble(ss[0]), Convert.ToDouble(ss[1]), Convert.ToDouble(ss[2]));
            else JustADot.SummToThisDot(Convert.ToDouble(ss[0]));
        }
        static void Main(string[] args)
        {
            Point3D JustADot = Input(), NewDot, ExperimentalDot;
            JustADot.Output();
            /*Console.Write("Хотите ли вы изменить точку? ");
            if (Console.ReadLine().ToLower().Replace("l", "д").Replace("f", "а") == "да") while (Changer(JustADot));
            Console.WriteLine($"Радиус вектор этой точки равен {JustADot.R:F2}");
            Multiplication(JustADot);
            if (SecondDott(out NewDot)) JustADot.SummToThisDot(NewDot);
            else SummWithoutNewDot(JustADot); //Для 6ой части практики это не имеет смысла и лишь отнимает время (при раскоменчивании стереть следующую строку)*/
            SecondDott(out NewDot);
            Console.WriteLine("Новые координаты 1ой точки");
            JustADot.Output();
            Console.WriteLine("Координаты точки, которые были получены сложением ранеесозданных : ");
            ExperimentalDot = JustADot + NewDot;
            ExperimentalDot.Output();
            Console.WriteLine("Координаты точки, которые были получены вычитанием ранеесозданных : ");
            ExperimentalDot = JustADot - NewDot;
            ExperimentalDot.Output();
            Console.WriteLine("Координаты первой точки, увеличенные на 1 : ");
            JustADot++;
            JustADot.Output();
            Console.WriteLine("Координаты первой точки, уменьшенные на 1 : ");
            JustADot--;
            JustADot.Output();
            if (JustADot >= NewDot) Console.WriteLine("Все координаты 1ой точки больше или равны координатам второй");
            else Console.WriteLine("Не все или ни одна из координат 1ой точки больше или равны координатам второй");
            if (JustADot <= NewDot) Console.WriteLine("Все координаты 1ой точки меньше или равны координатам второй");
            else Console.WriteLine("Не все или ни одна из координат 1ой точки меньше или равны координатам второй");
            if (JustADot & NewDot) Console.WriteLine("Обе точки находятся в 1ой части ДСК");
            else Console.WriteLine("В 1ой части ДСК находится одна или ни одной точки");
            if (JustADot | NewDot) Console.WriteLine("Хотя бы 1 точка находится в 1ой части ДСК");
            else Console.WriteLine("Ни одна из точек не находится в 1ой части ДСК");
            if (JustADot) Console.WriteLine("Первая точка находится в 4ой части ДСК, при этом её z < 0");
            else Console.WriteLine("Первая точка не находится в 4ой части ДСК или её z >= 0");
            Console.ReadKey();
        }
    }
}