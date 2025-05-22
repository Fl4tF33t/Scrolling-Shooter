using System;
using UnityEngine;

namespace ScrollShooter {
    public abstract class Item : MonoBehaviour {
        [SerializeField] protected float amount = 10f;
    }
}