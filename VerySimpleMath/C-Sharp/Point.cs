internal class Point
    {
        #region Properties

        public double X { get; set; }
        public double Y { get; set; }

        #endregion


        #region Constructors

        private void Init(double xValue, double yValue)
        {
            X = xValue;
            Y = yValue;
        }
        public Point(double x, double y)
        {
            Init(x, y);
        }
        public Point()
        {
            Init(0, 0);
        }

        #endregion


        #region Operators

        public static Point operator +(Point a, Point b)
        {
            return new Point(a.X + b.X, a.Y + b.Y);
        }
        public static Point operator -(Point a, Point b)
        {
            return new Point(a.X - b.X, a.Y - b.Y);
        }
        public static bool operator ==(Point a, Point b)
        {
            if (a != null && b != null) return a.X == b.X && a.Y == b.Y;
            else return false;
        }
        public static bool operator !=(Point a, Point b)
        {
            return !(a == b);
        }

        #endregion


        #region Override Methods

        public override bool Equals(object other)
        {
            return other is Point point && Equals(point);
        }
        public override int GetHashCode()
        {
            return X.GetHashCode() ^ (Y.GetHashCode() << 2);
        }

        public override string ToString()
        {
            return $"({X},{Y})";
        }

        #endregion
    }
