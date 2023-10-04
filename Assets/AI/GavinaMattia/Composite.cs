using Codice.Client.Common.Tree;
using System.Collections.Generic;

namespace DBGA.AI.Gavina
{
	public abstract class Composite : Node
	{
		public List<Node> children= new List<Node>();

		private void Awake()
		{
			for (int i = 0; i < transform.childCount; i++) 
			{
				transform.GetChild(i).TryGetComponent(out Node child);
				children.Add(child);
			}
		}
	}
}