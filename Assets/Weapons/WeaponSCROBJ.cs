using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "ScriptableObjects/New Weapon", order = 1)]
public class WeaponSCROBJ : ScriptableObject
{
    public int damage;

    public Sprite sprite;

    public int bullet;
}
