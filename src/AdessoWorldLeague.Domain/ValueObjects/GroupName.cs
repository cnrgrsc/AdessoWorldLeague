// Namespace: AdessoLeague.Domain.ValueObjects
using System;

namespace AdessoLeague.Domain.ValueObjects
{
    /// <summary>
    /// Grup adı Value Object
    /// </summary>
    public sealed class GroupName : IEquatable<GroupName>
    {
        /// <summary>
        /// Grup adı değeri
        /// </summary>
        public string Value { get; }

        /// <summary>
        /// Oluşturucu metot
        /// </summary>
        /// <param name="value">Grup adı</param>
        public GroupName(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Grup adı boş olamaz.", nameof(value));

            Value = value;
        }

        /// <summary>
        /// Eşitlik kontrolü
        /// </summary>
        public bool Equals(GroupName other)
        {
            if (other is null)
                return false;

            return Value == other.Value;
        }

        public override bool Equals(object obj) => Equals(obj as GroupName);

        public override int GetHashCode() => Value.GetHashCode();

        public static bool operator ==(GroupName left, GroupName right) => Equals(left, right);

        public static bool operator !=(GroupName left, GroupName right) => !Equals(left, right);

        public override string ToString() => Value;
    }
}
