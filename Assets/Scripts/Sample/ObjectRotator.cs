using UnityEngine;

namespace Sample
{
    public class ObjectRotator : MonoBehaviour
    {
        [SerializeField] private float _speed;

        [SerializeField] private Vector3 _axis;

        [SerializeField] private Transform _transformToRotate;

        private void Update()
        {
            _transformToRotate.Rotate(_axis, _speed * Time.deltaTime);
        }
    }
}