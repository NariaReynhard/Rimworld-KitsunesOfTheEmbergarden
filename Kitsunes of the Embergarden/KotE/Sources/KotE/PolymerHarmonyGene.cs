using RimWorld;
using Verse;

namespace KotE
{
    public class PolymerHarmonyGene : Gene
    {
        ModExtension_RequireXenotype authorizedXenotypes => def.GetModExtension<ModExtension_RequireXenotype>();
        ModExtension_GeneEmitsAura auraDatas => def.GetModExtension<ModExtension_GeneEmitsAura>();
        public override void PostAdd()
        {
            if (authorizedXenotypes.PawnHasRequiredXenotype(pawn)){
                pawn.genes.RemoveGene(this);
            };
        }

        public override void Tick()
        {
            base.Tick();
            applyEffect();
        }
        
        private void applyEffect(){
            foreach (Pawn potentialSubject in pawn.Map.mapPawns.AllHumanlikeSpawned){
                if (potentialSubject.Position.DistanceToSquared(pawn.Position)<=auraDatas.radius){
                    potentialSubject.health.AddHediff(auraDatas.auraEffect);
                };
            }
        }
    }

    public class ModExtension_RequireXenotype : DefModExtension
    {
        public XenotypeDef RequiredXenotypes;

        public bool PawnHasRequiredXenotype(Pawn pawn)
        {
            if(pawn?.genes==null) return false;
            return pawn.genes.Xenotype==RequiredXenotypes;
        }
    }

    public class ModExtension_GeneEmitsAura : DefModExtension
    {
        public HediffDef auraEffect;
        public float radius;
        public XenotypeDef affectsXenotypes;
    }
}