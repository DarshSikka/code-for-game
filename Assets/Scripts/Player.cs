using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Player : MonoBehaviour
{
    public float speed = 5f;
    public Rigidbody r;
    public Text maintext;
    public Button reset;
    private int level;
    bool onGround = true;
    Vector3 _default;
    string[] levels = { "Level0", "level1", "level2" };
    void Start()

    {
        level = 0;
        _default = new Vector3(0.95f, 1.15f,-0.05f);
        reset.onClick.AddListener(buttonClick);
    }
    void FixedUpdate()
    {
        float Horizontal = Input.GetAxis("Horizontal"); //A or D, Arrow keys
        float Vertical = Input.GetAxis("Vertical"); // W or S, Arrow Up and Down
        Vector3 direction = new Vector3(Horizontal, Horizontal, Vertical);
        r.AddForce(direction * speed);

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Finish")) {
              level++;
            transform.position = _default;
            maintext.text = "Level " + level;
              r.mass += 0.2f;
        }
    }
    public void buttonClick()
    {
        transform.position = _default;
        r.mass = 2;
        level = 0;
        maintext.text = "Level " + level;
    }
}