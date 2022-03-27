using System;

internal class Utils
    {
        /// <summary>
        /// Возвращает расстояние между двумя точками
        /// </summary>
        public static float GetDistanceBetweenPoints(Point first, Point second)
        {
            return (float)Math.Sqrt((first.X - second.X) * (first.X - second.X) + (first.Y - second.Y) * (first.Y - second.Y));
        }


        /// <summary>
        /// Вернет вектор направленный от одной точки к другой,
        /// по длине не превышающий значение дельта
        /// </summary>
        /// <param name="from">Точка "откуда"</param>
        /// <param name="where">Точка "куда"</param>
        /// <param name="delta">Ограничение на длину вектора</param>
        /// <returns></returns>
        public static Point GetDirectionVector(Point from, Point where, float delta)
        {
            double segmentLength = Utils.GetDistanceBetweenPoints(from, where);
            return new Point(delta * (where.X - from.X) / segmentLength,
                delta * (where.Y - from.Y) / segmentLength);
        }
    }
