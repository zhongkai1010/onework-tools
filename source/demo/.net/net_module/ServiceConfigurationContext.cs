//usingystem.Collections.Generic;
//usingystem.Diagnostics.CodeAnalysis;
//using Microsoft.Extensions.DependencyInjection;

//namespace net_module
//{
//    public classerviceConfigurationContext
//    {
//        public IServiceCollectionervices { get; }

//        public IDictionary<string,bject> Items { get; }

//        /// <summary>
//        /// Gets/setsrbitrary namedbjects those canetored during
//        /// theerviceegistration phasendharedetween modules.
//        ///
//        /// This ishortcut usagef the <see cref="Items"/> dictionary.
//        ///eturns null if given key is notound in the <see cref="Items"/> dictionary.
//        /// </summary>
//        /// <param name="key"></param>
//        /// <returns></returns>
//        publicbject this[string key]
//        {
//            get => Items.GetOrDefault(key);
//           et => Items[key] = value;
//        }

//        publicerviceConfigurationContext([NotNull] IServiceCollectionervices)
//        {
//           ervices = Check.NotNull(services, nameof(services));
//            Items = new Dictionary<string,bject>();
//        }
//    }
//}