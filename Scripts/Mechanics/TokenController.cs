using UnityEngine;

namespace Platformer.Mechanics
{
    // ����� ��� �������� �������, ���� ������ �� ����������� �������, �� �� �������

    public class TokenController : MonoBehaviour 
    {
        [Tooltip("��� ��������")]
        public float frameRate = 12;
        [Tooltip("������� �������, ������� ���� �����������. ���� �����, �� ������ ��� ������ ��� ������� �� �����")]
        public TokenInstance[] tokens;

        float nextFrameTime = 0;

        void FindAllTokensInScene()
        {
            tokens = UnityEngine.Object.FindObjectsOfType<TokenInstance>();
        }

        void Awake()
        {
            if (tokens.Length == 0)
                FindAllTokensInScene();

            for (var i = 0; i < tokens.Length; i++)
            {
                tokens[i].tokenIndex = i;
                tokens[i].controller = this;
            }
        }

        void Update()
        {
            if (Time.time - nextFrameTime > (1f / frameRate))  // ������, ���� ����� ����� ������� ������ ��� ������ ���� (��� 12 ��� ��� 0,08 � ���� ������) �� ��������� �������
            {
                for (var i = 0; i < tokens.Length; i++)
                {
                    var token = tokens[i];

                    if (token != null)
                    {
                        token._renderer.sprite = token.sprites[token.frame];
                        if (token.collected && token.frame == token.sprites.Length - 1)
                        {
                            token.gameObject.SetActive(false);
                            tokens[i] = null;
                        }
                        else
                        {
                            token.frame = (token.frame + 1) % token.sprites.Length;
                        }
                    }
                }

                nextFrameTime += 1f / frameRate;
            }
        }

    }
}