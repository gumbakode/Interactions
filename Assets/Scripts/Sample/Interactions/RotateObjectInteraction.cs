using Interactions;
using Interactions.UIModels;
using Sample.Interactions.Conditions;
using UnityEngine;

namespace Sample.Interactions
{
    /// <summary>
    /// Interaction will work only if target object destroyed
    /// </summary>
    public class RotateObjectInteraction : AbstractInteraction
    {
        [SerializeField] private SimpleUiModel _uiModel;

        public override IInteractionUiModel UiModel
        {
            get { return _uiModel; }
        }

        [Header("Interaction will work only if target object destroyed")] [SerializeField]
        private ObjectDestroyedCondition _postCondition;

        public override IInteractionUsageCondition PostCondition
        {
            get { return _postCondition; }
        }

        [SerializeField] private ObjectRotator _rotatorComponent;

        protected override void OnActivate(GameObject interactor)
        {
            _rotatorComponent.enabled = !_rotatorComponent.enabled;
        }

        protected override void OnStop()
        {
        }
    }
}