using System;
using AutoFixture.Community.Optional;

// ReSharper disable once CheckNamespace
namespace AutoFixture
{
  /// <inheritdoc />
  /// <summary>
  /// A customization that enables creating specimens of type <see cref="T:Optional.Option" />.
  /// </summary>
  public class OptionalCustomization : ICustomization
  {
    public void Customize(IFixture fixture)
    {
      if (fixture == null) throw new ArgumentNullException(nameof(fixture));
      
      fixture.Customizations.Add(new OptionRelay());
    }
  }
}