using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Interactions
{
    public class InteractiveObject : IInteractiveObject
    {
        private readonly IList<IInteractionContainer> _interactions;

        private IInteraction _activeInteraction;

        public InteractiveObject()
        {
            _interactions = new List<IInteractionContainer>();
        }

        public InteractiveObject(IEnumerable<IInteractionContainer> interactions)
        {
            _interactions = new List<IInteractionContainer>(interactions);
        }

        public IEnumerable<IInteractionContainer> GetAvailableInteractions(GameObject interactor)
        {
            return _interactions.Where(c => c.IsAvailable(interactor));
        }

        public void AddInteractive(IInteractionContainer container)
        {
            if (container != null && !_interactions.Contains(container))
                _interactions.Add(container);
        }

        public void RemoveInteractive(IInteractionContainer container)
        {
            _interactions.Remove(container);
        }

        public void Run(GameObject interactor, IInteraction interaction)
        {
            if (interactor == null || interaction == null)
            {
                Debug.LogErrorFormat("interactor is null:{0}; interaction is null:{1}",
                    interactor == null,
                    interaction == null);
                return;
            }

            Stop();

            _activeInteraction = interaction;
            _activeInteraction.Activate(interactor);
        }

        public void Stop()
        {
            if (_activeInteraction == null)
                return;

            _activeInteraction.Stop();
            _activeInteraction = null;
        }
    }
}