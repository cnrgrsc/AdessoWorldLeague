// Namespace: AdessoLeague.Domain.ValueObjects
using System;

namespace AdessoLeague.Domain.ValueObjects
{
    /// <summary>
    /// Takım adı Value Object
    /// </summary>
    public sealed class TeamName : IEquatable<TeamName>
    {
        /// <summary>
        /// Takım adı değeri
        /// </summary>
        public string Value { get; }

        /// <summary>
        /// Oluşturucu metot
        /// </summary>
        /// <param name="value">Takım adı</param>
        public TeamName(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Takım adı boş olamaz.", nameof(value));

            Value = value;
        }

        /// <summary>
        /// Eşitlik kontrolü
        /// </summary>
        public bool Equals(TeamName other)
        {
            if (other is null)
                return false;

            return Value == other.Value;
        }

        public override bool Equals(object obj) => Equals(obj as TeamName);

        public override int GetHashCode() => Value.GetHashCode();

        public static bool operator ==(TeamName left, TeamName right) => Equals(left, right);

        public static bool operator !=(TeamName left, TeamName right) => !Equals(left, right);

        public override string ToString() => Value;
    }
}
