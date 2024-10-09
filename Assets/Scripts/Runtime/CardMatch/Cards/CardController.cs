using UnityEngine;
using Zenject;
using UniRx;
using Assets.Scripts.Runtime.CardMatch.Misc;
using System.Collections;
using Assets.Scripts.Runtime.CardMatch.Installers;

namespace Assets.Scripts.Runtime.CardMatch.Cards
{
    public class CardController : IInitializable
    {
        [Inject(Id = "audioSettings")]
        private readonly MainSceneInstaller.AudioClipsSettings _audioSettings;
        private readonly AudioPlayer _audioPlayer;
        private readonly CardModel _cardModel;
        private readonly CardView _cardView;
        private readonly Camera _camera;
        private readonly SignalBus _signalBus;

        private bool _isFlipped;
        private bool _canClick = true;
        public string CardName => _cardView.name;

        public CardController(AudioPlayer audioPlayer, CardModel cardModel, CardView cardView, Camera camera, SignalBus signalBus)
        {
            _audioPlayer = audioPlayer;
            _cardModel = cardModel;
            _cardView = cardView;
            _camera = camera;
            _signalBus = signalBus;
        }

        public void Initialize()
        {
            _cardView.SignalBus = _signalBus;
            Observable.EveryUpdate()
           .Where(_ => Input.GetMouseButtonDown(0))
           .Select(_ => _camera.ScreenToWorldPoint(Input.mousePosition))
           .Subscribe(OnClick)
           .AddTo(_cardView);

            _signalBus.Subscribe<SwapSpriteSignal>(SwapSprite);
            _signalBus.Subscribe<GameOverSignal>(RestartBehaviour);
        }

        public void Flip()
        {
            if (_isFlipped)
            {
                _isFlipped = false;
                _cardView.StartCoroutine(WaitForAnimation("FlipBackAnimation"));
            }
            else
            {
                _isFlipped = true;
                _cardView.StartCoroutine(WaitForAnimation("FlipAnimation"));
            }
        }

        public void SwapSprite(SwapSpriteSignal signal)
        {
            if (!signal.cardView.Equals(_cardView))
            {
                return;
            }

            SwapViewSprite();
        }

        private void SwapViewSprite()
        {
            var sprite = _cardView.SpriteRenderer.sprite;
            _cardView.SpriteRenderer.sprite = _cardView.CardSprite;
            _cardView.CardSprite = sprite;
            
        }

        public bool Compare(CardController otherCard)
        {
            if (otherCard == null)
            {
                return false;
            }

            return otherCard.CardName.Equals(CardName);
        }

        public bool Compare(Sprite otherCardSprite)
        {
            return otherCardSprite.name.Equals(_cardView.SpriteRenderer.sprite.name);
        }

        public void MatchCard()
        {
            _cardView.SpriteRenderer.enabled = false;
        }

        private void OnClick(Vector3 clickPosition)
        {
            RaycastHit2D hit = Physics2D.Raycast(clickPosition, Vector2.zero);

            if (hit.collider != null && hit.collider.gameObject == _cardView.gameObject && _canClick)
            {
                Debug.Log("Clicked card name: " + _cardView.name);
                _audioPlayer.Play(_audioSettings.SelectedCardAudio);
                Flip();
            }
        }

        private void RestartBehaviour(GameOverSignal signal)
        {
            _isFlipped = false;
            _canClick = true;
        }

        private IEnumerator WaitForAnimation(string animationName)
        {
            if (_isFlipped)
            {
                _cardModel.Animator.SetTrigger("Flip");
            }
            else
            {
                _cardModel.Animator.SetTrigger("FlipBack");
            }

            yield return new WaitForEndOfFrame();

            AnimatorStateInfo stateInfo = _cardModel.Animator.GetCurrentAnimatorStateInfo(0);

            while (!stateInfo.IsName(animationName))
            {
                yield return null;
                stateInfo = _cardModel.Animator.GetCurrentAnimatorStateInfo(0);
            }

            while (stateInfo.normalizedTime < 1.0f)
            {
                yield return null;
                stateInfo = _cardModel.Animator.GetCurrentAnimatorStateInfo(0);
            }

            if (animationName.Equals("FlipAnimation"))
            {
                _canClick = false;
                _signalBus.Fire(new FlipCardSignal() { cardFlipped = this });
            }
            else
            {
                _canClick = true;
            }
        }
    }
}