using UnityEngine;

public class Ball : MonoBehaviour
{
    private Vector2 InitPosition { get; set; }

    private Camera _camera;
    private Vector2 Velocity { get; set; }
    private Rigidbody2D Rigidbody { get; set; }
    private LineRenderer LineRenderer { get; set; }


    [SerializeField] float launchForce;
    [SerializeField] int numOfDots;
    [SerializeField] float offset;

    private Vector3[] Positions { get; set; }

    private void Awake()
    {
        InitPosition = transform.position;

        _camera = Camera.main;
        Rigidbody = GetComponent<Rigidbody2D>();
        LineRenderer = FindObjectOfType<LineRenderer>();

        Positions = new Vector3[numOfDots];
    }

    private void Start()
    {
        Rigidbody.isKinematic = true;
    }

    private void Update()
    {
        if(GameManager.IsPause)
        {
            return;
        }

        if (InteractionArea.IsPressing && Rigidbody.isKinematic)
        {
            Vector2 toInput = _camera.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            toInput.Normalize();

            toInput.x = Mathf.Clamp(toInput.x, -0.3f, 0.3f);
            toInput.y = Mathf.Clamp(toInput.y, 0.2f, 1);

            Velocity = toInput;
            transform.up = toInput;

            Physics2D.gravity = new Vector2(-Mathf.Sign(Velocity.x) * 13, 0);

            for (int i = 0; i < Positions.Length; i++)
            {
                Positions[i] = DotPositionByTime(i * offset);
            }

            LineRenderer.positionCount = Positions.Length;
            LineRenderer.SetPositions(Positions);
        }
    }

    public void Pull()
    {
        if(!Rigidbody.isKinematic || LineRenderer.positionCount == 0)
        {
            return;
        }

        Rigidbody.isKinematic = false;
        Rigidbody.AddForce(Velocity * launchForce, ForceMode2D.Impulse);

        Invoke(nameof(ResetMe), 2.0f);
    }

    private void ResetMe()
    {
        Rigidbody.isKinematic = true;

        Rigidbody.velocity = Vector2.zero;
        Rigidbody.angularVelocity = 0;

        transform.position = InitPosition;
        LineRenderer.positionCount = 0;
    }

    private Vector2 DotPositionByTime(float t)
    {
        return (Vector2)transform.position + (Velocity * launchForce * t) + 0.5f * Physics2D.gravity * Mathf.Pow(t, 2);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Physics2D.gravity = Vector2.down * 9.8f;
    }
}
