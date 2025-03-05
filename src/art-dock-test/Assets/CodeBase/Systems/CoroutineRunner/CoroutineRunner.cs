using System.Collections;
using UnityEngine;

namespace CodeBase.Systems.CoroutineRunner
{
    public class CoroutineRunner : MonoBehaviour, ICoroutineRunner
    {
        public Coroutine RunCoroutine(IEnumerator coroutine)
        {
            return StartCoroutine(coroutine);
        }
    }
}