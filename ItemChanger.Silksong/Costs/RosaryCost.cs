using ItemChanger.Costs;
using ItemChanger.Silksong.Extensions;
using Newtonsoft.Json;
using PrepatcherPlugin;
using System.Diagnostics.CodeAnalysis;

namespace ItemChanger.Silksong.Costs;

[method: SetsRequiredMembers]
public class RosaryCost(int amount) : Cost
{
    public required int Amount = amount;

    /// <summary>
    /// Amount after accounting for any discount rate.
    /// </summary>
    [JsonIgnore]
    public int ActualAmount => (int)(Amount * base.DiscountRate);

    public override bool CanPay() => PlayerDataAccess.geo >= ActualAmount;

    public override string GetCostText() => RawData.ItemChangerLanguageStrings.CreatePayRosariesString(ActualAmount.ToValueProvider()).Value;

    public override bool HasPayEffects() => true;

    public override void OnPay()
    {
        if (ActualAmount > 0) HeroController.instance.TakeGeo(ActualAmount);
    }

    public override bool IsFree => ActualAmount <= 0;

    public static int GetRosaryCost(Cost cost) => cost.GetCostsOfType<RosaryCost>().Select(c => c.ActualAmount).Sum();
}
