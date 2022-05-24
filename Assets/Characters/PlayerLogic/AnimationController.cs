using UnityEngine;
public class AnimationController
{
    private const string IS_MOVING_PARAMETER = "isMoving";

    private Animator animator;
    private Transform transform;

    public AnimationController(Animator animator, Transform transform)
    {
        this.animator = animator;
        this.transform = transform;
    }

    public void SetMoving(bool isMoving)
    {
        animator.SetBool(IS_MOVING_PARAMETER, isMoving);
    }

    public void FlipSpriteWithDirection(Vector2 direction)
    {
        if (direction.x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (direction.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }

}
