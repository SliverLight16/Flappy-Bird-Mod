using UnityEngine;

public class Player : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    private int spriteIndex;

    private Vector3 direction;
    
    public float gravity = -9.8f;

    public float strength = 5f;

    private Rigidbody2D rb;


    void Start() {

        rb = GetComponent<Rigidbody2D>();

   }

    private void Awake() {

        spriteRenderer = GetComponent<SpriteRenderer>();
    }


    private void OnEnable() {

        Vector2 position = transform.position;
        position.y = 0f;
        transform.position = position;
        direction = Vector3.zero;
        
    }

    private void Update() {

        if (Input.GetKey(KeyCode.Space)) {
            direction = Vector3.up * strength;
            gravity = 100f ;
            GetComponent<Rigidbody>().AddForce(Vector3(0,-gravity,0));
            transform.rotation = Quaternion.Euler(Vector3.forward * 45);
        }

        else {
            transform.rotation = Quaternion.Euler(Vector3.forward * -45);
            gravity = -15f;
        }


        direction.y += gravity * Time.deltaTime;
        transform.position += direction * Time.deltaTime;
    }


    private void OnTriggerEnter2D(Collider2D other) {

        if (other.gameObject.tag == "Obstacle") {
            FindObjectOfType<GameManager>().GameOver(); } 
        
        else if (other.gameObject.tag == "Scoring") {
            FindObjectOfType<GameManager>().IncreaseScore(); }

         //else if (other.gameObject.tag == "Deduct") {
            //FindObjectOfType<GameManager>().IncreaseScore(); }
    }
}
