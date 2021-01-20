using System;
using System.Drawing;
using System.Windows.Forms;

namespace #cTc
{
	// Token: 0x0200001D RID: 29
	internal sealed class #TVc
	{
		// Token: 0x06000175 RID: 373 RVA: 0x000094D8 File Offset: 0x000084D8
		private #TVc()
		{
		}

		// Token: 0x06000176 RID: 374 RVA: 0x000094E0 File Offset: 0x000084E0
		public static int #KVc(Label #88b)
		{
			return #TVc.#KVc(#88b, #88b.Width);
		}

		// Token: 0x06000177 RID: 375 RVA: 0x000094F0 File Offset: 0x000084F0
		public static int #KVc(Label #88b, int #LVc)
		{
			return #TVc.#RVc(#88b, #88b.UseCompatibleTextRendering, #LVc);
		}

		// Token: 0x06000178 RID: 376 RVA: 0x00009500 File Offset: 0x00008500
		public static int #MVc(CheckBox #NVc)
		{
			return #TVc.#RVc(#NVc, #NVc.UseCompatibleTextRendering, #NVc.Width);
		}

		// Token: 0x06000179 RID: 377 RVA: 0x00009514 File Offset: 0x00008514
		public static void #OVc(Control #FN)
		{
			#FN.Left = #FN.Parent.Right - #FN.Parent.Padding.Left - #FN.Margin.Left - #FN.Width;
			if ((#FN.Anchor & AnchorStyles.Left) == AnchorStyles.None || (#FN.Anchor & AnchorStyles.Right) == AnchorStyles.None)
			{
				#FN.Anchor &= ~AnchorStyles.Left;
				#FN.Anchor |= AnchorStyles.Right;
			}
		}

		// Token: 0x0600017A RID: 378 RVA: 0x00009590 File Offset: 0x00008590
		public static void #OVc(Control #FN, Control #PVc)
		{
			#FN.Left = #PVc.Right - #FN.Width;
			if ((#FN.Anchor & AnchorStyles.Left) == AnchorStyles.None || (#FN.Anchor & AnchorStyles.Right) == AnchorStyles.None)
			{
				#FN.Anchor &= ~AnchorStyles.Left;
				#FN.Anchor |= AnchorStyles.Right;
			}
		}

		// Token: 0x0600017B RID: 379 RVA: 0x000095E4 File Offset: 0x000085E4
		public static void #QVc(Control #FN)
		{
			#FN.Left = #FN.Parent.Left + #FN.Parent.Padding.Left + #FN.Margin.Left;
			if ((#FN.Anchor & AnchorStyles.Left) == AnchorStyles.None || (#FN.Anchor & AnchorStyles.Right) == AnchorStyles.None)
			{
				#FN.Anchor &= ~AnchorStyles.Right;
				#FN.Anchor |= AnchorStyles.Left;
			}
		}

		// Token: 0x0600017C RID: 380 RVA: 0x00009658 File Offset: 0x00008658
		public static void #QVc(Control #FN, Control #PVc)
		{
			#FN.Left = #PVc.Left;
			if ((#FN.Anchor & AnchorStyles.Left) == AnchorStyles.None || (#FN.Anchor & AnchorStyles.Right) == AnchorStyles.None)
			{
				#FN.Anchor &= ~AnchorStyles.Right;
				#FN.Anchor |= AnchorStyles.Left;
			}
		}

		// Token: 0x0600017D RID: 381 RVA: 0x00009698 File Offset: 0x00008698
		private static int #RVc(Control #FN, bool #SVc, int #LVc)
		{
			int height;
			using (Graphics graphics = Graphics.FromHwnd(#FN.Handle))
			{
				if (#SVc)
				{
					height = graphics.MeasureString(#FN.Text, #FN.Font, #FN.Width).ToSize().Height;
				}
				else
				{
					height = TextRenderer.MeasureText(graphics, #FN.Text, #FN.Font, new Size(#LVc, int.MaxValue), TextFormatFlags.WordBreak).Height;
				}
			}
			return height;
		}
	}
}
