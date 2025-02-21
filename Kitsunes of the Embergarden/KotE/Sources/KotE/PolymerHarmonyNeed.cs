using System.Collections.Generic;
using RimWorld;
using Verse;

namespace KotE
{
    public class PolymerHarmonyNeed : Need
    {
        public PolymerHarmonyNeed(Pawn pawn) : base(pawn){
            this.threshPercents = new List<float> {0.15f, 0.4f, 0.85f};
        }
        public override void SetInitialLevel()
        {
            this.CurLevel = 0.001f;
        }
        public override void NeedInterval()
        {
            this.CurLevel-=0.001f;
        }
    }
}