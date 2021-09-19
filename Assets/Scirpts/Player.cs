using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerSerializeFields))]
public class Player : MonoBehaviour
{
    public bool CanMove { get; set; }

    [SerializeField]
    private float movementSpeed = 5f;

    private PlayerSerializeFields serializeFields;

    Vector2 movement;

    private float maxFirePower = 100f;

    private float firePower = 0f;

    private void Start()
    {
        serializeFields = GetComponent<PlayerSerializeFields>();
    }

    private EDirection direction = EDirection.Bottom;

    private float fireMulti = 25f;

    private void Update()
    {
        if(GameManager.Instance.GameStarted)
        {
            if (CanMove)
            {
                movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            }
            else
            {
                movement = Vector2.zero;
            }

            if (movement.x > 0)
            {
                serializeFields.SideSet.SetActive(true);
                serializeFields.SideSet.transform.localScale = new Vector3(1, 1, 1);
                serializeFields.TopSet.SetActive(false);
                serializeFields.BottomSet.SetActive(false);
                serializeFields.SideSetAnimator.SetBool("IsMoving", true);
                direction = EDirection.Side;
                if (serializeFields.SideSmallFire.activeSelf)
                {
                    serializeFields.SideSmallFire.SetActive(false);
                    serializeFields.SideMediumFire.SetActive(false);
                    serializeFields.SideBigFire.SetActive(false);
                }
            }
            else if (movement.x < 0)
            {
                serializeFields.SideSet.SetActive(true);
                serializeFields.SideSet.transform.localScale = new Vector3(-1, 1, 1);
                serializeFields.TopSet.SetActive(false);
                serializeFields.BottomSet.SetActive(false);
                serializeFields.SideSetAnimator.SetBool("IsMoving", true);
                direction = EDirection.Side;
                if (serializeFields.SideSmallFire.activeSelf)
                {
                    serializeFields.SideSmallFire.SetActive(false);
                    serializeFields.SideMediumFire.SetActive(false);
                    serializeFields.SideBigFire.SetActive(false);
                }

            }
            else if (movement.y > 0)
            {
                serializeFields.SideSet.SetActive(false);
                serializeFields.TopSet.SetActive(true);
                serializeFields.BottomSet.SetActive(false);
                serializeFields.TopSetAnimator.SetBool("IsMoving", true);
                direction = EDirection.Top;
                if (serializeFields.TopSmallFire.activeSelf)
                {
                    serializeFields.TopSmallFire.SetActive(false);
                    serializeFields.TopMediumFire.SetActive(false);
                    serializeFields.TopBigFire.SetActive(false);
                }
            }
            else if (movement.y < 0)
            {
                serializeFields.SideSet.SetActive(false);
                serializeFields.TopSet.SetActive(false);
                serializeFields.BottomSet.SetActive(true);
                serializeFields.BottomSetAnimator.SetBool("IsMoving", true);
                direction = EDirection.Bottom;
                if (serializeFields.BottomSmallFire.activeSelf)
                {
                    serializeFields.BottomSmallFire.SetActive(false);
                    serializeFields.BottomMediumFire.SetActive(false);
                    serializeFields.BottomBigFire.SetActive(false);
                }
            }
            else
            {
                if (serializeFields.BottomSet.activeSelf)
                {
                    serializeFields.BottomSetAnimator.SetBool("IsMoving", false);
                }
                if (serializeFields.TopSet.activeSelf)
                {
                    serializeFields.TopSetAnimator.SetBool("IsMoving", false);
                }
                if (serializeFields.SideSet.activeSelf)
                {
                    serializeFields.SideSetAnimator.SetBool("IsMoving", false);
                }
            }

            if (Input.GetKeyUp(KeyCode.Space))
            {
                CanMove = true;
                SetWings(false);
                SetFire();
                GameManager.Instance.SetFireDisplay(-1f);
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                CanMove = false;
                firePower = 0f;
                SetWings(true);
            }

            if (Input.GetKey(KeyCode.Space))
            {
                if (firePower < maxFirePower)
                {
                    firePower += Time.deltaTime * (fireMulti);
                    GameManager.Instance.SetFireDisplay(firePower);
                }
            }
        }
    }

    public void SetWings(bool value)
    {
        switch (direction)
        {
            case EDirection.Bottom:
                serializeFields.BottomWings.enabled = value;
                break;

            case EDirection.Side:
                serializeFields.SideWings[0].enabled = value;
                serializeFields.SideWings[1].enabled = value;
                break;

            case EDirection.Top:
                serializeFields.TopWings.enabled = value;
                break;
        }
    }

    public void SetFire()
    {
        switch(direction)
        {
            case EDirection.Bottom:
                if (firePower > 15 && firePower < 50)
                {
                    serializeFields.BottomSmallFire.SetActive(true);
                }
                else if( firePower > 50 && firePower < 80)
                {
                    serializeFields.BottomMediumFire.SetActive(true);
                }
                else if(firePower > 80)
                {
                    serializeFields.BottomBigFire.SetActive(true);
                }
                break;

            case EDirection.Side:
                if (firePower > 15 && firePower < 50)
                {
                    serializeFields.SideSmallFire.SetActive(true);
                }
                else if (firePower > 50 && firePower < 80)
                {
                    serializeFields.SideMediumFire.SetActive(true);
                }
                else if (firePower > 80)
                {
                    serializeFields.SideBigFire.SetActive(true);
                }
                break;

            case EDirection.Top:
                if (firePower > 15 && firePower < 50)
                {
                    serializeFields.TopSmallFire.SetActive(true);
                }
                else if (firePower > 50 && firePower < 80)
                {
                    serializeFields.TopMediumFire.SetActive(true);
                }
                else if (firePower > 80)
                {
                    serializeFields.TopBigFire.SetActive(true);
                }
                break;
        }
    }

    private void FixedUpdate()
    {
        serializeFields.Rb.MovePosition(serializeFields.Rb.position + movement * movementSpeed * Time.fixedDeltaTime);
    }
}
