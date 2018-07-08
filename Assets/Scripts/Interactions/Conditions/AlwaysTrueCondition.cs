using UnityEngine;

namespace Interactions.Conditions
{
    public class AlwaysTrueCondition : IInteractionUsageCondition
    {
        public bool CanInteract(GameObject interactor)
        {
            return true;
        }
    }
}