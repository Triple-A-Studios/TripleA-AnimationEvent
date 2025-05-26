using UnityEngine.Events;

namespace TripleA.AnimationEvents
{
	[System.Serializable]
	public class AnimationEvent
	{
		public string eventName;
		public UnityEvent onAnimationEvent;
	}
}
