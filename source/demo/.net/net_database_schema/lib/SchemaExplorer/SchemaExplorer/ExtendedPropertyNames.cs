using System;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security;
using #Nk;

namespace SchemaExplorer
{
	// Token: 0x020000A0 RID: 160
	public class ExtendedPropertyNames
	{
		// Token: 0x06000591 RID: 1425 RVA: 0x00017B18 File Offset: 0x00016B18
		// Note: this type is marked as 'beforefieldinit'.
		static ExtendedPropertyNames()
		{
			bool flag = false;
			Assembly executingAssembly = Assembly.GetExecutingAssembly();
			if (ExtendedPropertyNames.StrongNameSignatureVerificationEx(executingAssembly.Location, true, out flag) && flag && executingAssembly.FullName.EndsWith(#Mk.#Lk(774)))
			{
				return;
			}
			throw new SecurityException(#Mk.#Lk(799));
		}

		// Token: 0x06000592 RID: 1426
		[DllImport("mscorwks.dll", CharSet = CharSet.Unicode)]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool StrongNameSignatureVerificationEx([MarshalAs(UnmanagedType.LPWStr)] string, [MarshalAs(UnmanagedType.Bool)] bool, [MarshalAs(UnmanagedType.Bool)] out bool);

		// Token: 0x040001E0 RID: 480
		public const string IsCLR = "CS_IsCLR";

		// Token: 0x040001E1 RID: 481
		public const string IsInlineTableValuedFunction = "CS_IsInlineTableValuedFunction";

		// Token: 0x040001E2 RID: 482
		public const string IsMultiStatementTableValuedFunction = "CS_IsMultiStatementTableValuedFunction";

		// Token: 0x040001E3 RID: 483
		public const string IsAggregateFunction = "CS_IsAggregateFunction";

		// Token: 0x040001E4 RID: 484
		public const string IsScalarFunction = "CS_IsScalarFunction";

		// Token: 0x040001E5 RID: 485
		public const string IsTableValuedFunction = "CS_IsTableValuedFunction";

		// Token: 0x040001E6 RID: 486
		public const string IsUserDefinedTableType = "CS_IsUserDefinedTableType";

		// Token: 0x040001E7 RID: 487
		public const string SpecificName = "CS_SpecificName";

		// Token: 0x040001E8 RID: 488
		public const string NumberOfResultSets = "CS_NumberOfResultSets";

		// Token: 0x040001E9 RID: 489
		public const string DatabaseMajorVersion = "CS_DatabaseMajorVersion";

		// Token: 0x040001EA RID: 490
		public const string DatabaseVersion = "CS_DatabaseVersion";

		// Token: 0x040001EB RID: 491
		public const string Collation = "CS_Collation";

		// Token: 0x040001EC RID: 492
		public const string Comment = "CS_Comment";

		// Token: 0x040001ED RID: 493
		public const string ComputedDefinition = "CS_ComputedDefinition";

		// Token: 0x040001EE RID: 494
		public const string DefaultValue = "CS_Default";

		// Token: 0x040001EF RID: 495
		public const string IsIdentity = "CS_IsIdentity";

		// Token: 0x040001F0 RID: 496
		public const string IdentityIncrement = "CS_IdentityIncrement";

		// Token: 0x040001F1 RID: 497
		public const string IdentitySeed = "CS_IdentitySeed";

		// Token: 0x040001F2 RID: 498
		public const string IsComputed = "CS_IsComputed";

		// Token: 0x040001F3 RID: 499
		public const string IsDeterministic = "CS_IsDeterministic";

		// Token: 0x040001F4 RID: 500
		public const string IsRowGuidColumn = "CS_IsRowGuidCol";

		// Token: 0x040001F5 RID: 501
		public const string ParameterID = "CS_ParameterID";

		// Token: 0x040001F6 RID: 502
		public const string ConstraintDefinitionFormat = "CS_Constraint_{0}_Definition";

		// Token: 0x040001F7 RID: 503
		public const string ConstraintNameFormat = "CS_Constraint_{0}_Name";

		// Token: 0x040001F8 RID: 504
		public const string ConstraintTypeFormat = "CS_Constraint_{0}_Type";

		// Token: 0x040001F9 RID: 505
		public const string DRIIndex = "CS_DRIIndex";

		// Token: 0x040001FA RID: 506
		public const string DRIPrimaryKey = "CS_DRIPrimaryKey";

		// Token: 0x040001FB RID: 507
		public const string DRIUniqueKey = "CS_DRIUniqueKey";

		// Token: 0x040001FC RID: 508
		public const string DropExist = "CS_DropExist";

		// Token: 0x040001FD RID: 509
		public const string IsAutoStatistics = "CS_IsAutoStatistics";

		// Token: 0x040001FE RID: 510
		public const string IsConstraint = "CS_IsConstraint";

		// Token: 0x040001FF RID: 511
		public const string IsClustered = "CS_IsClustered";

		// Token: 0x04000200 RID: 512
		public const string IsDescending = "CS_IsDescending";

		// Token: 0x04000201 RID: 513
		public const string IsFullTextKey = "CS_IsFullTextKey";

		// Token: 0x04000202 RID: 514
		public const string IgnoreDuplicateKey = "CS_IgnoreDupKey";

		// Token: 0x04000203 RID: 515
		public const string IsHypothetical = "CS_IsHypothetical";

		// Token: 0x04000204 RID: 516
		public const string IsStatistics = "CS_IsStatistics";

		// Token: 0x04000205 RID: 517
		public const string IsTableIndex = "CS_IsTable";

		// Token: 0x04000206 RID: 518
		public const string NoRecompute = "CS_NoRecompute";

		// Token: 0x04000207 RID: 519
		public const string OriginalFillFactor = "CS_OrigFillFactor";

		// Token: 0x04000208 RID: 520
		public const string PadIndex = "CS_PadIndex";

		// Token: 0x04000209 RID: 521
		public const string CascadeDelete = "CS_CascadeDelete";

		// Token: 0x0400020A RID: 522
		public const string CascadeUpdate = "CS_CascadeUpdate";

		// Token: 0x0400020B RID: 523
		public const string IsNotForReplication = "CS_IsNotForReplication";

		// Token: 0x0400020C RID: 524
		public const string WithNoCheck = "CS_WithNoCheck";

		// Token: 0x0400020D RID: 525
		public const string IsSchemaAlias = "CS_IsSchemaAlias";

		// Token: 0x0400020E RID: 526
		public const string SourceSchemaName = "CS_SourceSchemaName";

		// Token: 0x0400020F RID: 527
		public const string SourceSchemaOwner = "CS_SourceSchemaOwner";

		// Token: 0x04000210 RID: 528
		public const string Description = "CS_Description";

		// Token: 0x04000211 RID: 529
		public const string FileGroup = "CS_FileGroup";

		// Token: 0x04000212 RID: 530
		public const string IsTrigger = "CS_IsTrigger";

		// Token: 0x04000213 RID: 531
		public const string ObjectID = "CS_ObjectID";

		// Token: 0x04000214 RID: 532
		public const string ObjectType = "CS_ObjectType";

		// Token: 0x04000215 RID: 533
		public const string Sequence = "CS_Sequence";

		// Token: 0x04000216 RID: 534
		public const string SystemType = "CS_SystemType";

		// Token: 0x04000217 RID: 535
		public const string UserDefinedType = "CS_UserDefinedType";
	}
}
