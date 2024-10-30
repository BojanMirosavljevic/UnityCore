using UnityEngine;

public class LoadingManager : StaticInstance<LoadingManager>
{
    public void DUMMY_GoToGameScene()
    {
        SceneSystem.Instance.LoadScene(
            Scene.Game,
            () =>
            {
                Debug.LogError("SceneChanged");
            }
        );
    }
}
