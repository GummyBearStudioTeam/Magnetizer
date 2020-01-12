using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetController : MonoBehaviour
{
    SpriteRenderer spriteComponent;
    public float MagnetRange;
    public Color clrEnabled, clrDisabled;

    bool isEnabled() {
        return spriteComponent.color == clrEnabled;
    }

    float effectRange() {
        return MagnetRange * this.gameObject.transform.localScale.magnitude;
    }

    void pullPoints() {
        if (!isEnabled())
            return;
		Collider2D[] items = Physics2D.OverlapCircleAll(transform.position, effectRange());
		Vector2 direction;
		foreach (Collider2D i in items)
		{
			if (i.CompareTag("PlayerPoint"))
			{
				direction = transform.position - i.transform.position;
				i.attachedRigidbody.AddForce(MagnetRange * direction / Mathf.Pow(1 + direction.magnitude, 2), ForceMode2D.Impulse);
			}
		}
	}

    bool rayOnObject(Vector2 screen) {
		Ray ray = Camera.main.ScreenPointToRay(screen);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, 100);
        return (hit.collider != null && hit.collider.CompareTag("Magnet") && hit.collider.transform == this.gameObject.transform);
    }

	void Start() {
        spriteComponent = GetComponent<SpriteRenderer>();
        spriteComponent.color = clrEnabled;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && rayOnObject(new Vector2(Input.mousePosition.x, Input.mousePosition.y)))
            spriteComponent.color = isEnabled() ? clrDisabled : clrEnabled;
    }

    void FixedUpdate() {
        pullPoints();
    }
}
