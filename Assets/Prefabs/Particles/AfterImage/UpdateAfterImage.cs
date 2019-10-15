using UnityEngine;

public class UpdateAfterImage : MonoBehaviour
{
    #region Variables

    public Material MaterialToUpdate;

    public SpriteRenderer Renderer;

    #endregion Variables

    private void FixedUpdate() => MaterialToUpdate.mainTexture = Resources.Load<Texture>($"AfterImages/Player/{Renderer.sprite.name}");
}