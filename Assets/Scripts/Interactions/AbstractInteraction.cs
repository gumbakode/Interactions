using Interactions.Conditions;
using UnityEngine;

namespace Interactions
{
    public abstract class AbstractInteraction : MonoBehaviour, IInteraction
    {
        protected GameObject Interactor { get; private set; }

        public virtual IInteractionUsageCondition PreCondition { get { return new AlwaysTrueCondition(); } }
        public virtual IInteractionUsageCondition PostCondition { get { return new AlwaysTrueCondition(); } }

        public abstract IInteractionUiModel UiModel { get; }

        public void Activate(GameObject interactor)
        {
            Interactor = interactor;

            if (PostCondition.CanInteract(interactor))
                OnActivate(interactor);
        }

        protected abstract void OnActivate(GameObject interactor);

        public void Stop()
        {
            OnStop();
        }

        protected abstract void OnStop();
    }
}