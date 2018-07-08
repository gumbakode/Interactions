using Interactions;
using Interactions.UIModels;
using UnityEngine;

namespace Sample.Interactions
{
    public class DestroyObjectInteraction : AbstractInteraction
    {
        [SerializeField] private SimpleUiModel _uiModel;

        public override IInteractionUiModel UiModel
        {
            get { return _uiModel; }
        }

        [SerializeField] private GameObject _objectToDestroy;

        protected override void OnActivate(GameObject interactor)
        {
            // nothing to check from interactor, just destroy it
            Destroy(_objectToDestroy);
        }

        protected override void OnStop()
        {
            // can't stop this action
        }
    }
}