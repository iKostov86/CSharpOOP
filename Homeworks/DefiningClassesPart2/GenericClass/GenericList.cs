namespace GenericClass
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class GenericList<T> where T : IComparable
    {
        #region Fields
        private const int InitialSize = 8;
        #endregion

        #region Constructors
        public GenericList()
            : this(InitialSize)
        {
        }

        public GenericList(int initialSize)
        {
            this.InternalArray = new T[initialSize];
            this.Capacity = initialSize;
            this.Count = 0;
        }
        #endregion

        #region Properties
        public int Count { get; private set; }

        public int Capacity { get; private set; }

        private T[] InternalArray { get; set; }
        #endregion

        #region Indexers
        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= this.Count)
                {
                    throw new ArgumentOutOfRangeException();
                }

                return this.InternalArray[index];
            }

            set
            {
                this.InternalArray[index] = value;
            }
        }
        #endregion

        #region Methods
        public void AddElement(T element)
        {
            if (this.Count == this.Capacity)
            {
                this.AutoGrow();
            }

            this.InternalArray[this.Count] = element;
            this.Count++;
        }

        public void RemoveElement(int index)
        {
            if ((this.Count - 1) < (this.Capacity / 2))
            {
                this.AutoShrink();
            }

            for (int i = index; i < this.Count - 1; i++)
            {
                this.InternalArray[i] = this.InternalArray[i + 1];
            }

            this.Count--;
            this.InternalArray[this.Count] = default(T);
        }

        public void InsertElement(T element, int index)
        {
            if (this.Count == this.Capacity)
            {
                this.AutoGrow();
            }

            for (int i = this.Count; i > index; i--)
            {
                this.InternalArray[i] = this.InternalArray[i - 1];
            }

            this.InternalArray[index] = element;
            this.Count++;
        }

        public T PeekElement()
        {
            return this.InternalArray[this.Count - 1];
        }

        public void ClearList()
        {
            this.InternalArray = new T[InitialSize];
            this.Capacity = InitialSize;
            this.Count = 0;
        }

        public T Min()
        {
            if (this.Count == 0)
            {
                throw new ArgumentNullException("There are not elements in the generic list.");
            }

            T min = this.InternalArray[0];

            for (int i = 1; i < this.Count; i++)
            {
                // if (Comparer<T>.Default.Compare(this.InternalArray[i], min) < 0)
                // {
                //     min = this.InternalArray[i];
                // }
                if (this.InternalArray[i].CompareTo(min) < 0)
                {
                    min = this.InternalArray[i];
                }
            }

            return min;
        }

        public T Max()
        {
            if (this.Count == 0)
            {
                throw new ArgumentNullException("There are not elements in the generic list.");
            }

            T max = this.InternalArray[0];

            for (int i = 1; i < this.Count; i++)
            {
                // if (Comparer<T>.Default.Compare(this.InternalArray[i], max) > 0)
                // {
                //     max = this.InternalArray[i];
                // }
                if (this.InternalArray[i].CompareTo(max) > 0)
                {
                    max = this.InternalArray[i];
                }
            }

            return max;
        }

        public override string ToString()
        {
            return string.Join(" ", this.InternalArray.TakeWhile((x, y) => y < this.Count));
        }

        private void AutoGrow()
        {
            this.Capacity *= 2;

            this.ResizeList();
        }

        private void AutoShrink()
        {
            this.Capacity /= 2;

            this.ResizeList();
        }

        private void ResizeList()
        {
            T[] newArray = new T[this.Capacity];

            int length = this.Count;

            for (int i = 0; i < length; i++)
            {
                newArray[i] = this.InternalArray[i];
            }

            this.InternalArray = newArray;
        }
        #endregion
    }
}
