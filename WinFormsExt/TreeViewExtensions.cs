﻿using System.Collections.Generic;
using System.Windows.Forms;

namespace AdamOneilSoftware
{
    public static class TreeViewExtensions
	{
		public static List<T> FindNodes<T>(this TreeView treeView, bool recursive = true) where T : TreeNode
		{
			List<T> results = new List<T>();
			foreach (TreeNode node in treeView.Nodes)
			{
				AddResult(node, results);
				if (recursive) FindNodesR<T>(node, results);
			}
			return results;
		}

		public static List<T> FindNodes<T>(this TreeNode treeNode, bool recursive = true) where T : TreeNode
		{
			List<T> results = new List<T>();
			FindNodesR<T>(treeNode, results, recursive);
			return results;
		}

		private static void FindNodesR<T>(TreeNode parent, List<T> results, bool recursive = true) where T : TreeNode
		{
			if (parent == null) return;
			foreach (TreeNode node in parent.Nodes)
			{
				AddResult(node, results);
				if (recursive) FindNodesR(node, results);
			}
		}

		private static void AddResult<T>(TreeNode node, List<T> results) where T : TreeNode
		{
			T checkNode = node as T;
			if (checkNode != null) results.Add(checkNode);
		}
	}
}