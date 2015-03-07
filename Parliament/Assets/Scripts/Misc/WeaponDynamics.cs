using UnityEngine;
using System.Collections;

public class WeaponDynamics
{
    private float _maxDistance; // Bullet Distance (Meters)
    private float _accuracy; // Bullet Accuracy (Percent)
    private float _spreadMax; // Maximum Bullet Spread (Angle)
    private float _spreadMin; // Minimum Bullet Spread (Angle)

    private float _spreadDifference;

    private Vector2 _startPoint, _endPoint;

    public WeaponDynamics(float maxDistance, float accuracy, float minSpread, float maxSpread)
    {
        this._maxDistance = maxDistance;
        this._accuracy = accuracy;
        this._spreadMax = maxSpread;
        this._spreadMin = minSpread;
    }


}
