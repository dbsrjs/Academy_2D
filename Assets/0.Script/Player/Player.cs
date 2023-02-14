using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public enum Direction
    {
        Center = 0,
        Left,
        Right
    }
    private Direction dir = Direction.Center;

    [SerializeField] private List<Sprite> CenterSP;
    [SerializeField] private List<Sprite> leftSP;
    [SerializeField] private List<Sprite> rightSP;

    [SerializeField] private Transform parent;
    [SerializeField] private GameObject bullet;

    private SpriteAnimation sa;

    private float speed = 3f;
    // Start is called before the first frame update
    void Start()
    {
        sa = GetComponent<SpriteAnimation>();
        sa.SetSprite(CenterSP, 0.2f);

        InvokeRepeating("CreateBullet", 1f, 0.2f);
    }

    // Update is called once per frame
    void Update()
    {
        // 캐릭터 이동 번위 지정
        float x = Input.GetAxisRaw("Horizontal") * Time.deltaTime * speed;
        float clampX = Mathf.Clamp(transform.position.x + x, -2.5f, 2.5f);
        float y = Input.GetAxisRaw("Vertical") * Time.deltaTime * speed;
        float clampY = Mathf.Clamp(transform.position.y + y, -4.5f, 4.5f);

        transform.position = new Vector2(clampX, clampY);

        // transform.position = new Vector2(x, y);
        transform.Translate(new Vector2(x, y));
        
        //방향에 따른 이미지 변경
        if (x < 0 && dir != Direction.Left)
        {
            dir = Direction.Left;
            sa.SetSprite(leftSP[0], leftSP, 0.2f);
        }
        else if(x > 0 && dir != Direction.Right)
        {
            dir = Direction.Right;
            sa.SetSprite(rightSP[0], rightSP,  0.2f);
        }
        else if(x == 0 && dir != Direction.Center)
        {
            dir = Direction.Center;
            sa.SetSprite(CenterSP[0], CenterSP,  0.2f);
        }
    }
   void CreateBullet()
    {
        Instantiate(bullet, parent);
    }
}
