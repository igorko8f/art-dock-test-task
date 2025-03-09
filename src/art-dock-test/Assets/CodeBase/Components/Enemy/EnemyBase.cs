using CodeBase.Services.ProjectResourcesProvider;
using UnityEngine;

namespace CodeBase.Components.Enemy
{
    public class EnemyBase : MonoBehaviour , IResource
    {
        public Vector3 GetPosition()
        {
            return transform.position;
        }
        
        public float GetDistanceFrom(Vector3 position)
        {
            return Vector3.Distance(position, transform.position);
        }
    }
}