// These sources have been forked from https://github.com/dotnet/corefx/releases/tag/v1.1.8
// then customized by Ole Consignado in order to meet it needs.
// Original sources should be found at: https://github.com/dotnet/corefx/tree/v1.1.8/src/System.ComponentModel.Annotations
// Thanks to Microsoft for making it open source!

// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Otc;
using System;
using System.Globalization;

namespace ComponentModel.DataAnnotations.Schema
{
    /// <summary>
    ///     Specifies the database column that a property is mapped to.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    public class ColumnAttribute : Attribute
    {
        private readonly string _name;
        private int _order = -1;
        private string _typeName;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ColumnAttribute" /> class.
        /// </summary>
        public ColumnAttribute()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ColumnAttribute" /> class.
        /// </summary>
        /// <param name="name">The name of the column the property is mapped to.</param>
        public ColumnAttribute(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture,
                    SR.ArgumentIsNullOrWhitespace, "name"));
            }

            _name = name;
        }

        /// <summary>
        ///     The name of the column the property is mapped to.
        /// </summary>
        public string Name
        {
            get { return _name; }
        }

        /// <summary>
        ///     The zero-based order of the column the property is mapped to.
        /// </summary>
        public int Order
        {
            get { return _order; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value));
                }

                _order = value;
            }
        }

        /// <summary>
        ///     The database provider specific data type of the column the property is mapped to.
        /// </summary>
        public string TypeName
        {
            get { return _typeName; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(string.Format(CultureInfo.CurrentCulture,
                        SR.ArgumentIsNullOrWhitespace, "value"));
                }

                _typeName = value;
            }
        }
    }
}
