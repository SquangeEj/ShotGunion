using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "ScriptableObjects/New Weapon", order = 1)]
public class WeaponSCROBJ : ScriptableObject
{
    public int damage;

    public AnimatorController controller;

    public GameObject bullet;
}
