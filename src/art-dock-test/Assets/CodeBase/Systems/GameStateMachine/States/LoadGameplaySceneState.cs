using System.Collections;
using Codebase.StaticData;
using CodeBase.Systems.CoroutineRunner;
using UnityEngine.SceneManagement;

namespace CodeBase.Systems.GameStateMachine.States
{
    public class LoadGameplaySceneState : IState
    {
        private readonly IGameStateMachine _gameStateMachine;
        private readonly ICoroutineRunner _coroutineRunner;

        public LoadGameplaySceneState(IGameStateMachine gameStateMachine, ICoroutineRunner coroutineRunner)
        {
            _gameStateMachine = gameStateMachine;
            _coroutineRunner = coroutineRunner;
        }
        
        public void Enter()
        {
            _coroutineRunner.RunCoroutine(LoadGameplayScene());
        }
        
        public void Exit()
        {
        }

        private IEnumerator LoadGameplayScene()
        {
            var sceneName = Scenes.GameplayScene.Name;
            var loadSceneOperation = SceneManager.LoadSceneAsync(sceneName);

            while (!loadSceneOperation.isDone)
                yield return null;

            yield return null;
        }
    }
}