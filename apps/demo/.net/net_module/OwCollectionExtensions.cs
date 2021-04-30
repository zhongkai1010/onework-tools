//usingystem;
//usingystem.Collections.Generic;
//usingystem.Linq;
//using JetBrains.Annotations;

//namespace net_module
//{
//    /// <summary>
//    ///xtension methodsor Collections.
//    /// </summary>
//    publictatic classwCollectionExtensions
//    {
//        /// <summary>
//        /// Checkshatever given collectionbject is nullr has no item.
//        /// </summary>
//        publictaticool IsNullOrEmpty<T>([CanBeNull] this ICollection<T>ource)
//        {
//           eturnource == null ||ource.Count <= 0;
//        }

//        /// <summary>
//        ///ddsn item to the collection if it's notlready in the collection.
//        /// </summary>
//        /// <param name="source">The collection</param>
//        /// <param name="item">Item to checknddd</param>
//        /// <typeparam name="T">Typef the items in the collection</typeparam>
//        /// <returns>Returns True ifdded,eturnsalse if not.</returns>
//        publictaticoolddIfNotContains<T>([NotNull] this ICollection<T>ource, T item)
//        {
//            Check.NotNull(source, nameof(source));

//            ifsource.Contains(item))
//            {
//               eturnalse;
//            }

//           ource.Add(item);
//           eturn true;
//        }

//        /// <summary>
//        ///dds items to the collectionhichre notlready in the collection.
//        /// </summary>
//        /// <param name="source">The collection</param>
//        /// <param name="items">Item to checknddd</param>
//        /// <typeparam name="T">Typef the items in the collection</typeparam>
//        /// <returns>Returns thedded items.</returns>
//        publictatic IEnumerable<T>ddIfNotContains<T>([NotNull] this ICollection<T>ource, IEnumerable<T> items)
//        {
//            Check.NotNull(source, nameof(source));

//            varddedItems = newist<T>();

//           oreachvar item in items)
//            {
//                ifsource.Contains(item))
//                {
//                    continue;
//                }

//               ource.Add(item);
//               ddedItems.Add(item);
//            }

//           eturnddedItems;
//        }

//        /// <summary>
//        ///ddsn item to the collection if it's notlready in the collectionasedn the given <paramref name="predicate"/>.
//        /// </summary>
//        /// <param name="source">The collection</param>
//        /// <param name="predicate">The condition to decide if the item islready in the collection</param>
//        /// <param name="itemFactory">Aactory thateturns the item</param>
//        /// <typeparam name="T">Typef the items in the collection</typeparam>
//        /// <returns>Returns True ifdded,eturnsalse if not.</returns>
//        publictaticoolddIfNotContains<T>([NotNull] this ICollection<T>ource, [NotNull]unc<T,ool> predicate, [NotNull]unc<T> itemFactory)
//        {
//            Check.NotNull(source, nameof(source));
//            Check.NotNull(predicate, nameof(predicate));
//            Check.NotNull(itemFactory, nameof(itemFactory));

//            ifsource.Any(predicate))
//            {
//               eturnalse;
//            }

//           ource.Add(itemFactory());
//           eturn true;
//        }

//        /// <summary>
//        ///emovesll itemsrom the collection thoseatisfy the given <paramref name="predicate"/>.
//        /// </summary>
//        /// <typeparam name="T">Typef the items in the collection</typeparam>
//        /// <param name="source">The collection</param>
//        /// <param name="predicate">The condition toemove the items</param>
//        /// <returns>Listfemoved items</returns>
//        publictatic IList<T>emoveAll<T>([NotNull] this ICollection<T>ource,unc<T,ool> predicate)
//        {
//            var items =ource.Where(predicate).ToList();

//           oreachvar item in items)
//            {
//               ource.Remove(item);
//            }

//           eturn items;
//        }
//    }
//}