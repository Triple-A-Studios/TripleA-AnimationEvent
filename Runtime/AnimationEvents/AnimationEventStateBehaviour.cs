using UnityEngine;

namespace TripleA.AnimationEvents
{
	public class AnimationEventStateBehaviour : StateMachineBehaviour
	{
		public string eventName;
		[Range(0, 1)] public float triggerTime;

		// this is to make sure the event is only triggered once when looping animation
		private bool m_hasTriggered;

		public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
		{
			m_hasTriggered = false;
		}

		public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
		{
			float currentTime = stateInfo.normalizedTime % 1f; // when looping normalizedTime can be > 1

			if (currentTime > triggerTime && !m_hasTriggered)
			{
				NotifyReceivers(animator);
				m_hasTriggered = true;
			}
		}

		private void NotifyReceivers(Animator animator)
		{
			AnimationEventReceiver receiver = animator.GetComponent<AnimationEventReceiver>();
			if (receiver)
			{
				receiver.OnAnimationEventTriggered(eventName);
			}
		}
	}
}
