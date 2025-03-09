using CodeBase.Services.ProjectResourcesProvider;
using UnityEngine;
using Zenject;

namespace CodeBase.Components.Player
{
    public class PlayerHolder : IPlayerHolder
    {
        public PlayerBase Player => _playerBase;
        private PlayerBase _playerBase;

        private readonly IProjectResourcesProvider _resourcesProvider;
        private readonly IInstantiator _instantiator;

        public PlayerHolder(IProjectResourcesProvider resourcesProvider, 
            IInstantiator instantiator, Transform playerSpawnpoint)
        {
            _instantiator = instantiator;
            _resourcesProvider = resourcesProvider;
            _playerBase = SpawnPlayer(playerSpawnpoint);
        }

        private PlayerBase SpawnPlayer(Transform playerSpawnpoint)
        {
            var playerPrefab = _resourcesProvider.LoadResource<PlayerBase>();
            return _instantiator.InstantiatePrefabForComponent<PlayerBase>(playerPrefab, playerSpawnpoint);
        }
    }
}