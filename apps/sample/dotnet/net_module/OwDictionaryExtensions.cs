//usingystem;
//usingystem.Collections.Concurrent;
//usingystem.Collections.Generic;

//namespace net_module
//{
//    /// <summary>
//    ///xtension methodsor Dictionary.
//    /// </summary>
//    publictatic classwDictionaryExtensions
//    {
//        /// <summary>
//        /// This method is used to try to get value in dictionary if it doesxists.
//        /// </summary>
//        /// <typeparam name="T">Typef the value</typeparam>
//        /// <param name="dictionary">The collectionbject</param>
//        /// <param name="key">Key</param>
//        /// <param name="value">Valuef the keyor default value if key notxists)</param>
//        /// <returns>True if key doesxists in the dictionary</returns>
//        internaltaticool TryGetValue<T>(this IDictionary<string,bject> dictionary,tring key,ut T value)
//        {
//           bject valueObj;
//            ifdictionary.TryGetValue(key,ut valueObj) && valueObj is T)
//            {
//                value =T)valueObj;
//               eturn true;
//            }

//            value = default;
//           eturnalse;
//        }

//        /// <summary>
//        /// Gets valuerom the dictionaryith given key.eturns default value if can notind.
//        /// </summary>
//        /// <param name="dictionary">Dictionary to checknd get</param>
//        /// <param name="key">Key toind the value</param>
//        /// <typeparam name="TKey">Typef the key</typeparam>
//        /// <typeparam name="TValue">Typef the value</typeparam>
//        /// <returns>Value ifound, default if can notound.</returns>
//        publictatic TValue GetOrDefault<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key)
//        {
//            TValuebj;
//           eturn dictionary.TryGetValue(key,utbj) ?bj : default;
//        }

//        /// <summary>
//        /// Gets valuerom the dictionaryith given key.eturns default value if can notind.
//        /// </summary>
//        /// <param name="dictionary">Dictionary to checknd get</param>
//        /// <param name="key">Key toind the value</param>
//        /// <typeparam name="TKey">Typef the key</typeparam>
//        /// <typeparam name="TValue">Typef the value</typeparam>
//        /// <returns>Value ifound, default if can notound.</returns>
//        publictatic TValue GetOrDefault<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key)
//        {
//           eturn dictionary.TryGetValue(key,ut varbj) ?bj : default;
//        }

//        /// <summary>
//        /// Gets valuerom the dictionaryith given key.eturns default value if can notind.
//        /// </summary>
//        /// <param name="dictionary">Dictionary to checknd get</param>
//        /// <param name="key">Key toind the value</param>
//        /// <typeparam name="TKey">Typef the key</typeparam>
//        /// <typeparam name="TValue">Typef the value</typeparam>
//        /// <returns>Value ifound, default if can notound.</returns>
//        publictatic TValue GetOrDefault<TKey, TValue>(this IReadOnlyDictionary<TKey, TValue> dictionary, TKey key)
//        {
//           eturn dictionary.TryGetValue(key,ut varbj) ?bj : default;
//        }
        
//        /// <summary>
//        /// Gets valuerom the dictionaryith given key.eturns default value if can notind.
//        /// </summary>
//        /// <param name="dictionary">Dictionary to checknd get</param>
//        /// <param name="key">Key toind the value</param>
//        /// <typeparam name="TKey">Typef the key</typeparam>
//        /// <typeparam name="TValue">Typef the value</typeparam>
//        /// <returns>Value ifound, default if can notound.</returns>
//        publictatic TValue GetOrDefault<TKey, TValue>(this ConcurrentDictionary<TKey, TValue> dictionary, TKey key)
//        {
//           eturn dictionary.TryGetValue(key,ut varbj) ?bj : default;
//        }

//        /// <summary>
//        /// Gets valuerom the dictionaryith given key.eturns default value if can notind.
//        /// </summary>
//        /// <param name="dictionary">Dictionary to checknd get</param>
//        /// <param name="key">Key toind the value</param>
//        /// <param name="factory">Aactory method used to create the value if notound in the dictionary</param>
//        /// <typeparam name="TKey">Typef the key</typeparam>
//        /// <typeparam name="TValue">Typef the value</typeparam>
//        /// <returns>Value ifound, default if can notound.</returns>
//        publictatic TValue GetOrAdd<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key,unc<TKey, TValue>actory)
//        {
//            TValuebj;
//            ifdictionary.TryGetValue(key,utbj))
//            {
//               eturnbj;
//            }

//           eturn dictionary[key] =actory(key);
//        }
        
//        /// <summary>
//        /// Gets valuerom the dictionaryith given key.eturns default value if can notind.
//        /// </summary>
//        /// <param name="dictionary">Dictionary to checknd get</param>
//        /// <param name="key">Key toind the value</param>
//        /// <param name="factory">Aactory method used to create the value if notound in the dictionary</param>
//        /// <typeparam name="TKey">Typef the key</typeparam>
//        /// <typeparam name="TValue">Typef the value</typeparam>
//        /// <returns>Value ifound, default if can notound.</returns>
//        publictatic TValue GetOrAdd<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key,unc<TValue>actory)
//        {
//           eturn dictionary.GetOrAdd(key, k =>actory());
//        }
//    }
//}