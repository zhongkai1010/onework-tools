using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;
using #Nk;

namespace #cTc
{
	// Token: 0x02000037 RID: 55
	[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
	[DebuggerNonUserCode]
	[CompilerGenerated]
	internal sealed class #Mk
	{
		// Token: 0x0600028A RID: 650 RVA: 0x00011E24 File Offset: 0x00010E24
		internal #Mk()
		{
		}

		// Token: 0x17000076 RID: 118
		// (get) Token: 0x0600028B RID: 651 RVA: 0x00011E2C File Offset: 0x00010E2C
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static ResourceManager ResourceManager
		{
			get
			{
				if (#Mk.#9h == null)
				{
					ResourceManager resourceManager = new ResourceManager(#Mk.#Lk(4466), typeof(#Mk).Assembly);
					#Mk.#9h = resourceManager;
				}
				return #Mk.#9h;
			}
		}

		// Token: 0x17000077 RID: 119
		// (get) Token: 0x0600028C RID: 652 RVA: 0x00011E6C File Offset: 0x00010E6C
		// (set) Token: 0x0600028D RID: 653 RVA: 0x00011E74 File Offset: 0x00010E74
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static CultureInfo Culture
		{
			get
			{
				return #Mk.#ai;
			}
			set
			{
				#Mk.#ai = value;
			}
		}

		// Token: 0x17000078 RID: 120
		// (get) Token: 0x0600028E RID: 654 RVA: 0x00011E7C File Offset: 0x00010E7C
		internal static string AccessConnectionUIControl_BrowseFileDefaultExt
		{
			get
			{
				return #Mk.ResourceManager.GetString(#Mk.#Lk(4519), #Mk.#ai);
			}
		}

		// Token: 0x17000079 RID: 121
		// (get) Token: 0x0600028F RID: 655 RVA: 0x00011E98 File Offset: 0x00010E98
		internal static string AccessConnectionUIControl_BrowseFileFilter
		{
			get
			{
				return #Mk.ResourceManager.GetString(#Mk.#Lk(4584), #Mk.#ai);
			}
		}

		// Token: 0x1700007A RID: 122
		// (get) Token: 0x06000290 RID: 656 RVA: 0x00011EB4 File Offset: 0x00010EB4
		internal static string AccessConnectionUIControl_BrowseFileTitle
		{
			get
			{
				return #Mk.ResourceManager.GetString(#Mk.#Lk(4641), #Mk.#ai);
			}
		}

		// Token: 0x1700007B RID: 123
		// (get) Token: 0x06000291 RID: 657 RVA: 0x00011ED0 File Offset: 0x00010ED0
		internal static string AccessConnectionUIControl_InvalidConnectionProperties
		{
			get
			{
				return #Mk.ResourceManager.GetString(#Mk.#Lk(4698), #Mk.#ai);
			}
		}

		// Token: 0x1700007C RID: 124
		// (get) Token: 0x06000292 RID: 658 RVA: 0x00011EEC File Offset: 0x00010EEC
		internal static string AdoDotNetConnectionProperties_NoProperties
		{
			get
			{
				return #Mk.ResourceManager.GetString(#Mk.#Lk(4771), #Mk.#ai);
			}
		}

		// Token: 0x1700007D RID: 125
		// (get) Token: 0x06000293 RID: 659 RVA: 0x00011F08 File Offset: 0x00010F08
		internal static string DataConnectionAdvancedDialog_Add
		{
			get
			{
				return #Mk.ResourceManager.GetString(#Mk.#Lk(4828), #Mk.#ai);
			}
		}

		// Token: 0x1700007E RID: 126
		// (get) Token: 0x06000294 RID: 660 RVA: 0x00011F24 File Offset: 0x00010F24
		internal static string DataConnectionAdvancedDialog_Description
		{
			get
			{
				return #Mk.ResourceManager.GetString(#Mk.#Lk(4873), #Mk.#ai);
			}
		}

		// Token: 0x1700007F RID: 127
		// (get) Token: 0x06000295 RID: 661 RVA: 0x00011F40 File Offset: 0x00010F40
		internal static string DataConnectionAdvancedDialog_Remove
		{
			get
			{
				return #Mk.ResourceManager.GetString(#Mk.#Lk(4930), #Mk.#ai);
			}
		}

		// Token: 0x17000080 RID: 128
		// (get) Token: 0x06000296 RID: 662 RVA: 0x00011F5C File Offset: 0x00010F5C
		internal static string DataConnectionAdvancedDialog_Reset
		{
			get
			{
				return #Mk.ResourceManager.GetString(#Mk.#Lk(4979), #Mk.#ai);
			}
		}

		// Token: 0x17000081 RID: 129
		// (get) Token: 0x06000297 RID: 663 RVA: 0x00011F78 File Offset: 0x00010F78
		internal static string DataConnectionDialog_CannotChangeSingleDataProvider
		{
			get
			{
				return #Mk.ResourceManager.GetString(#Mk.#Lk(5028), #Mk.#ai);
			}
		}

		// Token: 0x17000082 RID: 130
		// (get) Token: 0x06000298 RID: 664 RVA: 0x00011F94 File Offset: 0x00010F94
		internal static string DataConnectionDialog_CannotChangeSingleDataSource
		{
			get
			{
				return #Mk.ResourceManager.GetString(#Mk.#Lk(5097), #Mk.#ai);
			}
		}

		// Token: 0x17000083 RID: 131
		// (get) Token: 0x06000299 RID: 665 RVA: 0x00011FB0 File Offset: 0x00010FB0
		internal static string DataConnectionDialog_CannotModifyState
		{
			get
			{
				return #Mk.ResourceManager.GetString(#Mk.#Lk(5166), #Mk.#ai);
			}
		}

		// Token: 0x17000084 RID: 132
		// (get) Token: 0x0600029A RID: 666 RVA: 0x00011FCC File Offset: 0x00010FCC
		internal static string DataConnectionDialog_ChangeDataSourceTitle
		{
			get
			{
				return #Mk.ResourceManager.GetString(#Mk.#Lk(5219), #Mk.#ai);
			}
		}

		// Token: 0x17000085 RID: 133
		// (get) Token: 0x0600029B RID: 667 RVA: 0x00011FE8 File Offset: 0x00010FE8
		internal static string DataConnectionDialog_DataSourceNoAssociation
		{
			get
			{
				return #Mk.ResourceManager.GetString(#Mk.#Lk(5276), #Mk.#ai);
			}
		}

		// Token: 0x17000086 RID: 134
		// (get) Token: 0x0600029C RID: 668 RVA: 0x00012004 File Offset: 0x00011004
		internal static string DataConnectionDialog_DataSourceNotFound
		{
			get
			{
				return #Mk.ResourceManager.GetString(#Mk.#Lk(5337), #Mk.#ai);
			}
		}

		// Token: 0x17000087 RID: 135
		// (get) Token: 0x0600029D RID: 669 RVA: 0x00012020 File Offset: 0x00011020
		internal static string DataConnectionDialog_DataSourceWithShortProvider
		{
			get
			{
				return #Mk.ResourceManager.GetString(#Mk.#Lk(5390), #Mk.#ai);
			}
		}

		// Token: 0x17000088 RID: 136
		// (get) Token: 0x0600029E RID: 670 RVA: 0x0001203C File Offset: 0x0001103C
		internal static string DataConnectionDialog_NoDataProviderSelected
		{
			get
			{
				return #Mk.ResourceManager.GetString(#Mk.#Lk(5455), #Mk.#ai);
			}
		}

		// Token: 0x17000089 RID: 137
		// (get) Token: 0x0600029F RID: 671 RVA: 0x00012058 File Offset: 0x00011058
		internal static string DataConnectionDialog_NoDataProvidersForDataSource
		{
			get
			{
				return #Mk.ResourceManager.GetString(#Mk.#Lk(5516), #Mk.#ai);
			}
		}

		// Token: 0x1700008A RID: 138
		// (get) Token: 0x060002A0 RID: 672 RVA: 0x00012074 File Offset: 0x00011074
		internal static string DataConnectionDialog_NoDataSourcesAvailable
		{
			get
			{
				return #Mk.ResourceManager.GetString(#Mk.#Lk(5585), #Mk.#ai);
			}
		}

		// Token: 0x1700008B RID: 139
		// (get) Token: 0x060002A1 RID: 673 RVA: 0x00012090 File Offset: 0x00011090
		internal static string DataConnectionDialog_NoDataSourceSelected
		{
			get
			{
				return #Mk.ResourceManager.GetString(#Mk.#Lk(5646), #Mk.#ai);
			}
		}

		// Token: 0x1700008C RID: 140
		// (get) Token: 0x060002A2 RID: 674 RVA: 0x000120AC File Offset: 0x000110AC
		internal static string DataConnectionDialog_NoHelpAvailable
		{
			get
			{
				return #Mk.ResourceManager.GetString(#Mk.#Lk(5703), #Mk.#ai);
			}
		}

		// Token: 0x1700008D RID: 141
		// (get) Token: 0x060002A3 RID: 675 RVA: 0x000120C8 File Offset: 0x000110C8
		internal static string DataConnectionDialog_ShowDialogNotSupported
		{
			get
			{
				return #Mk.ResourceManager.GetString(#Mk.#Lk(5752), #Mk.#ai);
			}
		}

		// Token: 0x1700008E RID: 142
		// (get) Token: 0x060002A4 RID: 676 RVA: 0x000120E4 File Offset: 0x000110E4
		internal static string DataConnectionDialog_TestConnectionSucceeded
		{
			get
			{
				return #Mk.ResourceManager.GetString(#Mk.#Lk(5813), #Mk.#ai);
			}
		}

		// Token: 0x1700008F RID: 143
		// (get) Token: 0x060002A5 RID: 677 RVA: 0x00012100 File Offset: 0x00011100
		internal static string DataConnectionDialog_TestResults
		{
			get
			{
				return #Mk.ResourceManager.GetString(#Mk.#Lk(5874), #Mk.#ai);
			}
		}

		// Token: 0x17000090 RID: 144
		// (get) Token: 0x060002A6 RID: 678 RVA: 0x0001211C File Offset: 0x0001111C
		internal static string DataProvider_Odbc
		{
			get
			{
				return #Mk.ResourceManager.GetString(#Mk.#Lk(5919), #Mk.#ai);
			}
		}

		// Token: 0x17000091 RID: 145
		// (get) Token: 0x060002A7 RID: 679 RVA: 0x00012138 File Offset: 0x00011138
		internal static string DataProvider_Odbc_DataSource_Description
		{
			get
			{
				return #Mk.ResourceManager.GetString(#Mk.#Lk(5944), #Mk.#ai);
			}
		}

		// Token: 0x17000092 RID: 146
		// (get) Token: 0x060002A8 RID: 680 RVA: 0x00012154 File Offset: 0x00011154
		internal static string DataProvider_Odbc_Description
		{
			get
			{
				return #Mk.ResourceManager.GetString(#Mk.#Lk(6001), #Mk.#ai);
			}
		}

		// Token: 0x17000093 RID: 147
		// (get) Token: 0x060002A9 RID: 681 RVA: 0x00012170 File Offset: 0x00011170
		internal static string DataProvider_Odbc_Short
		{
			get
			{
				return #Mk.ResourceManager.GetString(#Mk.#Lk(6042), #Mk.#ai);
			}
		}

		// Token: 0x17000094 RID: 148
		// (get) Token: 0x060002AA RID: 682 RVA: 0x0001218C File Offset: 0x0001118C
		internal static string DataProvider_OleDB
		{
			get
			{
				return #Mk.ResourceManager.GetString(#Mk.#Lk(6075), #Mk.#ai);
			}
		}

		// Token: 0x17000095 RID: 149
		// (get) Token: 0x060002AB RID: 683 RVA: 0x000121A8 File Offset: 0x000111A8
		internal static string DataProvider_OleDB_AccessDataSource_Description
		{
			get
			{
				return #Mk.ResourceManager.GetString(#Mk.#Lk(6100), #Mk.#ai);
			}
		}

		// Token: 0x17000096 RID: 150
		// (get) Token: 0x060002AC RID: 684 RVA: 0x000121C4 File Offset: 0x000111C4
		internal static string DataProvider_OleDB_Description
		{
			get
			{
				return #Mk.ResourceManager.GetString(#Mk.#Lk(6165), #Mk.#ai);
			}
		}

		// Token: 0x17000097 RID: 151
		// (get) Token: 0x060002AD RID: 685 RVA: 0x000121E0 File Offset: 0x000111E0
		internal static string DataProvider_OleDB_OracleDataSource_Description
		{
			get
			{
				return #Mk.ResourceManager.GetString(#Mk.#Lk(6206), #Mk.#ai);
			}
		}

		// Token: 0x17000098 RID: 152
		// (get) Token: 0x060002AE RID: 686 RVA: 0x000121FC File Offset: 0x000111FC
		internal static string DataProvider_OleDB_Short
		{
			get
			{
				return #Mk.ResourceManager.GetString(#Mk.#Lk(6271), #Mk.#ai);
			}
		}

		// Token: 0x17000099 RID: 153
		// (get) Token: 0x060002AF RID: 687 RVA: 0x00012218 File Offset: 0x00011218
		internal static string DataProvider_OleDB_SqlDataSource_Description
		{
			get
			{
				return #Mk.ResourceManager.GetString(#Mk.#Lk(6304), #Mk.#ai);
			}
		}

		// Token: 0x1700009A RID: 154
		// (get) Token: 0x060002B0 RID: 688 RVA: 0x00012234 File Offset: 0x00011234
		internal static string DataProvider_Oracle
		{
			get
			{
				return #Mk.ResourceManager.GetString(#Mk.#Lk(6365), #Mk.#ai);
			}
		}

		// Token: 0x1700009B RID: 155
		// (get) Token: 0x060002B1 RID: 689 RVA: 0x00012250 File Offset: 0x00011250
		internal static string DataProvider_Oracle_DataSource_Description
		{
			get
			{
				return #Mk.ResourceManager.GetString(#Mk.#Lk(6394), #Mk.#ai);
			}
		}

		// Token: 0x1700009C RID: 156
		// (get) Token: 0x060002B2 RID: 690 RVA: 0x0001226C File Offset: 0x0001126C
		internal static string DataProvider_Oracle_Description
		{
			get
			{
				return #Mk.ResourceManager.GetString(#Mk.#Lk(6451), #Mk.#ai);
			}
		}

		// Token: 0x1700009D RID: 157
		// (get) Token: 0x060002B3 RID: 691 RVA: 0x00012288 File Offset: 0x00011288
		internal static string DataProvider_Oracle_Short
		{
			get
			{
				return #Mk.ResourceManager.GetString(#Mk.#Lk(6496), #Mk.#ai);
			}
		}

		// Token: 0x1700009E RID: 158
		// (get) Token: 0x060002B4 RID: 692 RVA: 0x000122A4 File Offset: 0x000112A4
		internal static string DataProvider_Sql
		{
			get
			{
				return #Mk.ResourceManager.GetString(#Mk.#Lk(6533), #Mk.#ai);
			}
		}

		// Token: 0x1700009F RID: 159
		// (get) Token: 0x060002B5 RID: 693 RVA: 0x000122C0 File Offset: 0x000112C0
		internal static string DataProvider_Sql_DataSource_Description
		{
			get
			{
				return #Mk.ResourceManager.GetString(#Mk.#Lk(6558), #Mk.#ai);
			}
		}

		// Token: 0x170000A0 RID: 160
		// (get) Token: 0x060002B6 RID: 694 RVA: 0x000122DC File Offset: 0x000112DC
		internal static string DataProvider_Sql_Description
		{
			get
			{
				return #Mk.ResourceManager.GetString(#Mk.#Lk(6611), #Mk.#ai);
			}
		}

		// Token: 0x170000A1 RID: 161
		// (get) Token: 0x060002B7 RID: 695 RVA: 0x000122F8 File Offset: 0x000112F8
		internal static string DataProvider_Sql_FileDataSource_Description
		{
			get
			{
				return #Mk.ResourceManager.GetString(#Mk.#Lk(6652), #Mk.#ai);
			}
		}

		// Token: 0x170000A2 RID: 162
		// (get) Token: 0x060002B8 RID: 696 RVA: 0x00012314 File Offset: 0x00011314
		internal static string DataProvider_Sql_Short
		{
			get
			{
				return #Mk.ResourceManager.GetString(#Mk.#Lk(6713), #Mk.#ai);
			}
		}

		// Token: 0x170000A3 RID: 163
		// (get) Token: 0x060002B9 RID: 697 RVA: 0x00012330 File Offset: 0x00011330
		internal static string DataSource_CannotChangeSingleDataProvider
		{
			get
			{
				return #Mk.ResourceManager.GetString(#Mk.#Lk(6746), #Mk.#ai);
			}
		}

		// Token: 0x170000A4 RID: 164
		// (get) Token: 0x060002BA RID: 698 RVA: 0x0001234C File Offset: 0x0001134C
		internal static string DataSource_DataProviderNotFound
		{
			get
			{
				return #Mk.ResourceManager.GetString(#Mk.#Lk(6803), #Mk.#ai);
			}
		}

		// Token: 0x170000A5 RID: 165
		// (get) Token: 0x060002BB RID: 699 RVA: 0x00012368 File Offset: 0x00011368
		internal static string DataSource_MicrosoftAccess
		{
			get
			{
				return #Mk.ResourceManager.GetString(#Mk.#Lk(6848), #Mk.#ai);
			}
		}

		// Token: 0x170000A6 RID: 166
		// (get) Token: 0x060002BC RID: 700 RVA: 0x00012384 File Offset: 0x00011384
		internal static string DataSource_MicrosoftOdbcDsn
		{
			get
			{
				return #Mk.ResourceManager.GetString(#Mk.#Lk(6885), #Mk.#ai);
			}
		}

		// Token: 0x170000A7 RID: 167
		// (get) Token: 0x060002BD RID: 701 RVA: 0x000123A0 File Offset: 0x000113A0
		internal static string DataSource_MicrosoftSqlServer
		{
			get
			{
				return #Mk.ResourceManager.GetString(#Mk.#Lk(6922), #Mk.#ai);
			}
		}

		// Token: 0x170000A8 RID: 168
		// (get) Token: 0x060002BE RID: 702 RVA: 0x000123BC File Offset: 0x000113BC
		internal static string DataSource_MicrosoftSqlServerFile
		{
			get
			{
				return #Mk.ResourceManager.GetString(#Mk.#Lk(6963), #Mk.#ai);
			}
		}

		// Token: 0x170000A9 RID: 169
		// (get) Token: 0x060002BF RID: 703 RVA: 0x000123D8 File Offset: 0x000113D8
		internal static string DataSource_Oracle
		{
			get
			{
				return #Mk.ResourceManager.GetString(#Mk.#Lk(7008), #Mk.#ai);
			}
		}

		// Token: 0x170000AA RID: 170
		// (get) Token: 0x060002C0 RID: 704 RVA: 0x000123F4 File Offset: 0x000113F4
		internal static string DataSource_UnspecifiedDisplayName
		{
			get
			{
				return #Mk.ResourceManager.GetString(#Mk.#Lk(7033), #Mk.#ai);
			}
		}

		// Token: 0x170000AB RID: 171
		// (get) Token: 0x060002C1 RID: 705 RVA: 0x00012410 File Offset: 0x00011410
		internal static string OdbcConnectionUIControl_InvalidConnectionProperties
		{
			get
			{
				return #Mk.ResourceManager.GetString(#Mk.#Lk(7078), #Mk.#ai);
			}
		}

		// Token: 0x170000AC RID: 172
		// (get) Token: 0x060002C2 RID: 706 RVA: 0x0001242C File Offset: 0x0001142C
		internal static string OdbcConnectionUIControl_SQLAllocConnectFailed
		{
			get
			{
				return #Mk.ResourceManager.GetString(#Mk.#Lk(7147), #Mk.#ai);
			}
		}

		// Token: 0x170000AD RID: 173
		// (get) Token: 0x060002C3 RID: 707 RVA: 0x00012448 File Offset: 0x00011448
		internal static string OdbcConnectionUIControl_SQLAllocEnvFailed
		{
			get
			{
				return #Mk.ResourceManager.GetString(#Mk.#Lk(7208), #Mk.#ai);
			}
		}

		// Token: 0x170000AE RID: 174
		// (get) Token: 0x060002C4 RID: 708 RVA: 0x00012464 File Offset: 0x00011464
		internal static string OdbcConnectionUIControl_SQLDriverConnectFailed
		{
			get
			{
				return #Mk.ResourceManager.GetString(#Mk.#Lk(7265), #Mk.#ai);
			}
		}

		// Token: 0x170000AF RID: 175
		// (get) Token: 0x060002C5 RID: 709 RVA: 0x00012480 File Offset: 0x00011480
		internal static string OleDBAccessConnectionProperties_MustSpecifyDataSource
		{
			get
			{
				return #Mk.ResourceManager.GetString(#Mk.#Lk(7330), #Mk.#ai);
			}
		}

		// Token: 0x170000B0 RID: 176
		// (get) Token: 0x060002C6 RID: 710 RVA: 0x0001249C File Offset: 0x0001149C
		internal static string OleDBConnectionUIControl_InvalidConnectionProperties
		{
			get
			{
				return #Mk.ResourceManager.GetString(#Mk.#Lk(7403), #Mk.#ai);
			}
		}

		// Token: 0x170000B1 RID: 177
		// (get) Token: 0x060002C7 RID: 711 RVA: 0x000124B8 File Offset: 0x000114B8
		internal static string OracleConnectionUIControl_InvalidConnectionProperties
		{
			get
			{
				return #Mk.ResourceManager.GetString(#Mk.#Lk(7476), #Mk.#ai);
			}
		}

		// Token: 0x170000B2 RID: 178
		// (get) Token: 0x060002C8 RID: 712 RVA: 0x000124D4 File Offset: 0x000114D4
		internal static string SqlConnectionProperties_CannotTestNonExistentDatabase
		{
			get
			{
				return #Mk.ResourceManager.GetString(#Mk.#Lk(7549), #Mk.#ai);
			}
		}

		// Token: 0x170000B3 RID: 179
		// (get) Token: 0x060002C9 RID: 713 RVA: 0x000124F0 File Offset: 0x000114F0
		internal static string SqlConnectionProperties_MustSpecifyDataSource
		{
			get
			{
				return #Mk.ResourceManager.GetString(#Mk.#Lk(7622), #Mk.#ai);
			}
		}

		// Token: 0x170000B4 RID: 180
		// (get) Token: 0x060002CA RID: 714 RVA: 0x0001250C File Offset: 0x0001150C
		internal static string SqlConnectionProperties_UnsupportedSqlVersion
		{
			get
			{
				return #Mk.ResourceManager.GetString(#Mk.#Lk(7683), #Mk.#ai);
			}
		}

		// Token: 0x170000B5 RID: 181
		// (get) Token: 0x060002CB RID: 715 RVA: 0x00012528 File Offset: 0x00011528
		internal static string SqlConnectionUIControl_BrowseFileDefaultExt
		{
			get
			{
				return #Mk.ResourceManager.GetString(#Mk.#Lk(7744), #Mk.#ai);
			}
		}

		// Token: 0x170000B6 RID: 182
		// (get) Token: 0x060002CC RID: 716 RVA: 0x00012544 File Offset: 0x00011544
		internal static string SqlConnectionUIControl_BrowseFileFilter
		{
			get
			{
				return #Mk.ResourceManager.GetString(#Mk.#Lk(7805), #Mk.#ai);
			}
		}

		// Token: 0x170000B7 RID: 183
		// (get) Token: 0x060002CD RID: 717 RVA: 0x00012560 File Offset: 0x00011560
		internal static string SqlConnectionUIControl_BrowseFileTitle
		{
			get
			{
				return #Mk.ResourceManager.GetString(#Mk.#Lk(7858), #Mk.#ai);
			}
		}

		// Token: 0x170000B8 RID: 184
		// (get) Token: 0x060002CE RID: 718 RVA: 0x0001257C File Offset: 0x0001157C
		internal static string SqlConnectionUIControl_InvalidConnectionProperties
		{
			get
			{
				return #Mk.ResourceManager.GetString(#Mk.#Lk(7911), #Mk.#ai);
			}
		}

		// Token: 0x170000B9 RID: 185
		// (get) Token: 0x060002CF RID: 719 RVA: 0x00012598 File Offset: 0x00011598
		internal static string SqlFileConnectionProperties_CannotTestNonExistentMdf
		{
			get
			{
				return #Mk.ResourceManager.GetString(#Mk.#Lk(7980), #Mk.#ai);
			}
		}

		// Token: 0x170000BA RID: 186
		// (get) Token: 0x060002D0 RID: 720 RVA: 0x000125B4 File Offset: 0x000115B4
		internal static string SqlFileConnectionProperties_NoFileSpecified
		{
			get
			{
				return #Mk.ResourceManager.GetString(#Mk.#Lk(8053), #Mk.#ai);
			}
		}

		// Token: 0x170000BB RID: 187
		// (get) Token: 0x060002D1 RID: 721 RVA: 0x000125D0 File Offset: 0x000115D0
		internal static string SqlFileConnectionProperties_TimeoutReasons
		{
			get
			{
				return #Mk.ResourceManager.GetString(#Mk.#Lk(8114), #Mk.#ai);
			}
		}

		// Token: 0x170000BC RID: 188
		// (get) Token: 0x060002D2 RID: 722 RVA: 0x000125EC File Offset: 0x000115EC
		internal static string SqlFileConnectionUIControl_InvalidConnectionProperties
		{
			get
			{
				return #Mk.ResourceManager.GetString(#Mk.#Lk(8171), #Mk.#ai);
			}
		}

		// Token: 0x04000144 RID: 324
		private static ResourceManager #9h;

		// Token: 0x04000145 RID: 325
		private static CultureInfo #ai;
	}
}
