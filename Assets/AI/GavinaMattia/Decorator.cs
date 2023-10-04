
namespace DBGA.AI.Gavina
{
	public abstract class Decorator : Node
	{
		public Node child;

		private void Awake()
		{
			transform.GetChild(0).TryGetComponent(out Node child);
			this.child = child;
		}
	}
}
