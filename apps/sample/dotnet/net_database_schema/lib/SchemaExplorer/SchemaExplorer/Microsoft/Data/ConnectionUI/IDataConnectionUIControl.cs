using System;

namespace Microsoft.Data.ConnectionUI
{
	// Token: 0x02000005 RID: 5
	public interface IDataConnectionUIControl
	{
		// Token: 0x0600001A RID: 26
		void Initialize(IDataConnectionProperties connectionProperties);

		// Token: 0x0600001B RID: 27
		void LoadProperties();
	}
}
