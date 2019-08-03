public class GrantJump : GrantPowerScript
{
    public override void GrantPower() => GlobalVariables.canJump = true;
}