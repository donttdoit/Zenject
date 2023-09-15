using System;
using UnityEngine;

public class Sphere : MonoBehaviour
{
    [SerializeField] private SphereType _sphereType;

    public SphereType SphereType => _sphereType;

    public event Action<Sphere> SphereClicked;
    void OnMouseDown()
    {
        SphereClicked?.Invoke(this);
        Destroy(gameObject);
    }

}