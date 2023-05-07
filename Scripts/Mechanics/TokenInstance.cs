using Platformer.Gameplay;
using UnityEngine;
using static Platformer.Core.Simulation;


namespace Platformer.Mechanics
{
    // Этот класс содержит данные, необходимые для реализации механики сбора монетки.
    // он не анимирует монетки, это обрабатывается батчами в TokenController в сцене.

    [RequireComponent(typeof(Collider2D))]
    public class TokenInstance : MonoBehaviour
    {
        public AudioClip tokenCollectAudio;
        [Tooltip("Если true, анимация начнется со случайной позиции в последовательности")]
        public bool randomAnimationStartTime = false;
        [Tooltip("Список кадров для анимации")]
        public Sprite[] idleAnimation, collectedAnimation;

        internal Sprite[] sprites = new Sprite[0];

        internal SpriteRenderer _renderer;

        internal int tokenIndex = -1;
        internal TokenController controller;
        internal int frame = 0;
        internal bool collected = false;

        void Awake()
        {
            _renderer = GetComponent<SpriteRenderer>();
            if (randomAnimationStartTime)
                frame = Random.Range(0, sprites.Length);
            sprites = idleAnimation;
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            var player = other.gameObject.GetComponent<PlayerController>();
            if (player != null) OnPlayerEnter(player);
        }

        void OnPlayerEnter(PlayerController player)
        {
            if (collected) return;
            frame = 0;
            sprites = collectedAnimation;
            if (controller != null)
                collected = true;
            var ev = Schedule<PlayerTokenCollision>();
            ev.token = this;
            ev.player = player;
        }
    }
}