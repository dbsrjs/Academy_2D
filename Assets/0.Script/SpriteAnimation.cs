using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.Events;

[RequireComponent(typeof(SpriteRenderer))]
public class SpriteAnimation : MonoBehaviour
{
    private List<Sprite> sprites = new List<Sprite>();
    private SpriteRenderer sr;

    private float spriteDelayTime;
    private float delayTime = 0f;

    private int spriteAnimationIndex = 0;

    private UnityAction action = null;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (sprites.Count == 0)
            return;

        delayTime += Time.deltaTime;
        if(delayTime > spriteDelayTime)
        {
            delayTime = 0;
            sr.sprite = sprites[spriteAnimationIndex];
            spriteAnimationIndex++;

            if (spriteAnimationIndex > sprites.Count - 1)
            {
                if(action == null)
                    spriteAnimationIndex = 0;
                else
                {
                    sprites.Clear();
                    action();
                    action = null;
                }
            }
        }
    }

    void Init()
    {
        delayTime = 0f;
        sprites.Clear();
        spriteAnimationIndex = 0;
    }

    public void SetSprite(List<Sprite> argSprites, float delayTime)
    {
        Init();
        sprites = argSprites.ToList();
        spriteDelayTime = delayTime;
    }

    public void SetSprite(List<Sprite> argSprites, float delayTime, UnityAction action)
    {
        Init();
        this.action = action;
        sprites = argSprites.ToList();
        spriteDelayTime = delayTime;
    }

    public void SetSprite(Sprite sprite, List<Sprite> argSprites, float delayTime)
    {
        Init();
        sr.sprite = sprite;
        StartCoroutine(ReturnSprite(argSprites, delayTime));
    }

    IEnumerator ReturnSprite(List<Sprite> argSprites, float delayTime)
    {
        yield return new WaitForSeconds(0.01f);
        SetSprite(argSprites, delayTime);
    }
}
