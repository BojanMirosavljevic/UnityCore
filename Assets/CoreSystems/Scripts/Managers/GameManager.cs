using UnityEngine;

public class GameManager : StaticInstance<GameManager>
{
    public void DUMMY_GoToGameScene()
    {
        SceneSystem.Instance.LoadScene(
            Scene.Loading,
            () =>
            {
                Debug.LogError("SceneChanged");
            }
        );
    }
}
