using UnityEngine;

namespace Interactions.UIModels
{
    [System.Serializable]
    public class SimpleUiModel : IInteractionUiModel
    {
        [SerializeField] private string _localizationId;

        public string LocalizationId
        {
            get { return _localizationId; }
        }

        [SerializeField] private string _spriteId;

        public string SpriteId
        {
            get { return _spriteId; }
        }

        public SimpleUiModel(string localizationId, string spriteId)
        {
            _localizationId = localizationId;
            _spriteId = spriteId;
        }
    }
}