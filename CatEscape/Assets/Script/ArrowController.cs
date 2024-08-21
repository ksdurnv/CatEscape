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

    //�浹üũ�� �� �Ŀ� �浹�� �Ǿ��ٸ� true�� ��ȯ
    private bool CheckCollsion()
    {
        float dirX = this.transform.position.x - player.transform.position.x;
        float dirY = this.transform.position.y - player.transform.position.y;

        if (dirY < 1.5f && dirX < 1f && dirX > -1f)
        {
            Debug.Log("ȭ��ǥ�� ����̿� �浹�Ͽ����ϴ�.");
            return true;
        }
        else
        {
            return false;
        }        
    }
}