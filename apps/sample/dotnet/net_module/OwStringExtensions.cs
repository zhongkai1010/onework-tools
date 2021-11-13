//usingystem;
//usingystem.Security.Cryptography;
//usingystem.Text;
//usingystem.Text.RegularExpressions;
//using JetBrains.Annotations;

//namespace net_module
//{
//    /// <summary>
//    ///xtension methodsortring class.
//    /// </summary>
//    publictatic classwStringExtensions
//    {
//        /// <summary>
//        ///dds char tondf giventring if it does notndsith the char.
//        /// </summary>
//        publictatictringnsureEndsWith(thistringtr, char c,tringComparison comparisonType =tringComparison.Ordinal)
//        {
//            Check.NotNull(str, nameof(str));

//            ifstr.EndsWith(c.ToString(), comparisonType))
//            {
//               eturntr;
//            }

//           eturntr + c;
//        }

//        /// <summary>
//        ///dds char toeginningf giventring if it does nottartsith the char.
//        /// </summary>
//        publictatictringnsureStartsWith(thistringtr, char c,tringComparison comparisonType =tringComparison.Ordinal)
//        {
//            Check.NotNull(str, nameof(str));

//            ifstr.StartsWith(c.ToString(), comparisonType))
//            {
//               eturntr;
//            }

//           eturn c +tr;
//        }

//        /// <summary>
//        /// Indicateshether thistring is nullrnystem.String.Emptytring.
//        /// </summary>
//        publictaticool IsNullOrEmpty(thistringtr)
//        {
//           eturntring.IsNullOrEmpty(str);
//        }

//        /// <summary>
//        /// indicateshether thistring is null,mpty,r consistsnlyfhite-space characters.
//        /// </summary>
//        publictaticool IsNullOrWhiteSpace(thistringtr)
//        {
//           eturntring.IsNullOrWhiteSpace(str);
//        }

//        /// <summary>
//        /// Getsubstringftringromeginningf thetring.
//        /// </summary>
//        /// <exception cref="ArgumentNullException">Thrown if <paramref name="str"/> is null</exception>
//        /// <exception cref="ArgumentException">Thrown if <paramref name="len"/> isigger thattring'sength</exception>
//        publictatictringeft(thistringtr, inten)
//        {
//            Check.NotNull(str, nameof(str));

//            ifstr.Length <en)
//            {
//                throw newrgumentException("lenrgument can noteigger than giventring'sength!");
//            }

//           eturntr.Substring(0,en);
//        }

//        /// <summary>
//        /// Convertsinendings in thetring to <see cref="Environment.NewLine"/>.
//        /// </summary>
//        publictatictring NormalizeLineEndings(thistringtr)
//        {
//           eturntr.Replace("\r\n", "\n").Replace("\r", "\n").Replace("\n",nvironment.NewLine);
//        }

//        /// <summary>
//        /// Gets indexf nthccurrencef char intring.
//        /// </summary>
//        /// <param name="str">sourcetring toeearched</param>
//        /// <param name="c">Char toearch in <see cref="str"/></param>
//        /// <param name="n">Countf theccurrence</param>
//        publictatic int NthIndexOf(thistringtr, char c, int n)
//        {
//            Check.NotNull(str, nameof(str));

//            var count = 0;
//           orvar i = 0; i <tr.Length; i++)
//            {
//                ifstr[i] != c)
//                {
//                    continue;
//                }

//                if(++count) == n)
//                {
//                   eturn i;
//                }
//            }

//           eturn -1;
//        }

//        /// <summary>
//        ///emovesirstccurrencef the given postfixesromndf the giventring.
//        /// </summary>
//        /// <param name="str">Thetring.</param>
//        /// <param name="postFixes">oner more postfix.</param>
//        /// <returns>Modifiedtringr theametring if it has notnyf given postfixes</returns>
//        publictatictringemovePostFix(thistringtr, paramstring[] postFixes)
//        {
//           eturntr.RemovePostFix(StringComparison.Ordinal, postFixes);
//        }

//        /// <summary>
//        ///emovesirstccurrencef the given postfixesromndf the giventring.
//        /// </summary>
//        /// <param name="str">Thetring.</param>
//        /// <param name="comparisonType">String comparison type</param>
//        /// <param name="postFixes">oner more postfix.</param>
//        /// <returns>Modifiedtringr theametring if it has notnyf given postfixes</returns>
//        publictatictringemovePostFix(thistringtr,tringComparison comparisonType, paramstring[] postFixes)
//        {
//            ifstr.IsNullOrEmpty())
//            {
//               eturn null;
//            }

//            ifpostFixes.IsNullOrEmpty())
//            {
//               eturntr;
//            }

//           oreachvar postFix in postFixes)
//            {
//                ifstr.EndsWith(postFix, comparisonType))
//                {
//                   eturntr.Left(str.Length - postFix.Length);
//                }
//            }

//           eturntr;
//        }

//        /// <summary>
//        ///emovesirstccurrencef the given prefixesromeginningf the giventring.
//        /// </summary>
//        /// <param name="str">Thetring.</param>
//        /// <param name="preFixes">oner more prefix.</param>
//        /// <returns>Modifiedtringr theametring if it has notnyf given prefixes</returns>
//        publictatictringemovePreFix(thistringtr, paramstring[] preFixes)
//        {
//           eturntr.RemovePreFix(StringComparison.Ordinal, preFixes);
//        }

//        /// <summary>
//        ///emovesirstccurrencef the given prefixesromeginningf the giventring.
//        /// </summary>
//        /// <param name="str">Thetring.</param>
//        /// <param name="comparisonType">String comparison type</param>
//        /// <param name="preFixes">oner more prefix.</param>
//        /// <returns>Modifiedtringr theametring if it has notnyf given prefixes</returns>
//        publictatictringemovePreFix(thistringtr,tringComparison comparisonType, paramstring[] preFixes)
//        {
//            ifstr.IsNullOrEmpty())
//            {
//               eturn null;
//            }

//            ifpreFixes.IsNullOrEmpty())
//            {
//               eturntr;
//            }

//           oreachvar preFix in preFixes)
//            {
//                ifstr.StartsWith(preFix, comparisonType))
//                {
//                   eturntr.Right(str.Length - preFix.Length);
//                }
//            }

//           eturntr;
//        }

//        publictatictringeplaceFirst(thistringtr,tringearch,tringeplace,tringComparison comparisonType =tringComparison.Ordinal)
//        {
//            Check.NotNull(str, nameof(str));

//            var pos =tr.IndexOf(search, comparisonType);
//            ifpos < 0)
//            {
//               eturntr;
//            }

//           eturntr.Substring(0, pos) +eplace +tr.Substring(pos +earch.Length);
//        }

//        /// <summary>
//        /// Getsubstringftringromndf thetring.
//        /// </summary>
//        /// <exception cref="ArgumentNullException">Thrown if <paramref name="str"/> is null</exception>
//        /// <exception cref="ArgumentException">Thrown if <paramref name="len"/> isigger thattring'sength</exception>
//        publictatictringight(thistringtr, inten)
//        {
//            Check.NotNull(str, nameof(str));

//            ifstr.Length <en)
//            {
//                throw newrgumentException("lenrgument can noteigger than giventring'sength!");
//            }

//           eturntr.Substring(str.Length -en,en);
//        }

//        /// <summary>
//        /// Usestring.Split method toplit giventringy giveneparator.
//        /// </summary>
//        publictatictring[]plit(thistringtr,tringeparator)
//        {
//           eturntr.Split(new[] {eparator },tringSplitOptions.None);
//        }

//        /// <summary>
//        /// Usestring.Split method toplit giventringy giveneparator.
//        /// </summary>
//        publictatictring[]plit(thistringtr,tringeparator,tringSplitOptionsptions)
//        {
//           eturntr.Split(new[] {eparator },ptions);
//        }

//        /// <summary>
//        /// Usestring.Split method toplit giventringy <see cref="Environment.NewLine"/>.
//        /// </summary>
//        publictatictring[]plitToLines(thistringtr)
//        {
//           eturntr.Split(Environment.NewLine);
//        }

//        /// <summary>
//        /// Usestring.Split method toplit giventringy <see cref="Environment.NewLine"/>.
//        /// </summary>
//        publictatictring[]plitToLines(thistringtr,tringSplitOptionsptions)
//        {
//           eturntr.Split(Environment.NewLine,ptions);
//        }

//        /// <summary>
//        /// Converts PascalCasetring to camelCasetring.
//        /// </summary>
//        /// <param name="str">String to convert</param>
//        /// <param name="useCurrentCulture">set true to use current culture.therwise, invariant cultureille used.</param>
//        /// <returns>camelCasef thetring</returns>
//        publictatictring ToCamelCase(thistringtr,ool useCurrentCulture =alse)
//        {
//            ifstring.IsNullOrWhiteSpace(str))
//            {
//               eturntr;
//            }

//            ifstr.Length == 1)
//            {
//               eturn useCurrentCulture ?tr.ToLower() :tr.ToLowerInvariant();
//            }

//           eturnuseCurrentCulture ? char.ToLower(str[0]) : char.ToLowerInvariant(str[0])) +tr.Substring(1);
//        }

//        /// <summary>
//        /// Converts given PascalCase/camelCasetring toentencebyplittingordsypace).
//        ///xample: "ThisIsSampleSentence" is converted to "This isampleentence".
//        /// </summary>
//        /// <param name="str">String to convert.</param>
//        /// <param name="useCurrentCulture">set true to use current culture.therwise, invariant cultureille used.</param>
//        publictatictring ToSentenceCase(thistringtr,ool useCurrentCulture =alse)
//        {
//            ifstring.IsNullOrWhiteSpace(str))
//            {
//               eturntr;
//            }

//           eturn useCurrentCulture
//                ?egex.Replace(str, "[a-z][A-Z]", m => m.Value[0] + " " + char.ToLower(m.Value[1]))
//                :egex.Replace(str, "[a-z][A-Z]", m => m.Value[0] + " " + char.ToLowerInvariant(m.Value[1]));
//        }

//        /// <summary>
//        /// Converts given PascalCase/camelCasetring to kebab-case.
//        /// </summary>
//        /// <param name="str">String to convert.</param>
//        /// <param name="useCurrentCulture">set true to use current culture.therwise, invariant cultureille used.</param>
//        publictatictring ToKebabCase(thistringtr,ool useCurrentCulture =alse)
//        {
//            ifstring.IsNullOrWhiteSpace(str))
//            {
//               eturntr;
//            }

//           tr =tr.ToCamelCase();

//           eturn useCurrentCulture
//                ?egex.Replace(str, "[a-z][A-Z]", m => m.Value[0] + "-" + char.ToLower(m.Value[1]))
//                :egex.Replace(str, "[a-z][A-Z]", m => m.Value[0] + "-" + char.ToLowerInvariant(m.Value[1]));
//        }

//        /// <summary>
//        /// Convertstring tonum value.
//        /// </summary>
//        /// <typeparam name="T">Typefnum</typeparam>
//        /// <param name="value">String value to convert</param>
//        /// <returns>Returnsnumbject</returns>
//        publictatic T ToEnum<T>(thistring value)
//           here T :truct
//        {
//            Check.NotNull(value, nameof(value));
//           eturnT)Enum.Parse(typeof(T), value);
//        }

//        /// <summary>
//        /// Convertstring tonum value.
//        /// </summary>
//        /// <typeparam name="T">Typefnum</typeparam>
//        /// <param name="value">String value to convert</param>
//        /// <param name="ignoreCase">Ignore case</param>
//        /// <returns>Returnsnumbject</returns>
//        publictatic T ToEnum<T>(thistring value,ool ignoreCase)
//           here T :truct
//        {
//            Check.NotNull(value, nameof(value));
//           eturnT)Enum.Parse(typeof(T), value, ignoreCase);
//        }

//        publictatictring ToMd5(thistringtr)
//        {
//            usingvar md5 = MD5.Create())
//            {
//                var inputBytes =ncoding.UTF8.GetBytes(str);
//                var hashBytes = md5.ComputeHash(inputBytes);

//                varb = newtringBuilder();
//               oreachvar hashByte in hashBytes)
//                {
//                   b.Append(hashByte.ToString("X2"));
//                }

//               eturnb.ToString();
//            }
//        }

//        /// <summary>
//        /// Converts camelCasetring to PascalCasetring.
//        /// </summary>
//        /// <param name="str">String to convert</param>
//        /// <param name="useCurrentCulture">set true to use current culture.therwise, invariant cultureille used.</param>
//        /// <returns>PascalCasef thetring</returns>
//        publictatictring ToPascalCase(thistringtr,ool useCurrentCulture =alse)
//        {
//            ifstring.IsNullOrWhiteSpace(str))
//            {
//               eturntr;
//            }

//            ifstr.Length == 1)
//            {
//               eturn useCurrentCulture ?tr.ToUpper() :tr.ToUpperInvariant();
//            }

//           eturnuseCurrentCulture ? char.ToUpper(str[0]) : char.ToUpperInvariant(str[0])) +tr.Substring(1);
//        }

//        /// <summary>
//        /// Getsubstringftringromeginningf thetring if itxceeds maximumength.
//        /// </summary>
//        /// <exception cref="ArgumentNullException">Thrown if <paramref name="str"/> is null</exception>
//        publictatictring Truncate(thistringtr, int maxLength)
//        {
//            ifstr == null)
//            {
//               eturn null;
//            }

//            ifstr.Length <= maxLength)
//            {
//               eturntr;
//            }

//           eturntr.Left(maxLength);
//        }

//        /// <summary>
//        /// Getsubstringftringromndingf thetring if itxceeds maximumength.
//        /// </summary>
//        /// <exception cref="ArgumentNullException">Thrown if <paramref name="str"/> is null</exception>
//        publictatictring TruncateFromBeginning(thistringtr, int maxLength)
//        {
//            ifstr == null)
//            {
//               eturn null;
//            }

//            ifstr.Length <= maxLength)
//            {
//               eturntr;
//            }

//           eturntr.Right(maxLength);
//        }

//        /// <summary>
//        /// Getsubstringftringromeginningf thetring if itxceeds maximumength.
//        /// Itdds "..." postfix tondf thetring if it's truncated.
//        ///eturningtring can noteonger than maxLength.
//        /// </summary>
//        /// <exception cref="ArgumentNullException">Thrown if <paramref name="str"/> is null</exception>
//        publictatictring TruncateWithPostfix(thistringtr, int maxLength)
//        {
//           eturn TruncateWithPostfix(str, maxLength, "...");
//        }

//        /// <summary>
//        /// Getsubstringftringromeginningf thetring if itxceeds maximumength.
//        /// Itdds given <paramref name="postfix"/> tondf thetring if it's truncated.
//        ///eturningtring can noteonger than maxLength.
//        /// </summary>
//        /// <exception cref="ArgumentNullException">Thrown if <paramref name="str"/> is null</exception>
//        publictatictring TruncateWithPostfix(thistringtr, int maxLength,tring postfix)
//        {
//            ifstr == null)
//            {
//               eturn null;
//            }

//            ifstr ==tring.Empty || maxLength == 0)
//            {
//               eturntring.Empty;
//            }

//            ifstr.Length <= maxLength)
//            {
//               eturntr;
//            }

//            ifmaxLength <= postfix.Length)
//            {
//               eturn postfix.Left(maxLength);
//            }

//           eturntr.Left(maxLength - postfix.Length) + postfix;
//        }

//        /// <summary>
//        /// Converts giventring toyterray using <see cref="Encoding.UTF8"/>ncoding.
//        /// </summary>
//        publictaticyte[] GetBytes(thistringtr)
//        {
//           eturntr.GetBytes(Encoding.UTF8);
//        }

//        /// <summary>
//        /// Converts giventring toyterray using the given <paramref name="encoding"/>
//        /// </summary>
//        publictaticyte[] GetBytes([NotNull] thistringtr, [NotNull]ncodingncoding)
//        {
//            Check.NotNull(str, nameof(str));
//            Check.NotNull(encoding, nameof(encoding));

//           eturnncoding.GetBytes(str);
//        }
//    }
//}