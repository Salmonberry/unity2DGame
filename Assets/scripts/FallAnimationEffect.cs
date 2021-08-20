using UnityEngine;

public class FallAnimationEffect : MonoBehaviour
{
   public EffectAnimation effectAnimation;

   public void UnActive()
   {
      gameObject.SetActive(false);
   }

   public void PlayFallAnimation()
   {
      effectAnimation.PlayGroundEffectAnimation();
   }
}
