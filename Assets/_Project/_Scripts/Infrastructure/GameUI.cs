using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Assets._Project._Scripts.Infrastructure
{
    public class GameUI : MonoBehaviour, ILateDisposable
    {
        [SerializeField] private Slider _healthSlider;
        [SerializeField] private Button _restartButton;

        private void Awake()
        {
            _restartButton.gameObject.SetActive(false);
        }

        [Inject]
        public void Construct(SceneController sceneController)
        {
            _restartButton.onClick.AddListener(sceneController.ToGame);
        }

        public void OnHealthChanged(float value, float maxValue)
        {
            _healthSlider.value = value / maxValue;
        }

        public void OnGameOver()
        {
            _restartButton.gameObject.SetActive(true);
        }

        public void LateDispose()
        {
            _restartButton.onClick.RemoveAllListeners();
        }
    }
}
