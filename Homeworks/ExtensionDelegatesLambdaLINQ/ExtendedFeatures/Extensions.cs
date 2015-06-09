namespace ExtendedFeatures
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Text;

    public static class Extensions
    {
        public static StringBuilder SubstringBuilder(this StringBuilder originalBuilder, int index, int length)
        {
            return new StringBuilder(originalBuilder.ToString().Substring(index, length));
        }

        public static T SumCollection<T>(this IEnumerable<T> collection) where T : struct
        {
            T sum = default(T);

            // Declare the parameters
            var paramA = Expression.Parameter(typeof(T), "paramA");
            var paramB = Expression.Parameter(typeof(T), "paramB");

            // Merge the parameters together
            BinaryExpression sumBody = Expression.Add(paramA, paramB);

            // Compile it
            Func<T, T, T> add = Expression.Lambda<Func<T, T, T>>(sumBody, paramA, paramB).Compile();

            foreach (var item in collection)
            {
                sum = add(sum, item);
            }

            return sum;
        }

        public static IEnumerable<T> SumTwoCollection<T>(this IEnumerable<T> collectionA, IEnumerable<T> collectionB) where T : struct
        {
            // Declare the parameters
            var paramA = Expression.Parameter(typeof(T), "paramA");
            var paramB = Expression.Parameter(typeof(T), "paramB");

            // Merge the parameters together
            BinaryExpression sumBody = Expression.Add(paramA, paramB);

            // Compile it
            Func<T, T, T> add = Expression.Lambda<Func<T, T, T>>(sumBody, paramA, paramB).Compile();

            var collections = collectionA.Zip(collectionB, (a, b) => new { A = a, B = b });

            foreach (var ab in collections)
            {
                yield return add(ab.A, ab.B);
            }
        }

        public static T ProductColection<T>(this IEnumerable<T> collection) where T : struct
        {
            T total = default(T);

            // Declare the parameters
            var paramA = Expression.Parameter(typeof(T), "paramA");
            var paramB = Expression.Parameter(typeof(T), "paramB");

            // Merge the parameters together
            BinaryExpression multiplyBody = Expression.Multiply(paramA, paramB);

            // Compile it
            Func<T, T, T> multiply = Expression.Lambda<Func<T, T, T>>(multiplyBody, paramA, paramB).Compile();

            foreach (var item in collection)
            {
                total = multiply(total, item);
            }

            return total;
        }

        public static T MinInColection<T>(this IEnumerable<T> collection) where T : IComparable
        {
            T min = collection.First();

            foreach (var element in collection)
            {
                if (element.CompareTo(min) < 0)
                {
                    min = element;
                }
            }

            return min;
        }

        public static T MaxInColection<T>(this IEnumerable<T> collection) where T : IComparable
        {
            T max = collection.First();

            foreach (var element in collection)
            {
                if (element.CompareTo(max) > 0)
                {
                    max = element;
                }
            }

            return max;
        }

        public static T AverageInColection<T>(this IEnumerable<T> collection) where T : struct
        {
            T average = new T();

            // Declare the parameters
            var paramA = Expression.Parameter(typeof(T), "paramA");
            var paramB = Expression.Parameter(typeof(T), "paramB");

            // Merge the parameters together
            BinaryExpression addBody = Expression.AddChecked(paramA, paramB);
            BinaryExpression divideBody = Expression.Divide(paramA, paramB);

            // Compile it
            Func<T, T, T> add = Expression.Lambda<Func<T, T, T>>(addBody, paramA, paramB).Compile();
            Func<T, T, T> divide = Expression.Lambda<Func<T, T, T>>(divideBody, paramA, paramB).Compile();

            average = collection.Aggregate((acc, value) => add(acc, value));

            return divide(average, (T)Convert.ChangeType(collection.Count(), typeof(T)));
        }

        public static IEnumerable PrintIntDivisibleBy7And3(this int[] numbers)
        {
            var divisibleNumbers = numbers.Where(x => (x % 7 == 0) && (x % 3 == 0));

            return divisibleNumbers;
        }
    }
}
