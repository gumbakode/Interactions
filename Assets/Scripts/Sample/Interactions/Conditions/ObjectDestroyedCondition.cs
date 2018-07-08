using Interactions;
using UnityEngine;

namespace Sample.Interactions.Conditions
{
    [System.Serializable]
    public class ObjectDestroyedCondition : IInteractionUsageCondition
    {
        [SerializeField] private GameObject _objectThatMustBeDestroyed;

        public bool CanInteract(GameObject interactor)
        {
            return _objectThatMustBeDestroyed == null;
        }
    }
}