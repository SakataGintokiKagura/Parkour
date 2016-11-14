namespace NPlayerState
{
    public class FirstJump : AbsState
    {
        public FirstJump(PlayerState player) : base(player)
        {
        }

        //public FirstJump(PlayerState player) {
        //    this.player = player;
        //}
        public override AbsState OnGrounded()
        {
            foreach (var item in player.stateList)
                if (item is Run)
                    return item;
            return this;
        }

        public override AbsState OnJump()
        {
            foreach (var item in player.stateList)
                if (item is SecondJump)
                    return item;
            return this;
        }

        public override AbsState OnUseSkill(bool isInterrupted)
        {
            if (isInterrupted)
            {
                foreach (var item in player.stateList)
                    if (item is GeneralSkill)
                        return item;
                return this;
            }
            foreach (var item in player.stateList)
                if (item is UnInterruptedSkill)
                    return item;
            return this;
            return this;
        }
    }
}