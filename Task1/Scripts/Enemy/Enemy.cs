using UnityEngine;
using Zenject;

public class Enemy : MonoBehaviour
{
    private int _health;
    private float _speed;

    private IEnemyTarget _target;

    [Inject]
    private void Construct(IEnemyTarget target)
    {
        _target = target;
    }

    private void Update()
    {
        Vector3 direction = (_target.Position - transform.position).normalized;
        transform.Translate(direction * _speed * Time.deltaTime);
    }

    public void Initialize(int helath, float speed)
    {
        _health = helath;
        _speed = speed;

        Debug.Log($"��: {_health}, ��������: {_speed}");
    }  
    
    public void MoveTo(Vector3 position) => transform.position = position;

}
