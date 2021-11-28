public abstract class CardAction
{
    public enum ActionType
    {
        INCOME,
        RESOURCE,
        CONSTRUCTION, //TODO: SPLIT TO DIFFERENT TYPES OF CONSTRUCTION
        TERRAFORMATION_POINTS,
        OXYGEN,
        HEAT,
        SKIP_TURN,
        UNITS //TODO: Microbs, animals etc
    }

    public int Amount = 1;
}

public class CardIncomeAction : CardAction
{
    public PlayerResources.Currency Currency;
}

public class CardResourceAction : CardAction
{
    public PlayerResources.Currency Currency;
}

