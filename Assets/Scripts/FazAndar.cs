using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FazAndar : MonoBehaviour
{

    private SpriteRenderer personagemSpriteRenderer;
    private Rigidbody2D personagemRigidBody;
    private PolygonCollider2D personagemCollider;
    public float moveSpeed = 1f;
    public Camera cam;
    Vector2 movement;
    Vector2 mousePos;
    void Awake() 
    {
        personagemSpriteRenderer = GetComponent<SpriteRenderer>();
        personagemRigidBody = GetComponent<Rigidbody2D>();
        personagemCollider = GetComponent<PolygonCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        /*float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        if (x < 0) // vira para a esquerda
            transform.localScale = new Vector3(-5, 5, 5);
        else
            if (x > 0)
                transform.localScale = new Vector3(5, 5, 5);

        Vector2 movimento = new Vector2(x, y) * Time.deltaTime;
        transform.Translate(movimento);*/

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    private void FixedUpdate()
    {
        personagemRigidBody.MovePosition(personagemRigidBody.position + movement * moveSpeed * Time.fixedDeltaTime);

        Vector2 lookDir = mousePos - personagemRigidBody.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        personagemRigidBody.rotation = angle;
    }
}

