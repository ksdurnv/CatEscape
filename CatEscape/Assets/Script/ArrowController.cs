using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    public float moveSpeed = 0.001f;
    private int dir = -1;
    public float radius;
    public GameObject player;

    void Update()
    {
        this.transform.Translate(0, dir * moveSpeed, 0);

        bool isCollided = this.CheckCollsion();

        if (isCollided)
        {
            Object.Destroy(this.gameObject);
        }

        if (this.transform.position.y <= -6.36f)
        {
            Object.Destroy(this.gameObject);
        }
    }

    private void OnDrawGizmos()
    {
        GizmosExtensions.DrawWireArc(this.transform.position, 360, radius);
    }

    //충돌체크를 한 후에 충돌이 되었다면 true를 반환
    private bool CheckCollsion()
    {
        float dirX = this.transform.position.x - player.transform.position.x;
        float dirY = this.transform.position.y - player.transform.position.y;

        if (dirY < 1.5f && dirX < 1f && dirX > -1f)
        {
            Debug.Log("화살표가 고양이와 충돌하였습니다.");
            return true;
        }
        else
        {
            return false;
        }        
    }
}