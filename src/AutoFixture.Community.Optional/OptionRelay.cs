using System;
using System.Linq;
using System.Reflection;
using AutoFixture.Kernel;
using Optional;

namespace AutoFixture.Community.Optional
{
    internal class OptionRelay : ISpecimenBuilder
    {
        public object Create(object request, ISpecimenContext context)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));

            var type = request as Type;
            if (type == null)
                return new NoSpecimen();

            var typeArguments = type.GetTypeInfo().GetGenericArguments();
            if (typeArguments.Length != 1 ||
                typeof(Option<>) != type.GetGenericTypeDefinition())
                return new NoSpecimen();

            var innerType = typeArguments.FirstOrDefault();
            if (innerType == null)
                return new NoSpecimen();

            var option = CreateOption(innerType, context);
            if (option == null)
                return new NoSpecimen();

            return option;
        }

        private static object CreateOption(Type resultType, ISpecimenContext context)
        {
            var result = context.Resolve(resultType);
            return result == null
                ? CreateOptionFromNone(resultType)
                : CreateOptionFromSome(resultType, result);
        }

        private static object CreateOptionFromNone(Type resultType)
        {
            var someMethod = typeof(Option)
                .GetTypeInfo().GetMethods()
                .FirstOrDefault(m => string.Equals(m.Name, nameof(Option.None), StringComparison.Ordinal) && m.IsGenericMethod && m.GetGenericArguments().Length == 1);
                
            if (someMethod == null)
                throw new ArgumentException($"Could not find suitable method {nameof(Option.Some)}");

            return someMethod
                .MakeGenericMethod(resultType)
                .Invoke(null, new object[0]);
        }
        
        private static object CreateOptionFromSome(Type resultType, object result)
        {
            var someMethod = typeof(Option)
                .GetTypeInfo().GetMethods()
                .FirstOrDefault(m => string.Equals(m.Name, nameof(Option.Some), StringComparison.Ordinal) && m.IsGenericMethod && m.GetGenericArguments().Length == 1);
                
            if (someMethod == null)
                throw new ArgumentException($"Could not find suitable method {nameof(Option.Some)}");

            return someMethod
                .MakeGenericMethod(resultType)
                .Invoke(null, new[] { result });
        }
    }
}