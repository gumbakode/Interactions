using Interactions;
using Interactions.UIModels;
using UnityEngine;

namespace Sample.Interactions
{
    /// <summary>
    /// Interaction that randomly changes color in material
    /// </summary>
    public class ChangeColorInteraction : AbstractInteraction
    {
        [SerializeField]
        private SimpleUiModel _uiModel;

        public override IInteractionUiModel UiModel
        {
            get { return _uiModel; }
        }

        [SerializeField] private MeshRenderer _renderer;
        
        private Material _materialInstance;

        private void Awake()
        {
            InitMaterialInstance();
        }

        private void InitMaterialInstance()
        {
            if (_renderer == null)
            {
                Debug.LogError("renderer component not assigned");
                return;
            }

            _materialInstance = _renderer.material;
        }

        protected override void OnActivate(GameObject interactor)
        {
            ChangeColor();
        }

        private void ChangeColor()
        {
            if(_materialInstance == null)
                return;

            _materialInstance.color = Random.ColorHSV();
        }

        protected override void OnStop()
        {
            // nothing to stop
        }
    }
}