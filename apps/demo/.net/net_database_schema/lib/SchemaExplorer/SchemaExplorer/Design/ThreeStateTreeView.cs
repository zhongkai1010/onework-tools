using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using #Nk;

namespace SchemaExplorer.Design
{
	// Token: 0x020000D6 RID: 214
	public class ThreeStateTreeView : TreeView
	{
		// Token: 0x170001E7 RID: 487
		// (get) Token: 0x0600077F RID: 1919 RVA: 0x00024390 File Offset: 0x00023390
		// (set) Token: 0x06000780 RID: 1920 RVA: 0x00024398 File Offset: 0x00023398
		[DefaultValue(false)]
		public new bool CheckBoxes
		{
			get
			{
				return this.#c4c;
			}
			set
			{
				if (this.CheckBoxes != value)
				{
					this.#c4c = value;
					if (base.IsHandleCreated)
					{
						if (this.CheckBoxes)
						{
							base.UpdateStyles();
							return;
						}
						base.RecreateHandle();
					}
				}
			}
		}

		// Token: 0x06000781 RID: 1921 RVA: 0x000243C8 File Offset: 0x000233C8
		public void InitializeNodesState(TreeNodeCollection nodes)
		{
			foreach (object obj in nodes)
			{
				TreeNode treeNode = (TreeNode)obj;
				treeNode.StateImageIndex = 0;
				if (treeNode.Nodes.Count != 0)
				{
					this.InitializeNodesState(treeNode.Nodes);
				}
			}
		}

		// Token: 0x06000782 RID: 1922 RVA: 0x00024438 File Offset: 0x00023438
		public void UpdateChildren(TreeNode parent)
		{
			int stateImageIndex = parent.StateImageIndex;
			if (!parent.IsExpanded)
			{
				parent.ExpandAll();
			}
			foreach (object obj in parent.Nodes)
			{
				TreeNode treeNode = (TreeNode)obj;
				treeNode.StateImageIndex = stateImageIndex;
				if (treeNode.Nodes.Count != 0)
				{
					this.UpdateChildren(treeNode);
				}
			}
		}

		// Token: 0x06000783 RID: 1923 RVA: 0x000244BC File Offset: 0x000234BC
		public void UpdateParent(TreeNode child)
		{
			TreeNode parent = child.Parent;
			if (parent == null)
			{
				return;
			}
			if (child.StateImageIndex == 2)
			{
				parent.StateImageIndex = 2;
			}
			else if (ThreeStateTreeView.IsChildrenChecked(parent))
			{
				parent.StateImageIndex = 1;
			}
			else if (ThreeStateTreeView.IsChildrenUnchecked(parent))
			{
				parent.StateImageIndex = 0;
			}
			else
			{
				parent.StateImageIndex = 2;
			}
			this.UpdateParent(parent);
		}

		// Token: 0x06000784 RID: 1924 RVA: 0x00024518 File Offset: 0x00023518
		public static bool IsChildrenChecked(TreeNode parent)
		{
			return ThreeStateTreeView.IsAllChildrenSame(parent, 1);
		}

		// Token: 0x06000785 RID: 1925 RVA: 0x00024524 File Offset: 0x00023524
		public static bool IsChildrenUnchecked(TreeNode parent)
		{
			return ThreeStateTreeView.IsAllChildrenSame(parent, 0);
		}

		// Token: 0x06000786 RID: 1926 RVA: 0x00024530 File Offset: 0x00023530
		public static bool IsAllChildrenSame(TreeNode parent, int state)
		{
			foreach (object obj in parent.Nodes)
			{
				TreeNode treeNode = (TreeNode)obj;
				if (treeNode.StateImageIndex != state)
				{
					return false;
				}
				if (treeNode.Nodes.Count != 0 && !ThreeStateTreeView.IsAllChildrenSame(treeNode, state))
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x06000787 RID: 1927 RVA: 0x000245AC File Offset: 0x000235AC
		private static Image #mO(CheckBoxState #8j, Size #d4c)
		{
			Bitmap bitmap = new Bitmap(16, 16);
			using (Graphics graphics = Graphics.FromImage(bitmap))
			{
				Point glyphLocation = new Point((16 - #d4c.Width) / 2, (16 - #d4c.Height) / 2);
				CheckBoxRenderer.DrawCheckBox(graphics, glyphLocation, #8j);
			}
			return bitmap;
		}

		// Token: 0x06000788 RID: 1928 RVA: 0x00024610 File Offset: 0x00023610
		protected override void OnHandleCreated(EventArgs e)
		{
			base.OnHandleCreated(e);
			if (!this.CheckBoxes)
			{
				return;
			}
			if (this.#b4c == null)
			{
				this.#b4c = new ImageList();
				using (Graphics graphics = base.CreateGraphics())
				{
					Size glyphSize = CheckBoxRenderer.GetGlyphSize(graphics, CheckBoxState.UncheckedNormal);
					this.#b4c.Images.Add(ThreeStateTreeView.#mO(CheckBoxState.UncheckedNormal, glyphSize));
					this.#b4c.Images.Add(ThreeStateTreeView.#mO(CheckBoxState.CheckedNormal, glyphSize));
					this.#b4c.Images.Add(ThreeStateTreeView.#mO(CheckBoxState.MixedNormal, glyphSize));
					this.#b4c.Images.Add(ThreeStateTreeView.#mO(CheckBoxState.UncheckedDisabled, glyphSize));
					this.#b4c.Images.Add(ThreeStateTreeView.#mO(CheckBoxState.CheckedDisabled, glyphSize));
					this.#b4c.Images.Add(ThreeStateTreeView.#mO(CheckBoxState.MixedDisabled, glyphSize));
				}
			}
			base.StateImageList = this.#b4c;
			this.InitializeNodesState(base.Nodes);
		}

		// Token: 0x06000789 RID: 1929 RVA: 0x00024714 File Offset: 0x00023714
		protected override void OnNodeMouseClick(TreeNodeMouseClickEventArgs e)
		{
			base.OnNodeMouseClick(e);
			if (e.Button != MouseButtons.Left)
			{
				return;
			}
			TreeViewHitTestInfo treeViewHitTestInfo = base.HitTest(e.Location);
			if (treeViewHitTestInfo.Node == null || treeViewHitTestInfo.Location != TreeViewHitTestLocations.StateImage)
			{
				return;
			}
			TreeNode node = treeViewHitTestInfo.Node;
			this.#e4c(node);
		}

		// Token: 0x0600078A RID: 1930 RVA: 0x00024764 File Offset: 0x00023764
		protected override void OnKeyDown(KeyEventArgs e)
		{
			base.OnKeyDown(e);
			if (e.KeyCode != Keys.Space)
			{
				return;
			}
			if (base.SelectedNode == null)
			{
				return;
			}
			TreeNode selectedNode = base.SelectedNode;
			this.#e4c(selectedNode);
		}

		// Token: 0x0600078B RID: 1931 RVA: 0x0002479C File Offset: 0x0002379C
		private void #e4c(TreeNode #YQ)
		{
			base.BeginUpdate();
			switch (#YQ.StateImageIndex)
			{
			case 0:
			case 2:
				#YQ.StateImageIndex = 1;
				break;
			case 1:
				#YQ.StateImageIndex = 0;
				break;
			}
			this.UpdateChildren(#YQ);
			this.UpdateParent(#YQ);
			base.EndUpdate();
		}

		// Token: 0x0600078C RID: 1932 RVA: 0x000247F0 File Offset: 0x000237F0
		protected override void OnEnabledChanged(EventArgs e)
		{
			base.OnEnabledChanged(e);
			if (this.#b4c == null)
			{
				return;
			}
			for (int i = 0; i < 3; i++)
			{
				Image value = this.#b4c.Images[0];
				this.#b4c.Images.RemoveAt(0);
				this.#b4c.Images.Add(value);
			}
		}

		// Token: 0x0600078D RID: 1933 RVA: 0x00024850 File Offset: 0x00023850
		public IList<TreeNode> CheckedNodes()
		{
			List<TreeNode> list = new List<TreeNode>();
			foreach (object obj in base.Nodes)
			{
				TreeNode #YQ = (TreeNode)obj;
				this.#f4c(#YQ, list);
			}
			return list;
		}

		// Token: 0x0600078E RID: 1934 RVA: 0x000248B4 File Offset: 0x000238B4
		private void #f4c(TreeNode #YQ, IList<TreeNode> #g4c)
		{
			if (this.GetChecked(#YQ))
			{
				#g4c.Add(#YQ);
			}
			foreach (object obj in #YQ.Nodes)
			{
				TreeNode #YQ2 = (TreeNode)obj;
				this.#f4c(#YQ2, #g4c);
			}
		}

		// Token: 0x0600078F RID: 1935 RVA: 0x00024920 File Offset: 0x00023920
		public bool GetChecked(TreeNode node)
		{
			return node.StateImageIndex == 1 || node.StateImageIndex == 2;
		}

		// Token: 0x06000790 RID: 1936 RVA: 0x00024938 File Offset: 0x00023938
		public void SetChecked(TreeNode node)
		{
			if (node.StateImageIndex == 1)
			{
				return;
			}
			this.#e4c(node);
		}

		// Token: 0x06000791 RID: 1937 RVA: 0x0002494C File Offset: 0x0002394C
		// Note: this type is marked as 'beforefieldinit'.
		static ThreeStateTreeView()
		{
			bool flag = false;
			Assembly executingAssembly = Assembly.GetExecutingAssembly();
			if (ThreeStateTreeView.StrongNameSignatureVerificationEx(executingAssembly.Location, true, out flag) && flag && executingAssembly.FullName.EndsWith(#Mk.#Lk(774)))
			{
				return;
			}
			throw new SecurityException(#Mk.#Lk(799));
		}

		// Token: 0x06000792 RID: 1938
		[DllImport("mscorwks.dll", CharSet = CharSet.Unicode)]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool StrongNameSignatureVerificationEx([MarshalAs(UnmanagedType.LPWStr)] string, [MarshalAs(UnmanagedType.Bool)] bool, [MarshalAs(UnmanagedType.Bool)] out bool);

		// Token: 0x040002E6 RID: 742
		private const int #83c = 0;

		// Token: 0x040002E7 RID: 743
		private const int #93c = 1;

		// Token: 0x040002E8 RID: 744
		private const int #a4c = 2;

		// Token: 0x040002E9 RID: 745
		private ImageList #b4c;

		// Token: 0x040002EA RID: 746
		private bool #c4c;
	}
}
