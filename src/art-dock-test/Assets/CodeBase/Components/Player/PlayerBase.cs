using CodeBase.Services.ProjectResourcesProvider;
using UnityEngine;
using Zenject;

namespace CodeBase.Components.Player
{
    public class PlayerBase : MonoBehaviour, IResource
    {
        [Inject]
        public void Construct(Transform spawnPoint)
        {
            transform.position = spawnPoint.position;
        }
    }
}