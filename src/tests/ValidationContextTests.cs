// These sources have been forked from https://github.com/dotnet/corefx/releases/tag/v1.1.8
// then customized by Ole Consignado in order to meet it needs.
// Original sources should be found at: https://github.com/dotnet/corefx/tree/v1.1.8/src/System.ComponentModel.Annotations
// Thanks to Microsoft for making it open source!

// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using Xunit;

namespace ComponentModel.DataAnnotations
{
    public class ValidationContextTests
    {
        [Fact]
        public static void Constructor_throws_if_passed_null_instance()
        {
            Assert.Equal("instance",
                Assert.Throws<ArgumentNullException>(() => new ValidationContext(null)).ParamName);
        }

        [Fact]
        public static void Constructor_creates_new_instance_for_one_arg_constructor()
        {
            var testDataAnnotationsDerived = new TestClass();
            AssertEx.DoesNotThrow(() => new ValidationContext(testDataAnnotationsDerived));
        }

        [Fact]
        public static void Constructor_creates_new_instance_for_two_arg_constructor()
        {
            var testDataAnnotationsDerived = new TestClass();
            AssertEx.DoesNotThrow(() => new ValidationContext(testDataAnnotationsDerived, null));
            var items = new Dictionary<object, object>();
            AssertEx.DoesNotThrow(() => new ValidationContext(testDataAnnotationsDerived, items));
        }

        [Fact]
        public static void Constructor_creates_new_instance_for_three_arg_constructor()
        {
            var testDataAnnotationsDerived = new TestClass();
            AssertEx.DoesNotThrow(() => new ValidationContext(testDataAnnotationsDerived, null, null));
            var items = new Dictionary<object, object>();
            AssertEx.DoesNotThrow(() => new ValidationContext(testDataAnnotationsDerived, null, items));
            var serviceProvider = new TestServiceProvider();
            AssertEx.DoesNotThrow(() => new ValidationContext(testDataAnnotationsDerived, serviceProvider, items));
        }

        [Fact]
        public static void ObjectInstance_and_ObjectType_return_same_instance_and_type_as_passed()
        {
            var testDataAnnotationsDerived = new TestClass();
            var validationContext = new ValidationContext(testDataAnnotationsDerived);
            Assert.Same(testDataAnnotationsDerived, validationContext.ObjectInstance);
            Assert.Equal(typeof(TestClass), validationContext.ObjectType);
        }

        [Fact]
        public static void Items_returns_new_Dictionary_with_same_keys_and_values()
        {
            var testDataAnnotationsDerived = new TestClass();
            var items = new Dictionary<object, object>();
            items.Add("testKey1", "testValue1");
            items.Add("testKey2", "testValue2");
            var validationContext = new ValidationContext(testDataAnnotationsDerived, items);
            Assert.NotSame(items, validationContext.Items);
            Assert.Equal(2, validationContext.Items.Count);
            Assert.Equal("testValue1", validationContext.Items["testKey1"]);
            Assert.Equal("testValue2", validationContext.Items["testKey2"]);
        }

        [Fact]
        public static void Can_get_and_set_MemberName_to_existent_and_non_existent_members_and_null()
        {
            var testDataAnnotationsDerived = new TestClass();
            var validationContext = new ValidationContext(testDataAnnotationsDerived);
            validationContext.MemberName = "ExistingMember";
            Assert.Equal("ExistingMember", validationContext.MemberName);
            validationContext.MemberName = "NonExistentMemberName";
            Assert.Equal("NonExistentMemberName", validationContext.MemberName);
            validationContext.MemberName = null;
            Assert.Null(validationContext.MemberName);
        }

        [Fact]
        public static void Can_get_and_set_DisplayName_to_existent_and_non_existent_members()
        {
            var testDataAnnotationsDerived = new TestClass();
            var validationContext = new ValidationContext(testDataAnnotationsDerived);
            validationContext.DisplayName = "ExistingMember";
            Assert.Equal("ExistingMember", validationContext.DisplayName);
            validationContext.DisplayName = "NonExistentDisplayName";
            Assert.Equal("NonExistentDisplayName", validationContext.DisplayName);
        }

        [Fact]
        public static void Setting_DisplayName_to_null_or_empty_throws()
        {
            var testDataAnnotationsDerived = new TestClass();
            var validationContext = new ValidationContext(testDataAnnotationsDerived);
            validationContext.DisplayName = "ExistingMember";
            Assert.Equal("ExistingMember", validationContext.DisplayName);
            validationContext.DisplayName = "NonExistentDisplayName";
            Assert.Equal("NonExistentDisplayName", validationContext.DisplayName);
            Assert.Equal("value",
                Assert.Throws<ArgumentNullException>(() => validationContext.DisplayName = null).ParamName);
            Assert.Equal("value",
                Assert.Throws<ArgumentNullException>(() => validationContext.DisplayName = string.Empty).ParamName);
        }

        // DisplayName_returns_class_name_for_unset_member_name_and_can_be_overridden()
        [Fact]
        public static void TestDisplayName()
        {
            var testDataAnnotationsDerived = new TestClass();
            var validationContext = new ValidationContext(testDataAnnotationsDerived);
            Assert.Equal("TestClass", validationContext.DisplayName);
            validationContext.DisplayName = "OverriddenDisplayName";
            Assert.Equal("OverriddenDisplayName", validationContext.DisplayName);
        }

        //  DisplayName_returns_name_from_DisplayAttribute_if_set_and_can_be_overridden
        [Fact]
        public static void TestDisplayNameDisplayAttribute()
        {
            var testDataAnnotationsDerived = new TestClass();
            var validationContext = new ValidationContext(testDataAnnotationsDerived);
            validationContext.MemberName = "DisplayNameMember";
            Assert.Equal("DisplayNameMemberDisplayName", validationContext.DisplayName);
            validationContext.DisplayName = "OverriddenDisplayName";
            Assert.Equal("OverriddenDisplayName", validationContext.DisplayName);
        }

        // DisplayName_returns_name_of_member_if_DisplayAttribute_not_set_and_can_be_overridden
        [Fact]
        public static void TestDisplayNameNoDisplayAttribute()
        {
            var testDataAnnotationsDerived = new TestClass();
            var validationContext = new ValidationContext(testDataAnnotationsDerived);
            validationContext.MemberName = "ExistingMember";
            Assert.Equal("ExistingMember", validationContext.DisplayName);
            validationContext.DisplayName = "OverriddenDisplayName";
            Assert.Equal("OverriddenDisplayName", validationContext.DisplayName);
        }
    }

    public class TestClass
    {
        [Display(Name = "DisplayNameMemberDisplayName")]
        public int DisplayNameMember { get; set; }

        public int ExistingMember { get; set; }
    }

    public class TestServiceProvider : IServiceProvider
    {
        public object GetService(Type serviceType)
        {
            return null;
        }
    }
}
