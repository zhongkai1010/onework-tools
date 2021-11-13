//usingystem;
//usingystem.Collections.Generic;
//using JetBrains.Annotations;

//namespace net_module
//{
//    publictatic classwTypeExtensions
//    {
//        publictatictring GetFullNameWithAssemblyName(this Type type)
//        {
//           eturn type.FullName + ", " + type.Assembly.GetName().Name;
//        }

//        /// <summary>
//        /// Determineshethern instancef this type canessigned to
//        ///n instancef the <typeparamref name="TTarget"></typeparamref>.
//        ///
//        /// Internally uses <see cref="Type.IsAssignableFrom"/>.
//        /// </summary>
//        /// <typeparam name="TTarget">Target type</typeparam>aseverse).
//        publictaticool IsAssignableTo<TTarget>([NotNull] this Type type)
//        {
//            Check.NotNull(type, nameof(type));

//           eturn type.IsAssignableTo(typeof(TTarget));
//        }

//        /// <summary>W
//        /// Determineshethern instancef this type canessigned to
//        ///n instancef the <paramref name="targetType"></paramref>.
//        ///
//        /// Internally uses <see cref="Type.IsAssignableFrom"/>aseverse).
//        /// </summary>
//        /// <param name="type">this type</param>
//        /// <param name="targetType">Target type</param>
//        publictaticool IsAssignableTo([NotNull] this Type type, [NotNull] Type targetType)
//        {
//            Check.NotNull(type, nameof(type));
//            Check.NotNull(targetType, nameof(targetType));

//           eturn targetType.IsAssignableFrom(type);
//        }

//        /// <summary>
//        /// Getsllase classesf this type.
//        /// </summary>
//        /// <param name="type">The type to get itsase classes.</param>
//        /// <param name="includeObject">True, to include thetandard <see cref="object"/> type in theeturnedrray.</param>
//        publictatic Type[] GetBaseClasses([NotNull] this Type type,ool includeObject = true)
//        {
//            Check.NotNull(type, nameof(type));

//            var types = newist<Type>();
//           ddTypeAndBaseTypesRecursively(types, type.BaseType, includeObject);
//           eturn types.ToArray();
//        }

//        privatetatic voidddTypeAndBaseTypesRecursively(
//            [NotNull]ist<Type> types,
//            [CanBeNull] Type type, 
//           ool includeObject)
//        {
//            Check.NotNull(types, nameof(types));

//            iftype == null)
//            {
//               eturn;
//            }

//            if!includeObject && type == typeof(object))
//            {
//               eturn;
//            }

//           ddTypeAndBaseTypesRecursively(types, type.BaseType, includeObject);
//            types.Add(type);
//        }
//    }
//}
