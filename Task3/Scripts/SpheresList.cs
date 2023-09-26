using System;
using System.Collections.Generic;
using UnityEngine;

namespace Task3
{
    public class SpheresList : MonoBehaviour
    {
        [SerializeField] private List<Sphere> _spheres;
        public List<Sphere> Spheres => _spheres;
        public event Action SphereDestroyed;

        private void Awake()
        {
            foreach (Sphere sphere in _spheres)
            {
                sphere.SphereClicked += RemoveSphereFromList;
            }
        }

        private void OnDestroy()
        {
            foreach (Sphere sphere in _spheres)
            {
                sphere.SphereClicked -= RemoveSphereFromList;
            }
        }

        public int GetCountOfSpheres() => _spheres.Count;

        private void RemoveSphereFromList(Sphere sphere)
        {
            _spheres.Remove(sphere);
            SphereDestroyed?.Invoke();
        }
    }
}

