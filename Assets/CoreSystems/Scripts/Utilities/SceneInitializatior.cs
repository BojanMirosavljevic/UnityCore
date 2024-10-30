using UnityEngine;

public static class SceneInitializator
{
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    public static void Execute()
    {
        Object systemsPrefab = Resources.Load("Systems/Systems");
        Object.Instantiate(systemsPrefab);
    }
}