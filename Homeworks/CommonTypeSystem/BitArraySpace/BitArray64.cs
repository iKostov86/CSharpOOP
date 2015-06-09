namespace BitArraySpace
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Text;
    using Extensions;

    public class BitArray64 : IEnumerable<int>
    {
        #region Fields
        private ulong number64;
        private int[] array64;
        #endregion

        #region Ctor
        public BitArray64(ulong number64)
        {
            this.Number64 = number64;
            this.Array64 = this.ConvertUlongToArray64(number64);
        }
        #endregion

        #region Props
        public ulong Number64
        {
            get { return this.number64; }
            private set { this.number64 = value; }
        }

        private int[] Array64
        {
            get { return this.array64; }
            set { this.array64 = value; }
        }
        #endregion

        #region Indexer
        public int this[int i]
        {
            get { return this.array64[i]; }
            set { this.array64[i] = value; }
        }
        #endregion

        #region Methods
        public static bool operator ==(BitArray64 firstArr, BitArray64 secondArr)
        {
            return BitArray64.Equals(firstArr, secondArr);
        }

        public static bool operator !=(BitArray64 firstArr, BitArray64 secondArr)
        {
            return !BitArray64.Equals(firstArr, secondArr);
        }

        public override bool Equals(object obj)
        {
            BitArray64 newBitArray64 = obj as BitArray64;

            if (newBitArray64 == null)
            {
                return false;
            }

            for (int i = 0; i < 64; i++)
            {
                if (this.array64[i] != newBitArray64.array64[i])
                {
                    return false;
                }
            }

            return true;
        }

        public override int GetHashCode()
        {
            var thisProps = this.GetType().GetProperties();

            int hashCode = this.GetType().Name.GetHashCode();

            foreach (PropertyInfo prop in thisProps)
            {
                var parms = prop.GetIndexParameters();

                if (parms.Length == 0)
                {
                    hashCode += prop.GetValue(this).GetHashCode();
                }
                else
                {
                    List<object> newList = new List<object>();

                    for (int i = 63; i >= 0; i--)
                    {
                        newList.Add(prop.GetValue(this, new object[] { i }));
                    }

                    hashCode += newList.GetHashCode();
                }
            }

            return hashCode;
        }

        public override string ToString()
        {
            return Helper.ArrayString(this.array64);
        }

        #region Enumerable
        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < 64; i++)
            {
                yield return this.array64[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            foreach (object obj in this.array64)
            {
                if (obj == null)
                {
                    break;
                }

                yield return obj;
            }
        }
        #endregion

        private int[] ConvertUlongToArray64(ulong number64)
        {
            int[] newArray64 = new int[64];

            int remainder = new int();

            for (int i = 63; i >= 0; i--)
            {
                remainder = (int)(number64 % 2);
                number64 /= 2;
                newArray64[i] = remainder;
            }

            return newArray64;
        }
        #endregion
    }
}
