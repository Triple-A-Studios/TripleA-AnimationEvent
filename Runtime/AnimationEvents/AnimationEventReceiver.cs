using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace TripleA.AnimationEvents
{
	public abstract class AnimationEventReceiver : MonoBehaviour
	{
		[SerializeField] private List<AnimationEvent> m_eventList = new();
		
		public virtual void OnAnimationEventTriggered(string eventName)
		{
			foreach (var @event in m_eventList.Where(@event => @event.eventName == eventName))
			{
				@event.onAnimationEvent?.Invoke();
			}
		}
	}
}
