using System;
using System.Collections;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security;
using #Nk;

namespace SchemaExplorer
{
	// Token: 0x020000A2 RID: 162
	public class PropertyComparer : IComparer, IEqualityComparer
	{
		// Token: 0x06000596 RID: 1430 RVA: 0x00017C18 File Offset: 0x00016C18
		public PropertyComparer(string orderByClause)
		{
			this.#g1c(orderByClause);
		}

		// Token: 0x06000597 RID: 1431 RVA: 0x00017C34 File Offset: 0x00016C34
		public PropertyComparer(string propertyName, ListSortDirection sortDirection)
		{
			this.#f1c = new SortExpression[]
			{
				new SortExpression(propertyName, sortDirection)
			};
		}

		// Token: 0x06000598 RID: 1432 RVA: 0x00017C64 File Offset: 0x00016C64
		public PropertyComparer(SortExpression[] sortExpressions)
		{
			this.#f1c = sortExpressions;
		}

		// Token: 0x17000192 RID: 402
		// (get) Token: 0x06000599 RID: 1433 RVA: 0x00017C80 File Offset: 0x00016C80
		// (set) Token: 0x0600059A RID: 1434 RVA: 0x00017C88 File Offset: 0x00016C88
		public SortExpression[] SortExpressions
		{
			get
			{
				return this.#f1c;
			}
			set
			{
				this.#f1c = value;
			}
		}

		// Token: 0x0600059B RID: 1435 RVA: 0x00017C94 File Offset: 0x00016C94
		public int Compare(object a, object b)
		{
			int i = 0;
			while (i < this.SortExpressions.Length)
			{
				if (this.SortExpressions[i].PropertyDescriptor == null)
				{
					PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(a);
					this.SortExpressions[i].PropertyDescriptor = properties.Find(this.SortExpressions[i].PropertyName, true);
				}
				object propertyValue = this.SortExpressions[i].GetPropertyValue(a);
				object propertyValue2 = this.SortExpressions[i].GetPropertyValue(b);
				if (!(propertyValue is IComparable))
				{
					throw new ArgumentException(#Mk.#Lk(12634));
				}
				IComparable comparable = (IComparable)propertyValue;
				int num = comparable.CompareTo(propertyValue2);
				if (num != 0)
				{
					if (this.SortExpressions[i].SortDirection == ListSortDirection.Ascending)
					{
						return num;
					}
					return this.#i1c(num);
				}
				else
				{
					i++;
				}
			}
			return 0;
		}

		// Token: 0x0600059C RID: 1436 RVA: 0x00017D74 File Offset: 0x00016D74
		private void #g1c(string #h1c)
		{
			string[] array = #h1c.Split(new char[]
			{
				','
			});
			this.#f1c = new SortExpression[array.Length];
			for (int i = 0; i < array.Length; i++)
			{
				string[] array2 = array[i].Trim().Split(new char[]
				{
					' '
				});
				this.#f1c[i].PropertyName = array2[0].Trim();
				if (array2.Length == 2 && (array2[1].Trim().ToUpperInvariant() == #Mk.#Lk(12691) || array2[1].Trim().ToUpperInvariant() == #Mk.#Lk(12700)))
				{
					this.#f1c[i].SortDirection = ListSortDirection.Descending;
				}
				else
				{
					this.#f1c[i].SortDirection = ListSortDirection.Ascending;
				}
			}
		}

		// Token: 0x0600059D RID: 1437 RVA: 0x00017E50 File Offset: 0x00016E50
		private int #i1c(int #Do)
		{
			switch (#Do)
			{
			case -1:
				return 1;
			case 0:
				return 0;
			case 1:
				return -1;
			default:
				throw new Exception(#Mk.#Lk(12717));
			}
		}

		// Token: 0x0600059E RID: 1438 RVA: 0x00017E80 File Offset: 0x00016E80
		public bool Equals(object x, object y)
		{
			return this.Compare(x, y) == 0;
		}

		// Token: 0x0600059F RID: 1439 RVA: 0x00017E90 File Offset: 0x00016E90
		public int GetHashCode(object obj)
		{
			int num = 7381;
			for (int i = 0; i < this.SortExpressions.Length; i++)
			{
				if (this.SortExpressions[i].PropertyDescriptor == null)
				{
					PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(obj);
					this.SortExpressions[i].PropertyDescriptor = properties.Find(this.SortExpressions[i].PropertyName, true);
				}
				object propertyValue = this.SortExpressions[i].GetPropertyValue(obj);
				num = ((num << 5) + num ^ ((propertyValue != null) ? propertyValue.GetHashCode() : 0));
			}
			return num;
		}

		// Token: 0x060005A0 RID: 1440 RVA: 0x00017F24 File Offset: 0x00016F24
		// Note: this type is marked as 'beforefieldinit'.
		static PropertyComparer()
		{
			bool flag = false;
			Assembly executingAssembly = Assembly.GetExecutingAssembly();
			if (PropertyComparer.StrongNameSignatureVerificationEx(executingAssembly.Location, true, out flag) && flag && executingAssembly.FullName.EndsWith(#Mk.#Lk(774)))
			{
				return;
			}
			throw new SecurityException(#Mk.#Lk(799));
		}

		// Token: 0x060005A1 RID: 1441
		[DllImport("mscorwks.dll", CharSet = CharSet.Unicode)]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool StrongNameSignatureVerificationEx([MarshalAs(UnmanagedType.LPWStr)] string, [MarshalAs(UnmanagedType.Bool)] bool, [MarshalAs(UnmanagedType.Bool)] out bool);

		// Token: 0x0400021C RID: 540
		private SortExpression[] #f1c = new SortExpression[0];
	}
}
