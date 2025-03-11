using System;
using UnityEngine;

namespace CodeBase.Components.Enemy
{
    public class EnemySelector : MonoBehaviour
    {
        public event Action EnemySelected; 
        
        public void OnMouseDown()
        {
            EnemySelected?.Invoke();
        }
    }
}