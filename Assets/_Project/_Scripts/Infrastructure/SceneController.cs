using UnityEngine.SceneManagement;

namespace Assets._Project._Scripts.Infrastructure
{
    public class SceneController
    {
        private const int GAME_SCENE_INDEX = 0;

        public void ToGame()
        {
            SceneManager.LoadScene(GAME_SCENE_INDEX, LoadSceneMode.Single);
        }
    }
}
