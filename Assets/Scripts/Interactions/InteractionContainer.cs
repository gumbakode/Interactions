using System;
using UnityEngine;

namespace Interactions
{
    [System.Serializable]
    public class InteractionContainer : IInteractionContainer, IEquatable<InteractionContainer>
    {
        public string Description;
        [SerializeField] private AbstractInteraction _interactionComponent;

        public bool IsAvailable(GameObject interactor)
        {
            return GetInteraction().PreCondition.CanInteract(interactor);
        }

        public IInteraction GetInteraction()
        {
            return _interactionComponent;
        }

        public InteractionContainer(string description, IInteraction interaction)
        {
            Description = description;
            _interactionComponent = interaction as AbstractInteraction;
        }

        #region equality

        // override object.Equals
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            var container = obj as IInteractionContainer;
            if ((System.Object) container == null)
            {
                return false;
            }

            return UnityEngine.Object.Equals(GetInteraction(), container.GetInteraction());
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            return GetInteraction().GetHashCode();
        }

        public bool Equals(InteractionContainer other)
        {
            if ((object) other == null)
            {
                return false;
            }

            return UnityEngine.Object.Equals(GetInteraction(), other.GetInteraction());
        }

        public static bool operator ==(InteractionContainer first, InteractionContainer second)
        {
            if (System.Object.ReferenceEquals(first, second))
                return true;

            if ((object) first == null || (object) second == null)
                return false;

            return UnityEngine.Object.Equals(first.GetInteraction(), second.GetInteraction());
        }

        public static bool operator !=(InteractionContainer first, InteractionContainer second)
        {
            return !(first == second);
        }

        #endregion
    }
}