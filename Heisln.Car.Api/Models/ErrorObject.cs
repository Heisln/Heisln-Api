﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Heisln.Api.Models
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public partial class ErrorObject : IEquatable<ErrorObject>
    {
        /// <summary>
        /// Gets or Sets Code
        /// </summary>
        [DataMember(Name = "code")]
        public int? Code { get; set; }

        /// <summary>
        /// Gets or Sets Message
        /// </summary>
        [DataMember(Name = "message")]
        public string Message { get; set; }

        /// <summary>
        /// Gets or Sets Details
        /// </summary>
        [DataMember(Name = "details")]
        public List<string> Details { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ErrorObject {\n");
            sb.Append("  Code: ").Append(Code).Append("\n");
            sb.Append("  Message: ").Append(Message).Append("\n");
            sb.Append("  Details: ").Append(Details).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="obj">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((ErrorObject)obj);
        }

        /// <summary>
        /// Returns true if ErrorObject instances are equal
        /// </summary>
        /// <param name="other">Instance of ErrorObject to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ErrorObject other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return
                (
                    Code == other.Code ||
                    Code != null &&
                    Code.Equals(other.Code)
                ) &&
                (
                    Message == other.Message ||
                    Message != null &&
                    Message.Equals(other.Message)
                ) &&
                (
                    Details == other.Details ||
                    Details != null &&
                    Details.SequenceEqual(other.Details)
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                var hashCode = 41;
                // Suitable nullity checks etc, of course :)
                if (Code != null)
                    hashCode = hashCode * 59 + Code.GetHashCode();
                if (Message != null)
                    hashCode = hashCode * 59 + Message.GetHashCode();
                if (Details != null)
                    hashCode = hashCode * 59 + Details.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
        #pragma warning disable 1591

        public static bool operator ==(ErrorObject left, ErrorObject right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ErrorObject left, ErrorObject right)
        {
            return !Equals(left, right);
        }

#pragma warning restore 1591
        #endregion Operators
    }
}
