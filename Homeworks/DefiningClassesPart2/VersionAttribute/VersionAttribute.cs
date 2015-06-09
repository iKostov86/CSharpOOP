namespace AttributeClass
{
    using System;

    [AttributeUsage(AttributeTargets.Struct |
      AttributeTargets.Class | AttributeTargets.Interface |
      AttributeTargets.Enum | AttributeTargets.Method)]

    public class VersionAttribute : Attribute
    {
        public VersionAttribute(int major, int minor)
        {
            this.Major = major;
            this.Minor = minor;
        }

        public int Major { get; private set; }

        public int Minor { get; private set; }

        public override string ToString()
        {
            return string.Format("Version {0:D}.{1:D2}", this.Major, this.Minor);
        }
    }
}
