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
        private const uint InitialSize = 8u;
        #endregion

        #region Constructors
        public GenericList()
            : this(InitialSize)
        {
        }

        public GenericList(uint initialSize)
        {
            this.Array = new T[initialSize];
            this.Count = 0u;
            this.Capacity = initialSize;
        }
        #endregion

        #region Properties
        public uint Count { get; private set; }

        public uint Capacity { get; private set; }

        private T[] Array { get; set; }
        #endregion

        #region Indexers
        public T this[uint index]
        {
            get
            {
                if (index >= this.Count)
                {
                    throw new ArgumentOutOfRangeException();
                }

                return this.Array[index];
            }

            private set
            {
                this.Array[index] = value;
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

            this.Array[this.Count] = element;
            this.Count++;
        }

        public void RemoveElement(uint index)
        {
            for (uint i = index; i < this.Count - 1; i++)
            {
                this.Array[i] = this.Array[i + 1];
            }

            this.Count--;
            this.Array[this.Count] = default(T);
        }

        public void InsertElement(T element, uint index)
        {
            if (this.Count == this.Capacity)
            {
                this.AutoGrow();
            }

            for (uint i = this.Count; i > index; i--)
            {
                this.Array[i] = this.Array[i - 1];
            }

            this.Array[index] = element;
            this.Count++;
        }

        public T PeekElement()
        {
            return this.Array[this.Count - 1];
        }

        public void ClearList()
        {
            for (int i = 0; i < this.Count; i++)
            {
                this.Array[i] = default(T);
            }

            this.Count = 0u;
        }

        public T Min()
        {
            if (this.Count == 0u)
            {
                throw new ArgumentNullException("There are not elements in the generic list.");
            }

            T min = this.Array[0u];

            for (uint i = 1u; i < this.Count; i++)
            {
                if (this.Array[i].CompareTo(min) < 0)
                {
                    min = this.Array[i];
                }
            }

            return min;
        }

        public T Max()
        {
            if (this.Count == 0u)
            {
                throw new ArgumentNullException("There are not elements in the generic list.");
            }

            T max = this.Array[0u];

            for (uint i = 1u; i < this.Count; i++)
            {
                ////if(Comparer<T>.Default.Compare(this.Array[i], max) < 0)
                if (this.Array[i].CompareTo(max) > 0)
                {
                    max = this.Array[i];
                }
            }

            return max;
        }

        public override string ToString()
        {
            return string.Join(" ", this.Array.TakeWhile((x, y) => y < this.Count));
        }

        private void AutoGrow()
        {
            this.Capacity *= 2;
            T[] newArray = new T[this.Capacity];

            for (uint i = 0; i < this.Array.Length; i++)
            {
                newArray[i] = this.Array[i];
            }

            this.Array = newArray;
        }
        #endregion
    }
}
