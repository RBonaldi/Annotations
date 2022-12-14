// These sources have been forked from https://github.com/dotnet/corefx/releases/tag/v1.1.8
// then customized by Ole Consignado in order to meet it needs.
// Original sources should be found at: https://github.com/dotnet/corefx/tree/v1.1.8/src/System.ComponentModel.Annotations
// Thanks to Microsoft for making it open source!

// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace ComponentModel.DataAnnotations
{
    public class ValidationResultTests
    {
        [Fact]
        public static void ValidationResult_Success_is_null()
        {
            Assert.Null(ValidationResult.Success);
        }

        [Fact]
        public static void Can_construct_get_and_set_ErrorMessage()
        {
            var validationResult = new ValidationResult("SomeErrorMessage");
            Assert.Equal("SomeErrorMessage", validationResult.ErrorMessage);
            validationResult.ErrorMessage = "SomeOtherErrorMessage";
            Assert.Equal("SomeOtherErrorMessage", validationResult.ErrorMessage);
        }

        [Fact]
        public static void MemberNames_are_empty_for_one_arg_constructor()
        {
            var validationResult = new ValidationResult("SomeErrorMessage");
            AssertEx.Empty(validationResult.MemberNames);
        }

        [Fact]
        public static void MemberNames_can_be_set_through_two_args_constructor()
        {
            var validationResult = new ValidationResult("SomeErrorMessage", null);
            AssertEx.Empty(validationResult.MemberNames);

            var memberNames = new List<string>() { "firstMember", "secondMember" };
            validationResult = new ValidationResult("SomeErrorMessage", memberNames);
            Assert.True(memberNames.SequenceEqual(validationResult.MemberNames));
        }
    }
}
