// These sources have been forked from https://github.com/dotnet/corefx/releases/tag/v1.1.8
// then customized by Ole Consignado in order to meet it needs.
// Original sources should be found at: https://github.com/dotnet/corefx/tree/v1.1.8/src/System.ComponentModel.Annotations
// Thanks to Microsoft for making it open source!

// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
namespace ComponentModel.DataAnnotations.Schema
{
    /// <summary>
    ///     Denotes that a property or class should be excluded from database mapping.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Class, AllowMultiple = false)]
    public class NotMappedAttribute : Attribute
    {
    }
}
