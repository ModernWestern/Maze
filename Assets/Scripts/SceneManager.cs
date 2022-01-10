using UnityEngine;
using Scene = UnityEngine.SceneManagement.SceneManager;

namespace Game
{
    public class SceneManager : MonoBehaviour
    {
        const string Congratulation = "Congratulation";

        const string GameOver = "GameOver";

        const string Maze = "Maze";

        [SerializeField] private Events events;

        private void Awake()
        {
            events.OnDistractorEnter += value =>
            {
                if (value)
                {
                    LoadCongratulationScene();
                };
            };

            events.OnGameOver += LoadGameOverScene;
        }

        private void LoadCongratulationScene()
        {
            Scene.LoadScene(Congratulation, UnityEngine.SceneManagement.LoadSceneMode.Additive);

            Invoke(nameof(UnloadCongratulationScene), 5);
        }

        private void UnloadCongratulationScene()
        {
            Scene.UnloadSceneAsync(Congratulation, UnityEngine.SceneManagement.UnloadSceneOptions.UnloadAllEmbeddedSceneObjects);

            Scene.LoadScene(Maze);

            events.CleanAll();
        }

        private void LoadGameOverScene()
        {
            Scene.LoadScene(GameOver, UnityEngine.SceneManagement.LoadSceneMode.Additive);

            Invoke(nameof(UnloadGameOverScene), 5);
        }

        private void UnloadGameOverScene()
        {
            Scene.UnloadSceneAsync(GameOver, UnityEngine.SceneManagement.UnloadSceneOptions.UnloadAllEmbeddedSceneObjects);

            Scene.LoadScene(Maze);

            events.CleanAll();
        }
    }
}