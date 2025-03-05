using System.Collections;
using UnityEngine;

namespace CodeBase.Systems.CoroutineRunner
{
    public interface ICoroutineRunner
    {
        Coroutine RunCoroutine(IEnumerator coroutine);
    }
}