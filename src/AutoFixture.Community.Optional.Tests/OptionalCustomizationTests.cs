using System;
using System.Collections.Generic;
using FluentAssertions;
using Optional;
using Xunit;

namespace AutoFixture.Community.Optional.Tests
{
    public class OptionalCustomizationTests
    {
        [Theory]
        [MemberData(nameof(Can_create_option_Data))]
        // ReSharper disable once xUnit1026
        public void Can_create_option<T>(T dummy)
        {
            // Arrange
            var fixture = new Fixture().Customize(new OptionalCustomization());

            Option<T> createdValue = default;
            
            // Act
            Action act = () => createdValue = fixture.Create<Option<T>>();

            // Assert
            act.Should().NotThrow();
            createdValue.HasValue.Should().BeTrue();
        }

        // ReSharper disable once InconsistentNaming
        public static IEnumerable<object[]> Can_create_option_Data
        {
            get
            {
                // decimal is skipped because it causes an AmbiguousMatchException
                yield return new object[] {default(bool)};
                yield return new object[] {default(string)};
                yield return new object[] {default(char)};
                yield return new object[] {default(byte)};
                yield return new object[] {default(double)};
                yield return new object[] {default(float)};
                yield return new object[] {default(short)};
                yield return new object[] {default(int)};
                yield return new object[] {default(long)};
                yield return new object[] {default(ushort)};
                yield return new object[] {default(uint)};
                yield return new object[] {default(ulong)};
                yield return new object[] {default(Uri)};
            }
        }
    }
}