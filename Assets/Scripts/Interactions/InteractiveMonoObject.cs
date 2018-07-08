using System;
using System.Collections.Generic;
using UnityEngine;

namespace Interactions
{
    /// <summary>
    /// Mono wrapper on native c# class
    /// </summary>
    public class InteractiveMonoObject : MonoBehaviour, IInteractiveObject
    {
        [SerializeField] private List<InteractionContainer> _editorBindedInteractions;

        private IInteractiveObject _interactiveObject;
        
        private void Awake()
        {
            CreateInternalInteractiveObject();
        }

        private void CreateInternalInteractiveObject()
        {
            _interactiveObject = new InteractiveObject();
            
            for (int i = 0; i < _editorBindedInteractions.Count; i++)
            {
                AddInteractive(_editorBindedInteractions[i]);
            }
        }

        public IEnumerable<IInteractionContainer> GetAvailableInteractions(GameObject interactor)
        {
            return _interactiveObject.GetAvailableInteractions(interactor);
        }

        public void AddInteractive(IInteractionContainer container)
        {
            _interactiveObject.AddInteractive(container);
        }

        public void RemoveInteractive(IInteractionContainer container)
        {
            _interactiveObject.RemoveInteractive(container);
        }

        public void Run(GameObject interactor, IInteraction interaction)
        {
            _interactiveObject.Run(interactor, interaction);
        }

        public void Stop()
        {
            _interactiveObject.Stop();
        }
    }
}