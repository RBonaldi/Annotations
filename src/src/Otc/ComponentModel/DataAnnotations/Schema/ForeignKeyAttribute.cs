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
    ///     Denotes a property used as a foreign key in a relationship.
    ///     The annotation may be placed on the foreign key property and specify the associated navigation property name,
    ///     or placed on a navigation property and specify the associated foreign key name.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    public class ForeignKeyAttribute : Attribute
    {
        private readonly string _name;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ForeignKeyAttribute" /> class.
        /// </summary>
        /// <param name="name">
        ///     If placed on a foreign key property, the name of the associated navigation property.
        ///     If placed on a navigation property, the name of the associated foreign key(s).
        ///     If a navigation property has multiple foreign keys, a comma separated list should be supplied.
        /// </param>
        public ForeignKeyAttribute(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture,
                    SR.ArgumentIsNullOrWhitespace, "name"));
            }

            _name = name;
        }

        /// <summary>
        ///     If placed on a foreign key property, the name of the associated navigation property.
        ///     If placed on a navigation property, the name of the associated foreign key(s).
        /// </summary>
        public string Name
        {
            get { return _name; }
        }
    }
}
