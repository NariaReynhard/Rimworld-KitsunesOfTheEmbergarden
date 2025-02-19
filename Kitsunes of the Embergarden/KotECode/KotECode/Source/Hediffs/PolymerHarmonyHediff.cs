using RimWorld;
using Verse;

namespace KitsunesOfTheEmbergarden
{
    public class PolymerHarmonyHediff : HediffWithComps
    {
        // Called when the hediff is first added to a pawn
        public override void PostAdd(DamageInfo? dinfo)
        {
            base.PostAdd(dinfo);
            // TODO: Initialize any necessary values
        }

        // Called every game tick to update the hediff's effects
        public override void Tick()
        {
            base.Tick();
            // TODO: Handle exposure increase and withdrawal mechanics
        }

        // Modifies the pawn's health stats based on severity
        public override void PostTick()
        {
            base.PostTick();
            // TODO: Apply buffs/debuffs depending on severity
            Need polymerHarmonyNeed = pawn.needs?.TryGetNeed(DefDatabase<NeedDef>.GetNamed("PolymerHarmonyNeed"));
            if(polymerHarmonyNeed == null) return;
        }

        // Determines whether the hediff should be removed
        public override bool ShouldRemove => false; // This is a permanent hediff
    }
}