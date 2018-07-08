using System.Collections.Generic;
using UnityEngine;

namespace Interactions
{
    public interface IInteractiveObject
    {
        IEnumerable<IInteractionContainer> GetAvailableInteractions(GameObject interactor);

        void AddInteractive(IInteractionContainer container);
        void RemoveInteractive(IInteractionContainer container);

        void Run(GameObject interactor, IInteraction interaction);
        void Stop();
    }

    public interface IInteractionContainer
    {
        IInteraction GetInteraction();
        bool IsAvailable(GameObject interactor);
    }

    public interface IInteraction
    {
        IInteractionUiModel UiModel { get; }

        IInteractionUsageCondition PreCondition { get; }
        IInteractionUsageCondition PostCondition { get; }

        void Activate(GameObject interactor);
        void Stop();
    }

    public interface IInteractionUiModel
    {
        string LocalizationId { get; }
        string SpriteId { get; }
    }

    public interface IInteractionUsageCondition
    {
        bool CanInteract(GameObject interactor);
    }
}