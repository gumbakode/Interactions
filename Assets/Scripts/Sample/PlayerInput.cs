using System.Linq;
using Interactions;
using UnityEngine;

namespace Sample
{
    public class PlayerInput : MonoBehaviour
    {
        private void Update()
        {
            if (Input.GetMouseButtonUp(0))
            {
                var interactiveObject = GetInteractiveObject();
                RunFirstAvailableInteraction(interactiveObject);
            }
        }

        private IInteractiveObject GetInteractiveObject()
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hitResult;
            if (!Physics.Raycast(ray, out hitResult, 1000f))
                return null;

            var hitTransform = hitResult.transform;
            var interactiveObject = hitTransform.GetComponent<IInteractiveObject>() ??
                                    hitTransform.GetComponentInParent<IInteractiveObject>();

            return interactiveObject;
        }

        private void RunFirstAvailableInteraction(IInteractiveObject interactiveObject)
        {
            if (interactiveObject == null)
                return;

            var availableInteractions = interactiveObject.GetAvailableInteractions(gameObject);
            var firstAvailableInteraction = availableInteractions.FirstOrDefault();
            if (firstAvailableInteraction != null)
                interactiveObject.Run(gameObject, firstAvailableInteraction.GetInteraction());
        }
    }
}