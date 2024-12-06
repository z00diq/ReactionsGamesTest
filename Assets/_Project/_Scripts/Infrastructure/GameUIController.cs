using Assets._Project._Scripts.Views;
using Zenject;

namespace Assets._Project._Scripts.Infrastructure
{
    public class GameUIController: IInitializable, ILateDisposable
    {
        private GameUI _gameUI;
        private Player _player;

        [Inject]
        public void Construct(GameUI gameUI, Player player)
        {
            _gameUI = gameUI;
            _player = player;
        }

        public void Initialize()
        {
            Bind();
        }

        public void LateDispose()
        {
            Unbind();
        }

        private void Bind()
        {
            _player.Health.Died += _gameUI.OnGameOver;
            _player.Health.HealthChanged += _gameUI.OnHealthChanged;
        }

        private void Unbind()
        {
            _player.Health.Died -= _gameUI.OnGameOver;
            _player.Health.HealthChanged -= _gameUI.OnHealthChanged;
        }
    }
}
