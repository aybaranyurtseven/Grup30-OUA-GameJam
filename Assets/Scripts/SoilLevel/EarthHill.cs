using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthHill : MonoBehaviour
{
    [SerializeField] Sprite grasslessSoil;
    [SerializeField] Sprite grassySoil;
    [SerializeField] Sprite viperSoil;

    [SerializeField] private SoilGameManager _gameManager;

    Vector2 startPosition = new Vector2(0f, -2.56f);
    Vector2 endPosition = Vector2.zero;

    float showDuration = 0.5f;
    float duration = 1f;

    SpriteRenderer _spriteRenderer;
    BoxCollider2D _boxCollider2D;
    Vector2 boxOffset;
    Vector2 boxSize;
    Vector2 boxOffsetHidden;
    Vector2 boxSizeHidden;

    bool hittable = true;

    public enum SoilType { Standart, Viper };
    SoilType soiltype;
    float hardRate = 0.25f;
    int hearts;
    int soilIndex = 0;

    private IEnumerator ShowHide(Vector2 start, Vector2 end)
    {
        transform.localPosition = start;

        float elapsed = 0f;
        while (elapsed < showDuration)
        {
            transform.localPosition = Vector2.Lerp(start, end, elapsed / showDuration);
            _boxCollider2D.offset = Vector2.Lerp(boxOffsetHidden, boxOffset, elapsed / showDuration);
            _boxCollider2D.size = Vector2.Lerp(boxSizeHidden, boxSize, elapsed / showDuration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.localPosition = end;
        _boxCollider2D.offset = boxOffset;
        _boxCollider2D.size = boxSize;

        yield return new WaitForSeconds(duration);

        elapsed = 0f;
        while (elapsed < showDuration)
        {
            transform.localPosition = Vector2.Lerp(end, start, elapsed / showDuration);
            _boxCollider2D.offset = Vector2.Lerp(boxOffset, boxOffsetHidden, elapsed / showDuration);
            _boxCollider2D.size = Vector2.Lerp(boxSize, boxSizeHidden, elapsed / showDuration);

            elapsed += Time.deltaTime;
            yield return null;
        }
        transform.localPosition = start;
        _boxCollider2D.offset = boxOffsetHidden;
        _boxCollider2D.size = boxSizeHidden;

        if (hittable)
        {
            hittable = false;

            _gameManager.Missed(soilIndex, soiltype != SoilType.Viper);
        }
    }
    public void Hide()
    {
        transform.localPosition = startPosition;
        _boxCollider2D.offset = boxOffsetHidden;
        _boxCollider2D.size = boxSizeHidden;
    }
    private IEnumerator QuickHide()
    {
        yield return new WaitForSeconds(0.25f);

        if (!hittable)
        {
            Hide();
        }
    }
    private void OnMouseDown()
    {
        if (hittable)
        {
            switch (soiltype)
            {
                case SoilType.Standart:
                    _spriteRenderer.sprite = grassySoil;
                    _gameManager.AddScore(soilIndex);
                    StopAllCoroutines();
                    StartCoroutine(QuickHide());
                    hittable = false;
                    break;
                case SoilType.Viper:
                    _gameManager.GameOver(1);
                    break;
                default:
                    break;
            }
        }
    }
    public void CreateNext()
    {
        float random = Random.Range(0f, 1f);
        if (random < hardRate)
        {
            soiltype = SoilType.Viper;
            _spriteRenderer.sprite = viperSoil;
            hearts = 2;
        }
        else
        {
            soiltype = SoilType.Standart;
            _spriteRenderer.sprite = grasslessSoil;
            hearts = 1;
        }
        hittable = true;
    }
    public void SetLevel(int level)
    {
        hardRate = Mathf.Min(level * 0.025f, 1f);

        float duraitonMin = Mathf.Clamp(1 - level * 0.1f, 0.01f, 1f);
        float duraitonMax = Mathf.Clamp(2 - level * 0.1f, 0.01f, 2f);
        duration = Random.Range(duraitonMin, duraitonMax);
    }
    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _boxCollider2D = GetComponent<BoxCollider2D>();
        boxOffset = _boxCollider2D.offset;
        boxSize = _boxCollider2D.size;
        boxOffsetHidden = new Vector2(boxOffset.x, -startPosition.y / 2f);
        boxSizeHidden = new Vector2(boxSize.x, 0f);
    }
    public void Activate(int level)
    {
        SetLevel(level);
        CreateNext();
        StartCoroutine(ShowHide(startPosition, endPosition));
    }
    public void SetIndex(int index)
    {
        soilIndex = index;
    }
    public void StopGame()
    {
        hittable = false;
        StopAllCoroutines();
    }
}
