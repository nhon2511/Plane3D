using UnityEngine;

public class AirplaneController : MonoBehaviour
{
    [Header("Thông số bay")]
    public float moveSpeed = 15f;  // Tốc độ tiến tới (Phím W / S)
    public float turnSpeed = 50f;  // Tốc độ rẽ trái/phải (Phím A / D)
    public float pitchSpeed = 40f; // Tốc độ ngóc/chúc mũi máy bay (Space / Left Shift)

    void Update()
    {
        // 1. Tiến / Lùi theo đúng hướng mũi máy bay đang chỉ (W / S)
        // Khi mũi máy bay đã ngóc lên, bấm W máy bay sẽ tự động bay vút lên trời!
        float moveInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * moveInput * moveSpeed * Time.deltaTime);

        // 2. Rẽ Trái / Phải (A / D) - Xoay theo trục thẳng đứng của thế giới để không bị xoắn máy bay
        float turnInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up * turnInput * turnSpeed * Time.deltaTime, Space.World);

        // 3. Giữ phím Space -> Mũi máy bay ngóc dần lên trời
        if (Input.GetKey(KeyCode.Space))
        {
            // Vector3.left (trục X âm) giúp xoay ngóc đầu máy bay lên mượt mà
            transform.Rotate(Vector3.left * pitchSpeed * Time.deltaTime, Space.Self);
        }

        // 4. Giữ phím Left Shift -> Mũi máy bay chúc dần xuống đất
        if (Input.GetKey(KeyCode.LeftShift))
        {
            transform.Rotate(Vector3.right * pitchSpeed * Time.deltaTime, Space.Self);
        }
    }
}