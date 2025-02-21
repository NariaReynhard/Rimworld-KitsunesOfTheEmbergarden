using System.Collections.Generic;
using RimWorld;
using Verse;

namespace KotE
{
    public class PolymerHarmonyNeed : Need
    {
        public override void SetInitialLevel()
        {
            base.SetInitialLevel();
            this.threshPercents = new List<float> {0.15f, 0.4f, 0.85f};
        }
        public override void NeedInterval()
        {
            
        }
    }
}