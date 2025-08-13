using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace TripleA.AnimationEvents
{
	public abstract class AnimationEventReceiver : MonoBehaviour
	{
		[SerializeField] private List<AnimationEvent> m_eventList = new();

		private bool m_eventFired;
		
		public virtual void OnAnimationEventTriggered(string eventName)
		{
			m_eventFired = false;
			foreach (var @event in m_eventList.Where(@event => @event.eventName == eventName))
			{
				@event.onAnimationEvent?.Invoke();
				m_eventFired = true;
			}
			
			if (m_eventFired) return;
			Debug.LogWarning($"Event {eventName} not found on {gameObject.name}\nYou might have forgotten to add the event name in the list or there might be a typo.", gameObject);
		}
	}
}
