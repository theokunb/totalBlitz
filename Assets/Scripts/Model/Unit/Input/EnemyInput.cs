using UnityEngine;

public class EnemyInput : Input
{
    private float[] _values = new float[4];
    private float _directionTimer;
    private float _rotationTimer;
    private float _delayDirection = 0.5f;
    private float _delayRotation = 5;
    private Vector3 _rotation = Vector3.zero;

    private void Start()
    {
        SetDirection();
    }

    private void Update()
    {
        _directionTimer += Time.deltaTime;
        _rotationTimer += Time.deltaTime;
        transform.Rotate(_rotation * Time.deltaTime);

        if (_directionTimer >= _delayDirection)
        {
            SetDirection();
            _directionTimer = 0;
        }

        if(_rotationTimer >= _delayRotation)
        {
            SetRotaion();
            _rotationTimer = 0;
        }
    }

    private void SetDirection()
    {
        int random = Random.Range(0, _values.Length);

        for (int i = 0; i < _values.Length; i++)
        {
            if (i == random)
            {
                random = Random.Range(0, 3);

                if(random == 0)
                {
                    _values[i] = 0;
                }
                else
                {
                    _values[i] = 1;
                }
            }
            else
            {
                _values[i] = 0;
            }
        }
    }

    private void SetRotaion()
    {
        int random = Random.Range(-10, 10);
        _rotation = new Vector3(0, random, 0);
    }

    public override void Enable()
    {
        _directionTimer = 0;
    }

    public override void Disable()
    {
        _values = null;
    }

    public override float ForwardReadValue()
    {
        return _values[0];
    }

    public override float LeftReadValue()
    {
        return _values[1];
    }

    public override float BackReadValue()
    {
        return _values[2];
    }

    public override float RightReadValue()
    {
        return _values[3];
    }
}
